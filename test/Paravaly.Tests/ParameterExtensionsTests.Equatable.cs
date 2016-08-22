using System;
using Paravaly.Tests.Helpers;
using Shouldly;
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
		public void IsIn_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
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

		[Fact]
		public void IsIn_with_error_message_throws_if_validValues_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", "x").IsIn(null));
		}

		#endregion

		#region IsNotIn

		[Fact]
		public void IsNotIn_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				3,
				p => p.IsNotIn(1, 2));
		}

		[Fact]
		public void IsNotIn_works_with_null_valid_values()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.IsNotIn("A", "B"));
		}

		[Fact]
		public void IsNotIn_works_with_null_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				(string)null,
				p => p.IsNotIn(null, "A", "B"));
		}

		[Fact]
		public void IsNotIn_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				1,
				p => p.IsNotIn(1, 2));
		}

		[Fact]
		public void IsNotIn_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				1,
				typeof(ArgumentException),
				p => p.IsNotIn(1, 2));
		}

		[Fact]
		public void IsNotIn_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				1,
				(p, e) => p.IsNotIn(new[] { 1, 2 }, e));
		}

		[Fact]
		public void IsNotIn_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsNotIn(1, 2));
		}

		[Fact]
		public void IsNotIn_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsNotIn(new[] { 1, 2 }, "Error"));
		}

		[Fact]
		public void IsNotIn_with_error_message_throws_if_validValues_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", "x").IsNotIn(null));
		}

		#endregion
	}
}