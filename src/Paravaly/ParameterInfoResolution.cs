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

		public static string NameFromProperty<T>(T anonymousObject)
		{
			return FirstPropertyCache<T>.Name;
		}

		public static T ValueFromProperty<T, TAnonymous>(T typeInferenceHelper, TAnonymous anonymousObject)
		{
			return (T)FirstPropertyCache<TAnonymous>.Property.GetValue(anonymousObject, null);
		}

		private static class FirstPropertyCache<T>
		{
			public static readonly PropertyInfo Property = typeof(T).GetProps().First();
			public static readonly string Name = Property.Name;
		}
	}
}