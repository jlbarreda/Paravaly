using System;
using BenchmarkDotNet.Running;

namespace Paravaly.Benchmarks
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<ParameterValidation>();

			Console.WriteLine();
			Console.WriteLine("Done...");
			Console.ReadKey();
		}
	}
}