using Russia.Graphics;
using Russia.UI.Constraints;

using SharpDX;

using System;
using System.Collections.Generic;

namespace Russia.UI
{
	public class UIObject : IDisposable
	{
		private readonly List<UIObject> children = new List<UIObject>();
		private readonly object childrenSaver = new object();
		private Vector2 absolutePosition, relativePosition;
		private UIObject parent;
		private Vector2 size;
		private RenderContext renderContext;

		public Vector2 AbsolutePosition
		{
			get => absolutePosition;
			set
			{
				if (absolutePosition != value)
				{
					absolutePosition = value;
					OnAbsolutePositionChanged();
				}
			}
		}

		public Vector2 RelativePosition
		{
			get => relativePosition;
			set
			{
				if (relativePosition != value)
				{
					relativePosition = value;
					UpdateChildPositions();
				}
			}
		}

		public Vector2 Size
		{
			get => size;
			set
			{
				if (size != value)
				{
					size = value;
					OnSizeChanged();
				}
			}
		}

		protected virtual void OnAbsolutePositionChanged() { }
		protected virtual void OnSizeChanged() { }

		private void UpdateChildPositions()
		{
			CalculatePosition();

			foreach (UIObject child in children)
			{
				child.UpdateChildPositions();
			}
		}

		private void CalculatePosition()
		{
			AbsolutePosition = (parent?.absolutePosition ?? new Vector2(0.0f, 0.0f)) + relativePosition;
		}

		public void AddChild(UIObject child)
		{
			lock (childrenSaver)
			{
				child.parent = this;
				child.Transform.Parent = Transform;
				children.Add(child);
				child.UpdateChildPositions();
				child.InitializeGraphics(RenderContext);
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

		public Transform Transform { get; } = new Transform();
		public RenderContext RenderContext => renderContext;

		internal void InitializeGraphics(RenderContext renderContext)
		{
			this.renderContext = renderContext;
			OnInitializeGraphics(renderContext);
			foreach (var child in children)
			{
				child.InitializeGraphics(renderContext);
			}
		}
		protected virtual void OnInitializeGraphics(RenderContext renderContext) { }
	}
}