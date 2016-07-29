using System;

// ReSharper disable once CheckNamespace
namespace JetBrains.Annotations
{
	/// <summary>
	/// Indicates that IEnumerable, passed as parameter, is not enumerated.
	/// </summary>
	[AttributeUsage(AttributeTargets.Parameter)]
#pragma warning disable SA1649 // File name must match first type name
	public sealed class NoEnumerationAttribute : Attribute
#pragma warning restore SA1649 // File name must match first type name
	{
	}
}