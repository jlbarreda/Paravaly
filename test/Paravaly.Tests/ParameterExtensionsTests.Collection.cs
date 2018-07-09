﻿using System;
using System.Collections.Generic;
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
		public void IsNotEmpty_for_ICollection_works_with_valid_values()
		{
			CommonValidationTests.IsValid<ICollection<int>>(
				Enumerable.Range(1, 1).ToList(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_ICollection_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(ICollection<int>)null,
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_ICollection_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid<ICollection<int>>(
				Enumerable.Empty<int>().ToList(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_ICollection_adds_an_ArgumentException_if_parameter_value_is_empty()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid<ICollection<CultureInfo>>(
				ArrayHelper.Empty<CultureInfo>(),
				typeof(ArgumentException),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_ICollection_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage<ICollection<CultureInfo>>(
				ArrayHelper.Empty<CultureInfo>(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_for_ICollection_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = (ICollection<CultureInfo>)ArrayHelper.Empty<CultureInfo>();
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).IsNotEmpty(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotEmpty_for_ICollection_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<CultureInfo>>(
				p => p.IsNotEmpty());
		}

		[Fact]
		public void IsNotEmpty_for_ICollection_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<CultureInfo>>(
				p => p.IsNotEmpty("Error"));
		}

		#endregion

		#region All

		[Fact]
		public void All_for_ICollection_works_with_valid_values()
		{
			CommonValidationTests.IsValid<ICollection<string>>(
				new[] { "A", "B" },
				p => p.All(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void All_for_ICollection_works_with_derived_values()
		{
			Require.Parameter("x", new List<string> { "A", "B" }).All(x => !string.IsNullOrEmpty(x));
		}

		[Fact]
		public void All_for_ICollection_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(ICollection<string>)null,
				p => p.All(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void All_for_ICollection_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid<ICollection<string>>(
				new[] { "A", null, "B" },
				p => p.All(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void All_for_ICollection_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid<ICollection<string>>(
				new[] { "A", null, "B" },
				typeof(ArgumentException),
				p => p.All(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void All_for_ICollection_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage<ICollection<string>>(
				new[] { "A", null, "B" },
				(p, e) => p.All(x => !string.IsNullOrEmpty(x), e));
		}

		[Fact]
		public void All_for_ICollection_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = (ICollection<string>)new[] { "A", null, "B" };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).All(x => !string.IsNullOrEmpty(x), p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void All_for_ICollection_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<string>>(
				p => p.All(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void All_for_ICollection_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<string>>(
				p => p.All(x => !string.IsNullOrEmpty(x), "Error"));
		}

		[Fact]
		public void All_for_ICollection_throws_if_predicate_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", (List<int>)null).All(null));
		}

		#endregion

		#region Any

		[Fact]
		public void Any_for_ICollection_works_with_valid_values()
		{
			CommonValidationTests.IsValid<ICollection<string>>(
				new[] { "A", "B" },
				p => p.Any(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void Any_for_ICollection_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(ICollection<string>)null,
				p => p.Any(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void Any_for_ICollection_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid<ICollection<string>>(
				new[] { string.Empty, null },
				p => p.Any(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void Any_for_ICollection_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid<ICollection<string>>(
				new[] { string.Empty, null },
				typeof(ArgumentException),
				p => p.Any(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void Any_for_ICollection_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage<ICollection<string>>(
				new[] { string.Empty, null },
				(p, e) => p.Any(x => !string.IsNullOrEmpty(x), e));
		}

		[Fact]
		public void Any_for_ICollection_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = (ICollection<string>)new[] { string.Empty, null };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).Any(x => !string.IsNullOrEmpty(x), p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void Any_for_ICollection_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<string>>(
				p => p.Any(x => !string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void Any_for_ICollection_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<string>>(
				p => p.Any(x => !string.IsNullOrEmpty(x), "Error"));
		}

		[Fact]
		public void Any_for_ICollection_throws_if_predicate_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", (ICollection<int>)null).Any(null));
		}

		#endregion

		#region None

		[Fact]
		public void None_for_ICollection_works_with_valid_values()
		{
			CommonValidationTests.IsValid<ICollection<string>>(
				new[] { "A", "B" },
				p => p.None(x => string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void None_for_ICollection_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(ICollection<string>)null,
				p => p.None(x => string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void None_for_ICollection_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid<ICollection<string>>(
				new[] { "A", null, "B" },
				p => p.None(x => string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void None_for_ICollection_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid<ICollection<string>>(
				new[] { "A", null, "B" },
				typeof(ArgumentException),
				p => p.None(x => string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void None_for_ICollection_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage<ICollection<string>>(
				new[] { "A", null, "B" },
				(p, e) => p.None(x => string.IsNullOrEmpty(x), e));
		}

		[Fact]
		public void None_for_ICollection_for_nullables_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = (ICollection<string>)new[] { "A", null, "B" };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).None(x => string.IsNullOrEmpty(x), p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void None_for_ICollection_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<string>>(
				p => p.None(x => string.IsNullOrEmpty(x)));
		}

		[Fact]
		public void None_for_ICollection_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<string>>(
				p => p.None(x => string.IsNullOrEmpty(x), "Error"));
		}

		[Fact]
		public void None_for_ICollection_throws_if_predicate_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", (ICollection<int>)null).None(null));
		}

		#endregion

		#region HasNoNullElements for collection with nullables

		[Fact]
		public void HasNoNullElements_for_ICollection_for_nullables_works_with_valid_values()
		{
			CommonValidationTests.IsValid<ICollection<int?>>(
				new int?[] { 1, 2 },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_for_nullables_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(ICollection<int?>)null,
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_for_nullables_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid<ICollection<int?>>(
				new int?[] { 1, null, 2 },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_for_nullables_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid<ICollection<int?>>(
				new int?[] { 1, null, 2 },
				typeof(ArgumentException),
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_for_nullables_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage<ICollection<int?>>(
				new int?[] { 1, null, 2 },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_for_nullables_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = (ICollection<int?>)new int?[] { 1, null, 2 };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).HasNoNullElements(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_for_nullables_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<int?>>(
				p => p.HasNoNullElements());
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_for_nullables_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<int?>>(
				p => p.HasNoNullElements("Error"));
		}

		#endregion

		#region HasNoNullElements

		[Fact]
		public void HasNoNullElements_for_ICollection_works_with_valid_values()
		{
			CommonValidationTests.IsValid<ICollection<int?>>(
				Enumerable.Range(1, 2).Cast<int?>().ToList(),
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(ICollection<int?>)null,
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid<ICollection<string>>(
				new[] { "A", null, "B" },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid<ICollection<string>>(
				new[] { "A", null, "B" },
				typeof(ArgumentException),
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage<ICollection<string>>(
				new[] { "A", null, "B" },
				ParameterExtensions.HasNoNullElements);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = (ICollection<string>)new[] { "A", null, "B" };
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).HasNoNullElements(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<CultureInfo>>(
				p => p.HasNoNullElements());
		}

		[Fact]
		public void HasNoNullElements_for_ICollection_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<CultureInfo>>(
				p => p.HasNoNullElements("Error"));
		}

		#endregion

		#region HasCountWithinRange

		[Fact]
		public void HasCountWithinRange_for_ICollection_works_with_valid_values()
		{
			CommonValidationTests.IsValid<ICollection<int>>(
				Enumerable.Range(1, 1).ToList(),
				p => p.HasCountWithinRange(1, 1));
		}

		[Fact]
		public void HasCountWithinRange_for_ICollection_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(ICollection<int>)null,
				p => p.HasCountWithinRange(1, 1));
		}

		[Fact]
		public void HasCountWithinRange_for_ICollection_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid<ICollection<CultureInfo>>(
				ArrayHelper.Empty<CultureInfo>(),
				p => p.HasCountWithinRange(1, 1));
		}

		[Fact]
		public void HasCountWithinRange_for_ICollection_adds_an_ArgumentOutOfRangeException_if_parameter_value_length_is_out_of_range()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid<ICollection<CultureInfo>>(
				ArrayHelper.Empty<CultureInfo>(),
				typeof(ArgumentOutOfRangeException),
				p => p.HasCountWithinRange(1, 1));
		}

		[Fact]
		public void HasCountWithinRange_for_ICollection_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage<ICollection<CultureInfo>>(
				ArrayHelper.Empty<CultureInfo>(),
				(p, e) => p.HasCountWithinRange(1, 1, e));
		}

		[Fact]
		public void HasCountWithinRange_for_ICollection_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = (ICollection<CultureInfo>)ArrayHelper.Empty<CultureInfo>();
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require.Parameter(nameof(invalidValue), invalidValue).HasCountWithinRange(1, 1, p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void HasCountWithinRange_for_ICollection_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<CultureInfo>>(
				p => p.HasCountWithinRange(1, 1));
		}

		[Fact]
		public void HasCountWithinRange_for_ICollection_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<ICollection<CultureInfo>>(
				p => p.HasCountWithinRange(1, 1, string.Empty));
		}

		[Fact]
		public void HasCountWithinRange_for_ICollection_throws_if_min_is_greater_than_max()
		{
			Should.Throw<ArgumentOutOfRangeException>(() => Require.Parameter("x", (ICollection<int>)null).HasCountWithinRange(1, 0));
		}

		#endregion
	}
}