using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Paravaly.Extensibility;
using Paravaly.Resources;

namespace Paravaly
{
	internal sealed class Parameter<T> :
		IValidatingParameter<T>,
		IValidatableParameter<T>
	{
		private readonly string name;
		private readonly T value;
		private readonly List<Exception> exceptions;
		private readonly ExceptionHandlingMode exceptionHandlingMode;

		internal Parameter(string name, T value, ExceptionHandlingMode exceptionHandlingMode)
			: this(name, value, exceptionHandlingMode, new List<Exception>())
		{
		}

		internal Parameter(string name, T value, ExceptionHandlingMode exceptionHandlingMode, List<Exception> exceptions)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			if (string.IsNullOrWhiteSpace(name))
			{
				if (string.IsNullOrEmpty(name))
				{
					throw new ArgumentException(ErrorMessage.ForEmpty, nameof(name));
				}

				throw new ArgumentException(ErrorMessage.ForWhiteSpace, nameof(name));
			}

			if (exceptions == null)
			{
				throw new ArgumentNullException(nameof(exceptions));
			}

			this.value = value;
			this.name = name;
			this.exceptions = exceptions;
			this.exceptionHandlingMode = exceptionHandlingMode;
		}

		/// <summary>
		/// Gets the parameter name.
		/// </summary>
		/// <value>
		/// The parameter name.
		/// </value>
		string IParameterInfo<T>.Name
		{
			get
			{
				return this.name;
			}
		}

		/// <summary>
		/// Gets the parameter value.
		/// </summary>
		/// <value>
		/// The parameter value.
		/// </value>
		T IParameterInfo<T>.Value
		{
			get
			{
				return this.value;
			}
		}

		/// <summary>
		/// Determines whether the current parameter is valid.
		/// </summary>
		/// <param name="validate">The validation action.</param>
		/// <returns>
		/// An object implementing <see cref="IValidatingParameter{T}" /> used to continue the
		/// validation of the parameter in a fluent way.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// The parameter validate is null.
		/// </exception>
		public IValidatingParameter<T> IsValid(Action<IValidatableParameter<T>> validate)
		{
			if (validate == null)
			{
				throw new ArgumentNullException(nameof(validate));
			}

			validate(this);

			return this;
		}

		/// <summary>
		/// Adds or throws the specified exception depending on the current validation mode.
		/// </summary>
		/// <param name="exception">The exception to be handled.</param>
		void IValidatableParameter<T>.Handle(Exception exception)
		{
			if (this.exceptionHandlingMode == ExceptionHandlingMode.Ignore)
			{
				return;
			}

			if (this.exceptionHandlingMode == ExceptionHandlingMode.ThrowAll)
			{
				this.exceptions.Add(exception);
			}
			else
			{
				throw exception;
			}
		}

		/// <summary>
		/// Adds another parameter to the current validation.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="parameterName">The parameter name.</param>
		/// <param name="parameterValue">The parameter value.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		public IParameter<TParameter> AndParameter<TParameter>(
			string parameterName,
			[NoEnumeration]TParameter parameterValue)
		{
			return new Parameter<TParameter>(
				parameterName,
				parameterValue,
				this.exceptionHandlingMode,
				this.exceptions);
		}

		/// <summary>
		/// Adds a generic type parameter named 'T' to the current validation.
		/// </summary>
		/// <typeparam name="TParameter">The generic type parameter to validate.</typeparam>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		public IParameter<Type> AndTypeParameter<TParameter>()
		{
			return this.AndParameter(Invariants.DefaultTypeParameterName, typeof(TParameter));
		}

		/// <summary>
		/// Adds a generic type parameter to the current validation.
		/// </summary>
		/// <typeparam name="TParameter">The generic type parameter to validate.</typeparam>
		/// <param name="parameterName">The generic type parameter name.</param>
		/// <returns>
		/// An object implementing <see cref="IParameter{T}"/> used to continue the validation of
		/// the parameter in a fluent way.
		/// </returns>
		public IParameter<Type> AndTypeParameter<TParameter>(string parameterName)
		{
			return this.AndParameter(parameterName, typeof(TParameter));
		}

		/// <summary>
		/// If any validation failed, returns a <see cref="ParameterValidationException" />
		/// containing all related exceptions; otherwise null;
		/// </summary>
		/// <returns>
		/// A <see cref="ParameterValidationException" /> containing all validation exceptions;
		/// otherwise null;
		/// </returns>
		/// <remarks>
		/// This method will never be executed when exceptions are thrown as soon as validations
		/// fail (e.g. when using <see cref="Require" />), making it useless in those cases. It
		/// works fine with <see cref="RequireAll" />. When using <see cref="RequireNothing"/> null
		/// is always returned.
		/// </remarks>
		public ParameterValidationException ThenGetException()
		{
			return this.exceptions.Count > 0 ? new ParameterValidationException(this.exceptions) : null;
		}

		/// <summary>
		/// Gets all failed validation exceptions, if any.
		/// </summary>
		/// <returns>
		/// All failed validation exceptions
		/// </returns>
		/// <remarks>
		/// This method will never be executed when exceptions are thrown as soon as validations
		/// fail (e.g. when using <see cref="Require" />), making it useless in those cases. It
		/// works fine with <see cref="RequireAll" />. When using <see cref="RequireNothing"/> an
		/// empty collection is always returned.
		/// </remarks>
		public IEnumerable<Exception> ThenGetExceptions()
		{
			return this.exceptions;
		}

		/// <summary>
		/// Applies rules and throws a <see cref="ParameterValidationException" /> containing all
		/// exceptions corresponding to all failed validation conditions, if any.
		/// </summary>
		public void Apply()
		{
			if (this.exceptions.Count > 0)
			{
				throw new ParameterValidationException(this.exceptions);
			}
		}
	}
}