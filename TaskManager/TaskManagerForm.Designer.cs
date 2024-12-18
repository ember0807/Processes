namespace TaskManager
{
	partial class FormTaskManager
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaskManager));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.ProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MainWindowTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MemoryUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.add = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessId,
            this.ProcessName,
            this.MainWindowTitle,
            this.MemoryUsage,
            this.StartTime});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(543, 420);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_MouseDown);
			// 
			// ProcessId
			// 
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
			this.ProcessId.DefaultCellStyle = dataGridViewCellStyle6;
			this.ProcessId.HeaderText = "ID";
			this.ProcessId.Name = "ProcessId";
			// 
			// ProcessName
			// 
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
			this.ProcessName.DefaultCellStyle = dataGridViewCellStyle7;
			this.ProcessName.HeaderText = "Имя процесса";
			this.ProcessName.Name = "ProcessName";
			// 
			// MainWindowTitle
			// 
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
			this.MainWindowTitle.DefaultCellStyle = dataGridViewCellStyle8;
			this.MainWindowTitle.HeaderText = "Заголовок";
			this.MainWindowTitle.Name = "MainWindowTitle";
			// 
			// MemoryUsage
			// 
			this.MemoryUsage.HeaderText = "Использование памяти (KB)";
			this.MemoryUsage.Name = "MemoryUsage";
			// 
			// StartTime
			// 
			this.StartTime.HeaderText = "Дата запуска";
			this.StartTime.Name = "StartTime";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(161, 29);
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.AccessibleName = "Закрыть процесс";
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
			this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
			// 
			// add
			// 
			this.add.Location = new System.Drawing.Point(0, 0);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(43, 34);
			this.add.TabIndex = 3;
			this.add.Text = "+";
			this.add.UseVisualStyleBackColor = true;
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 398);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(543, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// FormTaskManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GrayText;
			this.ClientSize = new System.Drawing.Size(543, 420);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.add);
			this.Controls.Add(this.dataGridView1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Name = "FormTaskManager";
			this.Text = "TaskManager";
			this.TransparencyKey = System.Drawing.SystemColors.ActiveCaptionText;
			this.Load += new System.EventHandler(this.FormTaskManager_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
		private System.Windows.Forms.Button add;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProcessId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
		private System.Windows.Forms.DataGridViewTextBoxColumn MainWindowTitle;
		private System.Windows.Forms.DataGridViewTextBoxColumn MemoryUsage;
		private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
	}
}

