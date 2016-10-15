using System;
using BenchmarkDotNet.Attributes;

namespace Paravaly.Benchmarks
{
	public class EnumValidations
	{
		private readonly IParameter<StringComparison> parameter = RequireAll.Parameter(nameof(parameter), StringComparison.Ordinal);

		[Benchmark]
		public IValidatingParameter<StringComparison> IsValidEnumValue()
		{
			return parameter.IsValidEnumValue();
		}
	}
}