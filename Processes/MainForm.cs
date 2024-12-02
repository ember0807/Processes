using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Processes
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			string cmd = TextBoxProgramm.Text;
			if(comboBoxPrograms.Text.Length > 0)cmd = comboBoxPrograms.Text;
			string[] splitted = cmd.Split(' ');
			string file = splitted[0];
			string arguments = "";
			if (splitted.Length > 1)cmd.Remove(0,cmd.IndexOf(' '));

			process.StartInfo.FileName = file;
			process.StartInfo.Arguments = arguments;
			//Наш процесс пытается найти запускаемый процесс сначала в своем рабочем 
			//каталоге а потом в системных каталогах , включая все каталоги хранимые
			// в переменной окружение %PATH%
			// Все переменные окружения виндовс можно отобразать командой set
			//Если указанный процесс не найден то возникает исключение 
			try
			{
				process.Start();
				if(comboBoxPrograms.Items.Contains(cmd))comboBoxPrograms.Items.Add(cmd);
				
			}
			catch (System.ComponentModel.Win32Exception ex )
			{
				MessageBox.Show(this, ex.GetType().ToString() + '\n' + ex.Message, "Error", MessageBoxButtons.OKCancel);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.GetType().ToString() + '\n' +  ex.Message, "Error", MessageBoxButtons.OKCancel);

			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void TextBoxProgramm_TextChanged(object sender, EventArgs e)
		{

		}

		private void comboBoxPrograms_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
