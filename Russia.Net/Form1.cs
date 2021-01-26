using Russia.UI;

using System;
using System.Windows.Forms;

namespace Russia
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			Instance = this;
		}

		public static Form1 Instance { get; private set; }

		protected override void OnLoad(EventArgs e)
		{
			Renderer.Initialize(this);

			UIManager.Initialize();

			Demo.Initialize();
		}

		protected override void OnClosed(EventArgs e)
		{
			UIManager.Release();

			Renderer.Release();
		}
	}
}
