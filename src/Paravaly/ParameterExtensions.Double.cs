﻿using System;
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
		public static IValidatingParameter<double> IsNotNaN(
			this IParameter<double> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (double.IsNaN(p.Value))
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
		public static IValidatingParameter<double> IsNotInfinity(this IParameter<double> parameter)
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
		public static IValidatingParameter<double> IsNotInfinity(
			this IParameter<double> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (double.IsInfinity(p.Value))
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
		public static IValidatingParameter<double> IsNotNegativeInfinity(this IParameter<double> parameter)
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
		public static IValidatingParameter<double> IsNotNegativeInfinity(
			this IParameter<double> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (double.IsNegativeInfinity(p.Value))
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
		public static IValidatingParameter<double> IsNotPositiveInfinity(this IParameter<double> parameter)
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
		public static IValidatingParameter<double> IsNotPositiveInfinity(
			this IParameter<double> parameter,
			string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (double.IsPositiveInfinity(p.Value))
					{
						p.Handle(new ArgumentOutOfRangeException(p.Name, errorMessage));
					}
				});
		}

		#endregion
	}
}