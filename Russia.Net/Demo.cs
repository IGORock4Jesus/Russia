using Russia.UI;

using SharpDX;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Russia
{
	static class Demo
	{
		public static void Initialize()
		{
			Panel panel = new Panel()
			{
				Rectangle = new RectangleF(-0.5f, -0.5f, 1.0f, 1.0f),
				Color = Color.Aqua
			};
			UIManager.Root.AddChild(panel);
		}
	}
}
