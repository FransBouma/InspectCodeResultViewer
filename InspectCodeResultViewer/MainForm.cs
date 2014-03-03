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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InspectCodeResultViewer
{
	/// <summary>
	/// The main UI
	/// </summary>
	public partial class MainForm : Form
	{
		#region Members
		private Report _loadedReport;
		private string _initialFileToLoad;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// </summary>
		/// <param name="initialFileToLoad">The initial file to load.</param>
		public MainForm(string initialFileToLoad)
		{
			InitializeComponent();
			_initialFileToLoad = initialFileToLoad;
			_reportViewer.Enabled = false;
		}


		/// <summary>
		/// Handles the click on the browse file button. Opens a file browse dialog to let the user browse for the xml file.
		/// </summary>
		private void HandleBrowseFile()
		{
			_browseResultsDialog.FileName = _resultsFilenameTextBox.Text;
			var result = _browseResultsDialog.ShowDialog(this);
			if(result != System.Windows.Forms.DialogResult.OK)
			{
				return;
			}
			_resultsFilenameTextBox.Text = _browseResultsDialog.FileName;
		}


		/// <summary>
		/// Handles the click on the load file button. It loads the file specified by the user, if possible. 
		/// </summary>
		private void HandleLoadFile()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				string filenameToUse = _resultsFilenameTextBox.Text;
				if(string.IsNullOrWhiteSpace(filenameToUse))
				{
					return;
				}
				_loadedReport = new Report();
				_loadedReport.LoadResults(filenameToUse);
				DisplayLoadedReport();
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}


		/// <summary>
		/// Displays the loaded report in the UI
		/// </summary>
		private void DisplayLoadedReport()
		{
			_reportViewer.Enabled = false;
			if(_loadedReport == null)
			{
				return;
			}

			_solutionPathTextBox.Text = _loadedReport.SolutionPath;
			_totalIssuesTextBox.Text = (from p in _loadedReport.KnownProjects select p.KnownIssues.Count()).Sum().ToString();
			_totalIssueTypesTextBox.Text = _loadedReport.KnownIssueTypes.Count().ToString();
			_totalProjectsTextBox.Text = _loadedReport.KnownProjects.Count().ToString();

			_reportViewer.BindData(_loadedReport);
			_reportViewer.Enabled = true;
		}


		#region Event Handlers
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			_resultsFilenameTextBox.Text = _initialFileToLoad ?? string.Empty;
			HandleLoadFile();
		}

		private void _browseFileButton_Click(object sender, EventArgs e)
		{
			HandleBrowseFile();
		}
		private void _loadFileButton_Click(object sender, EventArgs e)
		{
			HandleLoadFile();
		}
		#endregion
	}
}
