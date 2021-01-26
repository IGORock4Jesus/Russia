using SharpDX;

namespace Russia
{
	public static class ColorExtentions
	{
		public static uint ToArgb(this Color color)
		{
			return ((uint)color.A << 24)
				+ ((uint)color.R << 16)
				+ ((uint)color.G << 8)
				+ color.B;
		}
	}
}
