using SharpDX.Direct3D9;

using System;

namespace Russia
{
	internal interface IVertexProvider
	{
		Type VertexType { get; }
		int Size { get; }
		VertexFormat Format { get; }
	}
}
