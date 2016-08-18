using System;
using Paravaly.Tests.Helpers;
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
		public void IsNotEmpty_for_string_Can_use_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				string.Empty,
				ParameterExtensions.IsNotEmpty);
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

		#region Contains

		[Fact]
		public void Contains_for_string_works_with_valid_strings()
		{
			CommonValidationTests.IsValid(
				"XYZ",
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
		public void Contains_for_string_adds_an_ArgumentException_if_parameter_value_is_empty()
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
		public void Contains_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.Contains("X"));
		}

		[Fact]
		public void Contains_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.Contains("X", "Error"));
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
				"X",
				p => p.IsNotEqualTo("A"));
		}

		[Fact]
		public void IsNotEqualTo_for_string_works_with_invalid_strings()
		{
			CommonValidationTests.IsNotValid(
				"A",
				p => p.IsNotEqualTo("A"));
		}

		[Fact]
		public void IsNotEqualTo_for_string_adds_an_ArgumentException_if_parameter_value_is_not_valid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				"A",
				typeof(ArgumentException),
				p => p.IsNotEqualTo("A"));
		}

		[Fact]
		public void IsNotEqualTo_for_string_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				"A",
				(p, e) => p.IsNotEqualTo("A", e));
		}

		[Fact]
		public void IsNotEqualTo_for_string_can_be_used_with_specific_comparison_type()
		{
			CommonValidationTests.IsNotValid(
				"a",
				p => p.IsNotEqualTo("A", StringComparison.OrdinalIgnoreCase));
		}

		[Fact]
		public void IsNotEqualTo_for_string_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsNotEqualTo("A"));
		}

		[Fact]
		public void IsNotEqualTo_for_string_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string>(p => p.IsNotEqualTo("A", "Error"));
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