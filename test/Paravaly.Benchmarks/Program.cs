using System;
using BenchmarkDotNet.Running;

namespace Paravaly.Benchmarks
{
	public class Program
	{
		public static void Main()
		{
			var summary = BenchmarkRunner.Run<EnumValidations>();

			Console.WriteLine();
			Console.WriteLine("Done...");
			Console.ReadKey();
		}
	}
}