﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
		/// <typeparam name="T">The type of the collection elements.</typeparam>
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
		public static IValidatingParameter<ICollection<T>> IsNotEmpty<T>(this IParameter<ICollection<T>> parameter)
		{
			return parameter.IsNotEmpty(ErrorMessage.ForEmptyCollection);
		}

		/// <summary>
		/// Validates whether the parameter value is empty.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
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
		public static IValidatingParameter<ICollection<T>> IsNotEmpty<T>(
			this IParameter<ICollection<T>> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.Count < 1)
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion

		#region All

		/// <summary>
		/// Validates whether the parameter value matches the predicate in all its elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="parameter" /> is null.</exception>
		public static IValidatingParameter<ICollection<T>> All<T>(
			this IParameter<ICollection<T>> parameter,
			Func<T, bool> predicate)
		{
			return parameter.All(predicate, ErrorMessage.ForCollectionWithInvalidElements);
		}

		/// <summary>
		/// Validates whether the parameter value matches the predicate in all its elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
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
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<ICollection<T>> All<T>(
			this IParameter<ICollection<T>> parameter,
			Func<T, bool> predicate,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.Any(x => !predicate(x)))
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion

		#region Any

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="parameter" /> is null.</exception>
		public static IValidatingParameter<ICollection<T>> Any<T>(
			this IParameter<ICollection<T>> parameter,
			Func<T, bool> predicate)
		{
			return parameter.Any(predicate, ErrorMessage.ForCollectionWithInvalidElements);
		}

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
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
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<ICollection<T>> Any<T>(
			this IParameter<ICollection<T>> parameter,
			Func<T, bool> predicate,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.Any(predicate))
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion

		#region None

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="parameter" /> is null.</exception>
		public static IValidatingParameter<ICollection<T>> None<T>(
			this IParameter<ICollection<T>> parameter,
			Func<T, bool> predicate)
		{
			return parameter.None(predicate, ErrorMessage.ForCollectionWithInvalidElements);
		}

		/// <summary>
		/// Validates whether the parameter value matches the predicate in any of its elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
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
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<ICollection<T>> None<T>(
			this IParameter<ICollection<T>> parameter,
			Func<T, bool> predicate,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.Any(predicate))
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion

		#region HasNoNullElements

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
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
		public static IValidatingParameter<ICollection<T?>> HasNoNullElements<T>(this IParameter<ICollection<T?>> parameter)
			where T : struct
		{
			return parameter.None(x => !x.HasValue, ErrorMessage.ForCollectionWithNullElements);
		}

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
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
		public static IValidatingParameter<ICollection<T?>> HasNoNullElements<T>(
			this IParameter<ICollection<T?>> parameter,
			string errorMessage)
			where T : struct
		{
			return parameter.None(x => !x.HasValue, errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
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
		public static IValidatingParameter<ICollection<T>> HasNoNullElements<T>(this IParameter<ICollection<T>> parameter)
			where T : class
		{
			return parameter.None(x => x == null, ErrorMessage.ForCollectionWithNullElements);
		}

		/// <summary>
		/// Validates whether the parameter value has null elements.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
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
		public static IValidatingParameter<ICollection<T>> HasNoNullElements<T>(
			this IParameter<ICollection<T>> parameter,
			string errorMessage)
			where T : class
		{
			return parameter.None(x => x == null, errorMessage);
		}

		#endregion

		#region HasCountWithinRange

		/// <summary>
		/// Validates whether the parameter value's count is within the specified range.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid count.</param>
		/// <param name="max">The maximum valid count.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}"/> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<ICollection<T>> HasCountWithinRange<T>(this IParameter<ICollection<T>> parameter, int min, int max)
		{
			return parameter.HasCountWithinRange(
				min,
				max,
				p => string.Format(CultureInfo.CurrentCulture, ErrorMessage.ForOutOfRangeCount, min, max, p.Value?.Count));
		}

		/// <summary>
		/// Validates whether the parameter value's count is within the specified range.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid count.</param>
		/// <param name="max">The maximum valid count.</param>
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
		public static IValidatingParameter<ICollection<T>> HasCountWithinRange<T>(
			this IParameter<ICollection<T>> parameter,
			int min,
			int max,
			string errorMessage)
		{
			return parameter.HasCountWithinRange(min, max, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value's count is within the specified range.
		/// </summary>
		/// <typeparam name="T">The type of the collection elements.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="min">The minimum valid count.</param>
		/// <param name="max">The maximum valid count.</param>
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
		private static IValidatingParameter<ICollection<T>> HasCountWithinRange<T>(
			this IParameter<ICollection<T>> parameter,
			int min,
			int max,
			Func<IValidatableParameter<ICollection<T>>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && (p.Value.Count < min || p.Value.Count > max))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion
	}
}