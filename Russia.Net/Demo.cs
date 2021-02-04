using Russia.Core;
using Russia.UI;
using Russia.UI.Constraints;

using SharpDX;

namespace Russia
{
	internal class Demo : App
	{
		protected override void OnInitialize()
		{
			Panel panel = new Panel()
			{
				Color = Color.Aqua
			};

			panel.Transformer.Left = new AbsoluteConstraint(200.0f);
			panel.Transformer.Top = new AbsoluteConstraint(100.0f);
			panel.Transformer.Width = new AbsoluteConstraint(200.0f);
			panel.Transformer.Height = new AbsoluteConstraint(100.0f);

			UI.Root.AddChild(panel);

			Label label = new Label()
			{
				Text = "Должен быть поверх панели",
				Color = Color.Red
			};

			label.Transformer.Left = new AbsoluteConstraint(20.0f);
			label.Transformer.Top = new AbsoluteConstraint(20.0f);
			label.Transformer.Width = new AbsoluteConstraint(100.0f);
			label.Transformer.Height = new AbsoluteConstraint(100.0f);

			panel.AddChild(label);


			//Panel panel2 = new Panel()
			//{
			//	RelativePosition = new Vector2(100.0f, 100.0f),
			//	Size = new Vector2(50.0f, 50.0f),
			//	Color = Color.Red
			//};
			//panel.AddChild(panel2);

		}
	}
}
