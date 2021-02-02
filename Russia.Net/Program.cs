using System;
using System.Windows.Forms;

namespace Russia
{
	internal static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Demo demo = new Demo();
			demo.Run();
		}
	}
}
