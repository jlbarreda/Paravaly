using System;
using System.Globalization;
using Paravaly.Tests.Helpers;
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
		public void Can_use_IsNotNull_for_nullables_with_custom_error_message()
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
		public void Can_use_IsNotNull_with_custom_error_message()
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
	}
}