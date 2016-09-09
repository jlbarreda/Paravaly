using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Paravaly
{
	/// <summary>
	/// Provides methods to start parameter validation.
	/// </summary>
	public sealed class Require : IRequire
	{
		private static readonly IRequire require = new Require();

		/// <summary>
		/// Starts parameter validation. An exception is thrown as soon as any validation fails.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="name">The parameter name.</param>
		/// <param name="value">The parameter value.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		public static IParameter<T> Parameter<T>(string name, [NoEnumeration]T value)
		{
			return require.Parameter(name, value);
		}

		/// <summary>
		/// Starts parameter validation. An exception is thrown as soon as any validation fails.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <typeparam name="TParameterAsProperty">
		/// The type of <paramref name="parameterAsProperty"/>.
		/// </typeparam>
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
			TParameterAsProperty parameterAsProperty,
			[NoEnumeration]T value)
		{
			return require.Parameter(parameterAsProperty, value);
		}

		/// <summary>
		/// Starts validation for a generic type parameter named 'T'. An exception is thrown as
		/// soon as any validation fails.
		/// </summary>
		/// <typeparam name="T">The generic type parameter to validate.</typeparam>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		public static IParameter<Type> TypeParameter<T>()
		{
			return require.TypeParameter<T>();
		}

		/// <summary>
		/// Starts validation for a generic type parameter. An exception is thrown as soon as any
		/// validation fails.
		/// </summary>
		/// <typeparam name="T">The generic type parameter to validate.</typeparam>
		/// <param name="name">The generic type parameter name.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		public static IParameter<Type> TypeParameter<T>(string name)
		{
			return require.TypeParameter<T>(name);
		}

		/// <summary>
		/// Starts parameter validation. An exception is thrown as soon as any validation fails.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="name">The parameter name.</param>
		/// <param name="value">The parameter value.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		IParameter<T> IRequire.Parameter<T>(string name, [NoEnumeration]T value)
		{
			return new Parameter<T>(name, value, ExceptionHandlingMode.ThrowFirst);
		}

		/// <summary>
		/// Starts parameter validation. An exception is thrown as soon as any validation fails.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <typeparam name="TParameterAsProperty">
		/// The type of <paramref name="parameterAsProperty"/>.
		/// </typeparam>
		/// <param name="parameterAsProperty">
		/// An anonymous object with the parameter as a property (e.g. new { parameter }).
		/// </param>
		/// <param name="value">The parameter value.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}" /> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		IParameter<T> IRequire.Parameter<T, TParameterAsProperty>(
			TParameterAsProperty parameterAsProperty,
			[NoEnumeration]T value)
		{
			return new Parameter<T>(
				ParameterInfoResolution.NameFromProperty(parameterAsProperty),
				value,
				ExceptionHandlingMode.ThrowFirst);
		}

		/// <summary>
		/// Starts validation for a generic type parameter named 'T'. An exception is thrown as
		/// soon as any validation fails.
		/// </summary>
		/// <typeparam name="T">The generic type parameter to validate.</typeparam>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		IParameter<Type> IRequire.TypeParameter<T>()
		{
			return new Parameter<Type>(Invariants.DefaultTypeParameterName, typeof(T), ExceptionHandlingMode.ThrowFirst);
		}

		/// <summary>
		/// Starts validation for a generic type parameter. An exception is thrown as soon as any
		/// validation fails.
		/// </summary>
		/// <typeparam name="T">The generic type parameter to validate.</typeparam>
		/// <param name="name">The generic type parameter name.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		[DebuggerStepThrough]
		IParameter<Type> IRequire.TypeParameter<T>(string name)
		{
			return new Parameter<Type>(name, typeof(T), ExceptionHandlingMode.ThrowFirst);
		}
	}
}