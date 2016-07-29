using System;
using Paravaly.Tests.Helpers;
using Xunit;

namespace Paravaly.Tests
{
	public sealed class ParameterExtensionsTests_Double
	{
		#region IsNotNaN

		[Fact]
		public void IsNotNaN_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1D,
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				double.NaN,
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				double.NaN,
				typeof(ArgumentOutOfRangeException),
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void Can_use_IsNotNaN_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				double.NaN,
				ParameterExtensions.IsNotNaN);
		}

		[Fact]
		public void IsNotNaN_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotNaN());
		}

		[Fact]
		public void IsNotNaN_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<double>(
				p => p.IsNotNaN("Error"));
		}

		#endregion
	}
}