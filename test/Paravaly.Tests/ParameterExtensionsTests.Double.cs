using System;
using Paravaly.Tests.Helpers;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public sealed partial class ParameterExtensionsTests
	{
		#region IsNotNaN

		[Fact]
		public void IsNotNaN_for_double_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1D,
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_for_double_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				double.NaN,
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_for_double_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				double.NaN,
				typeof(ArgumentOutOfRangeException),
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_for_double_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				double.NaN,
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_for_double_can_be_used_with_custom_exception()
		{
			// Given
			double invalidValue = double.NaN;
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).IsNotNaN(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotNaN_for_double_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotNaN());
		}

		[Fact]
		public void IsNotNaN_for_double_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotNaN("Error"));
		}

		#endregion

		#region IsNotInfinity

		[Fact]
		public void IsNotInfinity_for_double_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1D,
				ParameterExtensions.IsNotInfinity);
		}

		[Fact]
		public void IsNotInfinity_for_double_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				double.PositiveInfinity,
				ParameterExtensions.IsNotInfinity);
		}

		[Fact]
		public void IsNotInfinity_for_double_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				double.PositiveInfinity,
				typeof(ArgumentOutOfRangeException),
				ParameterExtensions.IsNotInfinity);
		}

		[Fact]
		public void IsNotInfinity_for_double_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				double.PositiveInfinity,
				ParameterExtensions.IsNotInfinity);
		}

		[Fact]
		public void IsNotInfinity_for_double_can_be_used_with_custom_exception()
		{
			// Given
			double invalidValue = double.PositiveInfinity;
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsNotInfinity(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotInfinity_for_double_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotInfinity());
		}

		[Fact]
		public void IsNotInfinity_for_double_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotInfinity("Error"));
		}

		#endregion

		#region IsNotNegativeInfinity

		[Fact]
		public void IsNotNegativeInfinity_for_double_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1D,
				ParameterExtensions.IsNotNegativeInfinity);
		}

		[Fact]
		public void IsNotNegativeInfinity_for_double_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				double.NegativeInfinity,
				ParameterExtensions.IsNotNegativeInfinity);
		}

		[Fact]
		public void IsNotNegativeInfinity_for_double_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				double.NegativeInfinity,
				typeof(ArgumentOutOfRangeException),
				ParameterExtensions.IsNotNegativeInfinity);
		}

		[Fact]
		public void IsNotNegativeInfinity_for_double_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				double.NegativeInfinity,
				ParameterExtensions.IsNotNegativeInfinity);
		}

		[Fact]
		public void IsNotNegativeInfinity_for_double_can_be_used_with_custom_exception()
		{
			// Given
			double invalidValue = double.NegativeInfinity;
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsNotNegativeInfinity(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotNegativeInfinity_for_double_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotNegativeInfinity());
		}

		[Fact]
		public void IsNotNegativeInfinity_for_double_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotNegativeInfinity("Error"));
		}

		#endregion

		#region IsNotPositiveInfinity

		[Fact]
		public void IsNotPositiveInfinity_for_double_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1D,
				ParameterExtensions.IsNotPositiveInfinity);
		}

		[Fact]
		public void IsNotPositiveInfinity_for_double_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				double.PositiveInfinity,
				ParameterExtensions.IsNotPositiveInfinity);
		}

		[Fact]
		public void IsNotPositiveInfinity_for_double_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				double.PositiveInfinity,
				typeof(ArgumentOutOfRangeException),
				ParameterExtensions.IsNotPositiveInfinity);
		}

		[Fact]
		public void IsNotPositiveInfinity_for_double_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				double.PositiveInfinity,
				ParameterExtensions.IsNotPositiveInfinity);
		}

		[Fact]
		public void IsNotPositiveInfinity_for_double_can_be_used_with_custom_exception()
		{
			// Given
			double invalidValue = double.PositiveInfinity;
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsNotPositiveInfinity(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotPositiveInfinity_for_double_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotPositiveInfinity());
		}

		[Fact]
		public void IsNotPositiveInfinity_for_double_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotPositiveInfinity("Error"));
		}

		#endregion
	}
}