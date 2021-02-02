using Russia.UI;

using System;
using System.Windows.Forms;

namespace Russia.Core
{
	/// <summary>
	/// Прототип приложения.
	/// </summary>
	public class App
	{
		private readonly Form1 form;
		private readonly Graphics.GraphicsModule graphics;
		private readonly UI.UIManager ui;

		public UIManager UI => ui;

		public App()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			form = new Form1();
			graphics = new Graphics.GraphicsModule(form.Handle, form.ClientSize.Width, form.ClientSize.Height);
			ui = new UIManager();

			form.Load += Form_Load;
			form.FormClosed += Form_FormClosed;
		}

		public void Run()
		{
			Application.Run(form);
		}

		protected virtual void OnInitialize() { }
		protected virtual void OnRelease() { }

		private void Form_Load(object sender, EventArgs e)
		{
			graphics.Initialize();
			ui.Initialize(graphics);

			// after all
			OnInitialize();
		}

		private void Form_FormClosed(object sender, FormClosedEventArgs e)
		{
			// before all
			OnRelease();

			ui.Dispose();
			graphics.Dispose();
		}
	}
}
