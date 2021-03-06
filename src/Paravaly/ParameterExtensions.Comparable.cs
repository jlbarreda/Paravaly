﻿using System;
using System.Globalization;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// IComparable extensions.
	/// </content>
	public static partial class ParameterExtensions
	{
		#region IsLessThan

		/// <summary>
		/// Determines whether the parameter is less than the specified exclusive maximum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="exclusiveMax">The non-inclusive maximum value.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="exclusiveMax"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsLessThan<T>(this IParameter<T> parameter, T exclusiveMax)
			where T : IComparable<T>
		{
			return parameter.IsLessThan(
				exclusiveMax,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForIsLessThan,
					exclusiveMax.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Determines whether the parameter is less than the specified exclusive maximum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="exclusiveMax">The non-inclusive maximum value.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="exclusiveMax"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsLessThan<T>(
			this IParameter<T> parameter,
			T exclusiveMax,
			string errorMessage)
			where T : IComparable<T>
		{
			return parameter.IsLessThan(exclusiveMax, p => errorMessage);
		}

		/// <summary>
		/// Determines whether the parameter is less than the specified exclusive maximum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="exclusiveMax">The non-inclusive maximum value.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="exclusiveMax"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsLessThan<T>(
			this IParameter<T> parameter,
			T exclusiveMax,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : IComparable<T>
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsLessThan(
				exclusiveMax,
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Determines whether the parameter is less than the specified exclusive maximum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="exclusiveMax">The non-inclusive maximum value.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="exclusiveMax"/> or
		/// <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsLessThan<T>(
			this IParameter<T> parameter,
			T exclusiveMax,
			Func<IParameterInfo<T>, Exception> buildException)
			where T : IComparable<T>
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (exclusiveMax == null)
			{
				throw new ArgumentNullException(nameof(exclusiveMax));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && SafeComparer.Compare(p.Value, exclusiveMax) >= 0)
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion

		#region IsLessThanOrEqualTo

		/// <summary>
		/// Determines whether the parameter is less than or equal to the specified inclusive
		/// maximum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="inclusiveMax">The non-inclusive maximum value.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<T> IsLessThanOrEqualTo<T>(this IParameter<T> parameter, T inclusiveMax)
			where T : IComparable<T>
		{
			return parameter.IsLessThanOrEqualTo(
				inclusiveMax,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForIsLessThanOrEqualTo,
					inclusiveMax.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Determines whether the parameter is less than or equal to the specified inclusive
		/// maximum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="inclusiveMax">The non-inclusive maximum value.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<T> IsLessThanOrEqualTo<T>(
			this IParameter<T> parameter,
			T inclusiveMax,
			string errorMessage)
			where T : IComparable<T>
		{
			return parameter.IsLessThanOrEqualTo(inclusiveMax, p => errorMessage);
		}

		/// <summary>
		/// Determines whether the parameter is less than or equal to the specified inclusive
		/// maximum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="inclusiveMax">The non-inclusive maximum value.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="inclusiveMax"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsLessThanOrEqualTo<T>(
			this IParameter<T> parameter,
			T inclusiveMax,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : IComparable<T>
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsLessThanOrEqualTo(
				inclusiveMax,
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Determines whether the parameter is less than or equal to the specified inclusive
		/// maximum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="inclusiveMax">The non-inclusive maximum value.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="inclusiveMax"/> or
		/// <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsLessThanOrEqualTo<T>(
			this IParameter<T> parameter,
			T inclusiveMax,
			Func<IParameterInfo<T>, Exception> buildException)
			where T : IComparable<T>
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (inclusiveMax == null)
			{
				throw new ArgumentNullException(nameof(inclusiveMax));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && SafeComparer.Compare(p.Value, inclusiveMax) > 0)
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion

		#region IsGreaterThan

		/// <summary>
		/// Determines whether the parameter is greater than the specified exclusive minimum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="exclusiveMin">The non-inclusive minimum value.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="exclusiveMin"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsGreaterThan<T>(this IParameter<T> parameter, T exclusiveMin)
			where T : IComparable<T>
		{
			return parameter.IsGreaterThan(
				exclusiveMin,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForIsGreaterThan,
					exclusiveMin.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Determines whether the parameter is greater than the specified exclusive minimum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="exclusiveMin">The non-inclusive minimum value.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="exclusiveMin"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsGreaterThan<T>(
			this IParameter<T> parameter,
			T exclusiveMin,
			string errorMessage)
			where T : IComparable<T>
		{
			return parameter.IsGreaterThan(exclusiveMin, p => errorMessage);
		}

		/// <summary>
		/// Determines whether the parameter is greater than the specified exclusive minimum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="exclusiveMin">The non-inclusive minimum value.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="exclusiveMin"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsGreaterThan<T>(
			this IParameter<T> parameter,
			T exclusiveMin,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : IComparable<T>
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsGreaterThan(
				exclusiveMin,
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Determines whether the parameter is greater than the specified exclusive minimum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="exclusiveMin">The non-inclusive minimum value.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="exclusiveMin"/> or
		/// <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsGreaterThan<T>(
			this IParameter<T> parameter,
			T exclusiveMin,
			Func<IParameterInfo<T>, Exception> buildException)
			where T : IComparable<T>
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (exclusiveMin == null)
			{
				throw new ArgumentNullException(nameof(exclusiveMin));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && SafeComparer.Compare(p.Value, exclusiveMin) <= 0)
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion

		#region IsGreaterThanOrEqualTo

		/// <summary>
		/// Determines whether the parameter is greater than or equal to the specified inclusive
		/// minimum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="inclusiveMin">The non-inclusive minimum value.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="inclusiveMin"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsGreaterThanOrEqualTo<T>(this IParameter<T> parameter, T inclusiveMin)
			where T : IComparable<T>
		{
			return parameter.IsGreaterThanOrEqualTo(
				inclusiveMin,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForIsGreaterThanOrEqualTo,
					inclusiveMin.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Determines whether the parameter is greater than or equal to the specified inclusive
		/// minimum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="inclusiveMin">The non-inclusive minimum value.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="inclusiveMin"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsGreaterThanOrEqualTo<T>(
			this IParameter<T> parameter,
			T inclusiveMin,
			string errorMessage)
			where T : IComparable<T>
		{
			return parameter.IsGreaterThanOrEqualTo(inclusiveMin, p => errorMessage);
		}

		/// <summary>
		/// Determines whether the parameter is greater than or equal to the specified inclusive
		/// minimum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="inclusiveMin">The non-inclusive minimum value.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="inclusiveMin"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsGreaterThanOrEqualTo<T>(
			this IParameter<T> parameter,
			T inclusiveMin,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : IComparable<T>
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsGreaterThanOrEqualTo(
				inclusiveMin,
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Determines whether the parameter is greater than or equal to the specified inclusive
		/// minimum.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="inclusiveMin">The non-inclusive minimum value.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter <paramref name="parameter" /> or <paramref name="inclusiveMin"/> or
		/// <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsGreaterThanOrEqualTo<T>(
			this IParameter<T> parameter,
			T inclusiveMin,
			Func<IParameterInfo<T>, Exception> buildException)
			where T : IComparable<T>
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (inclusiveMin == null)
			{
				throw new ArgumentNullException(nameof(inclusiveMin));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && SafeComparer.Compare(p.Value, inclusiveMin) < 0)
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion

		#region IsWithinRange

		/// <summary>
		/// Validates whether the parameter value is within the specified range.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid value.</param>
		/// <param name="max">The maximum valid value.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="min"/> or <paramref name="max"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="min"/> is greater than <paramref name="max"/>.
		/// </exception>
		public static IValidatingParameter<T> IsWithinRange<T>(this IParameter<T> parameter, T min, T max)
			where T : IComparable<T>
		{
			return parameter.IsWithinRange(
				min,
				max,
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForIsWithinRange,
					min.ToPrettyString(),
					max.ToPrettyString(),
					p.Value.ToPrettyString()));
		}

		/// <summary>
		/// Validates whether the parameter value is within the specified range.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid value.</param>
		/// <param name="max">The maximum valid value.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="min"/> or <paramref name="max"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="min"/> is greater than <paramref name="max"/>.
		/// </exception>
		public static IValidatingParameter<T> IsWithinRange<T>(
			this IParameter<T> parameter,
			T min,
			T max,
			string errorMessage)
			where T : IComparable<T>
		{
			return parameter.IsWithinRange(min, max, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is within the specified range.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid value.</param>
		/// <param name="max">The maximum valid value.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="min"/> or <paramref name="max"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="min"/> is greater than <paramref name="max"/>.
		/// </exception>
		public static IValidatingParameter<T> IsWithinRange<T>(
			this IParameter<T> parameter,
			T min,
			T max,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : IComparable<T>
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsWithinRange(
				min,
				max,
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Validates whether the parameter value is within the specified range.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid value.</param>
		/// <param name="max">The maximum valid value.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="min"/> or <paramref name="max"/> or
		/// <paramref name="buildException"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="min"/> is greater than <paramref name="max"/>.
		/// </exception>
		public static IValidatingParameter<T> IsWithinRange<T>(
			this IParameter<T> parameter,
			T min,
			T max,
			Func<IParameterInfo<T>, Exception> buildException)
			where T : IComparable<T>
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (min == null)
			{
				throw new ArgumentNullException(nameof(min));
			}

			if (max == null)
			{
				throw new ArgumentNullException(nameof(max));
			}

			if (SafeComparer.Compare(min, max) > 0)
			{
				throw new ArgumentOutOfRangeException(nameof(min));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null
						&& (SafeComparer.Compare(p.Value, min) < 0 || SafeComparer.Compare(p.Value, max) > 0))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion
	}
}