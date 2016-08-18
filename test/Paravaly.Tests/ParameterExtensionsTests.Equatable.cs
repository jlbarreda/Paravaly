using System;
using Paravaly.Tests.Helpers;
using Xunit;

namespace Paravaly.Tests
{
	public sealed partial class ParameterExtensionsTests
	{
		#region IsIn

		[Fact]
		public void IsIn_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1,
				p => p.IsIn(1, 2));
		}

		[Fact]
		public void IsIn_works_with_null_valid_values()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.IsIn(null, "A", "B"));
		}

		[Fact]
		public void IsIn_works_with_null_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				(string)null,
				p => p.IsIn("A", "B"));
		}

		[Fact]
		public void IsIn_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0,
				p => p.IsIn(1, 2));
		}

		[Fact]
		public void IsIn_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_out_of_range()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				0,
				typeof(ArgumentOutOfRangeException),
				p => p.IsIn(1, 2));
		}

		[Fact]
		public void IsIn_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				0,
				(p, e) => p.IsIn(new[] { 1, 2 }, e));
		}

		[Fact]
		public void IsIn_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsIn(1, 2));
		}

		[Fact]
		public void IsIn_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsIn(new[] { 1, 2 }, "Error"));
		}

		#endregion
	}
}