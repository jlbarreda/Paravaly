using System;
using System.Collections.Generic;
using System.Reflection;

namespace Paravaly
{
	internal static class TypeExtensions
	{
		public static IEnumerable<PropertyInfo> GetProps(this Type type)
		{
#if NETSTANDARD1_0
			return type.GetTypeInfo().DeclaredProperties;
#else
			return type.GetProperties();
#endif
		}

#if !NETSTANDARD1_0
		public static Type GetTypeInfo(this Type type)
		{
			return type;
		}
#endif
	}
}