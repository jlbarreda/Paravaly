using System;
using Paravaly.Tests.Helpers;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public sealed partial class ParameterExtensionsTests
	{
		#region IsClass

		[Fact]
		public void IsClass_for_Type_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				typeof(string),
				ParameterExtensions.IsClass);
		}

		[Fact]
		public void IsClass_for_Type_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				typeof(float),
				ParameterExtensions.IsClass);
		}

		[Fact]
		public void IsClass_for_Type_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				typeof(float),
				typeof(ArgumentException),
				ParameterExtensions.IsClass);
		}

		[Fact]
		public void IsClass_for_Type_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				typeof(float),
				ParameterExtensions.IsClass);
		}

		[Fact]
		public void IsClass_for_Type_can_be_used_with_custom_exception()
		{
			// Given
			Type invalidValue = typeof(float);
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsClass(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsClass_for_Type_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsClass());
		}

		[Fact]
		public void IsClass_for_Type_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsClass("Error"));
		}

		#endregion

		#region IsNotClass

		[Fact]
		public void IsNotClass_for_Type_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				typeof(int),
				ParameterExtensions.IsNotClass);
		}

		[Fact]
		public void IsNotClass_for_Type_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				typeof(string),
				ParameterExtensions.IsNotClass);
		}

		[Fact]
		public void IsNotClass_for_Type_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				typeof(string),
				typeof(ArgumentException),
				ParameterExtensions.IsNotClass);
		}

		[Fact]
		public void IsNotClass_for_Type_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				typeof(string),
				ParameterExtensions.IsNotClass);
		}

		[Fact]
		public void IsNotClass_for_Type_can_be_used_with_custom_exception()
		{
			// Given
			Type invalidValue = typeof(string);
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsNotClass(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotClass_for_Type_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsNotClass());
		}

		[Fact]
		public void IsNotClass_for_Type_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsNotClass("Error"));
		}

		#endregion

		#region IsInterface

		[Fact]
		public void IsInterface_for_Type_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				typeof(IComparable),
				ParameterExtensions.IsInterface);
		}

		[Fact]
		public void IsInterface_for_Type_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				typeof(float),
				ParameterExtensions.IsInterface);
		}

		[Fact]
		public void IsInterface_for_Type_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				typeof(float),
				typeof(ArgumentException),
				ParameterExtensions.IsInterface);
		}

		[Fact]
		public void IsInterface_for_Type_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				typeof(float),
				ParameterExtensions.IsInterface);
		}

		[Fact]
		public void IsInterface_for_Type_can_be_used_with_custom_exception()
		{
			// Given
			Type invalidValue = typeof(float);
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsInterface(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsInterface_for_Type_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsInterface());
		}

		[Fact]
		public void IsInterface_for_Type_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsInterface("Error"));
		}

		#endregion

		#region IsNotInterface

		[Fact]
		public void IsNotInterface_for_Type_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				typeof(int),
				ParameterExtensions.IsNotInterface);
		}

		[Fact]
		public void IsNotInterface_for_Type_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				typeof(IComparable),
				ParameterExtensions.IsNotInterface);
		}

		[Fact]
		public void IsNotInterface_for_Type_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				typeof(IComparable),
				typeof(ArgumentException),
				ParameterExtensions.IsNotInterface);
		}

		[Fact]
		public void IsNotInterface_for_Type_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				typeof(IComparable),
				ParameterExtensions.IsNotInterface);
		}

		[Fact]
		public void IsNotInterface_for_Type_can_be_used_with_custom_exception()
		{
			// Given
			Type invalidValue = typeof(IComparable);
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsNotInterface(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotInterface_for_Type_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsNotInterface());
		}

		[Fact]
		public void IsNotInterface_for_Type_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsNotInterface("Error"));
		}

		#endregion

		#region IsValueType

		[Fact]
		public void IsValueType_for_Type_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				typeof(int),
				ParameterExtensions.IsValueType);
		}

		[Fact]
		public void IsValueType_for_Type_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				typeof(string),
				ParameterExtensions.IsValueType);
		}

		[Fact]
		public void IsValueType_for_Type_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				typeof(string),
				typeof(ArgumentException),
				ParameterExtensions.IsValueType);
		}

		[Fact]
		public void IsValueType_for_Type_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				typeof(string),
				ParameterExtensions.IsValueType);
		}

		[Fact]
		public void IsValueType_for_Type_can_be_used_with_custom_exception()
		{
			// Given
			Type invalidValue = typeof(string);
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsValueType(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsValueType_for_Type_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsValueType());
		}

		[Fact]
		public void IsValueType_for_Type_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsValueType("Error"));
		}

		#endregion

		#region IsNotValueType

		[Fact]
		public void IsNotValueType_for_Type_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				typeof(string),
				ParameterExtensions.IsNotValueType);
		}

		[Fact]
		public void IsNotValueType_for_Type_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				typeof(int),
				ParameterExtensions.IsNotValueType);
		}

		[Fact]
		public void IsNotValueType_for_Type_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				typeof(int),
				typeof(ArgumentException),
				ParameterExtensions.IsNotValueType);
		}

		[Fact]
		public void IsNotValueType_for_Type_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				typeof(int),
				ParameterExtensions.IsNotValueType);
		}

		[Fact]
		public void IsNotValueType_for_Type_can_be_used_with_custom_exception()
		{
			// Given
			Type invalidValue = typeof(int);
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsNotValueType(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotValueType_for_Type_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsNotValueType());
		}

		[Fact]
		public void IsNotValueType_for_Type_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsNotValueType("Error"));
		}

		#endregion

		#region IsEnum

		[Fact]
		public void IsEnum_for_Type_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				typeof(StringComparison),
				ParameterExtensions.IsEnum);
		}

		[Fact]
		public void IsEnum_for_Type_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				typeof(string),
				ParameterExtensions.IsEnum);
		}

		[Fact]
		public void IsEnum_for_Type_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				typeof(string),
				typeof(ArgumentException),
				ParameterExtensions.IsEnum);
		}

		[Fact]
		public void IsEnum_for_Type_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				typeof(string),
				ParameterExtensions.IsEnum);
		}

		[Fact]
		public void IsEnum_for_Type_can_be_used_with_custom_exception()
		{
			// Given
			Type invalidValue = typeof(string);
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsEnum(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsEnum_for_Type_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsEnum());
		}

		[Fact]
		public void IsEnum_for_Type_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsEnum("Error"));
		}

		#endregion

		#region IsNotEnum

		[Fact]
		public void IsNotEnum_for_Type_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				typeof(string),
				ParameterExtensions.IsNotEnum);
		}

		[Fact]
		public void IsNotEnum_for_Type_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				typeof(StringComparison),
				ParameterExtensions.IsNotEnum);
		}

		[Fact]
		public void IsNotEnum_for_Type_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				typeof(StringComparison),
				typeof(ArgumentException),
				ParameterExtensions.IsNotEnum);
		}

		[Fact]
		public void IsNotEnum_for_Type_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				typeof(StringComparison),
				ParameterExtensions.IsNotEnum);
		}

		[Fact]
		public void IsNotEnum_for_Type_can_be_used_with_custom_exception()
		{
			// Given
			Type invalidValue = typeof(StringComparison);
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.IsNotEnum(p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void IsNotEnum_for_Type_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsNotEnum());
		}

		[Fact]
		public void IsNotEnum_for_Type_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Type>(
				p => p.IsNotEnum("Error"));
		}

		#endregion
	}
}