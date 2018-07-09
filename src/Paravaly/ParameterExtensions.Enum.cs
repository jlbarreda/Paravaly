using System;
using System.Globalization;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// Enumeration extensions.
	/// </content>
	public static partial class ParameterExtensions
	{
		#region IsValidEnumValue

		/// <summary>
		/// Validates whether the parameter value is defined in the enumeration.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
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
		public static IValidatingParameter<T> IsValidEnumValue<T>(this IParameter<T> parameter)
			where T : Enum
		{
			return parameter.IsValidEnumValue(
				p => string.Format(
					CultureInfo.CurrentCulture,
					ErrorMessage.ForIsValidEnumValue,
					typeof(T).FullName,
					p.Value));
		}

		/// <summary>
		/// Validates whether the parameter value is defined in the enumeration.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
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
		public static IValidatingParameter<T> IsValidEnumValue<T>(
			this IParameter<T> parameter,
			string errorMessage)
			where T : Enum
		{
			return parameter.IsValidEnumValue(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is defined in the enumeration.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
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
		public static IValidatingParameter<T> IsValidEnumValue<T>(
			this IParameter<T> parameter,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : Enum
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValidEnumValue(
				p => new ArgumentException(buildErrorMessage(p), p.Name));
		}

		/// <summary>
		/// Validates whether the parameter value is defined in the enumeration.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
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
		public static IValidatingParameter<T> IsValidEnumValue<T>(
			this IParameter<T> parameter,
			Func<IParameterInfo<T>, Exception> buildException)
			where T : Enum
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
					if (!EnumValidationWithCache<T>.IsValid(p.Value))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion
	}
}