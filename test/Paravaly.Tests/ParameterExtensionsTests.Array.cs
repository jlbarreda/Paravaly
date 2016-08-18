using System;
using System.Globalization;
using System.Linq;
using Paravaly.Tests.Helpers;
using Xunit;

namespace Paravaly.Tests
{
	public sealed partial class ParameterExtensionsTests
	{
		#region IsNotEmpty

		[Fact]
		public void IsNotEmpty_for_array_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				Enumerable.Range(1, 1).ToArray(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_array_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				Enumerable.Empty<CultureInfo>().ToArray(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_array_adds_an_ArgumentException_if_parameter_value_is_empty()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				Enumerable.Empty<CultureInfo>().ToArray(),
				typeof(ArgumentException),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_array_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				Enumerable.Empty<CultureInfo>().ToArray(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_array_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo[]>(
				p => p.IsNotEmpty());
		}

		[Fact]
		public void IsNotEmpty_for_array_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo[]>(
				p => p.IsNotEmpty(string.Empty));
		}

		#endregion

		#region All

		[Fact]
		public void All_for_array_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				new[] { "A", "B" },
				p => p.All(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void All_for_array_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				new[] { "A", null, "B" },
				p => p.All(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void All_for_array_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				new[] { "A", null, "B" },
				typeof(ArgumentException),
				p => p.All(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void All_for_array_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				new[] { "A", null, "B" },
				(p, e) => p.All(x => !string.IsNullOrEmpty(x), e));
		}

		[Fact]
		public void All_for_array_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string[]>(
				p => p.All(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void All_for_array_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string[]>(
				p => p.All(x => !string.IsNullOrEmpty(x), "Error"));
		}

		#endregion

		#region Any

		[Fact]
		public void Any_for_array_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				new[] { "A", "B" },
				p => p.Any(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void Any_for_array_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				new[] { string.Empty, null },
				p => p.Any(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void Any_for_array_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				new[] { string.Empty, null },
				typeof(ArgumentException),
				p => p.Any(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void Any_for_array_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				new[] { string.Empty, null },
				(p, e) => p.Any(x => !string.IsNullOrEmpty(x), e));
		}

		[Fact]
		public void Any_for_array_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string[]>(
				p => p.Any(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void Any_for_array_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string[]>(
				p => p.Any(x => !string.IsNullOrEmpty(x), "Error"));
		}

		#endregion

		#region None

		[Fact]
		public void None_for_array_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				new[] { "A", "B" },
				p => p.None(x => string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void None_for_array_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				new[] { "A", null, "B" },
				p => p.None(x => string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void None_for_array_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				new[] { "A", null, "B" },
				typeof(ArgumentException),
				p => p.None(x => string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void None_for_array_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				new[] { "A", null, "B" },
				(p, e) => p.None(x => string.IsNullOrEmpty(x), e));
		}

		[Fact]
		public void None_for_array_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string[]>(
				p => p.None(x => string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void None_for_array_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<string[]>(
				p => p.None(x => string.IsNullOrEmpty(x), "Error"));
		}

		#endregion

		#region HasNoNullElements for array of nullables

		[Fact]
		public void HasNoNullElements_for_array_of_nullables_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				new int?[] { 1, 2 },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_array_of_nullables_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				new int?[] { 1, null, 2 },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_array_of_nullables_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				new int?[] { 1, null, 2 },
				typeof(ArgumentException),
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_array_of_nullables_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				new int?[] { 1, null, 2 },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_array_of_nullables_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int?[]>(
				p => p.HasNoNullElements());
		}

		[Fact]
		public void HasNoNullElements_for_array_of_nullables_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int?[]>(
				p => p.HasNoNullElements("Error"));
		}

		#endregion

		#region HasNoNullElements

		[Fact]
		public void HasNoNullElements_for_array_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				new[] { "A", "B" },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_array_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				new[] { "A", null, "B" },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_array_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				new[] { "A", null, "B" },
				typeof(ArgumentException),
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_array_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				new[] { "A", null, "B" },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_array_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo[]>(
				p => p.HasNoNullElements());
		}

		[Fact]
		public void HasNoNullElements_for_array_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo[]>(
				p => p.HasNoNullElements("Error"));
		}

		#endregion

		#region HasLengthWithinRange

		[Fact]
		public void HasLengthWithinRange_for_array_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				Enumerable.Range(1, 1).ToArray(),
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_array_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				Enumerable.Empty<CultureInfo>().ToArray(),
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_array_adds_an_ArgumentOutOfRangeException_if_parameter_value_length_is_out_of_range()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				Enumerable.Empty<CultureInfo>().ToArray(),
				typeof(ArgumentOutOfRangeException),
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_array_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				Enumerable.Empty<CultureInfo>().ToArray(),
				(p, e) => p.HasLengthWithinRange(1, 1, e));
		}

		[Fact]
		public void HasLengthWithinRange_for_array_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo[]>(
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_array_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo[]>(
				p => p.HasLengthWithinRange(1, 1, string.Empty));
		}

		#endregion
	}
}