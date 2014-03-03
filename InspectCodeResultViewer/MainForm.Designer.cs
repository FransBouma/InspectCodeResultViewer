namespace InspectCodeResultViewer
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this._totalIssuesTextBox = new System.Windows.Forms.TextBox();
			this._totalProjectsTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this._totalIssueTypesTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this._browseFileButton = new System.Windows.Forms.Button();
			this._loadFileButton = new System.Windows.Forms.Button();
			this._solutionPathTextBox = new System.Windows.Forms.TextBox();
			this._resultsFilenameTextBox = new System.Windows.Forms.TextBox();
			this._browseResultsDialog = new System.Windows.Forms.OpenFileDialog();
			this._reportViewer = new InspectCodeResultViewer.ReportViewer();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "File name";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this._browseFileButton);
			this.groupBox1.Controls.Add(this._loadFileButton);
			this.groupBox1.Controls.Add(this._solutionPathTextBox);
			this.groupBox1.Controls.Add(this._resultsFilenameTextBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(5, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(880, 139);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Results file information";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this._totalIssuesTextBox);
			this.groupBox2.Controls.Add(this._totalProjectsTextBox);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this._totalIssueTypesTextBox);
			this.groupBox2.Location = new System.Drawing.Point(6, 77);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(868, 55);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Totals found in file";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(283, 28);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Issues";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(152, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Projects";
			// 
			// _totalIssuesTextBox
			// 
			this._totalIssuesTextBox.Location = new System.Drawing.Point(326, 25);
			this._totalIssuesTextBox.Name = "_totalIssuesTextBox";
			this._totalIssuesTextBox.ReadOnly = true;
			this._totalIssuesTextBox.Size = new System.Drawing.Size(55, 20);
			this._totalIssuesTextBox.TabIndex = 2;
			// 
			// _totalProjectsTextBox
			// 
			this._totalProjectsTextBox.Location = new System.Drawing.Point(203, 25);
			this._totalProjectsTextBox.Name = "_totalProjectsTextBox";
			this._totalProjectsTextBox.ReadOnly = true;
			this._totalProjectsTextBox.Size = new System.Drawing.Size(55, 20);
			this._totalProjectsTextBox.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Issue types";
			// 
			// _totalIssueTypesTextBox
			// 
			this._totalIssueTypesTextBox.Location = new System.Drawing.Point(75, 25);
			this._totalIssueTypesTextBox.Name = "_totalIssueTypesTextBox";
			this._totalIssueTypesTextBox.ReadOnly = true;
			this._totalIssueTypesTextBox.Size = new System.Drawing.Size(55, 20);
			this._totalIssueTypesTextBox.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Solution path";
			// 
			// _browseFileButton
			// 
			this._browseFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._browseFileButton.Location = new System.Drawing.Point(767, 21);
			this._browseFileButton.Name = "_browseFileButton";
			this._browseFileButton.Size = new System.Drawing.Size(26, 26);
			this._browseFileButton.TabIndex = 1;
			this._browseFileButton.Text = "...";
			this._browseFileButton.UseVisualStyleBackColor = true;
			this._browseFileButton.Click += new System.EventHandler(this._browseFileButton_Click);
			// 
			// _loadFileButton
			// 
			this._loadFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._loadFileButton.Location = new System.Drawing.Point(799, 21);
			this._loadFileButton.Name = "_loadFileButton";
			this._loadFileButton.Size = new System.Drawing.Size(75, 26);
			this._loadFileButton.TabIndex = 2;
			this._loadFileButton.Text = "Load";
			this._loadFileButton.UseVisualStyleBackColor = true;
			this._loadFileButton.Click += new System.EventHandler(this._loadFileButton_Click);
			// 
			// _solutionPathTextBox
			// 
			this._solutionPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._solutionPathTextBox.Location = new System.Drawing.Point(87, 51);
			this._solutionPathTextBox.Name = "_solutionPathTextBox";
			this._solutionPathTextBox.ReadOnly = true;
			this._solutionPathTextBox.Size = new System.Drawing.Size(674, 20);
			this._solutionPathTextBox.TabIndex = 3;
			// 
			// _resultsFilenameTextBox
			// 
			this._resultsFilenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._resultsFilenameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this._resultsFilenameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this._resultsFilenameTextBox.Location = new System.Drawing.Point(87, 24);
			this._resultsFilenameTextBox.Name = "_resultsFilenameTextBox";
			this._resultsFilenameTextBox.Size = new System.Drawing.Size(674, 20);
			this._resultsFilenameTextBox.TabIndex = 0;
			// 
			// _browseResultsDialog
			// 
			this._browseResultsDialog.Filter = "Result xml files|*.xml|All files|*.*";
			this._browseResultsDialog.InitialDirectory = "c:\\";
			// 
			// _reportViewer
			// 
			this._reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._reportViewer.Location = new System.Drawing.Point(5, 149);
			this._reportViewer.Name = "_reportViewer";
			this._reportViewer.Size = new System.Drawing.Size(880, 470);
			this._reportViewer.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(889, 624);
			this.Controls.Add(this._reportViewer);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InspectCode Results Viewer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox _totalIssuesTextBox;
		private System.Windows.Forms.TextBox _totalProjectsTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _totalIssueTypesTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button _browseFileButton;
		private System.Windows.Forms.Button _loadFileButton;
		private System.Windows.Forms.TextBox _solutionPathTextBox;
		private System.Windows.Forms.TextBox _resultsFilenameTextBox;
		private System.Windows.Forms.OpenFileDialog _browseResultsDialog;
		private ReportViewer _reportViewer;
	}
}

