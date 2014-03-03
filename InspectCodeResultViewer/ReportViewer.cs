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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using System.IO;
using System.Diagnostics;

namespace InspectCodeResultViewer
{
	public partial class ReportViewer : UserControl
	{
		#region Enums
		private enum IconIndex
		{
			Project,
			File,
			Warning, 
			Info
		}
		#endregion

		#region Members
		private Report _viewedReport;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="ReportViewer"/> class.
		/// </summary>
		public ReportViewer()
		{
			InitializeComponent();
		}


		/// <summary>
		/// Binds the report data to the viewer.
		/// </summary>
		/// <param name="toBind">To bind.</param>
		public void BindData(Report toBind)
		{
			if(toBind == null)
			{
				return;
			}

			_mainTreeList.BeginUnboundLoad();
			_mainTreeList.ClearNodes();
			foreach(var project in toBind.KnownProjects)
			{
				AddProject(project);
			}
			_mainTreeList.EndUnboundLoad();
			_viewedReport = toBind;
		}


		/// <summary>
		/// Adds the project as a node to the tree view
		/// </summary>
		/// <param name="project">The project.</param>
		private void AddProject(Project project)
		{
			var projectNode = _mainTreeList.AppendNode(new object[] { project.Name, null, null }, null, project);
			projectNode.StateImageIndex = (int)IconIndex.Project;

			var groupedIssues = from i in project.KnownIssues
								group i by i.File into g
								select g;
			foreach(var group in groupedIssues)
			{
				AddFileIssues(group.Key, group.ToList(), projectNode);
			}
		}


		/// <summary>
		/// Adds the issues belonging to the file specified to the tree view, grouped per issue category.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="issues">The issues.</param>
		/// <param name="parent">The parent.</param>
		private void AddFileIssues(string fileName, List<Issue> issues, TreeListNode parent)
		{
			var fileNode = _mainTreeList.AppendNode(new object[] { fileName, null, null }, parent, fileName);
			fileNode.StateImageIndex = (int)IconIndex.File;

			var groupedIssuesByCategory = from i in issues
										  orderby i.Line ascending
										  group i by new { i.TypeInstance.Category, i.TypeInstance.SubCategory } into g
										  select g;
			foreach(var group in groupedIssuesByCategory)
			{
				var iconIndex = -1;
				switch(group.First().TypeInstance.Severity)
				{
					case SeverityType.Suggestion:
						iconIndex = (int)IconIndex.Info;
						break;
					case SeverityType.Warning:
						iconIndex = (int)IconIndex.Warning;
						break;
				}
				string categoryName = group.Key.Category;
				if(!string.IsNullOrWhiteSpace(group.Key.SubCategory))
				{
					categoryName += ". " + group.Key.SubCategory;
				}
				var groupNode = _mainTreeList.AppendNode(new object[] { categoryName }, fileNode, categoryName);
				groupNode.StateImageIndex = iconIndex;
				foreach(var issue in group)
				{
					var issueNode = _mainTreeList.AppendNode(new object[] { issue.TypeInstance.ToString(), issue.Line, issue.Message }, groupNode, issue);
					issueNode.StateImageIndex = iconIndex;
				}
			}
		}


		/// <summary>
		/// Opens the file in IDE.
		/// </summary>
		private void OpenFileInIDE()
		{
			if((_viewedReport == null) || !_issueInfoGroupBox.Enabled || string.IsNullOrWhiteSpace(_fileNameTextBox.Text))
			{
				return;
			}
			var controller = new DevEnvController();
			try
			{
				this.Cursor = Cursors.WaitCursor;
				controller.OpenFileInIDE(_fileNameTextBox.Text, Convert.ToInt32(_lineTextBox.Text));
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		

		/// <summary>
		/// Views the node information if the focused node is an issue, otherwise hides the panel with the info.
		/// </summary>
		/// <param name="focusedNode">The focused node.</param>
		private void ViewNodeInfo(TreeListNode focusedNode)
		{
			if(focusedNode == null)
			{
				_issueInfoGroupBox.Enabled= false;
				return;
			}

			var issue = focusedNode.Tag as Issue;
			if(issue == null)
			{
				_issueInfoGroupBox.Enabled = false;
				return;
			}
			_issueInfoGroupBox.Enabled = true;
			_lineTextBox.Text = issue.Line.ToString();
			_issueTypeTextBox.Text = issue.TypeInstance.Id;
			_descriptionTextBox.Text = issue.TypeInstance.Description;
			_wikiURLLabel.Text = issue.TypeInstance.WikiUrl;
			_fileNameTextBox.Text = Path.Combine(Path.GetDirectoryName(_viewedReport.SolutionPath), issue.File);
		}



		private void HandleWikiLinkClick()
		{
			if(!string.IsNullOrWhiteSpace(_wikiURLLabel.Text))
			{
				Process.Start(_wikiURLLabel.Text);
			}
		}


		#region Event handlers
		private void _mainTreeList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
		{
			ViewNodeInfo(e.Node);
		}

		private void _openInIDEButton_Click(object sender, EventArgs e)
		{
			OpenFileInIDE();
		}

		private void _wikiURLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			HandleWikiLinkClick();
		}
		#endregion
	}
}
