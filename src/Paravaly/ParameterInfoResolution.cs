using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Paravaly
{
	internal static class ParameterInfoResolution
	{
		public static string NameFromExpression<T>(Expression<Func<T>> parameterExpression)
		{
			return ((MemberExpression)parameterExpression.Body).Member.Name;
		}

		public static T ValueFromExpression<T>(Expression<Func<T>> parameterExpression)
		{
			var memberExpression = (MemberExpression)parameterExpression.Body;
			var constantExpression = (ConstantExpression)memberExpression.Expression;

			return (T)((FieldInfo)memberExpression.Member).GetValue(constantExpression.Value);
		}

#pragma warning disable RECS0154 // Parameter is never used
		public static string NameFromProperty<T>(T anonymousObject)
#pragma warning restore RECS0154 // Parameter is never used
		{
			return FirstPropertyCache<T>.Name;
		}

#pragma warning disable RECS0154 // Parameter is never used
		public static T ValueFromProperty<T, TAnonymous>(T typeInferenceHelper, TAnonymous anonymousObject)
#pragma warning restore RECS0154 // Parameter is never used
		{
			return (T)FirstPropertyCache<TAnonymous>.Property.GetValue(anonymousObject, null);
		}

		private static class FirstPropertyCache<T>
		{
#pragma warning disable RECS0108 // Warns about static fields in generic types
#if NETSTANDARD1_0
			public static readonly PropertyInfo Property = typeof(T).GetTypeInfo().DeclaredProperties.First();
#else
			public static readonly PropertyInfo Property = typeof(T).GetProperties().First();
#endif
			public static readonly string Name = Property.Name;
#pragma warning restore RECS0108 // Warns about static fields in generic types
		}
	}
}