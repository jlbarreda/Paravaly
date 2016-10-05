using System;

namespace Paravaly.Extensibility
{
	/// <summary>
	/// Exposes the state of the current validation to allow the creation of validation extension
	/// methods.
	/// </summary>
	/// <typeparam name="T">The parameter type.</typeparam>
	public interface IValidatableParameter<out T> : IParameterInfo<T>
	{
		/// <summary>
		/// Adds or throws the specified exception depending on the current validation mode.
		/// </summary>
		/// <param name="exception">The exception to be handled.</param>
		void Handle(Exception exception);
	}
}