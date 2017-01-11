using System;
using BenchmarkDotNet.Attributes;

namespace Paravaly.Benchmarks
{
	public class EnumValidations
	{
		private readonly IParameter<StringComparison> parameter = RequireAll.Parameter(nameof(parameter), StringComparison.Ordinal);

		private readonly IParameter<StringComparison> invalidParameter = RequireAll.Parameter(nameof(invalidParameter), (StringComparison)13000);

		[Benchmark]
		public IValidatingParameter<StringComparison> IsValidEnumValue()
		{
			return parameter.IsValidEnumValue();
		}

		[Benchmark]
		public IValidatingParameter<StringComparison> IsNotValidEnumValue()
		{
			return invalidParameter.IsValidEnumValue();
		}
	}
}