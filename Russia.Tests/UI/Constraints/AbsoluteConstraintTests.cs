using NUnit.Framework;

using SharpDX;

namespace Russia.UI.Constraints
{
	internal class AbsoluteConstraintTests
	{
		[Test]
		public void Construction()
		{
			float expectedValue = 13.6f;
			AbsoluteConstraint relation = new AbsoluteConstraint(expectedValue);
			Assert.IsNotNull(relation);
			Assert.AreEqual(expectedValue, relation.Value);
		}

		[Test]
		public void ParentRectangleTests()
		{
			AbsoluteConstraint constraint = new AbsoluteConstraint(10.0f);
			RectangleF expected = new RectangleF(100.0f, 100.0f, 100.0f, 100.0f);
			//constraint.ParentRectangle = expected;
			//Assert.AreEqual(expected, constraint.ParentRectangle);
		}

		[Test]
		public void LeftTest()
		{
			float expectedValue = 13.6f;
			AbsoluteConstraint actual = new AbsoluteConstraint(expectedValue);
			RectangleF parentRectangle = new RectangleF(100.0f, 100.0f, 100.0f, 100.0f);
			//actual.ParentRectangle = parentRectangle;
			//Assert.AreEqual(expectedValue + 100.0f, actual.Left());
		}

		[Test]
		public void TopTest()
		{
			float expectedValue = 13.6f;
			AbsoluteConstraint actual = new AbsoluteConstraint(expectedValue);
			RectangleF parentRectangle = new RectangleF(100.0f, 100.0f, 100.0f, 100.0f);
			//actual.ParentRectangle = parentRectangle;
			//Assert.AreEqual(expectedValue, actual.Top());
		}

		[Test]
		public void WidthTest()
		{
			float expectedValue = 13.6f;
			//AbsoluteConstraint actual = new AbsoluteConstraint(expectedValue);
			//Assert.AreEqual(expectedValue, actual.Width());
		}

		[Test]
		public void HeightTest()
		{
			float expectedValue = 13.6f;
			AbsoluteConstraint actual = new AbsoluteConstraint(expectedValue);
			//Assert.AreEqual(expectedValue, actual.Height());
		}
	}
}
