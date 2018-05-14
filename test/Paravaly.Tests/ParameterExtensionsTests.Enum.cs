using System;
using Paravaly.Tests.Helpers;
using Xunit;

namespace Paravaly.Tests
{
	public sealed partial class ParameterExtensionsTests
	{
		[Flags]
		private enum FlagsEnum
		{
			None = 0,
			First = 1,
			Second = 2,
			Third = 4,
			All = First | Second | Third,
			Negative = -4
		}

		#region IsValidEnumValue

		[Fact]
		public void IsValidEnumValue_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				StringComparison.OrdinalIgnoreCase,
				ParameterExtensions.IsValidEnumValue);
		}

		[Fact]
		public void IsValidEnumValue_works_with_valid_negative_values()
		{
			CommonValidationTests.IsValid(
				FlagsEnum.Negative,
				ParameterExtensions.IsValidEnumValue);
		}

		[Fact]
		public void IsValidEnumValue_works_with_valid_FlagsEnum_values()
		{
			CommonValidationTests.IsValid(
				new FlagsEnum[]
				{
					FlagsEnum.None,
					FlagsEnum.None | FlagsEnum.Third,
					FlagsEnum.First | FlagsEnum.Second,
					FlagsEnum.Third,
					FlagsEnum.All,
					(FlagsEnum)3,
					(FlagsEnum)6,
					(FlagsEnum)7
				},
				ParameterExtensions.IsValidEnumValue);
		}

		[Fact]
		public void IsValidEnumValue_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				(StringComparison)1313,
				ParameterExtensions.IsValidEnumValue);
		}

		[Fact]
		public void IsValidEnumValue_works_with_invalid_negative_values()
		{
			CommonValidationTests.IsNotValid(
				(StringComparison)(-1313),
				ParameterExtensions.IsValidEnumValue);
		}

		[Fact]
		public void IsValidEnumValue_works_with_invalid_FlagsEnum_values()
		{
			CommonValidationTests.IsNotValid(
				new FlagsEnum[]
				{
					(FlagsEnum)1313,
					FlagsEnum.First | (FlagsEnum)13,
				},
				ParameterExtensions.IsValidEnumValue);
		}

		[Fact]
		public void IsValidEnumValue_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				(StringComparison)1313,
				typeof(ArgumentException),
				ParameterExtensions.IsValidEnumValue);
		}

		[Fact]
		public void IsValidEnumValue_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				(StringComparison)1313,
				ParameterExtensions.IsValidEnumValue);
		}

		[Fact]
		public void IsValidEnumValue_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<StringComparison>(
				p => p.IsValidEnumValue());
		}

		[Fact]
		public void IsValidEnumValue_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<StringComparison>(
				p => p.IsValidEnumValue("Error"));
		}

		#endregion
	}
}