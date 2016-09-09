using System;
using Paravaly.Extensibility;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public sealed class RequireNothingTests
	{
		[Fact]
		public void Parameter_with_name_and_value_returns_valid_parameter()
		{
			// Given
			var value = 1;
			IRequire sut = new RequireNothing();

			// When
			var result = sut.Parameter(nameof(value), value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}

		[Fact]
		public void Parameter_with_parameterAsProperty_and_value_returns_valid_parameter()
		{
			// Given
			var value = 1;
			IRequire sut = new RequireNothing();

			// When
			var result = sut.Parameter(new { value }, value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}

		[Fact]
		public void Parameter_with_name_and_value_ignores_invalid_values()
		{
			// Given
			var value = 1;
			IRequire sut = new RequireNothing();

			// When/Then
			Should.NotThrow(() => sut.Parameter(nameof(value), value).Is(typeof(string)).Apply());
		}

		[Fact]
		public void Parameter_with_parameterAsProperty_and_value_ignores_invalid_values()
		{
			// Given
			var value = 1;
			IRequire sut = new RequireNothing();

			// When/Then
			Should.NotThrow(() => sut.Parameter(new { value }, value).Is(typeof(string)).Apply());
		}

		[Fact]
		public void TypeParameter_returns_valid_parameter()
		{
			// Given
			IRequire sut = new RequireNothing();

			// When
			var result = sut.TypeParameter<int>() as IValidatableParameter<Type>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(Invariants.DefaultTypeParameterName);
			result.Value.ShouldBe(typeof(int));
		}

		[Fact]
		public void TypeParameter_with_name_returns_valid_parameter()
		{
			// Given
			var name = "TName";
			IRequire sut = new RequireNothing();

			// When
			var result = sut.TypeParameter<int>(name) as IValidatableParameter<Type>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(name);
			result.Value.ShouldBe(typeof(int));
		}

		[Fact]
		public void TypeParameter_ignores_invalid_values()
		{
			// Given
			IRequire sut = new RequireNothing();

			// When/Then
			Should.NotThrow(() => sut.TypeParameter<int>().IsInterface().Apply());
		}

		[Fact]
		public void TypeParameter_with_name_ignores_invalid_values()
		{
			// Given
			var name = "TName";
			IRequire sut = new RequireNothing();

			// When/Then
			Should.NotThrow(() => sut.TypeParameter<int>(name).IsInterface().Apply());
		}
	}
}