﻿using System;
using System.Linq;
using Paravaly.Tests.Helpers;
using Xunit;

namespace Paravaly.Tests
{
	public sealed class ParameterExtensionsTests_Comparable
	{
		#region IsWithinRange

		[Fact]
		public void IsWithinRange_works_with_DateTime_valid_values()
		{
			CommonValidationTests.IsValid(
				DateTime.Now,
				p => p.IsWithinRange(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(1)));
		}

		[Fact]
		public void IsWithinRange_works_with_byte_valid_values()
		{
			CommonValidationTests.IsValid(
				(byte)1,
				p => p.IsWithinRange((byte)1, (byte)2));
		}

		[Fact]
		public void IsWithinRange_works_with_char_valid_values()
		{
			CommonValidationTests.IsValid(
				'B',
				p => p.IsWithinRange('B', 'C'));
		}

		[Fact]
		public void IsWithinRange_works_with_decimal_valid_values()
		{
			CommonValidationTests.IsValid(
				1M,
				p => p.IsWithinRange(1M, 2M));
		}

		[Fact]
		public void IsWithinRange_works_with_double_valid_values()
		{
			CommonValidationTests.IsValid(
				1,
				p => p.IsWithinRange(1, 2));
		}

		[Fact]
		public void IsWithinRange_works_with_float_valid_values()
		{
			CommonValidationTests.IsValid(
				1F,
				p => p.IsWithinRange(1F, 2F));
		}

		[Fact]
		public void IsWithinRange_works_with_int_valid_values()
		{
			CommonValidationTests.IsValid(
				1,
				p => p.IsWithinRange(1, 2));
		}

		[Fact]
		public void IsWithinRange_works_with_long_valid_values()
		{
			CommonValidationTests.IsValid(
				1L,
				p => p.IsWithinRange(1L, 2L));
		}

		[Fact]
		public void IsWithinRange_works_with_sbyte_valid_values()
		{
			CommonValidationTests.IsValid(
				(sbyte)1,
				p => p.IsWithinRange((sbyte)1, (sbyte)2));
		}

		[Fact]
		public void IsWithinRange_works_with_short_valid_values()
		{
			CommonValidationTests.IsValid(
				(short)1,
				p => p.IsWithinRange((short)1, (short)2));
		}

		[Fact]
		public void IsWithinRange_works_with_uint_valid_values()
		{
			CommonValidationTests.IsValid(
				1U,
				p => p.IsWithinRange(1U, 2U));
		}

		[Fact]
		public void IsWithinRange_works_with_ulong_valid_values()
		{
			CommonValidationTests.IsValid(
				1UL,
				p => p.IsWithinRange(1UL, 2UL));
		}

		[Fact]
		public void IsWithinRange_works_with_ushort_valid_values()
		{
			CommonValidationTests.IsValid(
				(ushort)1,
				p => p.IsWithinRange((ushort)1, (ushort)2));
		}

