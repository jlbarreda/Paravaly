using System;
using Paravaly.Extensibility;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public sealed class RequireTests
	{
		[Fact]
		public void Parameter_with_name_and_value_returns_valid_parameter()
		{
			// Given
			var value = 1;
			IRequire sut = new Require();

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
			IRequire sut = new Require();

			// When
			var result = sut.Parameter(new { value }, value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}

		[Fact]
		public void Parameter_with_name_and_value_throws_on_first()
		{
			// Given
			var value = 1;
			IRequire sut = new Require();

			// When/Then
			Should.Throw<ArgumentException>(() => sut.Parameter(nameof(value), value).Is(typeof(string)));
		}

		[Fact]
		public void Parameter_with_parameterAsProperty_and_value_throws_on_first()
		{
			// Given
			var value = 1;
			IRequire sut = new Require();

			// When/Then
			Should.Throw<ArgumentException>(() => sut.Parameter(new { value }, value).Is(typeof(string)));
		}

		[Fact]
		public void Parameter_static_with_name_and_value_returns_valid_parameter()
		{
			// Given
			var value = 1;

			// When
			var result = Require.Parameter(nameof(value), value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}

		[Fact]
		public void Parameter_static_with_parameterAsProperty_and_value_returns_valid_parameter()
		{
			// Given
			var value = 1;

			// When
			var result = Require.Parameter(new { value }, value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}

		[Fact]
		public void TypeParameter_returns_valid_parameter()
		{
			// Given
			IRequire sut = new Require();

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
			IRequire sut = new Require();

			// When
			var result = sut.TypeParameter<int>(name) as IValidatableParameter<Type>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(name);
			result.Value.ShouldBe(typeof(int));
		}

		[Fact]
		public void TypeParameter_throws_on_first()
		{
			// Given
			IRequire sut = new Require();

			// When/Then
			Should.Throw<ArgumentException>(() => sut.TypeParameter<int>().Is(typeof(string)));
		}

		[Fact]
		public void TypeParameter_with_name_throws_on_first()
		{
			// Given
			var name = "TName";
			IRequire sut = new Require();

			// When/Then
			Should.Throw<ArgumentException>(() => sut.TypeParameter<int>(name).Is(typeof(string)));
		}
	}
}