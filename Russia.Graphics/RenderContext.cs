using SharpDX.Direct3D9;

namespace Russia.Graphics
{
	public class RenderContext
	{
		public RenderContext(Device device, Scene scene)
		{
			Device = device ?? throw new System.ArgumentNullException(nameof(device));
			Scene = scene ?? throw new System.ArgumentNullException(nameof(scene));
		}

		public Device Device { get; }
		public Scene Scene { get; }
	}
}
