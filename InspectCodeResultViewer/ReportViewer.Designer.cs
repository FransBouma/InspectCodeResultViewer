namespace InspectCodeResultViewer
{
	partial class ReportViewer
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewer));
			this._mainTreeList = new DevExpress.XtraTreeList.TreeList();
			this.IssueIdCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.lineNoCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.MessageCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this._treeIcons = new System.Windows.Forms.ImageList(this.components);
			this._issueInfoGroupBox = new System.Windows.Forms.GroupBox();
			this._wikiURLLabel = new System.Windows.Forms.LinkLabel();
			this._openInIDEButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this._lineTextBox = new System.Windows.Forms.TextBox();
			this._descriptionTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this._issueTypeTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this._fileNameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this._mainTreeList)).BeginInit();
			this._issueInfoGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// _mainTreeList
			// 
			this._mainTreeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this._mainTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.IssueIdCol,
            this.lineNoCol,
            this.MessageCol});
			this._mainTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
			this._mainTreeList.Location = new System.Drawing.Point(0, 0);
			this._mainTreeList.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
			this._mainTreeList.LookAndFeel.UseDefaultLookAndFeel = false;
			this._mainTreeList.LookAndFeel.UseWindowsXPTheme = true;
			this._mainTreeList.Name = "_mainTreeList";
			this._mainTreeList.OptionsBehavior.Editable = false;
			this._mainTreeList.OptionsBehavior.EnableFiltering = true;
			this._mainTreeList.OptionsBehavior.PopulateServiceColumns = true;
			this._mainTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
			this._mainTreeList.OptionsView.ShowVertLines = false;
			this._mainTreeList.Size = new System.Drawing.Size(685, 292);
			this._mainTreeList.StateImageList = this._treeIcons;
			this._mainTreeList.TabIndex = 0;
			this._mainTreeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this._mainTreeList_FocusedNodeChanged);
			// 
			// IssueIdCol
			// 
			this.IssueIdCol.Caption = "Issue name";
			this.IssueIdCol.FieldName = "TypeInstance";
			this.IssueIdCol.MinWidth = 33;
			this.IssueIdCol.Name = "IssueIdCol";
			this.IssueIdCol.Visible = true;
			this.IssueIdCol.VisibleIndex = 0;
			this.IssueIdCol.Width = 488;
			// 
			// lineNoCol
			// 
			this.lineNoCol.Caption = "Line no";
			this.lineNoCol.FieldName = "Line";
			this.lineNoCol.Name = "lineNoCol";
			this.lineNoCol.OptionsColumn.AllowFocus = false;
			this.lineNoCol.OptionsColumn.FixedWidth = true;
			this.lineNoCol.Visible = true;
			this.lineNoCol.VisibleIndex = 1;
			this.lineNoCol.Width = 59;
			// 
			// MessageCol
			// 
			this.MessageCol.Caption = "Message";
			this.MessageCol.FieldName = "Message";
			this.MessageCol.Name = "MessageCol";
			this.MessageCol.OptionsColumn.AllowFocus = false;
			this.MessageCol.Visible = true;
			this.MessageCol.VisibleIndex = 2;
			this.MessageCol.Width = 117;
			// 
			// _treeIcons
			// 
			this._treeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_treeIcons.ImageStream")));
			this._treeIcons.TransparentColor = System.Drawing.Color.Magenta;
			this._treeIcons.Images.SetKeyName(0, "CSharpProject_SolutionExplorerNode_24.bmp");
			this._treeIcons.Images.SetKeyName(1, "CSharpFile_SolutionExplorerNode_24.bmp");
			this._treeIcons.Images.SetKeyName(2, "Warning_yellow_7231_16x16_24.bmp");
			this._treeIcons.Images.SetKeyName(3, "Information_blue_6227_16x16_24.bmp");
			// 
			// _issueInfoGroupBox
			// 
			this._issueInfoGroupBox.Controls.Add(this._wikiURLLabel);
			this._issueInfoGroupBox.Controls.Add(this._openInIDEButton);
			this._issueInfoGroupBox.Controls.Add(this.label5);
			this._issueInfoGroupBox.Controls.Add(this._lineTextBox);
			this._issueInfoGroupBox.Controls.Add(this._descriptionTextBox);
			this._issueInfoGroupBox.Controls.Add(this.label4);
			this._issueInfoGroupBox.Controls.Add(this._issueTypeTextBox);
			this._issueInfoGroupBox.Controls.Add(this.label3);
			this._issueInfoGroupBox.Controls.Add(this._fileNameTextBox);
			this._issueInfoGroupBox.Controls.Add(this.label2);
			this._issueInfoGroupBox.Controls.Add(this.label1);
			this._issueInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._issueInfoGroupBox.Location = new System.Drawing.Point(0, 292);
			this._issueInfoGroupBox.Name = "_issueInfoGroupBox";
			this._issueInfoGroupBox.Size = new System.Drawing.Size(685, 114);
			this._issueInfoGroupBox.TabIndex = 1;
			this._issueInfoGroupBox.TabStop = false;
			this._issueInfoGroupBox.Text = "Selected issue information";
			// 
			// _wikiURLLabel
			// 
			this._wikiURLLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._wikiURLLabel.Location = new System.Drawing.Point(71, 67);
			this._wikiURLLabel.Name = "_wikiURLLabel";
			this._wikiURLLabel.Size = new System.Drawing.Size(608, 13);
			this._wikiURLLabel.TabIndex = 8;
			this._wikiURLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._wikiURLLabel_LinkClicked);
			// 
			// _openInIDEButton
			// 
			this._openInIDEButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._openInIDEButton.Location = new System.Drawing.Point(569, 82);
			this._openInIDEButton.Name = "_openInIDEButton";
			this._openInIDEButton.Size = new System.Drawing.Size(110, 26);
			this._openInIDEButton.TabIndex = 7;
			this._openInIDEButton.Text = "Open in VS.NET";
			this._openInIDEButton.UseVisualStyleBackColor = true;
			this._openInIDEButton.Click += new System.EventHandler(this._openInIDEButton_Click);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(483, 89);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(27, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Line";
			// 
			// _lineTextBox
			// 
			this._lineTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._lineTextBox.Location = new System.Drawing.Point(516, 86);
			this._lineTextBox.Name = "_lineTextBox";
			this._lineTextBox.ReadOnly = true;
			this._lineTextBox.Size = new System.Drawing.Size(47, 20);
			this._lineTextBox.TabIndex = 5;
			// 
			// _descriptionTextBox
			// 
			this._descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._descriptionTextBox.Location = new System.Drawing.Point(74, 40);
			this._descriptionTextBox.Name = "_descriptionTextBox";
			this._descriptionTextBox.ReadOnly = true;
			this._descriptionTextBox.Size = new System.Drawing.Size(605, 20);
			this._descriptionTextBox.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Wiki URL";
			// 
			// _issueTypeTextBox
			// 
			this._issueTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._issueTypeTextBox.Location = new System.Drawing.Point(74, 16);
			this._issueTypeTextBox.Name = "_issueTypeTextBox";
			this._issueTypeTextBox.ReadOnly = true;
			this._issueTypeTextBox.Size = new System.Drawing.Size(605, 20);
			this._issueTypeTextBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Description";
			// 
			// _fileNameTextBox
			// 
			this._fileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._fileNameTextBox.Location = new System.Drawing.Point(74, 86);
			this._fileNameTextBox.Name = "_fileNameTextBox";
			this._fileNameTextBox.ReadOnly = true;
			this._fileNameTextBox.Size = new System.Drawing.Size(403, 20);
			this._fileNameTextBox.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Issue type";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Filename";
			// 
			// ReportViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._mainTreeList);
			this.Controls.Add(this._issueInfoGroupBox);
			this.Name = "ReportViewer";
			this.Size = new System.Drawing.Size(685, 406);
			((System.ComponentModel.ISupportInitialize)(this._mainTreeList)).EndInit();
			this._issueInfoGroupBox.ResumeLayout(false);
			this._issueInfoGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraTreeList.TreeList _mainTreeList;
		private DevExpress.XtraTreeList.Columns.TreeListColumn IssueIdCol;
		private DevExpress.XtraTreeList.Columns.TreeListColumn lineNoCol;
		private DevExpress.XtraTreeList.Columns.TreeListColumn MessageCol;
		private System.Windows.Forms.GroupBox _issueInfoGroupBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _fileNameTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox _lineTextBox;
		private System.Windows.Forms.Button _openInIDEButton;
		private System.Windows.Forms.LinkLabel _wikiURLLabel;
		private System.Windows.Forms.TextBox _descriptionTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox _issueTypeTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ImageList _treeIcons;

	}
}
