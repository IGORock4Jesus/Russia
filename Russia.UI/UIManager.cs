using Russia.Graphics;

using System;

namespace Russia.UI
{
	public class UIManager : IDisposable
	{
		private Scene scene;

		public UIObject Root { get; } = new UIObject();

		public void Dispose()
		{
			Root.Dispose();
		}

		public void Initialize(GraphicsModule graphics)
		{
			Root.InitializeGraphics(graphics.Context);
		}
	}
}
