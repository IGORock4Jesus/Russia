using NUnit.Framework;

using SharpDX;

namespace Russia.UI
{
	internal class TransformTests
	{
		[Test]
		public void Construction()
		{
			Transform actual = new Transform();
			Assert.IsNotNull(actual);
			Assert.IsNull(actual.Left);
			Assert.IsNull(actual.Top);
			Assert.IsNull(actual.Width);
			Assert.IsNull(actual.Height);
		}

		[Test]
		public void WithAbsoluteConstraints()
		{
			Transform actual = new Transform
			{
				Left = new AbsoluteConstraint(50.0f),
				Top = new AbsoluteConstraint(100.0f),
				Width = new AbsoluteConstraint(150.0f),
				Height = new AbsoluteConstraint(200.0f)
			};

			RectangleF expected = new RectangleF(50.0f, 100.0f, 150.0f, 200.0f);

			Assert.AreEqual(expected, actual.Rectangle);
		}

	}
}
