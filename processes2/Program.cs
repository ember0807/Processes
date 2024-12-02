using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace processes2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Process[] allProcess = Process.GetProcesses();
			for (int i = 0; i < allProcess.Length; i++)
			{
				Console.WriteLine($"{allProcess[i].Id}'\t'{allProcess[i].ProcessName}");
			}
		}
	}
}
