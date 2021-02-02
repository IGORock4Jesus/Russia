using SharpDX;
using SharpDX.Direct3D9;

using System;
using System.Collections.Generic;


namespace Russia.Graphics
{
	internal class Renderer : IDisposable
	{
		private Device device;
		private Direct3D direct;
		private readonly List<IDisposable> disposables = new List<IDisposable>();

		public Device Device => device;


		internal void Initialize(IntPtr handle, int width, int height)
		{
			direct = new Direct3D();
			device = new Device(direct, 0, DeviceType.Hardware, handle, CreateFlags.HardwareVertexProcessing | CreateFlags.Multithreaded, new PresentParameters
			{
				AutoDepthStencilFormat = Format.D24S8,
				BackBufferCount = 1,
				BackBufferFormat = Format.A8R8G8B8,
				BackBufferHeight = height,
				BackBufferWidth = width,
				DeviceWindowHandle = handle,
				EnableAutoDepthStencil = true,
				SwapEffect = SwapEffect.Discard,
				Windowed = true
			});

			device.SetRenderState(RenderState.Lighting, false);
		}

		internal void BeginFrame()
		{
			device.Clear(ClearFlags.All, Color.DarkGray, 1.0f, 0);
			device.BeginScene();
		}

		internal void EndFrame()
		{
			device.EndScene();
			device.Present();
		}

		public void Dispose()
		{
			foreach (IDisposable disposable in disposables)
			{
				disposable.Dispose();
			}
		}
	}
}
