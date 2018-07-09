using System;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// Double extensions.
	/// </content>
	public static partial class ParameterExtensions
	{
		#region IsNotNaN

		/// <summary>
		/// Validates whether the parameter value is NaN (Not a Number).
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
		public static IValidatingParameter<double> IsNotNaN(this IParameter<double> parameter)
		{
			return parameter.IsNotNaN(p => ErrorMessage.ForIsNotNaN);
		}

		/// <summary>
		/// Validates whether the parameter value is NaN (Not a Number).
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
		public static IValidatingParameter<double> IsNotNaN(
			this IParameter<double> parameter,
			string errorMessage)
		{
			return parameter.IsNotNaN(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is NaN (Not a Number).
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
		public static IValidatingParameter<double> IsNotNaN(
			this IParameter<double> parameter,
			Func<IParameterInfo<double>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsNotNaN(
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Validates whether the parameter value is NaN (Not a Number).
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
		public static IValidatingParameter<double> IsNotNaN(
			this IParameter<double> parameter,
			Func<IParameterInfo<double>, Exception> buildException)
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
					if (double.IsNaN(p.Value))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion

		#region IsNotInfinity

		/// <summary>
		/// Validates that the parameter value is not infinity.
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
		public static IValidatingParameter<double> IsNotInfinity(this IParameter<double> parameter)
		{
			return parameter.IsNotInfinity(p => ErrorMessage.ForIsNotInfinity);
		}

		/// <summary>
		/// Validates that the parameter value is not infinity.
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
		public static IValidatingParameter<double> IsNotInfinity(
			this IParameter<double> parameter,
			string errorMessage)
		{
			return parameter.IsNotInfinity(p => errorMessage);
		}

		/// <summary>
		/// Validates that the parameter value is not infinity.
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
		public static IValidatingParameter<double> IsNotInfinity(
			this IParameter<double> parameter,
			Func<IParameterInfo<double>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsNotInfinity(
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Validates that the parameter value is not infinity.
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
		public static IValidatingParameter<double> IsNotInfinity(
			this IParameter<double> parameter,
			Func<IParameterInfo<double>, Exception> buildException)
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
					if (double.IsInfinity(p.Value))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion

		#region IsNotNegativeInfinity

		/// <summary>
		/// Validates that the parameter value is not negative infinity.
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
		public static IValidatingParameter<double> IsNotNegativeInfinity(this IParameter<double> parameter)
		{
			return parameter.IsNotNegativeInfinity(p => ErrorMessage.ForIsNotNegativeInfinity);
		}

		/// <summary>
		/// Validates that the parameter value is not negative infinity.
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
		public static IValidatingParameter<double> IsNotNegativeInfinity(
			this IParameter<double> parameter,
			string errorMessage)
		{
			return parameter.IsNotNegativeInfinity(p => errorMessage);
		}

		/// <summary>
		/// Validates that the parameter value is not negative infinity.
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
		public static IValidatingParameter<double> IsNotNegativeInfinity(
			this IParameter<double> parameter,
			Func<IParameterInfo<double>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsNotNegativeInfinity(
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Validates that the parameter value is not negative infinity.
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
		public static IValidatingParameter<double> IsNotNegativeInfinity(
			this IParameter<double> parameter,
			Func<IParameterInfo<double>, Exception> buildException)
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
					if (double.IsNegativeInfinity(p.Value))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion

		#region IsNotPositiveInfinity

		/// <summary>
		/// Validates that the parameter value is not positive infinity.
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
		public static IValidatingParameter<double> IsNotPositiveInfinity(this IParameter<double> parameter)
		{
			return parameter.IsNotPositiveInfinity(p => ErrorMessage.ForIsNotPositiveInfinity);
		}

		/// <summary>
		/// Validates that the parameter value is not positive infinity.
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
		public static IValidatingParameter<double> IsNotPositiveInfinity(
			this IParameter<double> parameter,
			string errorMessage)
		{
			return parameter.IsNotPositiveInfinity(p => errorMessage);
		}

		/// <summary>
		/// Validates that the parameter value is not positive infinity.
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
		public static IValidatingParameter<double> IsNotPositiveInfinity(
			this IParameter<double> parameter,
			Func<IParameterInfo<double>, string> buildErrorMessage)
		{
			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsNotPositiveInfinity(
				p => new ArgumentOutOfRangeException(p.Name, buildErrorMessage(p)));
		}

		/// <summary>
		/// Validates that the parameter value is not positive infinity.
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
		public static IValidatingParameter<double> IsNotPositiveInfinity(
			this IParameter<double> parameter,
			Func<IParameterInfo<double>, Exception> buildException)
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
					if (double.IsPositiveInfinity(p.Value))
					{
						p.Handle(buildException(p));
					}
				});
		}

		#endregion
	}
}