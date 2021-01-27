using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Russia
{
	internal static class VertexController
	{
		private static readonly IEnumerable<IVertexProvider> providers;

		static VertexController()
		{
			providers = Assembly.GetExecutingAssembly().GetTypes()
				.Where(w => w.GetInterface(nameof(IVertexProvider)) != null)
				.Select(w => Activator.CreateInstance(w) as IVertexProvider);
		}

		public static IVertexProvider GetProvider(Type vertexType)
		{
			return providers.First(w => w.VertexType == vertexType);
		}

		public static IVertexProvider GetProvider<T>() where T : struct
		{
			return GetProvider(typeof(T));
		}
	}
}
