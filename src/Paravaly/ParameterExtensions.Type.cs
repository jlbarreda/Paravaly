using System;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	/// <content>
	/// Type extensions.
	/// </content>
	public static partial class ParameterExtensions
	{
		#region IsClass

		/// <summary>
		/// Validates whether the parameter is a class type.
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
		public static IValidatingParameter<Type> IsClass(this IParameter<Type> parameter)
		{
			return parameter.IsClass(p => ErrorMessage.ForIsClass);
		}

		/// <summary>
		/// Validates whether the parameter is a class type.
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
		public static IValidatingParameter<Type> IsClass(
			this IParameter<Type> parameter,
			string errorMessage)
		{
			return parameter.IsClass(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter is a class type.
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
		/// <paramref name="parameter"/> is null or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<Type> IsClass(
			this IParameter<Type> parameter,
			Func<IParameterInfo<Type>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.GetInfo().IsClass)
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsNotClass

		/// <summary>
		/// Validates whether the parameter is not a class type.
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
		public static IValidatingParameter<Type> IsNotClass(this IParameter<Type> parameter)
		{
			return parameter.IsNotClass(p => ErrorMessage.ForIsNotClass);
		}

		/// <summary>
		/// Validates whether the parameter is not a class type.
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
		public static IValidatingParameter<Type> IsNotClass(
			this IParameter<Type> parameter,
			string errorMessage)
		{
			return parameter.IsNotClass(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter is not a class type.
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
		/// <paramref name="parameter"/> is null or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<Type> IsNotClass(
			this IParameter<Type> parameter,
			Func<IParameterInfo<Type>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.GetInfo().IsClass)
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsInterface

		/// <summary>
		/// Validates whether the parameter is an interface type.
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
		public static IValidatingParameter<Type> IsInterface(this IParameter<Type> parameter)
		{
			return parameter.IsInterface(p => ErrorMessage.ForIsInterface);
		}

		/// <summary>
		/// Validates whether the parameter is an interface type.
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
		public static IValidatingParameter<Type> IsInterface(
			this IParameter<Type> parameter,
			string errorMessage)
		{
			return parameter.IsInterface(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter is an interface type.
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
		/// <paramref name="parameter"/> is null or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<Type> IsInterface(
			this IParameter<Type> parameter,
			Func<IParameterInfo<Type>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.GetInfo().IsInterface)
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsNotInterface

		/// <summary>
		/// Validates whether the parameter is not an interface type.
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
		public static IValidatingParameter<Type> IsNotInterface(this IParameter<Type> parameter)
		{
			return parameter.IsNotInterface(p => ErrorMessage.ForIsNotInterface);
		}

		/// <summary>
		/// Validates whether the parameter is not an interface type.
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
		public static IValidatingParameter<Type> IsNotInterface(
			this IParameter<Type> parameter,
			string errorMessage)
		{
			return parameter.IsNotInterface(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter is not an interface type.
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
		/// <paramref name="parameter"/> is null or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<Type> IsNotInterface(
			this IParameter<Type> parameter,
			Func<IParameterInfo<Type>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.GetInfo().IsInterface)
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsValueType

		/// <summary>
		/// Validates whether the parameter is a value type.
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
		public static IValidatingParameter<Type> IsValueType(this IParameter<Type> parameter)
		{
			return parameter.IsValueType(p => ErrorMessage.ForIsValueType);
		}

		/// <summary>
		/// Validates whether the parameter is a value type.
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
		public static IValidatingParameter<Type> IsValueType(
			this IParameter<Type> parameter,
			string errorMessage)
		{
			return parameter.IsValueType(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter is a value type.
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
		/// <paramref name="parameter"/> is null or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<Type> IsValueType(
			this IParameter<Type> parameter,
			Func<IParameterInfo<Type>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.GetInfo().IsValueType)
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsNotValueType

		/// <summary>
		/// Validates whether the parameter is not a value type.
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
		public static IValidatingParameter<Type> IsNotValueType(this IParameter<Type> parameter)
		{
			return parameter.IsNotValueType(p => ErrorMessage.ForIsNotValueType);
		}

		/// <summary>
		/// Validates whether the parameter is not a value type.
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
		public static IValidatingParameter<Type> IsNotValueType(
			this IParameter<Type> parameter,
			string errorMessage)
		{
			return parameter.IsNotValueType(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter is not a value type.
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
		/// <paramref name="parameter"/> is null or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<Type> IsNotValueType(
			this IParameter<Type> parameter,
			Func<IParameterInfo<Type>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.GetInfo().IsValueType)
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsEnum

		/// <summary>
		/// Validates whether the parameter is an enumeration.
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
		public static IValidatingParameter<Type> IsEnum(this IParameter<Type> parameter)
		{
			return parameter.IsEnum(p => ErrorMessage.ForIsEnum);
		}

		/// <summary>
		/// Validates whether the parameter is an enumeration.
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
		public static IValidatingParameter<Type> IsEnum(
			this IParameter<Type> parameter,
			string errorMessage)
		{
			return parameter.IsEnum(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter is an enumeration.
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
		/// <paramref name="parameter"/> is null or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<Type> IsEnum(
			this IParameter<Type> parameter,
			Func<IParameterInfo<Type>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && !p.Value.GetInfo().IsEnum)
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion

		#region IsNotEnum

		/// <summary>
		/// Validates whether the parameter is not an enumeration.
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
		public static IValidatingParameter<Type> IsNotEnum(this IParameter<Type> parameter)
		{
			return parameter.IsNotEnum(p => ErrorMessage.ForIsNotEnum);
		}

		/// <summary>
		/// Validates whether the parameter is not an enumeration.
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
		public static IValidatingParameter<Type> IsNotEnum(
			this IParameter<Type> parameter,
			string errorMessage)
		{
			return parameter.IsNotEnum(p => errorMessage);
		}

		/// <summary>
		/// Validates whether the parameter is not an enumeration.
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
		/// <paramref name="parameter"/> is null or <paramref name="buildErrorMessage"/> is null.
		/// </exception>
		public static IValidatingParameter<Type> IsNotEnum(
			this IParameter<Type> parameter,
			Func<IParameterInfo<Type>, string> buildErrorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			if (buildErrorMessage == null)
			{
				throw new ArgumentNullException(nameof(buildErrorMessage));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value != null && p.Value.GetInfo().IsEnum)
					{
						p.Handle(new ArgumentException(p.Name, buildErrorMessage(p)));
					}
				});
		}

		#endregion
	}
}