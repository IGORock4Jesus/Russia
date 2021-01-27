using SharpDX;
using SharpDX.Direct3D9;

using System;
using System.Runtime.InteropServices;

namespace Russia
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct Vertex3D
	{
		public Vector3 position;
		public uint color;
	}


	class Vertex3DProvider : IVertexProvider
	{
		public int Size => Marshal.SizeOf<Vertex3D>();
		public VertexFormat Format => VertexFormat.Position | VertexFormat.Diffuse;
		public Type VertexType => typeof(Vertex3D);
	}
}
