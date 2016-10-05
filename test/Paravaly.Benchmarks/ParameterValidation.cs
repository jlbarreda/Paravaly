using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Paravaly.Benchmarks.Paravaly2;

namespace Paravaly.Benchmarks
{
	public class ParameterValidation
	{
		[Benchmark]
		public bool IsNotWhiteSpace()
		{
			return this.DoIsNotWhiteSpace("Some test");
		}

		[Benchmark]
		public bool IsNotEmpty()
		{
			return this.DoIsNotEmpty("Some test");
		}

		[Benchmark]
		public bool LocalIsNotEmpty()
		{
			return this.DoLocalIsNotEmpty("Some test");
		}

		//[Benchmark]
		//public bool RawIsNotEmpty()
		//{
		//	return this.DoRawIsNotEmpty("Some test");
		//}

		private bool DoIsNotWhiteSpace(string text)
		{
			return RequireAll.Parameter(nameof(text), text).IsNotWhiteSpace().ThenGetExceptions().Any();
		}

		private bool DoIsNotEmpty(string text)
		{
			return RequireAll.Parameter(nameof(text), text).IsNotEmpty().ThenGetExceptions().Any();
		}

		private bool DoLocalIsNotEmpty(string text)
		{
			return new Parameter2<string>(nameof(text), text).IsNotEmpty().ThenGetExceptions().Any();
		}

		private bool DoRawIsNotEmpty(string text)
		{
			var exceptions = new List<Exception>();

			if (text == null)
			{
				throw new ArgumentNullException(nameof(text));
			}

			if (string.IsNullOrWhiteSpace(text))
			{
				if (string.IsNullOrEmpty(text))
				{
					throw new ArgumentException("ErrorMessage.ForEmpty", nameof(text));
				}

				throw new ArgumentException("ErrorMessage.ForWhiteSpace", nameof(text));
			}

			if (exceptions == null)
			{
				throw new ArgumentNullException(nameof(exceptions));
			}

			if (this.IsValid(
				x => x?.Length < 1,
				text))
			{
				exceptions.Add(new ArgumentException("Error", nameof(text)));
			}

			return exceptions.Any();
		}

		private bool IsValid(Func<string, bool> isValid, string text)
		{
			if (isValid == null)
			{
				throw new ArgumentNullException(nameof(isValid));
			}

			return isValid(text);
		}
	}
}