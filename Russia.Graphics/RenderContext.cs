using SharpDX;
using SharpDX.Direct3D9;

namespace Russia.Graphics
{
	public class RenderContext
	{
		public RenderContext(Device device, Scene scene, RectangleF viewport)
		{
			Device = device ?? throw new System.ArgumentNullException(nameof(device));
			Scene = scene ?? throw new System.ArgumentNullException(nameof(scene));
			Viewport = viewport;
		}

		public Device Device { get; }
		public Scene Scene { get; }
		public RectangleF Viewport { get; }
	}
}
