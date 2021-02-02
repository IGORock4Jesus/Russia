namespace Russia.UI.Constraints
{
	public class AbsoluteConstraint : IConstraint
	{
		public AbsoluteConstraint(float value)
		{
			Value = value;
		}

		public float Value { get; }

		public Transform Parent { get; set; }
		public Transform Current { get; set; }

		public float Left => Parent?.Rectangle.Left ?? 0.0f + Value;
		public float Top => Parent?.Rectangle.Top ?? 0.0f + Value;
		public float Width => Value;
		public float Height => Value;
	}
}
