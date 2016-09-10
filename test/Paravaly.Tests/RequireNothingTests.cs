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
		public void Parameter_with_name_and_value_ignores_invalid_values()
		{
			// Given
			var value = 1;
			IRequire sut = new RequireNothing();

			// When/Then
			Should.NotThrow(() => sut.Parameter(nameof(value), value).Is(typeof(string)).Apply());
		}
	}
}