using System;
using System.Collections.Generic;

namespace Russia.Graphics
{
	public class Scene:IDisposable
	{
		private readonly Queue<Action<RenderContext>> acts = new Queue<Action<RenderContext>>();
		private readonly List<IView> views = new List<IView>();

		public int Count => views.Count;
		public bool IsReadOnly => false;

		public void Add(IView item)
		{
			acts.Enqueue((renderContext) =>
			{
				views.Add(item);
				item.Initialize(renderContext);
			});
		}

		public void Remove(IView item)
		{
			acts.Enqueue((renderContext) => views.Remove(item));
		}

		public void Dispose()
		{
			foreach (IView view in views)
			{
				view.Dispose();
			}
		}

		internal void Render(RenderContext renderContext)
		{
			while (acts.Count != 0)
			{
				acts.Dequeue().Invoke(renderContext);
			}

			foreach (IView view in views)
			{
				view.Render(renderContext);
			}
		}
	}
}
