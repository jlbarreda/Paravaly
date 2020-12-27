using System;
using System.Collections.Generic;
using System.Reflection;

namespace Paravaly
{
	internal static class TypeExtensions
	{
		public static IEnumerable<PropertyInfo> GetProps(this Type type)
		{
#if NETSTANDARD1_0 || NETSTANDARD1_3
			return type.GetTypeInfo().DeclaredProperties;
#else
			return type.GetProperties();
#endif
		}

#if !HAS_GET_TYPE_INFO

		public static Type GetTypeInfo(this Type type)
		{
			return type;
		}

#endif

		public static bool IsNullableType(this Type type)
		{
			return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
	}
}
