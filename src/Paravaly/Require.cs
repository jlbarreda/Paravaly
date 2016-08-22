﻿using System.Diagnostics;
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

		/// <inheritdoc />
		[DebuggerStepThrough]
		IParameter<T> IRequire.Parameter<T>(string name, [NoEnumeration]T value)
		{
			return new Parameter<T>(name, value, ExceptionHandlingMode.ThrowFirst);
		}

		/// <inheritdoc />
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
	}
}