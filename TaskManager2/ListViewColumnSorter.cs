using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TaskManager2
{
	//public class ListViewColumnSorter : IComparer
	//{
	//	public int SortColumn { get; set; } // Колонка, по которой будем сортировать
	//	public SortOrder Order { get; set; } // Порядок сортировки: по возрастанию или убыванию

	//	public ListViewColumnSorter()
	//	{
	//		SortColumn = 0; // По умолчанию сортируем по первой колонке
	//		Order = SortOrder.Ascending; // По умолчанию сортируем по возрастанию
	//	}

	//	public int Compare(object x, object y)
	//	{
	//		// Приведение объектов к ListViewItem
	//		ListViewItem item1 = (ListViewItem)x;
	//		ListViewItem item2 = (ListViewItem)y;

	//		// Получаем значения из выбранной колонки
	//		string string1 = item1.SubItems[SortColumn].Text;
	//		string string2 = item2.SubItems[SortColumn].Text;

	//		// Сравниваем значения в зависимости от типа данных (можно расширить при необходимости)
	//		int result = string.Compare(string1, string2);

	//		// Если порядок сортировки - по убыванию, инвертируем результат
	//		if (Order == SortOrder.Descending)
	//		{
	//			result = -result;
	//		}

	//		return result; // Возвращаем результат сравнения
	//	}
	//}
	class ListViewColumnSorter : IComparer
	{
		//int columnToSort;
		//SortOrder orderOfSort;
		CaseInsensitiveComparer objectCompare;
		public int SortColumn { get; set; }
		//{
		//	get => columnToSort;
		//	set => columnToSort = value;
		//}
		public SortOrder Order { get; set; }
		//{
		//	get => orderOfSort;
		//	set => orderOfSort = value;
		//}
		public ListViewColumnSorter()
		{
			//columnToSort = 0;
			//orderOfSort = SortOrder.None;
			SortColumn = 0;
			Order = SortOrder.None;
			objectCompare = new CaseInsensitiveComparer();
		}
		public int Compare(object x, object y)
		{
			ListViewItem listViewX = (ListViewItem)x;
			ListViewItem listViewY = (ListViewItem)y;
			int compareResult;
			if (double.TryParse(listViewX.SubItems[SortColumn].Text, out _))
			{
				compareResult = objectCompare.Compare
					(
					Convert.ToDouble(listViewX.SubItems[SortColumn].Text),
					Convert.ToDouble(listViewY.SubItems[SortColumn].Text)
					);
			}
			else
			{
				compareResult =
					objectCompare.Compare
					(
						listViewX.SubItems[SortColumn].Text,
						listViewY.SubItems[SortColumn].Text
					);
			}

			if (Order == SortOrder.Ascending)
				return compareResult;
			else if (Order == SortOrder.Descending)
				return -compareResult;
			//else
			return compareResult;
		}
	}

}
