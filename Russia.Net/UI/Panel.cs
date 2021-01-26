using SharpDX;

namespace Russia.UI
{
	internal class Panel : UIObject
	{
		public RectangleF Rectangle { get; internal set; }
		public Color Color { get; set; }

		protected override void OnRender(RenderContext renderContext)
		{
			var scolor = Color.ToArgb();

			renderContext.Device.VertexFormat = Vertex.format;
			renderContext.Device.DrawUserPrimitives(SharpDX.Direct3D9.PrimitiveType.TriangleFan, 2, new Vertex[]
			{
				new Vertex{ position = new Vector4(Rectangle.TopLeft,0.0f, 0.0f), color=scolor},
				new Vertex{ position = new Vector4(Rectangle.TopRight,0.0f, 0.0f), color=scolor},
				new Vertex{ position = new Vector4(Rectangle.BottomRight,0.0f, 0.0f), color=scolor},
				new Vertex{ position = new Vector4(Rectangle.BottomLeft,0.0f, 0.0f), color=scolor},
			});
		}
	}
}
