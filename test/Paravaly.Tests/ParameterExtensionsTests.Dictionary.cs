using System;
using System.Collections.Generic;
using Paravaly.Tests.Helpers;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public sealed partial class ParameterExtensionsTests
	{
		#region ContainsKey

		[Fact]
		public void ContainsKey_works_with_valid_values()
		{
			CommonValidationTests.IsValid<IDictionary<int, string>>(
				new Dictionary<int, string>(2)
				{
					[1] = "One",
					[2] = "Two"
				},
				p => p.ContainsKey(1));
		}

		[Fact]
		public void ContainsKey_works_with_derived_values()
		{
			Require
				.Parameter(
					"x",
					new Dictionary<int, string>(2)
					{
						[1] = "One",
						[2] = "Two"
					})
				.ContainsKey(1);
		}

		[Fact]
		public void ContainsKey_works_with_null_values()
		{
			CommonValidationTests.IsValid(
				(IDictionary<int, string>)null,
				p => p.ContainsKey(1));
		}

		[Fact]
		public void ContainsKey_works_with_invalid_values()
		{
			CommonValidationTests.IsNotValid<IDictionary<int, string>>(
				new Dictionary<int, string>(2)
				{
					[1] = "One",
					[2] = "Two"
				},
				p => p.ContainsKey(3));
		}

		[Fact]
		public void ContainsKey_adds_an_ArgumentException_if_parameter_value_is_invalid()
		{
			CommonValidationTests.AddsCorrectExceptionWhenInvalid<IDictionary<int, string>>(
				new Dictionary<int, string>(2)
				{
					[1] = "One",
					[2] = "Two"
				},
				typeof(ArgumentException),
				p => p.ContainsKey(3));
		}

		[Fact]
		public void ContainsKey_can_be_used_with_custom_error_message()
		{
			CommonValidationTests.CanUseCustomErrorMessage<IDictionary<int, string>>(
				new Dictionary<int, string>(2)
				{
					[1] = "One",
					[2] = "Two"
				},
				(p, e) => p.ContainsKey(3, e));
		}

		[Fact]
		public void ContainsKey_can_be_used_with_custom_exception()
		{
			// Given
			var invalidValue = new Dictionary<int, string>(2)
			{
				[1] = "One",
				[2] = "Two"
			};
			var exception = new Exception();

			// When
			Exception result = Should.Throw<Exception>(
				() => Require
					.Parameter(nameof(invalidValue), invalidValue)
					.ContainsKey(3, p => exception));

			// Then
			result.ShouldBe(exception);
		}

		[Fact]
		public void ContainsKey_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<IDictionary<int, string>>(
				p => p.ContainsKey(1));
		}

		[Fact]
		public void ContainsKey_with_error_message_throws_if_parameter_is_null()
		{
			CommonValidationTests.ThrowsIfParameterIsNull<IDictionary<int, string>>(
				p => p.ContainsKey(1, "Error"));
		}

		[Fact]
		public void ContainsKey_throws_if_key_is_null()
		{
			Should.Throw<ArgumentNullException>(() =>
				Require.Parameter("x", (IDictionary<string, string>)null).ContainsKey(null));
		}

		#endregion
	}
}