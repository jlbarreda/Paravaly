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
		public void Parameter_with_parameterAsProperty_and_value_returns_valid_parameter()
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