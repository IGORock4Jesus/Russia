﻿using Russia.Graphics;
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

		public Vector2 Position
		{
			get => Transformer.Rectangle.TopLeft;
		}

		public Vector2 Size
		{
			get => new Vector2(Transformer.Rectangle.Width, Transformer.Rectangle.Height);
		}

		protected virtual void OnAbsolutePositionChanged() { }
		protected virtual void OnSizeChanged() { }

		public void AddChild(UIObject child)
		{
			lock (childrenSaver)
			{
				child.parent = this;
				child.Transformer.Parent = Transformer.Current;
				child.Transformer.Current = new Transform();
				children.Add(child);
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

		public Transformer Transformer { get; } = new Transformer();
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