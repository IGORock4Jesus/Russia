using System;
using System.Collections.Generic;

namespace Russia.UI
{
	internal class UIObject : IDisposable
	{
		private readonly List<UIObject> children = new List<UIObject>();
		private readonly object childrenSaver = new object();

		internal void Render(RenderContext renderContext)
		{
			OnRender(renderContext);

			lock (childrenSaver)
			{
				foreach (UIObject child in children)
				{
					child.Render(renderContext);
				} 
			}
		}

		protected virtual void OnRender(RenderContext renderContext)
		{
		}

		public void AddChild(UIObject child)
		{
			lock (childrenSaver)
			{
				children.Add(child);
			}
		}

		public void Dispose()
		{
			lock (childrenSaver)
			{
				foreach (UIObject child in children)
				{
					child.Dispose();
				}
				children.Clear();
			}

			OnDispose();
		}

		protected virtual void OnDispose()
		{
		}
	}
}