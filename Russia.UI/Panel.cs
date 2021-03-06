﻿using Russia.Graphics;

using SharpDX;

namespace Russia.UI
{
	public class Panel : UIObject
	{
		public Color Color
		{
			get => color;
			set
			{
				color = value;
				UpdateMesh();
			}
		}

		private readonly Mesh<Vertex2D> mesh;
		private Color color;

		public Panel()
		{
			mesh = new Mesh<Vertex2D>();
		}

		protected override void OnAbsolutePositionChanged()
		{
			//rectangle = new RectangleF(Position.X, Position.Y, Size.X, Size.Y);
			//UpdateMesh();
		}
		protected override void OnSizeChanged()
		{
			//rectangle = new RectangleF(Position.X, Position.Y, Size.X, Size.Y);
			//UpdateMesh();
		}

		private void UpdateMesh()
		{
			uint scolor = Color.ToArgb();
			Vertex2D[] vertices = new Vertex2D[]
			{
				new Vertex2D{ position = new Vector4(Position.X, Position.Y, 0.0f, 1.0f), color=scolor},
				new Vertex2D{ position = new Vector4(Position.X+Size.X, Position.Y, 0.0f, 1.0f), color=scolor},
				new Vertex2D{ position = new Vector4(Position.X+Size.X, Position.Y+Size.Y, 0.0f, 1.0f), color=scolor},
				new Vertex2D{ position = new Vector4(Position.X, Position.Y+Size.Y, 0.0f, 1.0f), color=scolor},
			};
			mesh.UpdateBuffer(vertices);
		}

		protected override void OnInitializeGraphics(RenderContext renderContext)
		{
			UpdateMesh();
			renderContext.Scene.Add(mesh);
		}
	}
}
