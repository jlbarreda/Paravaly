using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Paravaly
{
	/// <summary>
	/// Represents a parameter that has at least one validation applied to it.
	/// </summary>
	/// <typeparam name="T">The parameter type.</typeparam>
	public interface IValidatingParameter<out T> : IParameter<T>
	{
		/// <summary>
		/// Adds another parameter to the current validation.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="parameterName">The parameter name.</param>
		/// <param name="parameterValue">The parameter value.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		IParameter<TParameter> AndParameter<TParameter>(string parameterName, [NoEnumeration]TParameter parameterValue);

		/// <summary>
		/// Adds a generic type parameter named 'T' to the current validation.
		/// </summary>
		/// <typeparam name="TParameter">The generic type parameter to validate.</typeparam>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		IParameter<Type> AndTypeParameter<TParameter>();

		/// <summary>
		/// Adds a generic type parameter to the current validation.
		/// </summary>
		/// <typeparam name="TParameter">The generic type parameter to validate.</typeparam>
		/// <param name="parameterName">The generic type parameter name.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		IParameter<Type> AndTypeParameter<TParameter>(string parameterName);

		/// <summary>
		/// If any validation failed, returns a <see cref="ParameterValidationException" />
		/// containing all related exceptions; otherwise null;
		/// </summary>
		/// <returns>
		/// A <see cref="ParameterValidationException" /> containing all validation exceptions;
		/// otherwise null;
		/// </returns>
		/// <remarks>
		/// This method will never be executed when exceptions are thrown as soon as validations
		/// fail (e.g. when using <see cref="Require" />), making it useless in those cases. It
		/// works fine with <see cref="RequireAll" />. When using <see cref="RequireNothing"/> null
		/// is always returned.
		/// </remarks>
		ParameterValidationException ThenGetException();

		/// <summary>
		/// Gets all failed validation exceptions, if any.
		/// </summary>
		/// <returns>
		/// All failed validation exceptions
		/// </returns>
		/// <remarks>
		/// This method will never be executed when exceptions are thrown as soon as validations
		/// fail (e.g. when using <see cref="Require"/>), making it useless in those cases. It
		/// works fine with <see cref="RequireAll" />. When using <see cref="RequireNothing"/> an
		/// empty collection is always returned.
		/// </remarks>
		IEnumerable<Exception> ThenGetExceptions();

		/// <summary>
		/// Throws a <see cref="ParameterValidationException" /> containing all exceptions
		/// corresponding to all failed validation conditions, if any.
		/// </summary>
		void Apply();
	}
}