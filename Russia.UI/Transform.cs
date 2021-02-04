using SharpDX;

namespace Russia.UI
{
	public class Transform
	{
		public Transform()
		{

		}

		public Transform(RectangleF rectangle)
		{
			Rectangle = rectangle;
		}

		public RectangleF Rectangle { get; set; }
	}
}
