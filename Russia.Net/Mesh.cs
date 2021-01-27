using SharpDX.Direct3D9;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Russia
{
	class Mesh : IDisposable
	{
		VertexBuffer vertexBuffer;

		public void UpdateBuffer(Vertex3D[] vertices)
		{
			if (vertexBuffer != null)
			{
				vertexBuffer.Dispose();
			}
			vertexBuffer = new VertexBuffer(Renderer.Device, Vertex3D.size * vertices.Length, Usage.WriteOnly, Vertex3D.format, Pool.Managed);
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
			renderContext.Device.VertexFormat = Vertex3D.format;
			renderContext.Device.SetStreamSource(0, vertexBuffer, 0, Vertex3D.size);
			renderContext.Device.DrawPrimitives(PrimitiveType.TriangleFan, 0, 2);
		}
	}
}
