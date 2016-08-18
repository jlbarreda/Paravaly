using System;
using System.Diagnostics;

namespace Paravaly
{
	/// <summary>
	/// Provides extension methods for objects implementing the <see cref="IParameter{T}"/>
	/// interface.
	/// </summary>
	[DebuggerStepThrough]
	public static partial class ParameterExtensions
	{
		#region IsNotNull

		/// <summary>
		/// Validates whether the parameter value is null.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T?> IsNotNull<T>(this IParameter<T?> parameter)
			where T : struct
		{
			return parameter.IsNotNull(null);
		}

		/// <summary>
		/// Validates whether the parameter value is null.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="errorMessage">
		/// The error message used for the exception thrown if the validation fails.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter" /> is null.
		/// </exception>
		public static IValidatingParameter<T?> IsNotNull<T>(this IParameter<T?> parameter, string errorMessage)
			where T : struct
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (!p.Value.HasValue)
					{
						if (errorMessage == null)
						{
							p.Handle(new ArgumentNullException(p.Name));
						}
						else
						{
							p.Handle(new ArgumentNullException(p.Name, errorMessage));
						}
					}
				});
		}

		/// <summary>
		/// Validates whether the parameter value is null.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsNotNull<T>(this IParameter<T> parameter)
			where T : class
		{
			return parameter.IsNotNull(null);
		}

		/// <summary>
		/// Validates whether the parameter value is null.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
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
		public static IValidatingParameter<T> IsNotNull<T>(this IParameter<T> parameter, string errorMessage)
			where T : class
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value == null)
					{
						if (errorMessage == null)
						{
							p.Handle(new ArgumentNullException(p.Name));
						}
						else
						{
							p.Handle(new ArgumentNullException(p.Name, errorMessage));
						}
					}
				});
		}

		#endregion
	}
}