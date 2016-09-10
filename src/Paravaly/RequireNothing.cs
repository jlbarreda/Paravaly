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
	}
}