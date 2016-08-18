using System;
using System.Diagnostics;
#if NETSTANDARD1_0
using System.Reflection;
#endif
using Paravaly.Extensibility;
using Paravaly.Resources;

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

		#region Is

		/// <summary>
		/// Validates whether the parameter value is of the specified type.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="type">The type to compare to.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T> Is<T>(this IParameter<T> parameter, Type type)
		{
			return parameter.Is(
				type,
				p => string.Format(ErrorMessage.ForInvalidType, type.FullName, p.Value?.GetType().FullName));
		}

		/// <summary>
		/// Validates whether the parameter value is of the specified type.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="type">The type to compare to.</param>
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
		public static IValidatingParameter<T> Is<T>(this IParameter<T> parameter, Type type, string errorMessage)
		{
			return parameter.Is(type, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is of the specified type.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="type">The type to compare to.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		private static IValidatingParameter<T> Is<T>(
			this IParameter<T> parameter,
			Type type,
			Func<IValidatableParameter<T>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value?.GetType() != type)
					{
						p.Handle(new ArgumentException(buildErrorMessage(p), p.Name));
					}
				});
		}

		#endregion

		#region IsAssignableTo

		/// <summary>
		/// Validates whether the parameter value is assignable to an instance of the specified
		/// type.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="type">The type to compare to.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		public static IValidatingParameter<T> IsAssignableTo<T>(this IParameter<T> parameter, Type type)
		{
			return parameter.IsAssignableTo(
				type,
				p => string.Format(ErrorMessage.ForNotAssignableType, type.FullName, p.Value?.GetType().FullName));
		}

		/// <summary>
		/// Validates whether the parameter value is assignable to an instance of the specified
		/// type.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="type">The type to compare to.</param>
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
		public static IValidatingParameter<T> IsAssignableTo<T>(this IParameter<T> parameter, Type type, string errorMessage)
		{
			return parameter.IsAssignableTo(type, p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter value is assignable to an instance of the specified
		/// type.
		/// </summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="type">The type to compare to.</param>
		/// <param name="buildErrorMessage">
		/// A function that builds an error message.
		/// </param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is null.
		/// </exception>
		private static IValidatingParameter<T> IsAssignableTo<T>(
			this IParameter<T> parameter,
			Type type,
			Func<IValidatableParameter<T>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
#if NETSTANDARD1_0
					if (!type.GetTypeInfo().IsAssignableFrom(p.Value?.GetType()?.GetTypeInfo()))
#else
					if (!type.IsAssignableFrom(p.Value?.GetType()))
#endif
					{
						p.Handle(new ArgumentException(buildErrorMessage(p), p.Name));
					}
				});
		}

		#endregion
	}
}