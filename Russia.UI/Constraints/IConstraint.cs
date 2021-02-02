namespace Russia.UI.Constraints
{
	public interface IConstraint
	{
		Transform Parent { get;  set; }
		Transform Current { get; set; }

		float Left { get; }
		float Top { get; }
		float Width { get; }
		float Height { get; }
	}
}
