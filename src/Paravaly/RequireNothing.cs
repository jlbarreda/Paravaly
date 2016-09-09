using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Paravaly
{
	/// <summary>
	/// Provides methods to start parameter validation in disabled mode.
	/// </summary>
	public sealed class RequireNothing : IRequire
	{
		/// <inheritdoc />
		[DebuggerStepThrough]
		public IParameter<T> Parameter<T>(string name, [NoEnumeration]T value)
		{
			return new Parameter<T>(name, value, ExceptionHandlingMode.Ignore);
		}

		/// <inheritdoc />
		[DebuggerStepThrough]
		public IParameter<T> Parameter<T, TParameterAsProperty>(
			TParameterAsProperty parameterAsProperty,
			[NoEnumeration]T value)
		{
			return new Parameter<T>(
				ParameterInfoResolution.NameFromProperty(parameterAsProperty),
				value,
				ExceptionHandlingMode.Ignore);
		}

		/// <inheritdoc />
		[DebuggerStepThrough]
		public IParameter<Type> TypeParameter<T>()
		{
			return new Parameter<Type>(Invariants.DefaultTypeParameterName, typeof(T), ExceptionHandlingMode.Ignore);
		}

		/// <inheritdoc />
		[DebuggerStepThrough]
		public IParameter<Type> TypeParameter<T>(string name)
		{
			return new Parameter<Type>(name, typeof(T), ExceptionHandlingMode.Ignore);
		}
	}
}