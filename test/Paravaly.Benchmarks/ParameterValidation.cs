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

		[Benchmark]
		public bool IsNotNullOrEmpty()
		{
			return this.DoIsNotNullOrEmpty("Some test");
		}

		[Benchmark]
		public bool IsNotNullOrWhiteSpace()
		{
			return this.DoIsNotNullOrWhiteSpace("Some test");
		}

		private bool DoIsNotEmpty(string text)
		{
			return RequireAll.Parameter(nameof(text), text).IsNotEmpty().ThenGetExceptions().Any();
		}

		private bool DoIsNotWhiteSpace(string text)
		{
			return RequireAll.Parameter(nameof(text), text).IsNotWhiteSpace().ThenGetExceptions().Any();
		}

		private bool DoIsNotNullOrEmpty(string text)
		{
			return RequireAll.Parameter(nameof(text), text).IsNotNullOrEmpty().ThenGetExceptions().Any();
		}

		private bool DoIsNotNullOrWhiteSpace(string text)
		{
			return RequireAll.Parameter(nameof(text), text).IsNotNullOrWhiteSpace().ThenGetExceptions().Any();
		}
	}
}