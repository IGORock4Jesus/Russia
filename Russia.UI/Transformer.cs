using Russia.UI.Constraints;

using SharpDX;

using System;

namespace Russia.UI
{
	/// <summary>
	/// Позволяет гибко управлять положением и размерами.
	/// </summary>
	public class Transformer
	{
		private IConstraint left;
		private IConstraint top;
		private IConstraint width;
		private IConstraint height;

		public RectangleF Rectangle { get; private set; }
		public Transform Current { get; internal set; }
		public Transform Parent { get; internal set; }

		public IConstraint Left
		{
			get => left;
			set => SetRelation(value, ref left);
		}

		public IConstraint Top
		{
			get => top;
			set => SetRelation(value, ref top);
		}

		public IConstraint Width
		{
			get => width;
			set => SetRelation(value, ref width);
		}

		public IConstraint Height
		{
			get => height;
			set => SetRelation(value, ref height);
		}

		private void SetRelation(IConstraint value, ref IConstraint field)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value), $"{nameof(IConstraint)} cannot be null.");
			}
			if (field != value)
			{
				field = value;
				value.Current = Current;
				value.Parent = Parent;
				UpdateRectangle();
			}
		}

		private void UpdateRectangle()
		{
			if (left == null || top == null || width == null || height == null)
			{
				return;
			}

			Rectangle = new RectangleF(left.Left, top.Top, width.Width, height.Height);
		}

	}
}
