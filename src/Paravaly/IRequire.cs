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
	}
}