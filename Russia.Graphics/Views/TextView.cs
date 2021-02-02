using SharpDX;
using SharpDX.Direct3D9;

namespace Russia.Graphics.Views
{
	public class TextView : IView
	{
		private Font font;
		private FontDescription description;

		public string Text { get; set; }
		public RectangleF Rectangle { get; set; }
		public Color Color { get; set; }

		public TextView()
		{
			description = new FontDescription
			{
				CharacterSet = FontCharacterSet.Russian,
				FaceName = "Consolas",
				Height = 20,
				Italic = false,
				MipLevels = 1,
				OutputPrecision = FontPrecision.TrueType,
				PitchAndFamily = FontPitchAndFamily.Roman,
				Quality = FontQuality.ClearType,
				Weight = FontWeight.Regular,
				Width = 10
			};
		}

		public void Dispose()
		{
			font?.Dispose();
		}

		void IView.Initialize(RenderContext context)
		{
			font = new Font(context.Device, description);
		}

		void IView.Render(RenderContext context)
		{
			font.DrawText(null, Text, Rectangle, FontDrawFlags.Left | FontDrawFlags.Top, Color);
		}
	}
}
