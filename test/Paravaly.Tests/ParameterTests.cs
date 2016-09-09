using System;
using Paravaly.Extensibility;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public sealed class ParameterTests
	{
		[Fact]
		public void AndParameter_with_name_and_value_returns_valid_parameter()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.Ignore);

			// When
			var result = sut.AndParameter(nameof(value), value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}

		[Fact]
		public void AndParameter_with_parameterAsProperty_and_value_returns_valid_parameter()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.Ignore);

			// When
			var result = sut.AndParameter(new { value }, value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}

		[Fact]
		public void AndParameter_with_name_value_and_ThrowFirst_throws_on_first()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.ThrowFirst);

			// When/Then
			Should.Throw<ArgumentException>(() => sut.AndParameter(nameof(value), value).Is(typeof(string)));
		}

		[Fact]
		public void AndParameter_with_parameterAsProperty_value_and_ThrowFirst_throws_on_first()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.ThrowFirst);

			// When/Then
			Should.Throw<ArgumentException>(() => sut.AndParameter(new { value }, value).Is(typeof(string)));
		}

		[Fact]
		public void AndParameter_with_name_value_and_ThrowAll_throws_on_Apply()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.ThrowAll);
			var parameter = sut.AndParameter(nameof(value), value).Is(typeof(string));

			// When/Then
			Should.Throw<ParameterValidationException>(() => parameter.Apply());
		}

		[Fact]
		public void AndParameter_with_parameterAsProperty_value_and_ThrowAll_throws_on_Apply()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.ThrowAll);
			var parameter = sut.AndParameter(new { value }, value).Is(typeof(string));

			// When/Then
			Should.Throw<ParameterValidationException>(() => parameter.Apply());
		}

		[Fact]
		public void AndParameter_with_name_value_and_Ignore_ignores_invalid_values()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.Ignore);

			// When/Then
			Should.NotThrow(() => sut.AndParameter(nameof(value), value).Is(typeof(string)).Apply());
		}

		[Fact]
		public void AndParameter_with_parameterAsProperty_value_and_Ignore_ignores_invalid_values()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.Ignore);

			// When/Then
			Should.NotThrow(() => sut.AndParameter(new { value }, value).Is(typeof(string)).Apply());
		}

		[Fact]
		public void AndTypeParameter_returns_valid_parameter()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.Ignore);

			// When
			var result = sut.AndTypeParameter<string>() as IValidatableParameter<Type>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(Invariants.DefaultTypeParameterName);
			result.Value.ShouldBe(typeof(string));
		}

		[Fact]
		public void AndTypeParameter_with_name_returns_valid_parameter()
		{
			// Given
			var value = 1;
			var name = "TName";
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.Ignore);

			// When
			var result = sut.AndTypeParameter<string>(name) as IValidatableParameter<Type>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(name);
			result.Value.ShouldBe(typeof(string));
		}

		[Fact]
		public void AndTypeParameter_with_ThrowFirst_throws_on_first()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.ThrowFirst);

			// When/Then
			Should.Throw<ArgumentException>(() => sut.AndTypeParameter<string>().IsInterface());
		}

		[Fact]
		public void AndTypeParameter_with_ThrowAll_throws_on_Apply()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.ThrowAll);
			var parameter = sut.AndTypeParameter<string>().IsInterface();

			// When/Then
			Should.Throw<ParameterValidationException>(() => parameter.Apply());
		}

		[Fact]
		public void AndTypeParameter_with_Ignore_ignores_invalid_values()
		{
			// Given
			var value = 1;
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.Ignore);

			// When/Then
			Should.NotThrow(() => sut.AndTypeParameter<string>().IsInterface().Apply());
		}

		[Fact]
		public void AndTypeParameter_with_name_and_ThrowFirst_throws_on_first()
		{
			// Given
			var value = 1;
			var name = "TName";
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.ThrowFirst);

			// When/Then
			Should.Throw<ArgumentException>(() => sut.AndTypeParameter<string>(name).IsInterface());
		}

		[Fact]
		public void AndTypeParameter_with_name_and_ThrowAll_throws_on_Apply()
		{
			// Given
			var value = 1;
			var name = "TName";
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.ThrowAll);
			var parameter = sut.AndTypeParameter<string>(name).IsInterface();

			// When/Then
			Should.Throw<ParameterValidationException>(() => parameter.Apply());
		}

		[Fact]
		public void AndTypeParameter_with_name_and_Ignore_ignores_invalid_values()
		{
			// Given
			var value = 1;
			var name = "TName";
			var sut = new Parameter<int>(nameof(value), value, ExceptionHandlingMode.Ignore);

			// When/Then
			Should.NotThrow(() => sut.AndTypeParameter<string>(name).IsInterface().Apply());
		}
	}
}