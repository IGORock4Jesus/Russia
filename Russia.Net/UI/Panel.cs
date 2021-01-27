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

		Mesh mesh;
		private RectangleF rectangle;
		private Color color;

		public Panel()
		{
			mesh = new Mesh();
		}

		private void UpdateMesh()
		{
			var scolor = Color.ToArgb();
			var vertices = new Vertex3D[]
			{
				new Vertex3D{ position = new Vector3(Rectangle.Left, -Rectangle.Top, 0.0f), color=scolor},
				new Vertex3D{ position = new Vector3(Rectangle.Right, -Rectangle.Top, 0.0f), color=scolor},
				new Vertex3D{ position = new Vector3(Rectangle.Right, -Rectangle.Bottom, 0.0f), color=scolor},
				new Vertex3D{ position = new Vector3(Rectangle.Left, -Rectangle.Bottom, 0.0f), color=scolor},
			};
			mesh.UpdateBuffer(vertices);
		}

		protected override void OnRender(RenderContext renderContext)
		{
			mesh.Render(renderContext);
		}
	}
}
