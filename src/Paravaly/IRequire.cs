using System;
using JetBrains.Annotations;

namespace Paravaly
{
	/// <summary>
	/// Provides methods to start parameter validation.
	/// </summary>
	public interface IRequire
	{
		/// <summary>
		/// Starts parameter validation.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="name">The parameter name.</param>
		/// <param name="value">The parameter value.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		IParameter<T> Parameter<T>(string name, [NoEnumeration]T value);

		/// <summary>
		/// Starts parameter validation.
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
		IParameter<T> Parameter<T, TParameterAsProperty>(TParameterAsProperty parameterAsProperty, [NoEnumeration]T value);

		/// <summary>
		/// Starts validation for a generic type parameter named 'T'.
		/// </summary>
		/// <typeparam name="T">The generic type parameter to validate.</typeparam>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		IParameter<Type> TypeParameter<T>();

		/// <summary>
		/// Starts validation for a generic type parameter.
		/// </summary>
		/// <typeparam name="T">The generic type parameter to validate.</typeparam>
		/// <param name="name">The genric type parameter name.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		IParameter<Type> TypeParameter<T>(string name);
	}
}