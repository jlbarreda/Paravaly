using System;
using Paravaly.Extensibility;

namespace Paravaly
{
	/// <summary>
	/// Represents a parameter with no validation conditions applied to it.
	/// </summary>
	/// <typeparam name="T">The parameter type.</typeparam>
	public interface IParameter<out T>
	{
		/// <summary>
		/// Determines whether the current parameter is valid.
		/// </summary>
		/// <param name="validate">The validation action.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		IValidatingParameter<T> IsValid(Action<IValidatableParameter<T>> validate);
	}
}