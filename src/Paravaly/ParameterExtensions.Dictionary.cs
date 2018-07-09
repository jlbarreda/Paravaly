﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// IDictionary extensions.
	/// </content>
	public static partial class ParameterExtensions
	{
		#region ContainsKey

		/// <summary>
		/// Validates whether the parameter value contains the specified key.
		/// </summary>
		/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
		/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="key">The key to search for.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> or <paramref name="key" /> is null.
		/// </exception>
		public static IValidatingParameter<IDictionary<TKey, TValue>> ContainsKey<TKey, TValue>(
			this IParameter<IDictionary<TKey, TValue>> parameter,
			TKey key)
		{
			return parameter.ContainsKey(
				key,
				p => string.Format(CultureInfo.CurrentCulture, ErrorMessage.ForContainsKey, key));
		}

		/// <summary>
		/// Validates whether the parameter value contains the specified key.
		/// </summary>
		/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
		/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="key">The key to search for.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="key"/> is null.
		/// </exception>
		public static IValidatingParameter<IDictionary<TKey, TValue>> ContainsKey<TKey, TValue>(
			this IParameter<IDictionary<TKey, TValue>> parameter,
			TKey key,
			string errorMessage)
		{
			return parameter.ContainsKey(key, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value contains the specified key.
		/// </summary>
		/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
		/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="key">The key to search for.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="key"/> or
		/// <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<IDictionary<TKey, TValue>> ContainsKey<TKey, TValue>(
			this IParameter<IDictionary<TKey, TValue>> parameter,
			TKey key,
			Func<IParameterInfo<IDictionary<TKey, TValue>>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.ContainsKey(
				key,
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value contains the specified key.
		/// </summary>
		/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
		/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
		/// <param name="parameter">
		/// The parameter holding the state of the current validation.
		/// </param>
		/// <param name="key">The key to search for.</param>
		/// <param name="buildException">
		/// A function that builds an exception.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> or <paramref name="key"/> or
		/// <paramref name="buildException"/> is null.
		/// </exception>
		public static IValidatingParameter<IDictionary<TKey, TValue>> ContainsKey<TKey, TValue>(
			this IParameter<IDictionary<TKey, TValue>> parameter,
			TKey key,
			Func<IParameterInfo<IDictionary<TKey, TValue>>, Exception> buildException)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}

			if (buildException == null)
			{
				throw new ArgumentNullException(nameof(buildException));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.ContainsKey(key))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion
	}
}