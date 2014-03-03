///////////////////////////////////////////////////////////////////////////
// Some code based on ideas from http://www.codeproject.com/KB/cs/automatingvisualstudio.aspx
///////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EnvDTE;

namespace InspectCodeResultViewer
{
	/// <summary>
	/// Class which is able to open a file in the IDE instance that has it currently open / in a project, or if none found, it will open 
	/// a new IDE instance.
	/// </summary>
	public class DevEnvController
	{
		#region Class DLL Imports
		[DllImport("ole32.dll")]
		public static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
		[DllImport("ole32.dll")]
		public static extern int CreateBindCtx(int reserved, out IBindCtx ppbc);
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll")]
		private static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
		#endregion


		/// <summary>
		/// Opens the file specified in the existing IDE which has the file open or a project which references it, or opens it in a new IDE if necessary.
		/// </summary>
		/// <param name="fileToOpen">The file to open.</param>
		/// <param name="lineNumber">The line number.</param>
		/// <returns>true if succeeded, false if none of the actions succeeded, and the file then has to be opened otherwise.</returns>
		public bool OpenFileInIDE(string fileToOpen, int lineNumber)
		{
			try
			{
				var runningIDEs = GetIDEInstances();
				if(!runningIDEs.Any())
				{
					// create new instance. 
					Type ideType = System.Type.GetTypeFromProgID("VisualStudio.DTE");
					if(ideType == null)
					{
						// give up, no vs.net available.
						return false;
					}
					var dte = (DTE)System.Activator.CreateInstance(ideType);
					if(dte == null)
					{
						// give up, no vs.net available.
						return false;
					}
					else
					{
						runningIDEs.Add(dte);
					}
				}
				foreach(var runningIDE in runningIDEs)
				{
					var hasFile = DetermineIfIDEHasFileOpen(runningIDE, fileToOpen);
					if(hasFile)
					{
						OpenFileAndNavigateToLocation(runningIDE, fileToOpen, lineNumber);
						return true;
					}
				}
				foreach(var runningIDE in runningIDEs)
				{
					var hasFile = DetermineIfIDEHasFileInProject(runningIDE, fileToOpen);
					if(hasFile)
					{
						OpenFileAndNavigateToLocation(runningIDE, fileToOpen, lineNumber);
						return true;
					}
				}
				// load it manually, in first ide that's open. 
				OpenFileAndNavigateToLocation(runningIDEs[0], fileToOpen, lineNumber);
				return true;
			}
			catch
			{
				// not succeeded, return false so the caller can open the file in another way
				return false;	
			}
		}


		/// <summary>
		/// Opens the file specified in the ide specifed and navigates to the linenumber
		/// </summary>
		/// <param name="dte">The DTE.</param>
		/// <param name="fileToOpen">The file to open.</param>
		/// <param name="lineNumber">The line number.</param>
		private void OpenFileAndNavigateToLocation(_DTE dte, string fileToOpen, int lineNumber)
		{
			dte.MainWindow.Visible = true;
			dte.UserControl = true;
			//Open file and select given line
			Window win = dte.ItemOperations.OpenFile(fileToOpen, "{7651A703-06E5-11D1-8EBD-00A0C90F26EA}");
			TextSelection selection = dte.ActiveDocument.Selection as TextSelection;
			selection.GotoLine(lineNumber, false);
			dte.MainWindow.Activate();
			if(GetForegroundWindow().ToInt32() != win.HWnd)
			{
				SwitchToThisWindow(new IntPtr(win.HWnd), false);
			}
		}


