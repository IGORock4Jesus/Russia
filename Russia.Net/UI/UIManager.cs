using System;
using System.Collections.Generic;

namespace Russia.UI
{
	internal static class UIManager
	{
		public static UIObject Root { get; } = new UIObject();

		internal static void Initialize()
		{
			Renderer.Rendering += Renderer_Rendering;
		}

		private static void Renderer_Rendering(RenderContext renderContext)
		{
			Root.Render(renderContext);
		}

		internal static void Release()
		{
			Renderer.Rendering -= Renderer_Rendering;

			Root.Dispose();
		}
	}
}
