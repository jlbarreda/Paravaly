using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Paravaly
{
	/// <summary>
	/// Provides extension methods for objects implementing the <see cref="IRequire"/>
	/// interface.
	/// </summary>
	public static class RequireExtensions
	{
		/// <summary>
		/// Starts parameter validation.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <typeparam name="TParameterAsProperty">
		/// The type of <paramref name="parameterAsProperty" />.
		/// </typeparam>
		/// <param name="require">
		/// The <see cref="IRequire"/> instance used by this extension.
		/// </param>
		/// <param name="parameterAsProperty">
		/// An anonymous object with the parameter as a property (e.g. new { parameter }).
		/// </param>
		/// <param name="value">The parameter value.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}" /> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		public static IParameter<T> Parameter<T, TParameterAsProperty>(
			this IRequire require,
			TParameterAsProperty parameterAsProperty,
			[NoEnumeration]T value)
		{
			return require.Parameter(
				ParameterInfoResolution.NameFromProperty(parameterAsProperty),
				value);
		}

		/// <summary>
		/// Starts validation for a generic type parameter named 'T'.
		/// </summary>
		/// <typeparam name="T">The generic type parameter to validate.</typeparam>
		/// <param name="require">
		/// The <see cref="IRequire"/> instance used by this extension.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		public static IParameter<Type> TypeParameter<T>(this IRequire require)
		{
			return require.Parameter(Invariants.DefaultTypeParameterName, typeof(T));
		}

		/// <summary>
		/// Starts validation for a generic type parameter.
		/// </summary>
		/// <typeparam name="T">The generic type parameter to validate.</typeparam>
		/// <param name="require">
		/// The <see cref="IRequire"/> instance used by this extension.
		/// </param>
		/// <param name="name">The generic type parameter name.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		public static IParameter<Type> TypeParameter<T>(this IRequire require, string name)
		{
			return require.Parameter(name, typeof(T));
		}
	}
}