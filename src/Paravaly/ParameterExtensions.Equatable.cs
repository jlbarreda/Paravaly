using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// IEquatable extensions.
	/// </content>
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
					ErrorMessage.ForIsIn,
					string.Join(", ", validValues?.Select(v => v.ToPrettyString())?.ToArray() ?? new string[0]),
					p.Value.ToPrettyString()));
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
		/// <paramref name="parameter"/> or <paramref name="validValues"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsIn<T>(
			this IParameter<T> parameter,
			IEnumerable<T> validValues,
			Func<IParameterInfo<T>, string> buildErrorMessage)
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

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (!validValues.Any(x => EqualityComparer<T>.Default.Equals(x, p.Value)))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsNotIn

		/// <summary>
		/// Validates whether the parameter value is not one of a list of invalid values.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="invalidValues">The list of invalid values.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="invalidValues"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotIn<T>(this IParameter<T> parameter, params T[] invalidValues)
			where T : IEquatable<T>
		{
			return parameter.IsNotIn(
				invalidValues,
				p => string.Format(
					CultureInfo.InvariantCulture,
					ErrorMessage.ForIsNotIn,
					string.Join(", ", invalidValues?.Select(v => v.ToPrettyString())?.ToArray() ?? new string[0]),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates whether the parameter value is not one of a list of invalid values.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="invalidValues">The list of invalid values.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="invalidValues"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotIn<T>(
			this IParameter<T> parameter,
			IEnumerable<T> invalidValues,
			string errorMessage)
			where T : IEquatable<T>
		{
			return parameter.IsNotIn(invalidValues, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is not one of a list of invalid values.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="invalidValues">The list of invalid values.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="invalidValues"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotIn<T>(
			this IParameter<T> parameter,
			IEnumerable<T> invalidValues,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : IEquatable<T>
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (invalidValues == null)
			{
				throw new ArgumentNullException(nameof(invalidValues));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (invalidValues.Any(x => EqualityComparer<T>.Default.Equals(x, p.Value)))
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsNotDefault

		/// <summary>
		/// Validates whether the parameter value is not equal to its default value.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotDefault<T>(this IParameter<T> parameter)
			where T : struct, IEquatable<T>
		{
			return parameter.IsNotDefault(
				p => string.Format(
					CultureInfo.InvariantCulture,
					ErrorMessage.ForIsNotDefault,
					default(T).ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates whether the parameter value is not equal to its default value.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotDefault<T>(
			this IParameter<T> parameter,
			string errorMessage)
			where T : struct, IEquatable<T>
		{
			return parameter.IsNotDefault(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is not equal to its default value.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotDefault<T>(
			this IParameter<T> parameter,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : struct, IEquatable<T>
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (EqualityComparer<T>.Default.Equals(p.Value, default(T)))
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsNotEqualTo

		/// <summary>
		/// Validates whether the parameter value is not equal to the specified value.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="invalidValue">The invalid value.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotEqualTo<T>(this IParameter<T> parameter, T invalidValue)
			where T : IEquatable<T>
		{
			return parameter.IsNotEqualTo(
				invalidValue,
				p => string.Format(
					CultureInfo.InvariantCulture,
					ErrorMessage.ForIsNotEqualTo,
					invalidValue.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates whether the parameter value is not equal to the specified value.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="invalidValue">The invalid value.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotEqualTo<T>(
			this IParameter<T> parameter,
			T invalidValue,
			string errorMessage)
			where T : IEquatable<T>
		{
			return parameter.IsNotEqualTo(invalidValue, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is not equal to the specified value.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="invalidValue">The invalid value.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotEqualTo<T>(
			this IParameter<T> parameter,
			T invalidValue,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : IEquatable<T>
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (EqualityComparer<T>.Default.Equals(p.Value, invalidValue))
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion
	}
}