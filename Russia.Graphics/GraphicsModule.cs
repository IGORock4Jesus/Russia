using Russia.Common;

using System;

namespace Russia.Graphics
{
	public class GraphicsModule : IDisposable
	{
		private readonly IntPtr handle;
		private readonly int width;
		private readonly int height;
		private Renderer renderer;
		private readonly Job job;
		private readonly Scene scene;
		RenderContext context;

		public RenderContext Context => context;


		public GraphicsModule(IntPtr handle, int width, int height)
		{
			this.handle = handle;
			this.width = width;
			this.height = height;

			job = new Job();
			job.Processing += Job_Processing;

			renderer = new Renderer();
			scene = new Scene();
		}

		private void Job_Processing(int elapsedTime)
		{
			renderer.BeginFrame();

			scene.Render(context);

			renderer.EndFrame();
		}

		public void Dispose()
		{
			job.Stop();

			scene.Dispose();
			renderer?.Dispose();
		}

		public void Initialize()
		{
			renderer.Initialize(handle, width, height);
			context = new RenderContext(renderer.Device, scene);

			job.Start();
		}
	}
}
