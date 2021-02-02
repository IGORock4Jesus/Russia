namespace Russia.UI.Constraints
{
	public class RelativeConstraint : IConstraint
	{
		public RelativeConstraint(float value)
		{
			Value = value;
		}

		public float Value { get; }

		public Transform Parent { get; set; }
		public Transform Current { get; set; }

		public float Left => Parent?.Rectangle.Left ?? 0.0f + Parent?.Rectangle.Width ?? 0.0f * Value;
		public float Top => Parent?.Rectangle.Top ?? 0.0f + Parent?.Rectangle.Height ?? 0.0f * Value;
		public float Width => Parent?.Rectangle.Width??0.0f * Value;
		public float Height => Parent?.Rectangle.Height??0.0f * Value;

	}
}
