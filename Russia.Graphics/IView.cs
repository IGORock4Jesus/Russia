using System;

namespace Russia.Graphics
{
	public interface IView : IDisposable
	{
		void Initialize(RenderContext context);
		void Render(RenderContext context);
	}
}