		[Fact]
		public void IsWithinRange_works_with_DateTime_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				DateTime.Now.AddHours(3),
				p => p.IsWithinRange(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(1)));
		}

		[Fact]
		public void IsWithinRange_works_with_byte_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				(byte)0,
				p => p.IsWithinRange((byte)1, (byte)2));
		}

		[Fact]
		public void IsWithinRange_works_with_char_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				'A',
				p => p.IsWithinRange('B', 'C'));
		}

		[Fact]
		public void IsWithinRange_works_with_decimal_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0M,
				p => p.IsWithinRange(1M, 2M));
		}

		[Fact]
		public void IsWithinRange_works_with_double_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0,
				p => p.IsWithinRange(1, 2));
		}

		[Fact]
		public void IsWithinRange_works_with_float_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0F,
				p => p.IsWithinRange(1F, 2F));
		}

		[Fact]
		public void IsWithinRange_works_with_int_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0,
				p => p.IsWithinRange(1, 2));
		}

		[Fact]
		public void IsWithinRange_works_with_long_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0L,
				p => p.IsWithinRange(1L, 2L));
		}

		[Fact]
		public void IsWithinRange_works_with_sbyte_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				(sbyte)0,
				p => p.IsWithinRange((sbyte)1, (sbyte)2));
		}

		[Fact]
		public void IsWithinRange_works_with_short_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				(short)0,
				p => p.IsWithinRange((short)1, (short)2));
		}

		[Fact]
		public void IsWithinRange_works_with_uint_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0U,
				p => p.IsWithinRange(1U, 2U));
		}

		[Fact]
		public void IsWithinRange_works_with_ulong_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0UL,
				p => p.IsWithinRange(1UL, 2UL));
		}

		[Fact]
		public void IsWithinRange_works_with_ushort_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				(ushort)0,
				p => p.IsWithinRange((ushort)1, (ushort)2));
		}

		[Fact]
		public void IsWithinRange_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_out_of_range()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				0,
				typeof(ArgumentOutOfRangeException),
				p => p.IsWithinRange(1, 2));
		}

		[Fact]
		public void Can_use_IsWithinRange_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				0,
				(p, e) => p.IsWithinRange(1, 2, e));
		}

		[Fact]
		public void IsWithinRange_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsWithinRange(1, 2));
		}

		[Fact]
		public void IsWithinRange_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsWithinRange(1, 2, "Error"));
		}

		#endregion

		#region IsLessThan

		[Fact]
		public void IsLessThan_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				0,
				p => p.IsLessThan(1));
		}

		[Fact]
		public void IsLessThan_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				1,
				p => p.IsLessThan(0));
		}

		[Fact]
		public void IsLessThan_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_not_valid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				1,
				typeof(ArgumentOutOfRangeException),
				p => p.IsLessThan(1));
		}

		[Fact]
		public void Can_use_IsLessThan_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				2,
				(p, e) => p.IsLessThan(1, e));
		}

		[Fact]
		public void IsLessThan_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsLessThan(1));
		}

		[Fact]
		public void IsLessThan_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsLessThan(1, "Error"));
		}

		#endregion

		#region IsLessThanOrEqualTo

		[Fact]
		public void IsLessThanOrEqualTo_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				Enumerable.Range(0, 1),
				p => p.IsLessThanOrEqualTo(1));
		}

		[Fact]
		public void IsLessThanOrEqualTo_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				1,
				p => p.IsLessThanOrEqualTo(0));
		}

		[Fact]
		public void IsLessThanOrEqualTo_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_not_valid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				2,
				typeof(ArgumentOutOfRangeException),
				p => p.IsLessThanOrEqualTo(1));
		}

		[Fact]
		public void Can_use_IsLessThanOrEqualTo_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				2,
				(p, e) => p.IsLessThanOrEqualTo(1, e));
		}

		[Fact]
		public void IsLessThanOrEqualTo_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsLessThanOrEqualTo(1));
		}

		[Fact]
		public void IsLessThanOrEqualTo_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsLessThanOrEqualTo(1, "Error"));
		}

		#endregion

		#region IsGreaterThan

		[Fact]
		public void IsGreaterThan_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				1,
				p => p.IsGreaterThan(0));
		}

		[Fact]
		public void IsGreaterThan_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0,
				p => p.IsGreaterThan(1));
		}

		[Fact]
		public void IsGreaterThan_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_not_valid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				0,
				typeof(ArgumentOutOfRangeException),
				p => p.IsGreaterThan(1));
		}

		[Fact]
		public void Can_use_IsGreaterThan_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				0,
				(p, e) => p.IsGreaterThan(1, e));
		}

		[Fact]
		public void IsGreaterThan_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsGreaterThan(1));
		}

		[Fact]
		public void IsGreaterThan_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsGreaterThan(1, "Error"));
		}

		#endregion

		#region IsGreaterThanOrEqualTo

		[Fact]
		public void IsGreaterThanOrEqualTo_works_with_valid_values()
		{
			CommonValidationTests.IsValid(
				Enumerable.Range(0, 1),
				p => p.IsGreaterThanOrEqualTo(0));
		}

		[Fact]
		public void IsGreaterThanOrEqualTo_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid(
				0,
				p => p.IsGreaterThanOrEqualTo(1));
		}

		[Fact]
		public void IsGreaterThanOrEqualTo_adds_an_ArgumentOutOfRangeException_if_parameter_value_is_not_valid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid(
				0,
				typeof(ArgumentOutOfRangeException),
				p => p.IsGreaterThanOrEqualTo(1));
		}

		[Fact]
		public void Can_use_IsGreaterThanOrEqualTo_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage(
				0,
				(p, e) => p.IsGreaterThanOrEqualTo(1, e));
		}

		[Fact]
		public void IsGreaterThanOrEqualTo_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsGreaterThanOrEqualTo(1));
		}

		[Fact]
		public void IsGreaterThanOrEqualTo_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<int>(p => p.IsGreaterThanOrEqualTo(1, "Error"));
		}

		#endregion
	}
}