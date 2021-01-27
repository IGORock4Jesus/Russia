using SharpDX.Direct3D9;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Russia
{
	class Mesh<T> : IDisposable where T : struct
	{
		VertexBuffer vertexBuffer;
		IVertexProvider provider = VertexController.GetProvider<T>();

		public void UpdateBuffer(T[] vertices)
		{
			if (vertexBuffer != null)
			{
				vertexBuffer.Dispose();
			}
			vertexBuffer = new VertexBuffer(Renderer.Device, provider.Size * vertices.Length, Usage.WriteOnly, provider.Format, Pool.Managed);
			using (var stream = vertexBuffer.Lock(0, 0, LockFlags.None))
			{
				stream.WriteRange(vertices);
			}
			vertexBuffer.Unlock();
		}

		public void Dispose()
		{


			vertexBuffer?.Dispose();
		}

		internal void Render(RenderContext renderContext)
		{
			renderContext.Device.VertexFormat = provider.Format;
			renderContext.Device.SetStreamSource(0, vertexBuffer, 0, provider.Size);
			renderContext.Device.DrawPrimitives(PrimitiveType.TriangleFan, 0, 2);
		}
	}
}
