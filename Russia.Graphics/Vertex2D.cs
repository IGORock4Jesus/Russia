using SharpDX;
using SharpDX.Direct3D9;

using System;
using System.Runtime.InteropServices;

namespace Russia.Graphics
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex2D
	{
		public Vector4 position;
		public uint color;
	}

	internal class Vertex2DProvider : IVertexProvider
	{
		public int Size => Marshal.SizeOf<Vertex2D>();
		public VertexFormat Format => VertexFormat.PositionRhw | VertexFormat.Diffuse;

		public Type VertexType => typeof(Vertex2D);
	}
}
