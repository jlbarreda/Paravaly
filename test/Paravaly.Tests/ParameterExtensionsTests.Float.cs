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
		public void IsNotNaN_for_float_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1F,
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_for_float_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				float.NaN,
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_for_float_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				float.NaN,
				typeof(ArgumentOutOfRangeException),
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_for_float_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				float.NaN,
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_for_float_can_be_used_with_custom_exception()
		{
			// Given
			float invalidValue = float.NaN;
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsNotNaN(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotNaN_for_float_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<float>(
				p => p.IsNotNaN());
		}

		[Fact]
		public void IsNotNaN_for_float_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<float>(
				p => p.IsNotNaN("Error"));
		}

		#endregion

		#region IsNotInfinity

		[Fact]
		public void IsNotInfinity_for_float_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1D,
				ParameterExtensions.IsNotInfinity);
		}

		[Fact]
		public void IsNotInfinity_for_float_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				float.PositiveInfinity,
				ParameterExtensions.IsNotInfinity);
		}

		[Fact]
		public void IsNotInfinity_for_float_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				float.PositiveInfinity,
				typeof(ArgumentOutOfRangeException),
				ParameterExtensions.IsNotInfinity);
		}

		[Fact]
		public void IsNotInfinity_for_float_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				float.PositiveInfinity,
				ParameterExtensions.IsNotInfinity);
		}

		[Fact]
		public void IsNotInfinity_for_float_can_be_used_with_custom_exception()
		{
			// Given
			float invalidValue = float.PositiveInfinity;
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
		public void IsNotInfinity_for_float_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<float>(
				p => p.IsNotInfinity());
		}

		[Fact]
		public void IsNotInfinity_for_float_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<float>(
				p => p.IsNotInfinity("Error"));
		}

		#endregion

		#region IsNotNegativeInfinity

		[Fact]
		public void IsNotNegativeInfinity_for_float_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1D,
				ParameterExtensions.IsNotNegativeInfinity);
		}

		[Fact]
		public void IsNotNegativeInfinity_for_float_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				float.NegativeInfinity,
				ParameterExtensions.IsNotNegativeInfinity);
		}

		[Fact]
		public void IsNotNegativeInfinity_for_float_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				float.NegativeInfinity,
				typeof(ArgumentOutOfRangeException),
				ParameterExtensions.IsNotNegativeInfinity);
		}

		[Fact]
		public void IsNotNegativeInfinity_for_float_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				float.NegativeInfinity,
				ParameterExtensions.IsNotNegativeInfinity);
		}

		[Fact]
		public void IsNotNegativeInfinity_for_float_can_be_used_with_custom_exception()
		{
			// Given
			float invalidValue = float.NegativeInfinity;
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
		public void IsNotNegativeInfinity_for_float_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<float>(
				p => p.IsNotNegativeInfinity());
		}

		[Fact]
		public void IsNotNegativeInfinity_for_float_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<float>(
				p => p.IsNotNegativeInfinity("Error"));
		}

		#endregion

		#region IsNotPositiveInfinity

		[Fact]
		public void IsNotPositiveInfinity_for_float_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1D,
				ParameterExtensions.IsNotPositiveInfinity);
		}

		[Fact]
		public void IsNotPositiveInfinity_for_float_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				float.PositiveInfinity,
				ParameterExtensions.IsNotPositiveInfinity);
		}

		[Fact]
		public void IsNotPositiveInfinity_for_float_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				float.PositiveInfinity,
				typeof(ArgumentOutOfRangeException),
				ParameterExtensions.IsNotPositiveInfinity);
		}

		[Fact]
		public void IsNotPositiveInfinity_for_float_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				float.PositiveInfinity,
				ParameterExtensions.IsNotPositiveInfinity);
		}

		[Fact]
		public void IsNotPositiveInfinity_for_float_can_be_used_with_custom_exception()
		{
			// Given
			float invalidValue = float.PositiveInfinity;
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
		public void IsNotPositiveInfinity_for_float_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<float>(
				p => p.IsNotPositiveInfinity());
		}

		[Fact]
		public void IsNotPositiveInfinity_for_float_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<float>(
				p => p.IsNotPositiveInfinity("Error"));
		}

		#endregion
	}
}