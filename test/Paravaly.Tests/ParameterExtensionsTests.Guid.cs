using System;
using Paravaly.Tests.Helpers;
using Xunit;

namespace Paravaly.Tests
{
	public sealed class ParameterExtensionsTests_Guid
	{
		#region IsNotEmpty

		[Fact]
		public void IsNotEmpty_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				Guid.NewGuid(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				new Guid(),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_adds_an_ArgumentException_if_parameter_value_is_empty()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				Guid.Empty,
				typeof(ArgumentException),
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void Can_use_IsNotEmpty_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				Guid.Empty,
				ParameterExtensions.IsNotEmpty);
		}

		[Fact]
		public void IsNotEmpty_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Guid>(p => p.IsNotEmpty());
		}

		[Fact]
		public void IsNotEmpty_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<Guid>(p => p.IsNotEmpty("Error"));
		}

		#endregion
	}
}