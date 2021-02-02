using SharpDX.Direct3D9;

using System;

namespace Russia.Graphics
{
	public class Mesh<T> : IView where T : struct
	{
		private VertexBuffer vertexBuffer;
		private readonly IVertexProvider provider = VertexController.GetProvider<T>();
		private T[] vertices;

		public void UpdateBuffer(T[] vertices)
		{
			this.vertices = vertices ?? throw new ArgumentNullException(nameof(vertices));
		}

		public void Dispose()
		{
			vertexBuffer?.Dispose();
		}

		void IView.Initialize(RenderContext context)
		{
			if (vertexBuffer != null)
			{
				vertexBuffer.Dispose();
			}
			vertexBuffer = new VertexBuffer(context.Device, provider.Size * vertices.Length, Usage.WriteOnly, provider.Format, Pool.Managed);
			using (SharpDX.DataStream stream = vertexBuffer.Lock(0, 0, LockFlags.None))
			{
				stream.WriteRange(vertices);
			}
			vertexBuffer.Unlock();
		}

		void IView.Render(RenderContext context)
		{
			context.Device.VertexFormat = provider.Format;
			context.Device.SetStreamSource(0, vertexBuffer, 0, provider.Size);
			context.Device.DrawPrimitives(PrimitiveType.TriangleFan, 0, 2);
		}
	}
}
