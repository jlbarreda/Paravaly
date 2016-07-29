using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	public static partial class ParameterExtensions
	{
		#region IsIn

		/// <summary>
		/// Validates whether the parameter value is one of a list of valid values.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="validValues">The accepted list of valid values.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="validValues"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsIn<T>(this IParameter<T> parameter, params T[] validValues)
			where T : IEquatable<T>
		{
			return parameter.IsIn(
				validValues,
				p => string.Format(
					CultureInfo.InvariantCulture,
					ErrorMessage.ForInvalidValue,
					string.Join(", ", validValues.Select(v => v?.ToString()).ToArray()),
					p.Value));
		}

		/// <summary>
		/// Validates whether the parameter value is one of a list of valid values.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="validValues">The accepted list of valid values.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="validValues"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsIn<T>(
			this IParameter<T> parameter,
			IEnumerable<T> validValues,
			string errorMessage)
			where T : IEquatable<T>
		{
			return parameter.IsIn(validValues, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is one of a list of valid values.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="validValues">The accepted list of valid values.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="validValues"/> is null.
		/// </exception>
		private static IValidatingParameter<T> IsIn<T>(
			this IParameter<T> parameter,
			IEnumerable<T> validValues,
			Func<IValidatableParameter<T>, string> buildErrorMessage)
			where T : IEquatable<T>
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (validValues == null)
			{
				throw new ArgumentNullException(nameof(validValues));
			}

			return parameter.IsValid(
				p =>
				{
					if (!validValues.Any(x => Equals(x, p.Value)))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion
	}
}