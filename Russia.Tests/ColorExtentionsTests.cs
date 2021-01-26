
using NUnit.Framework;

using SharpDX;


namespace Russia
{
	public class ColorExtentionsTests
	{
		[Test]
		[TestCase(0xff000000u, 0xff, 0, 0, 0)]
		[TestCase(0x00ff0000u, 0, 0xff, 0, 0)]
		[TestCase(0x0000ff00u, 0, 0, 0xff, 0)]
		[TestCase(0x000000ffu, 0, 0, 0, 0xff)]
		public void ToArgb(uint expected, byte a, byte r, byte g, byte b)
		{
			Color color = new Color(r, g, b, a);
			uint actual = color.ToArgb();
			Assert.AreEqual(expected, actual);
		}
	}
}
