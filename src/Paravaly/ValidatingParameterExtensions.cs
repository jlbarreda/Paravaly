using System.Diagnostics;
using JetBrains.Annotations;

namespace Paravaly
{
	/// <summary>
	/// Provides extension methods for objects implementing the <see cref="IValidatingParameter{T}"/>
	/// interface.
	/// </summary>
	[DebuggerStepThrough]
	public static class ValidatingParameterExtensions
	{
		/// <summary>
		/// Adds another parameter to the current validation.
		/// </summary>
		/// <typeparam name="TPreviousParameter">The previous parameter type.</typeparam>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <typeparam name="TParameterAsProperty">
		/// The type of <paramref name="parameterAsProperty"/>.
		/// </typeparam>
		/// <param name="parameter">
		/// The <see cref="IValidatingParameter{T}"/> instance used by this extension.
		/// </param>
		/// <param name="parameterAsProperty">
		/// An anonymous object with the parameter as a property (e.g. new { parameter }).
		/// </param>
		/// <param name="parameterValue">The parameter value.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		public static IParameter<TParameter> AndParameter<TPreviousParameter, TParameter, TParameterAsProperty>(
			this IValidatingParameter<TPreviousParameter> parameter,
			TParameterAsProperty parameterAsProperty,
			[NoEnumeration]TParameter parameterValue)
		{
			return parameter.AndParameter(
				ParameterInfoResolution.NameFromProperty(parameterAsProperty),
				parameterValue);
		}
	}
}