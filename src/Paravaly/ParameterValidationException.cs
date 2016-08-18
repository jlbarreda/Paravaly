using System;
using System.Collections.Generic;

namespace Paravaly
{
	/// <summary>
	/// Represents one or more parameter validation errors.
	/// </summary>
#if SUPPORTS_SERIALIZATION
	[Serializable]
#endif
	public class ParameterValidationException : AggregateException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValidationException"/> class.
		/// </summary>
		public ParameterValidationException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValidationException"/> class.
		/// </summary>
		/// <param name="message">
		/// The message that describes the exception. The caller of this constructor is required
		/// to ensure that this string has been localized for the current system culture.
		/// </param>
		public ParameterValidationException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValidationException"/> class.
		/// </summary>
		/// <param name="message">
		/// The message that describes the exception. The caller of this constructor is required
		/// to ensure that this string has been localized for the current system culture.
		/// </param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception. If the
		/// <paramref name="innerException" /> parameter is not null, the current exception is
		/// raised in a catch block that handles the inner exception.
		/// </param>
		public ParameterValidationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValidationException"/> class.
		/// </summary>
		/// <param name="innerExceptions">
		/// The exceptions that are the cause of the current exception.
		/// </param>
		public ParameterValidationException(IEnumerable<Exception> innerExceptions)
			: base(innerExceptions)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValidationException"/> class.
		/// </summary>
		/// <param name="innerExceptions">
		/// The exceptions that are the cause of the current exception.
		/// </param>
		public ParameterValidationException(params Exception[] innerExceptions)
			: base(innerExceptions)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValidationException"/> class.
		/// </summary>
		/// <param name="message">
		/// The error message that explains the reason for the exception.
		/// </param>
		/// <param name="innerExceptions">
		/// The exceptions that are the cause of the current exception.
		/// </param>
		public ParameterValidationException(string message, IEnumerable<Exception> innerExceptions)
			: base(message, innerExceptions)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValidationException"/> class.
		/// </summary>
		/// <param name="message">
		/// The error message that explains the reason for the exception.
		/// </param>
		/// <param name="innerExceptions">
		/// The exceptions that are the cause of the current exception.
		/// </param>
		public ParameterValidationException(string message, params Exception[] innerExceptions)
			: base(message, innerExceptions)
		{
		}

#if SUPPORTS_SERIALIZATION
		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValidationException"/> class.
		/// </summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">
		/// The contextual information about the source or destination.
		/// </param>
		protected ParameterValidationException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context)
			: base(info, context)
		{
		}
#endif
	}
}