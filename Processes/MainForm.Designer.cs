namespace Processes
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
			if (disposing && (components != null))
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
			this.TextBoxProgramm = new System.Windows.Forms.TextBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.process = new System.Diagnostics.Process();
			this.comboBoxPrograms = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// TextBoxProgramm
			// 
			this.TextBoxProgramm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.TextBoxProgramm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.TextBoxProgramm.Location = new System.Drawing.Point(12, 24);
			this.TextBoxProgramm.Name = "TextBoxProgramm";
			this.TextBoxProgramm.Size = new System.Drawing.Size(333, 20);
			this.TextBoxProgramm.TabIndex = 0;
			this.TextBoxProgramm.TextChanged += new System.EventHandler(this.TextBoxProgramm_TextChanged);
			// 
			// buttonStart
			// 
			this.buttonStart.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonStart.Location = new System.Drawing.Point(189, 86);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 1;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(270, 86);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// process
			// 
			this.process.StartInfo.Domain = "";
			this.process.StartInfo.LoadUserProfile = false;
			this.process.StartInfo.Password = null;
			this.process.StartInfo.StandardErrorEncoding = null;
			this.process.StartInfo.StandardOutputEncoding = null;
			this.process.StartInfo.UserName = "";
			this.process.SynchronizingObject = this;
			// 
			// comboBoxPrograms
			// 
			this.comboBoxPrograms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboBoxPrograms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.comboBoxPrograms.FormattingEnabled = true;
			this.comboBoxPrograms.Location = new System.Drawing.Point(13, 51);
			this.comboBoxPrograms.Name = "comboBoxPrograms";
			this.comboBoxPrograms.Size = new System.Drawing.Size(332, 21);
			this.comboBoxPrograms.TabIndex = 3;
			this.comboBoxPrograms.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrograms_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 118);
			this.Controls.Add(this.comboBoxPrograms);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.TextBoxProgramm);
			this.Name = "MainForm";
			this.Text = "Processes";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TextBoxProgramm;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonCancel;
		private System.Diagnostics.Process process;
		private System.Windows.Forms.ComboBox comboBoxPrograms;
	}
}

