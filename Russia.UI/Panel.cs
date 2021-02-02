using Russia.Graphics;

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
		private RectangleF rectangle;
		private Color color;

		public Panel()
		{
			mesh = new Mesh<Vertex2D>();
		}

		protected override void OnAbsolutePositionChanged()
		{
			rectangle = new RectangleF(AbsolutePosition.X, AbsolutePosition.Y, Size.X, Size.Y);
			UpdateMesh();
		}
		protected override void OnSizeChanged()
		{
			rectangle = new RectangleF(AbsolutePosition.X, AbsolutePosition.Y, Size.X, Size.Y);
			UpdateMesh();
		}

		private void UpdateMesh()
		{
			uint scolor = Color.ToArgb();
			Vertex2D[] vertices = new Vertex2D[]
			{
				new Vertex2D{ position = new Vector4(rectangle.Left, rectangle.Top, 0.0f, 1.0f), color=scolor},
				new Vertex2D{ position = new Vector4(rectangle.Right, rectangle.Top, 0.0f, 1.0f), color=scolor},
				new Vertex2D{ position = new Vector4(rectangle.Right, rectangle.Bottom, 0.0f, 1.0f), color=scolor},
				new Vertex2D{ position = new Vector4(rectangle.Left, rectangle.Bottom, 0.0f, 1.0f), color=scolor},
			};
			mesh.UpdateBuffer(vertices);
		}

		protected override void OnInitializeGraphics(RenderContext renderContext)
		{
			renderContext.Scene.Add(mesh);
		}
	}
}
