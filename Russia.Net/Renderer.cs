using SharpDX;
using SharpDX.Direct3D9;

using System;
using System.Collections.Generic;
using System.Threading;


namespace Russia
{
	public static class Renderer
	{
		private static Device device;
		private static Thread thread;
		private static bool enabled;
		private static RenderContext renderContext;
		private static Direct3D direct;
		private static readonly List<IDisposable> disposables = new List<IDisposable>();
		public delegate void RenderHandler(RenderContext renderContext);
		public static event RenderHandler Rendering;


		internal static void Initialize(Form1 form1)
		{
			InitializeSceneRenderer(form1);

			renderContext = new RenderContext(device);

			thread = new Thread(StartRendering);
			enabled = true;
			thread.Start();
		}

		private static void InitializeSceneRenderer(Form1 form1)
		{
			direct = new Direct3D();
			device = new Device(direct, 0, DeviceType.Hardware, form1.Handle, CreateFlags.HardwareVertexProcessing | CreateFlags.Multithreaded, new PresentParameters
			{
				AutoDepthStencilFormat = Format.D24S8,
				BackBufferCount = 1,
				BackBufferFormat = Format.A8R8G8B8,
				BackBufferHeight = form1.ClientSize.Height,
				BackBufferWidth = form1.ClientSize.Width,
				DeviceWindowHandle = form1.Handle,
				EnableAutoDepthStencil = true,
				SwapEffect = SwapEffect.Discard,
				Windowed = true
			});

			device.SetRenderState(RenderState.Lighting, false);
		}

		private static void StartRendering()
		{
			while (enabled)
			{
				device.Clear(ClearFlags.All, Color.DarkGray, 1.0f, 0);
				device.BeginScene();

				Rendering?.Invoke(renderContext);

				device.EndScene();
				device.Present();

				Thread.Sleep(0);
			}
		}

		internal static void Release()
		{
			if (enabled)
			{
				enabled = false;
				if (thread.IsAlive)
				{
					thread.Join();
				}
			}

			foreach (IDisposable disposable in disposables)
			{
				disposable.Dispose();
			}
		}
	}
}
