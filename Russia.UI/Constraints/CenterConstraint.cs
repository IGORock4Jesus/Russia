namespace Russia.UI.Constraints
{
	public class CenterConstraint : IConstraint
	{
		public Transform Parent { get; set; }
		public Transform Current { get; set; }

		public float Left => Parent.Rectangle.Left + Parent.Rectangle.Width / 2.0f - Current.Rectangle.Width / 2.0f;
		public float Top => Parent.Rectangle.Top + Parent.Rectangle.Height / 2.0f - Current.Rectangle.Height / 2.0f;
		public float Width => Current.Rectangle.Width;
		public float Height => Current.Rectangle.Height;
	}
}
