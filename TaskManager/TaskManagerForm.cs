using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TaskManager
{
	public partial class FormTaskManager : Form
	{
		
		private string _searchText = ""; // Для хранения текущего введенного текста
		private void FormTaskManager_KeyDown(object sender, KeyEventArgs e)
		{
			// Убедитесь, что фокус установлен на текстовом поле
			if (e.KeyCode == Keys.Back)
			{
				if (_searchText.Length > 0)
				{
					_searchText = _searchText.Substring(0, _searchText.Length - 1);
					PerformSearch(); // Выполняем поиск сразу после изменения текста
				}
			}
			else if (e.KeyCode == Keys.Escape)
			{
				_searchText = ""; // сброс
				ResetFilter(); // Сброс фильтра
			}
			else if (e.KeyCode == Keys.Enter)
			{
				PerformSearch(); // Выполняем поиск
			}
			else if (e.KeyCode != Keys.Shift && e.KeyCode != Keys.Control && e.KeyCode != Keys.Alt)
			{
				_searchText += e.KeyCode.ToString().Length == 1 ? e.KeyCode.ToString().ToLower() : "";
				PerformSearch(); // выполняем поиск после ввода текста
			}
		}
		private void FormTaskManager_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Игнорируем управляющие клавиши
			if (char.IsControl(e.KeyChar)) return;

			_searchText += e.KeyChar.ToString().ToLower();
			PerformSearch(); // Выполняем поиск
		}
		private void PerformSearch()
		{
			if (dataGridView1.Rows.Count == 0) return; // Проверка, есть ли вообще строки

			try
			{
				string searchTextLower = _searchText.ToLower();

				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					bool containsSearchText = false;

					if (row.Cells[1].Value != null)
					{
						containsSearchText = row.Cells[1].Value.ToString().ToLower().Contains(searchTextLower);
					}

					row.Visible = containsSearchText; // Скрываем или показываем строки в зависимости от условия
				}
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show("Ошибка: " + ex.Message); // Дополнительный вывод для отладки
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message); // Общая обработка ошибок
			}
		}

		private void ResetFilter()
		{
			_searchText = ""; // Сбрасываем текст поиска
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				row.Visible = true; // Показываем все строки
			}
			PerformSearch();  // Обновляем видимость строк, сбрасывая фильтр
		}
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// Сбросить фильтрацию при клике на ячейку
			ResetFilter();
		}
		public FormTaskManager()
		{
			InitializeComponent();
			this.KeyPreview = true; // Позволяет формы получать события клавиатуры 
			InitializeContextMenu();
			dataGridView1.Dock = DockStyle.Fill; // Заполнение DataGridView
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.ReadOnly = true;
			dataGridView1.AutoGenerateColumns = false; // Отключение авто генирации
													   // Подписка на событие KeyDown
			this.KeyDown += new KeyEventHandler(FormTaskManager_KeyDown);
			this.KeyPress += new KeyPressEventHandler(FormTaskManager_KeyPress);
		}
		private void InitializeContextMenu()
		{
			contextMenuStrip1 = new ContextMenuStrip();
			ToolStripMenuItem closeProcessMenuItem = new ToolStripMenuItem("Закрыть процесс");
			closeProcessMenuItem.Click += closeProcessToolStripMenuItem_Click; // Связываем событие клика
			contextMenuStrip1.Items.Add(closeProcessMenuItem);
			dataGridView1.ContextMenuStrip = contextMenuStrip1; // Присоединяем контекстное меню к DataGridView
		}
		private void closeProcessToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int processId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

				MessageBox.Show($"Попытка завершения процесса: {processId}");

				try
				{
					// Получаем процесс по ID
					var process = Process.GetProcessById(processId);
					MessageBox.Show($"Процесс найден: {process.ProcessName}");

					process.Kill(); // Завершение процесса
					MessageBox.Show($"Процесс {processId} (имя: {process.ProcessName}) завершён.");

					LoadProcesses(); // Обновляем список процессов после завершения
				}
				catch (ArgumentException ex) // Если ID процесса не верен
				{
					MessageBox.Show("Ошибка: неверный идентификатор процесса. " + ex.Message);
				}
				catch (InvalidOperationException ex) // Если процесс уже завершен
				{
					MessageBox.Show("Не удалось завершить процесс, так как он уже был завершён: " + ex.Message);
				}
				catch (UnauthorizedAccessException ex) // Если нет прав для завершения процесса
				{
					MessageBox.Show("У вас недостаточно прав для завершения этого процесса: " + ex.Message);
				}
				catch (Exception ex) // Обработка любых других исключений
				{
					MessageBox.Show("Не удалось завершить процесс: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Выберите процесс для завершения.");
			}
		}
		
		public void LoadProcesses()
		{
			// Сохраняем текущее положение первой отображаемой строки и горизонтальную прокрутку
			int firstDisplayedRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
			int horizontalScrollPosition = dataGridView1.HorizontalScrollingOffset;

			// Сохраняем идентификатор выбранного процесса
			//переменная может хранить либо значение типа int, либо быть null
			int? selectedProcessId = null;
			if (dataGridView1.SelectedRows.Count > 0)
			{
				selectedProcessId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
			}

			// приостановка обновления
			dataGridView1.SuspendLayout();

			// Сохраняем информацию о текущей сортировке
			var sortColumn = dataGridView1.SortedColumn;
			SortOrder sortOrder = dataGridView1.SortOrder;

			// Запоминаем количество текущих строк
			int currentRowCount = dataGridView1.Rows.Count;

			// Получаем список процессов
			Process[] processes = Process.GetProcesses();

			// Удаляем только те строки, которые не имеют соответствия в новой выборке
			for (int i = 0; i < currentRowCount; i++)
			{
				if (i >= processes.Length) // Удаляем лишние строки
				{
					dataGridView1.Rows.RemoveAt(i--); // Уменьшаем i, чтобы при удалении не пропустить строку
				}
				else
				{
					try
					{   // Обновляем существующие строки
						Process process = processes[i];
						long memorySize = process.WorkingSet64 / (1024 * 1024); // переход из байтов в мб
						DateTime startTime = process.StartTime; // время запуска процесса

						// Обновление данных в строке
						dataGridView1.Rows[i].Cells[0].Value = process.Id;
						dataGridView1.Rows[i].Cells[1].Value = process.ProcessName;
						dataGridView1.Rows[i].Cells[2].Value = process.MainWindowTitle;
						dataGridView1.Rows[i].Cells[3].Value = memorySize;
						dataGridView1.Rows[i].Cells[4].Value = startTime;

					}
					catch (Exception)
					{
						// Игнорируем процессы, к которым нет доступа
						continue;
					}
				}
			}

			// Добавляем новые строки, если их больше
			for (int i = currentRowCount; i < processes.Length; i++)
			{
				var process = processes[i];
				try
				{
					var memorySizeInMB = process.WorkingSet64 / (1024 * 1024); // переход из байтов в мегабайты
					var startTime = process.StartTime; // время запуска процесса

					// Добавляем новые строки
					dataGridView1.Rows.Add(process.Id, process.ProcessName, process.MainWindowTitle, memorySizeInMB, startTime);
				}
				catch (Exception)
				{
					// Игнорируем процессы, к которым нет доступа
					continue;
				}
			}
			
			// Восстанавливаем положение прокрутки
			if (firstDisplayedRowIndex >= 0 && firstDisplayedRowIndex < dataGridView1.Rows.Count)
			{
				dataGridView1.FirstDisplayedScrollingRowIndex = firstDisplayedRowIndex;
			}
			dataGridView1.HorizontalScrollingOffset = horizontalScrollPosition; // Восстанавливаем положение горизонтальной прокрутки

			// Применение сортировки
			if (sortColumn != null)
			{
				// Выполняем сортировку в зависимости от предыдущего состояния
				dataGridView1.Sort(sortColumn, sortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
			}
			// Если есть выбранный процесс и он все еще в списке
			if (selectedProcessId.HasValue)
			{
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					if ((int)row.Cells[0].Value == selectedProcessId.Value)
					{
						row.Selected = true; // Выбираем строку с соответствующим ID
						break;
					}
				}
			}
			// Возобновляем раскладку
			dataGridView1.ResumeLayout();
		}


		
		private void FormTaskManager_Load(object sender, EventArgs e)
		{
			try
			{
				LoadProcesses();
				this.ActiveControl = this; // Установка фокуса на форму
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при загрузке: " + ex.Message);
			}
		}

		private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var hitTest = dataGridView1.HitTest(e.X, e.Y);
				if (hitTest.RowIndex >= 0) // Проверяем, что мы нажали на строке
				{
					dataGridView1.ClearSelection();
					dataGridView1.Rows[hitTest.RowIndex].Selected = true; // выделяем строку
					contextMenuStrip1.Show(dataGridView1, e.Location); // отображаем контекстное меню
				}
			}
		}
		private void btnMinimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		private void btnMaximize_Click(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				this.WindowState = FormWindowState.Maximized;
			}
			else
			{
				this.WindowState = FormWindowState.Normal;
			}
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnKill_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int processId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
				try
				{
					Process.GetProcessById(processId).Kill();
					LoadProcesses(); // Обновить список процессов
					ResetFilter(); // Сбросить фильтрацию
				}
				catch (Exception ex)
				{
					MessageBox.Show("Не удалось завершить процесс: " + ex.Message);
				}
			}
		}
		//private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		//{

		//}

		private void timer1_Tick(object sender, EventArgs e)
		{
			LoadProcesses();
			toolStripStatusLabel1.Text = dataGridView1.Rows.Count.ToString();
		}

		private void toolStripTextBox1_Click(object sender, EventArgs e)
		{

		}

		private void add_Click(object sender, EventArgs e)
		{
			StartProcess();
		}
		// Обработка запуска процесса
		private void StartProcess()
		{
			// Открываем диалог для ввода имени процесса
			string processName = Prompt.ShowDialog("Введите имя процесса:", "Запуск процесса");

			if (!string.IsNullOrEmpty(processName))
			{
				try
				{
					// Запускаем новый процесс
					Process.Start(processName);
					LoadProcesses(); // Обновляем список процессов после старта
					ResetFilter(); // Очищаем фильтр после запуска
				}
				catch (Exception ex)
				{
					MessageBox.Show("Не удалось запустить процесс: " + ex.Message);
				}
			}
		}
		public static class Prompt
		{
			private static List<string> previousEntries = new List<string>(); // для хранения ввода

			public static string ShowDialog(string text, string caption)
			{
				Form prompt = new Form()
				{
					Width = 500,
					Height = 150,
					FormBorderStyle = FormBorderStyle.FixedDialog,
					Text = caption,
					StartPosition = FormStartPosition.CenterScreen
				};

				Label textLabel = new Label() { Left = 50, Top = 20, Text = text };

				// Используем ComboBox вместо TextBox
				ComboBox comboBox = new ComboBox() { Left = 50, Top = 50, Width = 400 };
				comboBox.DropDownStyle = ComboBoxStyle.DropDown; // Позволяет пользователю вводить текст, а не только выбирать из списка
			 // Заполняем ComboBox предыдущими введенными данными
				comboBox.Items.AddRange(previousEntries.ToArray());

				Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
				confirmation.Click += (sender, e) =>
				{
					// Добавляем новое значение в список только если оно не пустое
					if (!string.IsNullOrWhiteSpace(comboBox.Text) && !previousEntries.Contains(comboBox.Text))
					{
						previousEntries.Add(comboBox.Text);
					}
					prompt.Close();
				};

				prompt.Controls.Add(textLabel);
				prompt.Controls.Add(comboBox);
				prompt.Controls.Add(confirmation);
				prompt.ShowDialog();

				return comboBox.Text; // Возврат введенного текста
			}
		}
	}
}
