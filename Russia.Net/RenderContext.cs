using SharpDX.Direct3D9;

namespace Russia
{
	public class RenderContext
	{
		public RenderContext(Device device)
		{
			Device = device;
		}

		public Device Device { get; }
	}
}
