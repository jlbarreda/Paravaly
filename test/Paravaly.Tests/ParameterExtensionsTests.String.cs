using System;
using Paravaly.Tests.Helpers;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public sealed partial class ParameterExtensionsTests
	{
		#region IsNotEmpty

		[Fact]
		public void IsNotEmpty_for_string_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"X",
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_string_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_string_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				string.Empty,
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_string_adds_an_ArgumentException_if_parameter_value_is_empty()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				string.Empty,
				typeof(ArgumentException),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_string_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				string.Empty,
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = string.Empty;
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).IsNotEmpty(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotEmpty_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsNotEmpty());
		}

		[Fact]
		public void IsNotEmpty_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsNotEmpty("Error"));
		}

		#endregion

		#region IsNotNullOrEmpty

		[Fact]
		public void IsNotNullOrEmpty_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"X",
				ParameterExtensions.IsNotNullOrEmpty);
		}

		[Fact]
		public void IsNotNullOrEmpty_works_with_null_strings()
		{
			CommonValidationTests.IsNotValid(
				(string)null,
				ParameterExtensions.IsNotNullOrEmpty);
		}

		[Fact]
		public void IsNotNullOrEmpty_works_with_empty_strings()
		{
			CommonValidationTests.IsNotValid(
				string.Empty,
				ParameterExtensions.IsNotNullOrEmpty);
		}

		[Fact]
		public void IsNotNullOrEmpty_adds_an_ArgumentNullException_if_parameter_value_is_null()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				(string)null,
				typeof(ArgumentNullException),
				ParameterExtensions.IsNotNullOrEmpty);
		}

		[Fact]
		public void IsNotNullOrEmpty_adds_an_ArgumentException_if_parameter_value_is_empty()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				string.Empty,
				typeof(ArgumentException),
				ParameterExtensions.IsNotNullOrEmpty);
		}

		[Fact]
		public void IsNotNullOrEmpty_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				string.Empty,
				ParameterExtensions.IsNotNullOrEmpty);
		}

		[Fact]
		public void IsNotNullOrEmpty_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = string.Empty;
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).IsNotNullOrEmpty(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotNullOrEmpty_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsNotNullOrEmpty());
		}

		[Fact]
		public void IsNotNullOrEmpty_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsNotNullOrEmpty("Error"));
		}

		#endregion

		#region IsNotNullOrWhiteSpace

		[Fact]
		public void IsNotNullOrWhiteSpace_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"X",
				ParameterExtensions.IsNotNullOrWhiteSpace);
		}

		[Fact]
		public void IsNotNullOrWhiteSpace_works_with_null_strings()
		{
			CommonValidationTests.IsNotValid(
				(string)null,
				ParameterExtensions.IsNotNullOrWhiteSpace);
		}

		[Fact]
		public void IsNotNullOrWhiteSpace_works_with_empty_strings()
		{
			CommonValidationTests.IsNotValid(
				string.Empty,
				ParameterExtensions.IsNotNullOrWhiteSpace);
		}

		[Fact]
		public void IsNotNullOrWhiteSpace_works_with_white_space()
		{
			CommonValidationTests.IsNotValid(
				" \r\n\t",
				ParameterExtensions.IsNotNullOrWhiteSpace);
		}

		[Fact]
		public void IsNotNullOrWhiteSpace_adds_an_ArgumentNullException_if_parameter_value_is_null()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				(string)null,
				typeof(ArgumentNullException),
				ParameterExtensions.IsNotNullOrWhiteSpace);
		}

		[Fact]
		public void IsNotNullOrWhiteSpace_adds_an_ArgumentException_if_parameter_value_is_empty()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				string.Empty,
				typeof(ArgumentException),
				ParameterExtensions.IsNotNullOrWhiteSpace);
		}

		[Fact]
		public void IsNotNullOrWhiteSpace_adds_an_ArgumentException_if_parameter_value_is_white_space()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				" \r\n\t",
				typeof(ArgumentException),
				ParameterExtensions.IsNotNullOrWhiteSpace);
		}

		[Fact]
		public void Can_use_IsNotNullOrWhiteSpace_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				string.Empty,
				ParameterExtensions.IsNotNullOrWhiteSpace);
		}

		[Fact]
		public void IsNotNullOrWhiteSpace_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = string.Empty;
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).IsNotNullOrWhiteSpace(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotNullOrWhiteSpace_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsNotNullOrWhiteSpace());
		}

		[Fact]
		public void IsNotNullOrWhiteSpace_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsNotNullOrWhiteSpace("Error"));
		}

		#endregion

		#region StartsWith

		[Fact]
		public void StartsWith_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.StartsWith("X"));
		}

		[Fact]
		public void StartsWith_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.StartsWith("X"));
		}

		[Fact]
		public void StartsWith_works_with_valid_strings_and_comparison_type()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.StartsWith("x", StringComparison.OrdinalIgnoreCase));
		}

		[Fact]
		public void StartsWith_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				"XYZ",
				p => p.StartsWith("Y"));
		}

		[Fact]
		public void StartsWith_works_with_invalid_strings_and_comparison_type()
		{
			CommonValidationTests.IsNotValid(
				"XYZ",
				p => p.StartsWith("x", StringComparison.Ordinal));
		}

		[Fact]
		public void StartsWith_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"XYZ",
				typeof(ArgumentException),
				p => p.StartsWith("y"));
		}

		[Fact]
		public void StartsWith_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				"XYZ",
				(p, e) => p.StartsWith("y", e));
		}

		[Fact]
		public void StartsWith_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = "XYZ";
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).StartsWith("y", p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void StartsWith_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.StartsWith("X"));
		}

		[Fact]
		public void StartsWith_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.StartsWith("X", "Error"));
		}

		#endregion

		#region DoesNotStartWith

		[Fact]
		public void DoesNotStartWith_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.DoesNotStartWith("y"));
		}

		[Fact]
		public void DoesNotStartWith_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.DoesNotStartWith("X"));
		}

		[Fact]
		public void DoesNotStartWith_works_with_valid_strings_and_comparison_type()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.DoesNotStartWith("Y", StringComparison.OrdinalIgnoreCase));
		}

		[Fact]
		public void DoesNotStartWith_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				"XYZ",
				p => p.DoesNotStartWith("X"));
		}

		[Fact]
		public void DoesNotStartWith_works_with_invalid_strings_and_comparison_type()
		{
			CommonValidationTests.IsNotValid(
				"XYZ",
				p => p.DoesNotStartWith("X", StringComparison.Ordinal));
		}

		[Fact]
		public void DoesNotStartWith_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"XYZ",
				typeof(ArgumentException),
				p => p.DoesNotStartWith("X"));
		}

		[Fact]
		public void DoesNotStartWith_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				"XYZ",
				(p, e) => p.DoesNotStartWith("X", e));
		}

		[Fact]
		public void DoesNotStartWith_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = "XYZ";
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).DoesNotStartWith("X", p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void DoesNotStartWith_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.DoesNotStartWith("X"));
		}

		[Fact]
		public void DoesNotStartWith_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.DoesNotStartWith("X", "Error"));
		}

		#endregion

		#region Contains

		[Fact]
		public void Contains_for_string_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.Contains("Y"));
		}

		[Fact]
		public void Contains_for_string_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.Contains("Y"));
		}

		[Fact]
		public void Contains_for_string_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				string.Empty,
				p => p.Contains("X"));
		}

		[Fact]
		public void Contains_for_string_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"YZ",
				typeof(ArgumentException),
				p => p.Contains("X"));
		}

		[Fact]
		public void Contains_for_string_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				string.Empty,
				(p, e) => p.Contains("X", e));
		}

		[Fact]
		public void Contains_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = string.Empty;
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).Contains("X", p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void Contains_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.Contains("X"));
		}

		[Fact]
		public void Contains_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.Contains("X", "Error"));
		}

		[Fact]
		public void Contains_with_comparison_parameter_for_string_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.Contains("Y", StringComparison.Ordinal));
		}

		[Fact]
		public void Contains_with_comparison_parameter_for_string_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.Contains("Y", StringComparison.Ordinal));
		}

		[Fact]
		public void Contains_with_comparison_parameter_for_string_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				string.Empty,
				p => p.Contains("X", StringComparison.Ordinal));
		}

		[Fact]
		public void Contains_with_comparison_parameter_for_string_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"YZ",
				typeof(ArgumentException),
				p => p.Contains("X", StringComparison.Ordinal));
		}

		[Fact]
		public void Contains_with_comparison_parameter_for_string_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				string.Empty,
				(p, e) => p.Contains("X", StringComparison.Ordinal, e));
		}

		[Fact]
		public void Contains_with_comparison_parameter_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = string.Empty;
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.Contains("X", StringComparison.Ordinal, p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void Contains_with_comparison_parameter_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(
				p => p.Contains("X", StringComparison.Ordinal));
		}

		[Fact]
		public void Contains_with_comparison_parameter_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(
				p => p.Contains("X", StringComparison.Ordinal, "Error"));
		}

		#endregion

		#region DoesNotContain

		[Fact]
		public void DoesNotContain_for_string_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.DoesNotContain("A"));
		}

		[Fact]
		public void DoesNotContain_for_string_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.DoesNotContain("Y"));
		}

		[Fact]
		public void DoesNotContain_for_string_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				"X",
				p => p.DoesNotContain("X"));
		}

		[Fact]
		public void DoesNotContain_for_string_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"XYZ",
				typeof(ArgumentException),
				p => p.DoesNotContain("X"));
		}

		[Fact]
		public void DoesNotContain_for_string_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				"X",
				(p, e) => p.DoesNotContain("X", e));
		}

		[Fact]
		public void DoesNotContain_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = "X";
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).DoesNotContain("X", p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void DoesNotContain_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.DoesNotContain("X"));
		}

		[Fact]
		public void DoesNotContain_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.DoesNotContain("X", "Error"));
		}

		[Fact]
		public void DoesNotContain_with_comparison_parameter_for_string_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.DoesNotContain("A", StringComparison.Ordinal));
		}

		[Fact]
		public void DoesNotContain_with_comparison_parameter_for_string_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.DoesNotContain("Y", StringComparison.Ordinal));
		}

		[Fact]
		public void DoesNotContain_with_comparison_parameter_for_string_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				"X",
				p => p.DoesNotContain("X", StringComparison.Ordinal));
		}

		[Fact]
		public void DoesNotContain_with_comparison_parameter_for_string_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"XYZ",
				typeof(ArgumentException),
				p => p.DoesNotContain("X", StringComparison.Ordinal));
		}

		[Fact]
		public void DoesNotContain_with_comparison_parameter_for_string_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				"X",
				(p, e) => p.DoesNotContain("X", StringComparison.Ordinal, e));
		}

		[Fact]
		public void DoesNotContain_with_comparison_parameter_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = "X";
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.DoesNotContain("X", StringComparison.Ordinal, p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void DoesNotContain_with_comparison_parameter_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(
				p => p.DoesNotContain("X", StringComparison.Ordinal));
		}

		[Fact]
		public void DoesNotContain_with_comparison_parameter_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(
				p => p.DoesNotContain("X", StringComparison.Ordinal, "Error"));
		}

		#endregion

		#region EndsWith

		[Fact]
		public void EndsWith_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.EndsWith("Z"));
		}

		[Fact]
		public void EndsWith_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.EndsWith("Z"));
		}

		[Fact]
		public void EndsWith_works_with_valid_strings_and_comparison_type()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.EndsWith("z", StringComparison.OrdinalIgnoreCase));
		}

		[Fact]
		public void EndsWith_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				"XYZ",
				p => p.EndsWith("Y"));
		}

		[Fact]
		public void EndsWith_works_with_invalid_strings_and_comparison_type()
		{
			CommonValidationTests.IsNotValid(
				"XYZ",
				p => p.EndsWith("z", StringComparison.Ordinal));
		}

		[Fact]
		public void EndsWith_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"XYZ",
				typeof(ArgumentException),
				p => p.EndsWith("y"));
		}

		[Fact]
		public void EndsWith_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				"XYZ",
				(p, e) => p.EndsWith("y", e));
		}

		[Fact]
		public void EndsWith_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = "XYZ";
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).EndsWith("y", p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void EndsWith_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.EndsWith("X"));
		}

		[Fact]
		public void EndsWith_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.EndsWith("X", "Error"));
		}

		#endregion

		#region DoesNotEndWith

		[Fact]
		public void DoesNotEndWith_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.DoesNotEndWith("A"));
		}

		[Fact]
		public void DoesNotEndWith_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.DoesNotEndWith("Z"));
		}

		[Fact]
		public void DoesNotEndWith_works_with_valid_strings_and_comparison_type()
		{
			CommonValidationTests.IsValid(
				"XYZ",
				p => p.DoesNotEndWith("y", StringComparison.OrdinalIgnoreCase));
		}

		[Fact]
		public void DoesNotEndWith_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				"XYZ",
				p => p.DoesNotEndWith("Z"));
		}

		[Fact]
		public void DoesNotEndWith_works_with_invalid_strings_and_comparison_type()
		{
			CommonValidationTests.IsNotValid(
				"XYZ",
				p => p.DoesNotEndWith("z", StringComparison.OrdinalIgnoreCase));
		}

		[Fact]
		public void DoesNotEndWith_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"XYZ",
				typeof(ArgumentException),
				p => p.DoesNotEndWith("Z"));
		}

		[Fact]
		public void DoesNotEndWith_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				"XYZ",
				(p, e) => p.DoesNotEndWith("Z", e));
		}

		[Fact]
		public void DoesNotEndWith_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = "XYZ";
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).DoesNotEndWith("Z", p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void DoesNotEndWith_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.DoesNotEndWith("X"));
		}

		[Fact]
		public void DoesNotEndWith_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.DoesNotEndWith("X", "Error"));
		}

		#endregion

		#region IsMatch

		[Fact]
		public void IsMatch_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"X",
				p => p.IsMatch("X{1}"));
		}

		[Fact]
		public void IsMatch_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.IsMatch("X{1}"));
		}

		[Fact]
		public void IsMatch_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				string.Empty,
				p => p.IsMatch("X{1}"));
		}

		[Fact]
		public void IsMatch_adds_an_ArgumentException_if_parameter_value_is_empty()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				string.Empty,
				typeof(ArgumentException),
				p => p.IsMatch("X{1}"));
		}

		[Fact]
		public void IsMatch_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				string.Empty,
				(p, e) => p.IsMatch("X{1}", e));
		}

		[Fact]
		public void IsMatch_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = string.Empty;
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).IsMatch("X{1}", p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsMatch_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsMatch("X{1}"));
		}

		[Fact]
		public void IsMatch_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsMatch("X{1}", "Error"));
		}

		#endregion

		#region IsNotEqualTo

		[Fact]
		public void IsNotEqualTo_for_string_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				new[] { "X", "a" },
				p => p.IsNotEqualTo("A", StringComparison.Ordinal));
		}

		[Fact]
		public void IsNotEqualTo_for_string_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.IsNotEqualTo("A", StringComparison.Ordinal));
		}

		[Fact]
		public void IsNotEqualTo_for_string_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				new[] { "A", "a" },
				p => p.IsNotEqualTo("A", StringComparison.OrdinalIgnoreCase));
		}

		[Fact]
		public void IsNotEqualTo_for_string_adds_an_ArgumentException_if_parameter_value_is_not_valid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"A",
				typeof(ArgumentException),
				p => p.IsNotEqualTo("A", StringComparison.Ordinal));
		}

		[Fact]
		public void IsNotEqualTo_for_string_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				"A",
				(p, e) => p.IsNotEqualTo("A", StringComparison.Ordinal, e));
		}

		[Fact]
		public void IsNotEqualTo_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = "A";
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).IsNotEqualTo("A", p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotEqualTo_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsNotEqualTo("A", StringComparison.Ordinal));
		}

		[Fact]
		public void IsNotEqualTo_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(
				p => p.IsNotEqualTo("A", StringComparison.Ordinal, "Error"));
		}

		#endregion

		#region HasLengthWithinRange

		[Fact]
		public void HasLengthWithinRange_for_string_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"X",
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_string_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_string_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				string.Empty,
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_string_adds_an_ArgumentOutOfRangeException_if_parameter_value_length_is_out_of_range()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				string.Empty,
				typeof(ArgumentOutOfRangeException),
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_string_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				string.Empty,
				(p, e) => p.HasLengthWithinRange(1, 1, e));
		}

		[Fact]
		public void HasLengthWithinRange_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = string.Empty;
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).HasLengthWithinRange(1, 1, p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void HasLengthWithinRange_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(
				p => p.HasLengthWithinRange(1, 1, string.Empty));
		}

		#endregion

		#region HasLength

		[Fact]
		public void HasLength_for_string_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"X",
				p => p.HasLength(1));
		}

		[Fact]
		public void HasLength_for_string_works_with_null_strings()
		{
			CommonValidationTests.IsValid(
				(string)null,
				p => p.HasLength(1));
		}

		[Fact]
		public void HasLength_for_string_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				string.Empty,
				p => p.HasLength(1));
		}

		[Fact]
		public void HasLength_for_string_adds_an_ArgumentException_if_parameter_value_length_is_out_of_range()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				string.Empty,
				typeof(ArgumentException),
				p => p.HasLength(1));
		}

		[Fact]
		public void HasLength_for_string_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				string.Empty,
				(p, e) => p.HasLength(1, e));
		}

		[Fact]
		public void HasLength_for_string_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = string.Empty;
			var exception = new Exception();

			// When
			var result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).HasLength(1, p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void HasLength_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(
				p => p.HasLength(1));
		}

		[Fact]
		public void HasLength_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(
				p => p.HasLength(1, string.Empty));
		}

		#endregion
	}
}