using System;
using System.Globalization;
using System.Reflection;
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
		/// <exception cref="InvalidOperationException">
		/// <typeparamref name="T"/> is not an enumeration type.
		/// </exception>
		public static IValidatingParameter<T> IsValidEnumValue<T>(this IParameter<T> parameter)
			where T : struct, IComparable, IFormattable
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
		/// <exception cref="InvalidOperationException">
		/// <typeparamref name="T"/> is not an enumeration type.
		/// </exception>
		public static IValidatingParameter<T> IsValidEnumValue<T>(
			this IParameter<T> parameter,
			string errorMessage)
			where T : struct, IComparable, IFormattable
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
		/// <exception cref="InvalidOperationException">
		/// <typeparamref name="T"/> is not an enumeration type.
		/// </exception>
		public static IValidatingParameter<T> IsValidEnumValue<T>(
			this IParameter<T> parameter,
			Func<IParameterInfo<T>, string> buildErrorMessage)
			where T : struct, IComparable, IFormattable
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			if (!typeof(T).GetTypeInfo().IsEnum)
			{
				throw new InvalidOperationException(ErrorMessage.ForIsEnum);
			}

			return parameter.IsValid(
				p =>
				{
					// Slow!
					if (!Enum.IsDefined(typeof(T), p.Value))
					{
						// Slower!
						var value = p.Value.ToString();

						if (value.Length < 1 || char.IsDigit(value[0]) || value[0] == '-')
						{
							p.Handle(new ArgumentException(buildErrorMessage(p), p.Name));
						}
					}
				});
		}

		#endregion
	}
}