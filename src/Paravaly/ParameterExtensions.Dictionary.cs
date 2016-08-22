using System;
using System.Collections.Generic;
using System.Globalization;
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
				string.Format(CultureInfo.CurrentCulture, ErrorMessage.ForContainsKey, key));
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
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.ContainsKey(key))
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

		#endregion
	}
}