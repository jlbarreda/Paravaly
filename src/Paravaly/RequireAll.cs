using System.Diagnostics;
using JetBrains.Annotations;

namespace Paravaly
{
	/// <summary>
	/// Provides methods to start parameter validation.
	/// </summary>
	public static class RequireAll
	{
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
			return new Parameter<T>(name, value, ExceptionHandlingMode.ThrowAll);
		}
	}
}