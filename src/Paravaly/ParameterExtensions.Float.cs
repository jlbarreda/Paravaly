using System;
using Paravaly.Resources;

namespace Paravaly
{
	public static partial class ParameterExtensions
	{
		#region IsNotNaN

		/// <summary>
		/// Validates whether the parameter value is NaN (Not a Number).
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<float> IsNotNaN(this IParameter<float> parameter)
		{
			return parameter.IsNotNaN(ErrorMessage.ForNaN);
		}

		/// <summary>
		/// Validates whether the parameter value is NaN (Not a Number).
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<float> IsNotNaN(
			this IParameter<float> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (float.IsNaN(p.Value))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, errorMessage));
					}
				});
		}

		#endregion
	}
}