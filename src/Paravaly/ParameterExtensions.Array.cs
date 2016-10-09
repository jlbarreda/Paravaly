using System;
using System.Globalization;
using System.Linq;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// Array extensions.
	/// </content>
	public static partial class ParameterExtensions
	{
		#region IsNotEmpty

		/// <summary>
		/// Validates whether the parameter value is empty.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> IsNotEmpty<T>(this IParameter<T[]> parameter)
		{
			return parameter.IsNotEmpty(p => ErrorMessage.ForArrayIsNotEmpty);
		}

		/// <summary>
		/// Validates whether the parameter value is empty.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> IsNotEmpty<T>(
			this IParameter<T[]> parameter,
			string errorMessage)
		{
			return parameter.IsNotEmpty(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is empty.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
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
		public static IValidatingParameter<T[]> IsNotEmpty<T>(
			this IParameter<T[]> parameter,
			Func<IParameterInfo<T[]>, string> buildErrorMessage)
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
					if (p.Value != null && p.Value.Length < 1)
					{
						p.Handle(new ArgumentException(buildErrorMessage(p), p.Name));
					}
				});
		}

		#endregion

		#region All

		/// <summary>
		/// Validates whether the parameter value matches the predicate in all its elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="predicate"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> All<T>(
			this IParameter<T[]> parameter,
			Func<T, bool> predicate)
		{
			return parameter.All(predicate, p => ErrorMessage.ForArrayAll);
		}

		/// <summary>
		/// Validates whether the parameter value matches the predicate in all its elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="predicate"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> All<T>(
			this IParameter<T[]> parameter,
			Func<T, bool> predicate,
			string errorMessage)
		{
			return parameter.All(predicate, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value matches the predicate in all its elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="predicate"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> All<T>(
			this IParameter<T[]> parameter,
			Func<T, bool> predicate,
			Func<IParameterInfo<T[]>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.Any(x => !predicate(x)))
					{
						p.Handle(new ArgumentException(buildErrorMessage(p), p.Name));
					}
				});
		}

		#endregion

		#region Any

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="predicate"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> Any<T>(
			this IParameter<T[]> parameter,
			Func<T, bool> predicate)
		{
			return parameter.Any(predicate, p => ErrorMessage.ForArrayAny);
		}

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="predicate"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> Any<T>(
			this IParameter<T[]> parameter,
			Func<T, bool> predicate,
			string errorMessage)
		{
			return parameter.Any(predicate, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="predicate"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> Any<T>(
			this IParameter<T[]> parameter,
			Func<T, bool> predicate,
			Func<IParameterInfo<T[]>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.Any(predicate))
					{
						p.Handle(new ArgumentException(buildErrorMessage(p), p.Name));
					}
				});
		}

		#endregion

		#region None

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="predicate"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> None<T>(
			this IParameter<T[]> parameter,
			Func<T, bool> predicate)
		{
			return parameter.None(predicate, p => ErrorMessage.ForArrayNone);
		}

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="predicate"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> None<T>(
			this IParameter<T[]> parameter,
			Func<T, bool> predicate,
			string errorMessage)
		{
			return parameter.None(predicate, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="predicate"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> None<T>(
			this IParameter<T[]> parameter,
			Func<T, bool> predicate,
			Func<IParameterInfo<T[]>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.Any(predicate))
					{
						p.Handle(new ArgumentException(buildErrorMessage(p), p.Name));
					}
				});
		}

		#endregion

		#region HasNoNullElements

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T?[]> HasNoNullElements<T>(this IParameter<T?[]> parameter)
			where T : struct
		{
			return parameter.None(x => !x.HasValue, p => ErrorMessage.ForArrayHasNoNullElements);
		}

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
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
		public static IValidatingParameter<T?[]> HasNoNullElements<T>(
			this IParameter<T?[]> parameter,
			string errorMessage)
			where T : struct
		{
			return parameter.None(x => !x.HasValue, errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
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
		public static IValidatingParameter<T?[]> HasNoNullElements<T>(
			this IParameter<T?[]> parameter,
			Func<IParameterInfo<T?[]>, string> buildErrorMessage)
			where T : struct
		{
			return parameter.None(x => !x.HasValue, buildErrorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T[]> HasNoNullElements<T>(this IParameter<T[]> parameter)
			where T : class
		{
			return parameter.None(x => x == null, p => ErrorMessage.ForArrayHasNoNullElements);
		}

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
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
		public static IValidatingParameter<T[]> HasNoNullElements<T>(
			this IParameter<T[]> parameter,
			string errorMessage)
			where T : class
		{
			return parameter.None(x => x == null, errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
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
		public static IValidatingParameter<T[]> HasNoNullElements<T>(
			this IParameter<T[]> parameter,
			Func<IParameterInfo<T[]>, string> buildErrorMessage)
			where T : class
		{
			return parameter.None(x => x == null, buildErrorMessage);
		}

		#endregion

		#region HasLengthWithinRange

		/// <summary>
		/// Validates whether the parameter value's length is within the specified range.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
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
		public static IValidatingParameter<T[]> HasLengthWithinRange<T>(this IParameter<T[]> parameter, int min, int max)
		{
			return parameter.HasLengthWithinRange(
				min,
				max,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForHasLengthWithinRange,
					min,
					max,
					p.Value?.Length.ToPrettyString()));
		}

		/// <summary>
		/// Validates whether the parameter value's length is within the specified range.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
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
		public static IValidatingParameter<T[]> HasLengthWithinRange<T>(
			this IParameter<T[]> parameter,
			int min,
			int max,
			string errorMessage)
		{
			return parameter.HasLengthWithinRange(min, max, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value's length is within the specified range.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
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
		public static IValidatingParameter<T[]> HasLengthWithinRange<T>(
			this IParameter<T[]> parameter,
			int min,
			int max,
			Func<IParameterInfo<T[]>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			if (SafeComparer.Compare(min, max) > 0)
			{
				throw new ArgumentOutOfRangeException(nameof(min));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null
						&& (p.Value.Length < min || p.Value.Length > max))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion
	}
}