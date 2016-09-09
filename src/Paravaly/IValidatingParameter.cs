using System;
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
		/// Adds another parameter to the current validation.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
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
		IParameter<TParameter> AndParameter<TParameter, TParameterAsProperty>(
			TParameterAsProperty parameterAsProperty,
			[NoEnumeration]TParameter value);

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
		/// Throws a <see cref="ParameterValidationException" /> containing all exceptions
		/// corresponding to all failed validation conditions, if any.
		/// </summary>
		void Apply();
	}
}