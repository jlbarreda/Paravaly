using System;
using System.Collections.Generic;
using System.Reflection;

namespace Paravaly
{
	internal static class TypeExtensions
	{
#if NETSTANDARD1_0
		public static TypeInfo GetInfo(this Type type)
		{
			return type.GetTypeInfo();
		}
#else
		public static Type GetInfo(this Type type)
		{
			return type;
		}
#endif

		public static IEnumerable<PropertyInfo> GetProps(this Type type)
		{
#if NETSTANDARD1_0
			return type.GetTypeInfo().DeclaredProperties;
#else
			return type.GetProperties();
#endif
		}
	}
}