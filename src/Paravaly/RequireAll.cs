﻿using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Paravaly
{
	/// <summary>
	/// Provides methods to start parameter validation. When started with this class, all
	/// validations are executed and if one or more fail, a <see cref="ParameterValidationException"/>
	/// containing all relevant exceptions is thrown.
	/// </summary>
	public sealed class RequireAll : IRequire
	{
		private static readonly IRequire require = new RequireAll();

		/// <summary>
		/// Starts parameter validation. All validations are executed and if one or more fail,
		/// a <see cref="ParameterValidationException"/> containing all relevant exceptions is
		/// thrown.
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
		/// Starts parameter validation. All validations are executed and if one or more fail,
		/// a <see cref="ParameterValidationException"/> containing all relevant exceptions is
		/// thrown.
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
			T value)
		{
			return require.Parameter(parameterAsProperty, value);
		}

		/// <summary>
		/// Starts validation for a generic type parameter named 'T'. All validations are executed
		/// and if one or more fail, a <see cref="ParameterValidationException"/> containing all
		/// relevant exceptions is thrown.
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
		/// Starts validation for a generic type parameter. All validations are executed and if one
		/// or more fail, a <see cref="ParameterValidationException"/> containing all relevant
		/// exceptions is thrown.
		/// </summary>
		/// <typeparam name="T">The generic type parameter to validate.</typeparam>
		/// <param name="name">The parameter name.</param>
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
		/// Starts parameter validation. All validations are executed and if one or more fail,
		/// a <see cref="ParameterValidationException"/> containing all relevant exceptions is
		/// thrown.
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
			return new Parameter<T>(name, value, ExceptionHandlingMode.ThrowAll);
		}
	}
}