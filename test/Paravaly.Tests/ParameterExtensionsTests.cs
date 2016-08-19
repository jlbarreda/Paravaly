using System;
using System.Globalization;
using Paravaly.Tests.Helpers;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public sealed partial class ParameterExtensionsTests
	{
		#region IsNotNull for nullables

		[Fact]
		public void IsNotNull_for_nullables_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				(int?)1,
				ParameterExtensions.IsNotNull);
		}

		[Fact]
		public void IsNotNull_for_nullables_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				(int?)null,
				ParameterExtensions.IsNotNull);
		}

		[Fact]
		public void IsNotNull_for_nullables_adds_an_ArgumentNullException_if_parameter_value_is_null()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				(int?)null,
				typeof(ArgumentNullException),
				ParameterExtensions.IsNotNull);
		}

		[Fact]
		public void IsNotNull_can_be_used_for_nullables_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				(int?)null,
				ParameterExtensions.IsNotNull);
		}

		[Fact]
		public void IsNotNull_for_nullables_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int?>(p => p.IsNotNull());
		}

		[Fact]
		public void IsNotNull_for_nullables_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int?>(p => p.IsNotNull("Error"));
		}

		#endregion

		#region IsNotNull

		[Fact]
		public void IsNotNull_works_with_valid_reference_type_values()
		{
			CommonValidationTests.IsValid(
				CultureInfo.CurrentCulture,
				ParameterExtensions.IsNotNull);
		}

		[Fact]
		public void IsNotNull_works_with_invalid_reference_type_values()
		{
			CommonValidationTests.IsNotValid(
				(CultureInfo)null,
				ParameterExtensions.IsNotNull);
		}

		[Fact]
		public void IsNotNull_adds_an_ArgumentNullException_if_parameter_value_is_null()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				(CultureInfo)null,
				typeof(ArgumentNullException),
				ParameterExtensions.IsNotNull);
		}

		[Fact]
		public void IsNotNull_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				(CultureInfo)null,
				ParameterExtensions.IsNotNull);
		}

		[Fact]
		public void IsNotNull_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo>(p => p.IsNotNull());
		}

		[Fact]
		public void IsNotNull_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo>(p => p.IsNotNull("Error"));
		}

		#endregion

		#region Is

		[Fact]
		public void Is_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				CultureInfo.CurrentCulture,
				p => p.Is(typeof(CultureInfo)));
		}

		[Fact]
		public void Is_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(CultureInfo)null,
				p => p.Is(typeof(CultureInfo)));
		}

		[Fact]
		public void Is_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				CultureInfo.CurrentCulture,
				p => p.Is(typeof(string)));
		}

		[Fact]
		public void Is_adds_an_ArgumentException_if_parameter_value_type_is_not_valid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				CultureInfo.CurrentCulture,
				typeof(ArgumentException),
				p => p.Is(typeof(string)));
		}

		[Fact]
		public void Is_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				CultureInfo.CurrentCulture,
				(p, e) => p.Is(typeof(string), e));
		}

		[Fact]
		public void Is_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo>(p => p.Is(typeof(CultureInfo)));
		}

		[Fact]
		public void Is_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo>(p => p.Is(typeof(string), "Error"));
		}

		[Fact]
		public void Is_throws_if_type_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", "x").Is(null));
		}

		#endregion

		#region IsAssignableTo

		[Fact]
		public void IsAssignableTo_works_when_parameter_is_of_the_specified_type()
		{
			CommonValidationTests.IsValid(
				CultureInfo.CurrentCulture,
				p => p.IsAssignableTo(typeof(CultureInfo)));
		}

		[Fact]
		public void IsAssignableTo_works_when_parameter_is_assignable_to_the_specified_type()
		{
			CommonValidationTests.IsValid(
				new InvalidTimeZoneException(),
				p => p.IsAssignableTo(typeof(Exception)));
		}

		[Fact]
		public void IsAssignableTo_works_when_parameter_value_is_null()
		{
			CommonValidationTests.IsValid(
				(Exception)null,
				p => p.IsAssignableTo(typeof(Exception)));
		}

		[Fact]
		public void IsAssignableTo_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				CultureInfo.CurrentCulture,
				p => p.IsAssignableTo(typeof(string)));
		}

		[Fact]
		public void IsAssignableTo_adds_an_ArgumentException_if_parameter_value_type_is_not_valid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				CultureInfo.CurrentCulture,
				typeof(ArgumentException),
				p => p.IsAssignableTo(typeof(string)));
		}

		[Fact]
		public void IsAssignableTo_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				CultureInfo.CurrentCulture,
				(p, e) => p.IsAssignableTo(typeof(string), e));
		}

		[Fact]
		public void IsAssignableTo_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo>(p => p.IsAssignableTo(typeof(CultureInfo)));
		}

		[Fact]
		public void IsAssignableTo_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<CultureInfo>(p => p.IsAssignableTo(typeof(string), "Error"));
		}

		[Fact]
		public void IsAssignableTo_throws_if_type_is_null()
		{
			Should.Throw<ArgumentNullException>(() => Require.Parameter("x", "x").IsAssignableTo(null));
		}

		#endregion
	}
}