		/// <summary>
		/// Determines if IDE has the specified filename open.
		/// </summary>
		/// <param name="dte">The DTE.</param>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		private bool DetermineIfIDEHasFileOpen(_DTE dte, string filename)
		{
			try
			{
				// check open files. If file is open, return true already, so we don't have to enumerate the complete solution
				foreach(Document doc in dte.Documents)
				{
					foreach(string itemFilename in GetFilesOfItem(doc.ProjectItem))
					{
						if(string.IsNullOrEmpty(itemFilename))
						{
							continue;
						}
						if(itemFilename.Equals(filename, StringComparison.CurrentCultureIgnoreCase))
						{
							return true;
						}
					}
					if(!string.IsNullOrEmpty(doc.FullName) && doc.FullName.Equals(filename, StringComparison.CurrentCultureIgnoreCase))
					{
						return true;
					}
				}
				return false;
			}
			catch
			{
				return false;
			}
		}


		/// <summary>
		/// Determines if IDE has the specified filename open.
		/// </summary>
		/// <param name="dte">The DTE.</param>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		private bool DetermineIfIDEHasFileInProject(_DTE dte, string filename)
		{
			try
			{
				var solution = dte.Solution;
				if(solution == null)
				{
					return false;
				}
				Console.WriteLine(solution.FullName);
				foreach(EnvDTE.Project project in solution.Projects)
				{
					Console.WriteLine(project.Name);
					foreach(ProjectItem item in project.ProjectItems)
					{
						foreach(string itemFilename in GetFilesOfItem(item))
						{
							if(itemFilename == filename)
							{
								return true;
							}
						}
					}
				}
				return false;
			}
			catch
			{
				return false;
			}
		}


		/// <summary>
		/// Gets the files of the project item specified
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns></returns>
		private List<string> GetFilesOfItem(ProjectItem item)
		{
			List<string> toReturn = new List<string>();
			if(item == null)
			{
				return toReturn;
			}
			if(item.ProjectItems != null)
			{
				foreach(ProjectItem subItem in item.ProjectItems)
				{
					try
					{
						toReturn.AddRange(GetFilesOfItem(subItem));
					}
					catch { }
				}
			}
			for(short i = 0; i < item.FileCount; i++)
			{
				try
				{
					toReturn.Add(item.FileNames[i]);
				}
				catch { }
			}
			return toReturn;
		}


		/// <summary>
		/// Get a snapshot of the running object table (ROT).
		/// </summary>
		/// <returns>A hashtable mapping the name of the object in the ROT to the corresponding object</returns>
		private Dictionary<string, object> GetRunningObjectTable()
		{
			var toReturn = new Dictionary<string, object>();

			IntPtr numFetched = IntPtr.Zero;
			IRunningObjectTable runningObjectTable;
			IEnumMoniker monikerEnumerator;
			IMoniker[] monikers = new IMoniker[1];

			GetRunningObjectTable(0, out runningObjectTable);
			runningObjectTable.EnumRunning(out monikerEnumerator);
			monikerEnumerator.Reset();

			while(monikerEnumerator.Next(1, monikers, numFetched) == 0)
			{
				IBindCtx ctx;
				CreateBindCtx(0, out ctx);

				string runningObjectName;
				monikers[0].GetDisplayName(ctx, null, out runningObjectName);

				object runningObjectVal;
				runningObjectTable.GetObject(monikers[0], out runningObjectVal);

				toReturn[runningObjectName] = runningObjectVal;
			}
			return toReturn;
		}


		/// <summary>
		/// Get a table of the currently running instances of the Visual Studio .NET IDE.
		/// </summary>
		/// <returns>
		/// A list of the IDE in the running object table to the corresponding DTE object
		/// </returns>
		private List<_DTE> GetIDEInstances()
		{
			var runningIDEInstances = new List<_DTE>();
			Dictionary<string, object> runningObjects = GetRunningObjectTable();

			foreach(var runningObject in runningObjects)
			{
				string candidateName = runningObject.Key;
				if(!candidateName.StartsWith("!VisualStudio.DTE"))
				{
					continue;
				}
				_DTE ide = runningObject.Value as _DTE;
				if(ide == null)
				{
					continue;
				}
				runningIDEInstances.Add(ide);
			}
			return runningIDEInstances;
		}
	}
}
