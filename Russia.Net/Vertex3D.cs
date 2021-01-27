using SharpDX;
using SharpDX.Direct3D9;

using System.Runtime.InteropServices;

namespace Russia
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct Vertex3D
	{
		public Vector3 position;
		public uint color;

		public static readonly VertexFormat format = VertexFormat.Position | VertexFormat.Diffuse;
		public static readonly int size = Marshal.SizeOf<Vertex3D>();
	}
}
