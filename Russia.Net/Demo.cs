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
				RelativePosition = new Vector2(100.0f, 100.0f),
				Size = new Vector2(200.0f, 200.0f),
				Color = Color.Aqua
			};

			panel.Transform.Left = new AbsoluteConstraint(200.0f);
			panel.Transform.Top = new AbsoluteConstraint(100.0f);

			UI.Root.AddChild(panel);

			Label label = new Label()
			{
				RelativePosition = new Vector2(20.0f, 20.0f),
				Size = new Vector2(100.0f, 100.0f),
				Text = "Должен быть поверх панели",
				Color = Color.Red
			};
			panel.AddChild(label);


			Panel panel2 = new Panel()
			{
				RelativePosition = new Vector2(100.0f, 100.0f),
				Size = new Vector2(50.0f, 50.0f),
				Color = Color.Red
			};
			panel.AddChild(panel2);

		}
	}
}
