using Russia.Graphics;

using System;

namespace Russia.UI
{
	public class UIManager : IDisposable
	{
		public UIObject Root { get; } = new UIObject();

		public void Dispose()
		{
			Root.Dispose();
		}

		public void Initialize(GraphicsModule graphics)
		{
		}
	}
}
