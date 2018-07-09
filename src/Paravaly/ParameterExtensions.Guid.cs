using System;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// Guid extensions.
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
		public static IValidatingParameter<Guid> IsNotEmpty(this IParameter<Guid> parameter)
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
		public static IValidatingParameter<Guid> IsNotEmpty(this IParameter<Guid> parameter, string errorMessage)
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
		public static IValidatingParameter<Guid> IsNotEmpty(
			this IParameter<Guid> parameter,
			Func<IParameterInfo<Guid>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsNotEmpty(
				p => new ArgumentException(buildErrorMessage(p), p.Name));
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
		public static IValidatingParameter<Guid> IsNotEmpty(
			this IParameter<Guid> parameter,
			Func<IParameterInfo<Guid>, Exception> buildException)
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
					if (Guid.Empty.Equals(p.Value))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion
	}
}