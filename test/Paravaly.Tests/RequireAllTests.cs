using Paravaly.Extensibility;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public sealed class RequireAllTests
	{
		[Fact]
		public void Parameter_with_name_and_value_returns_valid_parameter()
		{
			// Given
			var value = 1;
			IRequire sut = new RequireAll();

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
			IRequire sut = new RequireAll();

			// When
			var result = sut.Parameter(new { value }, value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}

		[Fact]
		public void Parameter_with_name_and_value_throws_on_Apply()
		{
			// Given
			var value = 1;
			IRequire sut = new RequireAll();
			var parameter = sut.Parameter(nameof(value), value).Is(typeof(string));

			// When/Then
			Should.Throw<ParameterValidationException>(() => parameter.Apply());
		}

		[Fact]
		public void Parameter_with_parameterAsProperty_and_value_throws_on_Apply()
		{
			// Given
			var value = 1;
			IRequire sut = new RequireAll();
			var parameter = sut.Parameter(new { value }, value).Is(typeof(string));

			// When/Then
			Should.Throw<ParameterValidationException>(() => parameter.Apply());
		}

		[Fact]
		public void Parameter_static_with_name_and_value_returns_valid_parameter()
		{
			// Given
			var name = "x";
			var value = 1;

			// When
			var result = RequireAll.Parameter(name, value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(name);
			result.Value.ShouldBe(value);
		}

		[Fact]
		public void Parameter_static_with_parameterAsProperty_and_value_returns_valid_parameter()
		{
			// Given
			var value = 1;

			// When
			var result = RequireAll.Parameter(new { value }, value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}
	}
}