using System;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// Float extensions.
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
		public static IValidatingParameter<float> IsNotNaN(this IParameter<float> parameter)
		{
			return parameter.IsNotNaN(ErrorMessage.ForIsNotNaN);
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
		public static IValidatingParameter<float> IsNotNaN(
			this IParameter<float> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (float.IsNaN(p.Value))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, errorMessage));
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
		public static IValidatingParameter<float> IsNotInfinity(this IParameter<float> parameter)
		{
			return parameter.IsNotInfinity(ErrorMessage.ForIsNotInfinity);
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
		public static IValidatingParameter<float> IsNotInfinity(
			this IParameter<float> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (float.IsInfinity(p.Value))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, errorMessage));
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
		public static IValidatingParameter<float> IsNotNegativeInfinity(this IParameter<float> parameter)
		{
			return parameter.IsNotNegativeInfinity(ErrorMessage.ForIsNotNegativeInfinity);
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
		public static IValidatingParameter<float> IsNotNegativeInfinity(
			this IParameter<float> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (float.IsNegativeInfinity(p.Value))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, errorMessage));
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
		public static IValidatingParameter<float> IsNotPositiveInfinity(this IParameter<float> parameter)
		{
			return parameter.IsNotPositiveInfinity(ErrorMessage.ForIsNotPositiveInfinity);
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
		public static IValidatingParameter<float> IsNotPositiveInfinity(
			this IParameter<float> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (float.IsPositiveInfinity(p.Value))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, errorMessage));
					}
				});
		}

		#endregion
	}
}