using SharpDX;

namespace Russia.UI
{
	internal class Panel : UIObject
	{
		public RectangleF Rectangle
		{
			get => rectangle;
			internal set
			{
				rectangle = value;
				UpdateMesh();
			}
		}
		public Color Color
		{
			get => color;
			set
			{
				color = value;
				UpdateMesh();
			}
		}

		Mesh<Vertex2D> mesh;
		private RectangleF rectangle;
		private Color color;

		public Panel()
		{
			mesh = new Mesh<Vertex2D>();
		}

		private void UpdateMesh()
		{
			var scolor = Color.ToArgb();
			var vertices = new Vertex2D[]
			{
				new Vertex2D{ position = new Vector4(Rectangle.Left, Rectangle.Top, 0.0f, 1.0f), color=scolor},
				new Vertex2D{ position = new Vector4(Rectangle.Right, Rectangle.Top, 0.0f, 1.0f), color=scolor},
				new Vertex2D{ position = new Vector4(Rectangle.Right, Rectangle.Bottom, 0.0f, 1.0f), color=scolor},
				new Vertex2D{ position = new Vector4(Rectangle.Left, Rectangle.Bottom, 0.0f, 1.0f), color=scolor},
			};
			mesh.UpdateBuffer(vertices);
		}

		protected override void OnRender(RenderContext renderContext)
		{
			mesh.Render(renderContext);
		}
	}
}
