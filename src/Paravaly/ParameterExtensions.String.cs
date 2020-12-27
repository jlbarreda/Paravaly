using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// String extensions.
	/// </content>
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
			return parameter.IsNotEmpty(p => ErrorMessage.ForIsNotEmpty);
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
			return parameter.IsNotEmpty(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is empty.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotEmpty(
			this IParameter<string> parameter,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsNotEmpty(p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value is empty.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotEmpty(
			this IParameter<string> parameter,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value?.Length < 1)
					{
						p.Handle(buildException(p));
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
			return parameter.IsNotWhiteSpace(p => ErrorMessage.ForIsNotWhiteSpace);
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
			return parameter.IsNotWhiteSpace(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value contains only white space.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotWhiteSpace(
			this IParameter<string> parameter,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsNotWhiteSpace(p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value contains only white space.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotWhiteSpace(
			this IParameter<string> parameter,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value.IsWhiteSpace())
					{
						p.Handle(buildException(p));
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

		/// <summary>
		/// Validates whether the parameter value is null or empty.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotNullOrEmpty(
			this IParameter<string> parameter,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			return parameter.IsNotNull(buildErrorMessage).IsNotEmpty(buildErrorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is null or empty.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotNullOrEmpty(
			this IParameter<string> parameter,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			return parameter.IsNotNull(buildException).IsNotEmpty(buildException);
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

		/// <summary>
		/// Validates whether the parameter value is null, empty or white space.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotNullOrWhiteSpace(
			this IParameter<string> parameter,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			return parameter
				.IsNotNull(buildErrorMessage)
				.IsNotEmpty(buildErrorMessage)
				.IsNotWhiteSpace(buildErrorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is null, empty or white space.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotNullOrWhiteSpace(
			this IParameter<string> parameter,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			return parameter
				.IsNotNull(buildException)
				.IsNotEmpty(buildException)
				.IsNotWhiteSpace(buildException);
		}

		#endregion

		#region StartsWith

		/// <summary>
		/// Validates whether the parameter value starts with the specified text.
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
		public static IValidatingParameter<string> StartsWith(this IParameter<string> parameter, string text)
		{
			return parameter.StartsWith(text, StringComparison.Ordinal);
		}

		/// <summary>
		/// Validates whether the parameter value starts with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<string> StartsWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType)
		{
			return parameter.StartsWith(
				text,
				comparisonType,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForStartsWith,
					text.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates whether the parameter value starts with the specified text.
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
		public static IValidatingParameter<string> StartsWith(
			this IParameter<string> parameter,
			string text,
			string errorMessage)
		{
			return parameter.StartsWith(text, StringComparison.Ordinal, errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value starts with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
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
		public static IValidatingParameter<string> StartsWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			string errorMessage)
		{
			return parameter.StartsWith(text, comparisonType, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value starts with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
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
		public static IValidatingParameter<string> StartsWith(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			return parameter.StartsWith(text, StringComparison.Ordinal, buildErrorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value starts with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
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
		public static IValidatingParameter<string> StartsWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.StartsWith(
				text,
				comparisonType,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value starts with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> StartsWith(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			return parameter.StartsWith(text, StringComparison.Ordinal, buildException);
		}

		/// <summary>
		/// Validates whether the parameter value starts with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> StartsWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.StartsWith(text, comparisonType))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion

		#region DoesNotStartWith

		/// <summary>
		/// Validates that the parameter value does not start with the specified text.
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
		public static IValidatingParameter<string> DoesNotStartWith(this IParameter<string> parameter, string text)
		{
			return parameter.DoesNotStartWith(text, StringComparison.Ordinal);
		}

		/// <summary>
		/// Validates that the parameter value does not start with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<string> DoesNotStartWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType)
		{
			return parameter.DoesNotStartWith(
				text,
				comparisonType,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForDoesNotStartWith,
					text.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates that the parameter value does not start with the specified text.
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
		public static IValidatingParameter<string> DoesNotStartWith(
			this IParameter<string> parameter,
			string text,
			string errorMessage)
		{
			return parameter.DoesNotStartWith(text, StringComparison.Ordinal, errorMessage);
		}

		/// <summary>
		/// Validates that the parameter value does not start with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
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
		public static IValidatingParameter<string> DoesNotStartWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			string errorMessage)
		{
			return parameter.DoesNotStartWith(text, comparisonType, p => errorMessage);
		}

		/// <summary>
		/// Validates that the parameter value does not start with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
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
		public static IValidatingParameter<string> DoesNotStartWith(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			return parameter.DoesNotStartWith(
				text,
				StringComparison.Ordinal,
				buildErrorMessage);
		}

		/// <summary>
		/// Validates that the parameter value does not start with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
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
		public static IValidatingParameter<string> DoesNotStartWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.DoesNotStartWith(
				text,
				comparisonType,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates that the parameter value does not start with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> DoesNotStartWith(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			return parameter.DoesNotStartWith(
				text,
				StringComparison.Ordinal,
				buildException);
		}

		/// <summary>
		/// Validates that the parameter value does not start with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> DoesNotStartWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.StartsWith(text, comparisonType))
					{
						p.Handle(buildException(p));
					}
				});
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
			return parameter.Contains(
				text,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForContains,
					text.ToPrettyString(),
					p.Value.ToPrettyString()));
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
		public static IValidatingParameter<string> Contains(
			this IParameter<string> parameter,
			string text,
			string errorMessage)
		{
			return parameter.Contains(text, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value contains the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
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
		public static IValidatingParameter<string> Contains(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.Contains(
				text,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value contains the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> Contains(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
#if HAS_CONTAINS_WITH_STRING_COMPARISON
					if (p.Value != null && !p.Value.Contains(text, StringComparison.Ordinal))
#else
					if (p.Value != null && !p.Value.Contains(text))
#endif
					{
						p.Handle(buildException(p));
					}
				});
		}

#if HAS_CONTAINS_WITH_STRING_COMPARISON

		/// <summary>
		/// Validates whether the parameter value contains the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="stringComparison">
		/// One of the enumeration values that specifies the rules to use in the comparison.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<string> Contains(
			this IParameter<string> parameter,
			string text,
			StringComparison stringComparison)
		{
			return parameter.Contains(
				text,
				stringComparison,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForContains,
					text.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates whether the parameter value contains the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="stringComparison">
		/// One of the enumeration values that specifies the rules to use in the comparison.
		/// </param>
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
		public static IValidatingParameter<string> Contains(
			this IParameter<string> parameter,
			string text,
			StringComparison stringComparison,
			string errorMessage)
		{
			return parameter.Contains(text, stringComparison, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value contains the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="stringComparison">
		/// One of the enumeration values that specifies the rules to use in the comparison.
		/// </param>
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
		public static IValidatingParameter<string> Contains(
			this IParameter<string> parameter,
			string text,
			StringComparison stringComparison,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.Contains(
				text,
				stringComparison,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value contains the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="stringComparison">
		/// One of the enumeration values that specifies the rules to use in the comparison.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> Contains(
			this IParameter<string> parameter,
			string text,
			StringComparison stringComparison,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.Contains(text, stringComparison))
					{
						p.Handle(buildException(p));
					}
				});
		}

#endif

		#endregion

		#region DoesNotContain

		/// <summary>
		/// Validates that the parameter value does not contain the specified text.
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
		public static IValidatingParameter<string> DoesNotContain(this IParameter<string> parameter, string text)
		{
			return parameter.DoesNotContain(
				text,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForDoesNotContain,
					text.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates that the parameter value does not contain the specified text.
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
		public static IValidatingParameter<string> DoesNotContain(
			this IParameter<string> parameter,
			string text,
			string errorMessage)
		{
			return parameter.DoesNotContain(text, p => errorMessage);
		}

		/// <summary>
		/// Validates that the parameter value does not contain the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
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
		public static IValidatingParameter<string> DoesNotContain(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.DoesNotContain(
				text,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates that the parameter value does not contain the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> DoesNotContain(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
#if HAS_CONTAINS_WITH_STRING_COMPARISON
					if (p.Value != null && p.Value.Contains(text, StringComparison.Ordinal))
#else
					if (p.Value != null && p.Value.Contains(text))
#endif
					{
						p.Handle(buildException(p));
					}
				});
		}

#if HAS_CONTAINS_WITH_STRING_COMPARISON

		/// <summary>
		/// Validates that the parameter value does not contain the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="stringComparison">
		/// One of the enumeration values that specifies the rules to use in the comparison.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<string> DoesNotContain(
			this IParameter<string> parameter,
			string text,
			StringComparison stringComparison)
		{
			return parameter.DoesNotContain(
				text,
				stringComparison,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForContains,
					text.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates that the parameter value does not contain the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="stringComparison">
		/// One of the enumeration values that specifies the rules to use in the comparison.
		/// </param>
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
		public static IValidatingParameter<string> DoesNotContain(
			this IParameter<string> parameter,
			string text,
			StringComparison stringComparison,
			string errorMessage)
		{
			return parameter.DoesNotContain(text, stringComparison, p => errorMessage);
		}

		/// <summary>
		/// Validates that the parameter value does not contain the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="stringComparison">
		/// One of the enumeration values that specifies the rules to use in the comparison.
		/// </param>
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
		public static IValidatingParameter<string> DoesNotContain(
			this IParameter<string> parameter,
			string text,
			StringComparison stringComparison,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.DoesNotContain(
				text,
				stringComparison,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates that the parameter value does not contain the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="stringComparison">
		/// One of the enumeration values that specifies the rules to use in the comparison.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> DoesNotContain(
			this IParameter<string> parameter,
			string text,
			StringComparison stringComparison,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.Contains(text, stringComparison))
					{
						p.Handle(buildException(p));
					}
				});
		}

#endif

		#endregion

		#region EndsWith

		/// <summary>
		/// Validates whether the parameter value ends with the specified text.
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
		public static IValidatingParameter<string> EndsWith(this IParameter<string> parameter, string text)
		{
			return parameter.EndsWith(text, StringComparison.Ordinal);
		}

		/// <summary>
		/// Validates whether the parameter value ends with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<string> EndsWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType)
		{
			return parameter.EndsWith(
				text,
				comparisonType,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForEndsWith,
					text.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates whether the parameter value ends with the specified text.
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
		public static IValidatingParameter<string> EndsWith(
			this IParameter<string> parameter,
			string text,
			string errorMessage)
		{
			return parameter.EndsWith(text, StringComparison.Ordinal, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value ends with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
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
		public static IValidatingParameter<string> EndsWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			string errorMessage)
		{
			return parameter.EndsWith(text, comparisonType, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value ends with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
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
		public static IValidatingParameter<string> EndsWith(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			return parameter.EndsWith(
				text,
				StringComparison.Ordinal,
				buildErrorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value ends with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
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
		public static IValidatingParameter<string> EndsWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.EndsWith(
				text,
				comparisonType,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value ends with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> EndsWith(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			return parameter.EndsWith(
				text,
				StringComparison.Ordinal,
				buildException);
		}

		/// <summary>
		/// Validates whether the parameter value ends with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> EndsWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.EndsWith(text, comparisonType))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion

		#region DoesNotEndWith

		/// <summary>
		/// Validates that the parameter value does not end with the specified text.
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
		public static IValidatingParameter<string> DoesNotEndWith(this IParameter<string> parameter, string text)
		{
			return parameter.DoesNotEndWith(text, StringComparison.Ordinal);
		}

		/// <summary>
		/// Validates that the parameter value does not end with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<string> DoesNotEndWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType)
		{
			return parameter.DoesNotEndWith(
				text,
				comparisonType,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForDoesNotEndWith,
					text.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates that the parameter value does not end with the specified text.
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
		public static IValidatingParameter<string> DoesNotEndWith(
			this IParameter<string> parameter,
			string text,
			string errorMessage)
		{
			return parameter.DoesNotEndWith(text, StringComparison.Ordinal, p => errorMessage);
		}

		/// <summary>
		/// Validates that the parameter value does not end with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
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
		public static IValidatingParameter<string> DoesNotEndWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			string errorMessage)
		{
			return parameter.DoesNotEndWith(text, comparisonType, p => errorMessage);
		}

		/// <summary>
		/// Validates that the parameter value does not end with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
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
		public static IValidatingParameter<string> DoesNotEndWith(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			return parameter.DoesNotEndWith(
				text,
				StringComparison.Ordinal,
				buildErrorMessage);
		}

		/// <summary>
		/// Validates that the parameter value does not end with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
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
		public static IValidatingParameter<string> DoesNotEndWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.DoesNotEndWith(
				text,
				comparisonType,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates that the parameter value does not end with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> DoesNotEndWith(
			this IParameter<string> parameter,
			string text,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			return parameter.DoesNotEndWith(
				text,
				StringComparison.Ordinal,
				buildException);
		}

		/// <summary>
		/// Validates that the parameter value does not end with the specified text.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="text">The text.</param>
		/// <param name="comparisonType">
		/// One of the enumeration values that determines how the string is compared.
		/// </param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> DoesNotEndWith(
			this IParameter<string> parameter,
			string text,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.EndsWith(text, comparisonType))
					{
						p.Handle(buildException(p));
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
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> or <paramref name="regex"/> is null.
		/// </exception>
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
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> or <paramref name="regex"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsMatch(this IParameter<string> parameter, Regex regex)
		{
			return parameter.IsMatch(
				regex,
				p => string.Format(
					CultureInfo.InvariantCulture,
					ErrorMessage.ForIsMatch,
					regex.ToPrettyString(),
					p.Value.ToPrettyString()));
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
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> or <paramref name="regex"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsMatch(
			this IParameter<string> parameter,
			string regex,
			string errorMessage)
		{
			return parameter.IsMatch(new Regex(regex), p => errorMessage);
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
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> or <paramref name="regex"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsMatch(
			this IParameter<string> parameter,
			Regex regex,
			string errorMessage)
		{
			return parameter.IsMatch(regex, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value matches the specified regular expression.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="regex">The regular expression.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> or <paramref name="regex"/> is null
		/// or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsMatch(
			this IParameter<string> parameter,
			string regex,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			return parameter.IsMatch(
				new Regex(regex),
				buildErrorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value matches the specified regular expression.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="regex">The regular expression.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> or <paramref name="regex"/> is null
		/// or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsMatch(
			this IParameter<string> parameter,
			Regex regex,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsMatch(
				regex,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value matches the specified regular expression.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="regex">The regular expression.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> or <paramref name="regex"/> is null
		/// or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsMatch(
			this IParameter<string> parameter,
			string regex,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			return parameter.IsMatch(new Regex(regex), buildException);
		}

		/// <summary>
		/// Validates whether the parameter value matches the specified regular expression.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="regex">The regular expression.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> or <paramref name="regex"/> is null
		/// or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsMatch(
			this IParameter<string> parameter,
			Regex regex,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (regex == null)
			{
				throw new ArgumentNullException(nameof(regex));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !regex.IsMatch(p.Value))
					{
						p.Handle(buildException(p));
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
		public static IValidatingParameter<string> IsNotEqualTo(
			this IParameter<string> parameter,
			string value)
		{
			return parameter.IsNotEqualTo(
				value,
				StringComparison.Ordinal,
				p => string.Format(
					CultureInfo.InvariantCulture,
					ErrorMessage.ForStringIsNotEqualTo,
					value.ToPrettyString(),
					p.Value.ToPrettyString()));
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
				p => string.Format(
					CultureInfo.InvariantCulture,
					ErrorMessage.ForStringIsNotEqualTo,
					value.ToPrettyString(),
					p.Value.ToPrettyString()));
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
			return parameter.IsNotEqualTo(value, StringComparison.Ordinal, p => errorMessage);
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
			return parameter.IsNotEqualTo(value, comparisonType, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is equal to the specified <paramref name="value"/>.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="value">The value to compare to.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotEqualTo(
			this IParameter<string> parameter,
			string value,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			return parameter.IsNotEqualTo(
				value,
				StringComparison.Ordinal,
				buildErrorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is equal to the specified <paramref name="value"/>.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="value">The value to compare to.</param>
		/// <param name="comparisonType">The comparison type.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotEqualTo(
			this IParameter<string> parameter,
			string value,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsNotEqualTo(
				value,
				comparisonType,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value is equal to the specified <paramref name="value"/>.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="value">The value to compare to.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotEqualTo(
			this IParameter<string> parameter,
			string value,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			return parameter.IsNotEqualTo(
				value,
				StringComparison.Ordinal,
				buildException);
		}

		/// <summary>
		/// Validates whether the parameter value is equal to the specified <paramref name="value"/>.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="value">The value to compare to.</param>
		/// <param name="comparisonType">The comparison type.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> IsNotEqualTo(
			this IParameter<string> parameter,
			string value,
			StringComparison comparisonType,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (string.Equals(p.Value, value, comparisonType))
					{
						p.Handle(buildException(p));
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
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="min"/> is greater than <paramref name="max"/>.
		/// </exception>
		public static IValidatingParameter<string> HasLengthWithinRange(this IParameter<string> parameter, int min, int max)
		{
			return parameter.HasLengthWithinRange(
				min,
				max,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForHasLengthWithinRange,
					min,
					max,
					p.Value?.Length));
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
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="min"/> is greater than <paramref name="max"/>.
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
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="min"/> is greater than <paramref name="max"/>.
		/// </exception>
		public static IValidatingParameter<string> HasLengthWithinRange(
			this IParameter<string> parameter,
			int min,
			int max,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.HasLengthWithinRange(
				min,
				max,
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Validates whether the parameter value's length is within the specified range.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid length.</param>
		/// <param name="max">The maximum valid length.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="min"/> is greater than <paramref name="max"/>.
		/// </exception>
		public static IValidatingParameter<string> HasLengthWithinRange(
			this IParameter<string> parameter,
			int min,
			int max,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			if (min > max)
			{
				throw new ArgumentOutOfRangeException(nameof(min));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value?.Length < min || p.Value?.Length > max)
					{
						p.Handle(buildException(p));
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
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForStringHasLength,
					p.Value?.Length,
					length));
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
		/// <paramref name="parameter"/> or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<string> HasLength(
			this IParameter<string> parameter,
			int length,
			Func<IParameterInfo<string>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.HasLength(
				length,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value has the specified length.
		/// </summary>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="length">The valid length.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<string> HasLength(
			this IParameter<string> parameter,
			int length,
			Func<IParameterInfo<string>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.Length != length)
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion
	}
}