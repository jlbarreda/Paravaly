using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Paravaly.Benchmarks
{
	public class ParameterValidation
	{
		[Benchmark]
		public bool IsNotEmpty()
		{
			return this.DoIsNotEmpty("Some test");
		}

		[Benchmark]
		public bool IsNotWhiteSpace()
		{
			return this.DoIsNotWhiteSpace("Some test");
		}

		private bool DoIsNotEmpty(string text)
		{
			return RequireAll.Parameter(nameof(text), text).IsNotEmpty().ThenGetExceptions().Any();
		}

		private bool DoIsNotWhiteSpace(string text)
		{
			return RequireAll.Parameter(nameof(text), text).IsNotWhiteSpace().ThenGetExceptions().Any();
		}
	}
}