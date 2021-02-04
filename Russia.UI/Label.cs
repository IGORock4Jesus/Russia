using Russia.Graphics;
using Russia.Graphics.Views;

using SharpDX;

namespace Russia.UI
{
	public class Label : UIObject
	{
		private readonly TextView view;
		private RectangleF rectangle;

		public string Text
		{
			get => view.Text;
			set => view.Text = value;
		}

		public Color Color
		{
			get => view.Color;
			set => view.Color = value;
		}

		public Label()
		{
			view = new TextView();
		}

		protected override void OnAbsolutePositionChanged()
		{
			rectangle = new RectangleF(Position.X, Position.Y, Size.X, Size.Y);
			view.Rectangle = rectangle;
		}

		protected override void OnSizeChanged()
		{
			rectangle = new RectangleF(Position.X, Position.Y, Size.X, Size.Y);
			view.Rectangle = rectangle;
		}

		protected override void OnInitializeGraphics(RenderContext renderContext)
		{
			renderContext.Scene.Add(view);
		}
	}
}
