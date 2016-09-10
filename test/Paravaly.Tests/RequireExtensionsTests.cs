using System;
using System.Collections.Generic;
using Paravaly.Extensibility;
using Shouldly;
using Xunit;

namespace Paravaly.Tests
{
	public class RequireExtensionsTests
	{
		[Theory]
		[MemberData(nameof(GetRequireInstances))]
		public void Parameter_with_parameterAsProperty_and_value_returns_valid_parameter(IRequire sut)
		{
			// Given
			var value = 1;

			// When
			var result = sut.Parameter(new { value }, value) as IValidatableParameter<int>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(nameof(value));
			result.Value.ShouldBe(value);
		}

		[Theory]
		[MemberData(nameof(GetRequireInstances))]
		public void TypeParameter_returns_valid_parameter(IRequire sut)
		{
			// Given

			// When
			var result = sut.TypeParameter<int>() as IValidatableParameter<Type>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(Invariants.DefaultTypeParameterName);
			result.Value.ShouldBe(typeof(int));
		}

		[Theory]
		[MemberData(nameof(GetRequireInstances))]
		public void TypeParameter_with_name_returns_valid_parameter(IRequire sut)
		{
			// Given
			var name = "TName";

			// When
			var result = sut.TypeParameter<int>(name) as IValidatableParameter<Type>;

			// Then
			result.ShouldNotBeNull();
			result.Name.ShouldBe(name);
			result.Value.ShouldBe(typeof(int));
		}

		private static List<object[]> GetRequireInstances()
		{
			return new List<object[]>(3)
			{
				new object[1] { new Require() },
				new object[1] { new RequireAll() },
				new object[1] { new RequireNothing() }
			};
		}
	}
}