using System;
using System.Globalization;
using System.Linq;
using Paravaly.Tests.Helpers;
using Shouldly;
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
		public void IsNotEmpty_for_array_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(int[])null,
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_array_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				ArrayHelper.Empty<CultureInfo>(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_array_adds_an_ArgumentException_if_parameter_value_is_empty()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				ArrayHelper.Empty<CultureInfo>(),
				typeof(ArgumentException),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_array_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				ArrayHelper.Empty<CultureInfo>(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_array_can_be_used_with_custom_exception()
		{
			// Given
			CultureInfo[] invalidValue = ArrayHelper.Empty<CultureInfo>();
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).IsNotEmpty(p => exception));

			// Then
			result.ShouldBe(exception);
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
		public void All_for_array_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(string[])null,
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
		public void All_for_array_can_be_used_with_custom_exception()
		{
			// Given
			string[] invalidValue = new[] { "A", null, "B" };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue)
					.All(x => !string.IsNullOrEmpty(x), p => exception));

			// Then
			result.ShouldBe(exception);
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

		[Fact]
		public void All_for_array_throws_if_predicate_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", (int[])null).All(null));
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
		public void Any_for_array_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(string[])null,
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
		public void Any_for_array_can_be_used_with_custom_exception()
		{
			// Given
			string[] invalidValue = new[] { string.Empty, null };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue)
					.Any(x => !string.IsNullOrEmpty(x), p => exception));

			// Then
			result.ShouldBe(exception);
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

		[Fact]
		public void Any_for_array_throws_if_predicate_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", (int[])null).Any(null));
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
		public void None_for_array_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(string[])null,
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
		public void None_for_array_can_be_used_with_custom_exception()
		{
			// Given
			string[] invalidValue = new[] { "A", null, "B" };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue)
					.None(x => string.IsNullOrEmpty(x), p => exception));

			// Then
			result.ShouldBe(exception);
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

		[Fact]
		public void None_for_array_throws_if_predicate_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", (int[])null).None(null));
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
		public void HasNoNullElements_for_array_of_nullables_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(int?[])null,
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
		public void HasNoNullElements_for_array_of_nullables_can_be_used_with_custom_exception()
		{
			// Given
			int?[] invalidValue = new int?[] { 1, null, 2 };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).HasNoNullElements(p => exception));

			// Then
			result.ShouldBe(exception);
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
		public void HasNoNullElements_for_array_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(string[])null,
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
		public void HasNoNullElements_for_array_can_be_used_with_custom_exception()
		{
			// Given
			string[] invalidValue = new[] { "A", null, "B" };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).HasNoNullElements(p => exception));

			// Then
			result.ShouldBe(exception);
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
		public void HasLengthWithinRange_for_array_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(int[])null,
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_array_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				ArrayHelper.Empty<CultureInfo>(),
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_array_adds_an_ArgumentOutOfRangeException_if_parameter_value_length_is_out_of_range()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				ArrayHelper.Empty<CultureInfo>(),
				typeof(ArgumentOutOfRangeException),
				p => p.HasLengthWithinRange(1, 1));
		}

		[Fact]
		public void HasLengthWithinRange_for_array_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				ArrayHelper.Empty<CultureInfo>(),
				(p, e) => p.HasLengthWithinRange(1, 1, e));
		}

		[Fact]
		public void HasLengthWithinRange_can_be_used_with_custom_exception()
		{
			// Given
			CultureInfo[] invalidValue = ArrayHelper.Empty<CultureInfo>();
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.HasLengthWithinRange(1, 1, p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void HasLengthWithinRange_can_be_used_with_custom_exception_and_builtin_error_message()
		{
			// Given
			CultureInfo[] invalidValue = ArrayHelper.Empty<CultureInfo>();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.HasLengthWithinRange(1, 1, (p, e) => new Exception(e)));

			// Then
			result.Message.ShouldNotBeNullOrWhiteSpace();
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

		[Fact]
		public void HasLengthWithinRange_for_array_throws_if_min_is_greater_than_max()
		{
			Should.Throw<ArgumentOutOfRangeException>(() => Require.Parameter("x", (int[])null).HasLengthWithinRange(1, 0));
		}

		#endregion
	}
}