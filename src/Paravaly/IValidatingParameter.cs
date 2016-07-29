using JetBrains.Annotations;

namespace Paravaly
{
	/// <summary>
	/// Represents a parameter that has at least one validation applied to it.
	/// </summary>
	/// <typeparam name="T">The parameter type.</typeparam>
	public interface IValidatingParameter<T> : IParameter<T>
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
		/// Throws a <see cref="ParameterValidationException" /> containing all exceptions
		/// corresponding to all failed validation conditions, if any.
		/// </summary>
		void Apply();
	}
}