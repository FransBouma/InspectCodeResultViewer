//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2014 Solutions Design. All rights reserved.
// 
// This InspectCode result viewer is released under the following license: (BSD2)
// -------------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SD.Tools.BCLExtensions.CollectionsRelated;

namespace InspectCodeResultViewer
{
	/// <summary>
	/// Class which contains the read results from the xml file.
	/// </summary>
	public class Report
	{
		#region Members
		private Dictionary<string, IssueType> _knownIssueTypes;	// Key is Id
		private string _toolsVersion;
		private string _inspectCodePath;
		private List<Project> _projects;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="Report"/> class.
		/// </summary>
		public Report()
		{
			var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
			_inspectCodePath = configuration.AppSettings.Settings["InspectCodeRootPath"].Value;
			_knownIssueTypes = new Dictionary<string, IssueType>();
			this.SolutionPath = string.Empty;
			_toolsVersion = string.Empty;
			_projects = new List<Project>();
		}


		/// <summary>
		/// Loads the results in the file specified into this report. Clears all existing data
		/// </summary>
		/// <param name="resultsXmlFile">The results XML file.</param>
		public void LoadResults(string resultsXmlFile)
		{
			if(!File.Exists(resultsXmlFile))
			{
				MessageBox.Show(string.Format("File not found: '{0}'", resultsXmlFile), "The specified file wasn't found", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_knownIssueTypes.Clear();
			this.SolutionPath = string.Empty;
			_toolsVersion = string.Empty;
			_projects.Clear();

			using(var reader = XmlUtils.CreateXmlReader(resultsXmlFile))
			{
				if(!reader.PrepareReaderForFirstRead())
				{
					MessageBox.Show(string.Format("File '{0}' is empty.", resultsXmlFile), "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				_toolsVersion = reader.GetAttribute("ToolsVersion");
				while(reader.ReadNext())
				{
					switch(reader.LocalName)
					{
						case "Information":
							LoadInformation(reader);
							break;
						case "IssueTypes":
							LoadIssueTypes(reader);
							break;
						case "Issues":
							LoadIssues(reader);
							break;
					}
				}
				reader.Close();
			}
		}


		/// <summary>
		/// Gets the issuetype instance related to the specified typeid or null if not found.
		/// </summary>
		/// <param name="typeId">The type identifier.</param>
		/// <returns></returns>
		internal IssueType GetKnownIssueType(string typeId)
		{
			return _knownIssueTypes.GetValue(typeId);
		}


		/// <summary>
		/// Loads the issues.
		/// </summary>
		/// <param name="reader">The reader.</param>
		private void LoadIssues(XmlReader reader)
		{
			using(var localReader = reader.GetSubtreeReader())
			{
				while(localReader.ReadNext())
				{
					// contains solely project nodes
					var project = new Project(this);
					project.Load(localReader);
					_projects.Add(project);
				}
			}
		}


		/// <summary>
		/// Loads the issue types inside the IssueTypes element.
		/// </summary>
		/// <param name="reader">The reader.</param>
		private void LoadIssueTypes(XmlReader reader)
		{
			using(var localReader = reader.GetSubtreeReader())
			{
				while(localReader.ReadNext())
				{
					// contains solely IssueType elements
					var issueType = new IssueType();
					issueType.Load(localReader);
					_knownIssueTypes.Add(issueType.Id, issueType);
				}
			}
		}


		/// <summary>
		/// Loads the information element
		/// </summary>
		/// <param name="reader">The reader.</param>
		private void LoadInformation(XmlReader reader)
		{
			using(var localReader = reader.GetSubtreeReader())
			{
				while(localReader.ReadNext())
				{
					switch(localReader.LocalName)
					{
						case "Solution":
							string readPath = localReader.ReadElementContentAsString();
							this.SolutionPath = Path.GetFullPath(Path.Combine(_inspectCodePath, readPath));
							break;
						// rest is not interesting for now.
					}
				}
			}
		}


		#region Properties
		public List<IssueType> KnownIssueTypes
		{
			get { return _knownIssueTypes.Values.ToList(); }
		}

		public List<Project> KnownProjects
		{
			get { return _projects; }
		}

		public string SolutionPath { get; private set; }
		#endregion
	}
}
