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
				Rectangle = new RectangleF(20.0f, 20.0f, 200.0f, 200.0f),
				Color = Color.Aqua
			};
			UIManager.Root.AddChild(panel);
		}
	}
}
