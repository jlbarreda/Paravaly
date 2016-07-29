using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	public static partial class ParameterExtensions
	{
		#region IsNotEmpty

		/// <summary>
		/// Validates whether the parameter value is empty.
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
		public static IValidatingParameter<string> IsNotEmpty(this IParameter<string> parameter)
		{
			return parameter.IsNotEmpty(ErrorMessage.ForEmpty);
		}

		/// <summary>
		/// Validates whether the parameter value is empty.
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
		public static IValidatingParameter<string> IsNotEmpty(this IParameter<string> parameter, string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.Length < 1)
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion

		#region IsNotWhiteSpace

		/// <summary>
		/// Validates whether the parameter value contains only white space.
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
		public static IValidatingParameter<string> IsNotWhiteSpace(this IParameter<string> parameter)
		{
			return parameter.IsNotWhiteSpace(ErrorMessage.ForWhiteSpace);
		}

		/// <summary>
		/// Validates whether the parameter value contains only white space.
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
		public static IValidatingParameter<string> IsNotWhiteSpace(this IParameter<string> parameter, string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (!string.IsNullOrEmpty(p.Value) && string.IsNullOrWhiteSpace(p.Value))
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion

		#region IsNotNullOrEmpty

		/// <summary>
		/// Validates whether the parameter value is null or empty.
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
		public static IValidatingParameter<string> IsNotNullOrEmpty(this IParameter<string> parameter)
		{
			return parameter.IsNotNull().IsNotEmpty();
		}

		/// <summary>
		/// Validates whether the parameter value is null or empty.
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
		public static IValidatingParameter<string> IsNotNullOrEmpty(this IParameter<string> parameter, string errorMessage)
		{
			return parameter.IsNotNull(errorMessage).IsNotEmpty(errorMessage);
		}

		#endregion

		#region IsNotNullOrWhiteSpace

		/// <summary>
		/// Validates whether the parameter value is null, empty or white space.
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
		public static IValidatingParameter<string> IsNotNullOrWhiteSpace(this IParameter<string> parameter)
		{
			return parameter.IsNotNull().IsNotEmpty().IsNotWhiteSpace();
		}

		/// <summary>
		/// Validates whether the parameter value is null, empty or white space.
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
		public static IValidatingParameter<string> IsNotNullOrWhiteSpace(this IParameter<string> parameter, string errorMessage)
		{
			return parameter.IsNotNull(errorMessage).IsNotEmpty(errorMessage).IsNotWhiteSpace(errorMessage);
		}

		#endregion

		#region Contains

		/// <summary>
		/// Validates whether the parameter value contains the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<string> Contains(this IParameter<string> parameter, string text)
		{
			return parameter.Contains(text, string.Format(CultureInfo.CurrentCulture, ErrorMessage.ForMissingText, text));
		}

		/// <summary>
		/// Validates whether the parameter value contains the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<string> Contains(this IParameter<string> parameter, string text, string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.Contains(text))
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion

		#region IsMatch

		/// <summary>
		/// Validates whether the parameter value matches the specified regular expression.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="regex">The regular expression.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="parameter" /> is null.</exception>
		public static IValidatingParameter<string> IsMatch(this IParameter<string> parameter, string regex)
		{
			return parameter.IsMatch(new Regex(regex));
		}

		/// <summary>
		/// Validates whether the parameter value matches the specified regular expression.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="regex">The regular expression.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="parameter" /> is null.</exception>
		public static IValidatingParameter<string> IsMatch(this IParameter<string> parameter, Regex regex)
		{
			return parameter.IsMatch(
				regex,
				string.Format(CultureInfo.InvariantCulture, ErrorMessage.ForIsNotRegexMatch, regex));
		}

		/// <summary>
		/// Validates whether the parameter value matches the specified regular expression.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="regex">The regular expression.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="parameter" /> is null.</exception>
		public static IValidatingParameter<string> IsMatch(this IParameter<string> parameter, string regex, string errorMessage)
		{
			return parameter.IsMatch(new Regex(regex), errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value matches the specified regular expression.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="regex">The regular expression.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="parameter" /> is null.</exception>
		public static IValidatingParameter<string> IsMatch(
			this IParameter<string> parameter,
			Regex regex,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !regex.IsMatch(p.Value))
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion

		#region IsNotEqualTo

		/// <summary>
		/// Validates whether the parameter value is equal to the specified <paramref name="value"/>.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="value">The value to compare to.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotEqualTo(this IParameter<string> parameter, string value)
		{
			return parameter.IsNotEqualTo(
				value,
				string.Format(CultureInfo.InvariantCulture, ErrorMessage.ForNotEqualString, value));
		}

		/// <summary>
		/// Validates whether the parameter value is equal to the specified <paramref name="value"/>.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="value">The value to compare to.</param>
		/// <param name="comparisonType">The comparison type.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotEqualTo(
			this IParameter<string> parameter,
			string value,
			StringComparison comparisonType)
		{
			return parameter.IsNotEqualTo(
				value,
				comparisonType,
				string.Format(CultureInfo.InvariantCulture, ErrorMessage.ForNotEqualString, value));
		}

		/// <summary>
		/// Validates whether the parameter value is equal to the specified <paramref name="value"/>.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="value">The value to compare to.</param>
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
		public static IValidatingParameter<string> IsNotEqualTo(
			this IParameter<string> parameter,
			string value,
			string errorMessage)
		{
			return parameter.IsNotEqualTo(value, StringComparison.Ordinal, errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is equal to the specified <paramref name="value"/>.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="value">The value to compare to.</param>
		/// <param name="comparisonType">The comparison type.</param>
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
		public static IValidatingParameter<string> IsNotEqualTo(
			this IParameter<string> parameter,
			string value,
			StringComparison comparisonType,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (string.Equals(p.Value, value, comparisonType))
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion

		#region HasLengthWithinRange

		/// <summary>
		/// Validates whether the parameter value's length is within the specified range.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid length.</param>
		/// <param name="max">The maximum valid length.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<string> HasLengthWithinRange(this IParameter<string> parameter, int min, int max)
		{
			return parameter.HasLengthWithinRange(
				min,
				max,
				p => string.Format(CultureInfo.CurrentCulture, ErrorMessage.ForOutOfRangeLength, min, max, p.Value?.Length));
		}

		/// <summary>
		/// Validates whether the parameter value's length is within the specified range.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid length.</param>
		/// <param name="max">The maximum valid length.</param>
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
		public static IValidatingParameter<string> HasLengthWithinRange(
			this IParameter<string> parameter,
			int min,
			int max,
			string errorMessage)
		{
			return parameter.HasLengthWithinRange(min, max, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value's length is within the specified range.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid length.</param>
		/// <param name="max">The maximum valid length.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		private static IValidatingParameter<string> HasLengthWithinRange(
			this IParameter<string> parameter,
			int min,
			int max,
			Func<IValidatableParameter<string>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && (p.Value.Length < min || p.Value.Length > max))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region HasLength

		/// <summary>
		/// Validates whether the parameter value has the specified length.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="length">The valid length.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<string> HasLength(this IParameter<string> parameter, int length)
		{
			return parameter.HasLength(
				length,
				p => string.Format(CultureInfo.CurrentCulture, ErrorMessage.ForInvalidLength, p.Value.Length, length));
		}

		/// <summary>
		/// Validates whether the parameter value has the specified length.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="length">The valid length.</param>
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
		public static IValidatingParameter<string> HasLength(
			this IParameter<string> parameter,
			int length,
			string errorMessage)
		{
			return parameter.HasLength(length, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value has the specified length.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="length">The valid length.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		private static IValidatingParameter<string> HasLength(
			this IParameter<string> parameter,
			int length,
			Func<IValidatableParameter<string>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.Length != length)
					{
						p.Handle(new ArgumentException(buildErrorMessage(p), p.Name));
					}
				});
		}

		#endregion
	}
}