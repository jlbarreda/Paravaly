using System;
using BenchmarkDotNet.Attributes;

namespace Paravaly.Benchmarks
{
	public class StringValidations
	{
		private readonly IParameter<string> parameter = RequireAll.Parameter(nameof(parameter), Guid.NewGuid().ToString());

		[Benchmark]
		public IValidatingParameter<string> IsNotEmpty()
		{
			return parameter.IsNotEmpty();
		}

		[Benchmark]
		public IValidatingParameter<string> IsNotWhiteSpace()
		{
			return parameter.IsNotWhiteSpace();
		}

		[Benchmark]
		public IValidatingParameter<string> IsNotNullOrEmpty()
		{
			return parameter.IsNotNullOrEmpty();
		}

		[Benchmark]
		public IValidatingParameter<string> IsNotNullOrWhiteSpace()
		{
			return parameter.IsNotNullOrWhiteSpace();
		}
	}
}