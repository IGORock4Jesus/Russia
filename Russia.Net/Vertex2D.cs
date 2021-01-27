using SharpDX;
using SharpDX.Direct3D9;

using System.Runtime.InteropServices;

namespace Russia
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct Vertex2D
	{
		public Vector4 position;
		public uint color;

		public static readonly VertexFormat format = VertexFormat.PositionRhw | VertexFormat.Diffuse;
		public static readonly int size = Marshal.SizeOf<Vertex2D>();
	}
}
