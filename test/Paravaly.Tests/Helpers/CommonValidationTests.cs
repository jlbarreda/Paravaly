using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;

namespace Paravaly.Tests.Helpers
{
	public static class CommonValidationTests
	{
		private const string parameterName = "parameter";

		public static void IsValid<T>(IEnumerable<T> validValues, Func<IParameter<T>, IValidatingParameter<T>> validation)
		{
			foreach (T value in validValues)
			{
				IsValid(value, validation);
			}
		}

		public static void IsValid<T>(T validValue, Func<IParameter<T>, IValidatingParameter<T>> validation)
		{
			Require.Parameter(nameof(validation), validation).IsNotNull().Apply();

			// Given
			var parameter = new Parameter<T>(parameterName, validValue, ExceptionHandlingMode.ThrowAll);

			// When
			validation(parameter).Apply();

			// Then
			// No exception is thrown.
		}

		public static void IsNotValid<T>(IEnumerable<T> invalidValues, Func<IParameter<T>, IValidatingParameter<T>> validation)
		{
			foreach (T value in invalidValues)
			{
				IsNotValid(value, validation);
			}
		}

		public static void IsNotValid<T>(T invalidValue, Func<IParameter<T>, IValidatingParameter<T>> validation)
		{
			Require.Parameter(nameof(validation), validation).IsNotNull().Apply();

			// Given
			var parameter = new Parameter<T>(parameterName, invalidValue, ExceptionHandlingMode.ThrowAll);

			// When/Then
			Should.Throw<ParameterValidationException>(() => validation(parameter).Apply());
		}

		public static void AddsCorrectExceptionWhenInvalid<T>(
			T invalidValue,
			Type exceptionType,
			Func<IParameter<T>, IValidatingParameter<T>> validation)
		{
			Require.Parameter(nameof(exceptionType), exceptionType).IsNotNull()
				.AndParameter(nameof(validation), validation).IsNotNull()
				.Apply();

			// Given
			var parameter = new Parameter<T>(parameterName, invalidValue, ExceptionHandlingMode.ThrowFirst);

			// When
			var ex = Should.Throw<Exception>(() => validation(parameter).Apply());

			// Then
			ex.ShouldBeOfType(exceptionType);
		}

		public static void CanUseCustomErrorMessage<T>(
			T invalidValue,
			Func<IParameter<T>, string, IValidatingParameter<T>> validation)
		{
			Require.Parameter(nameof(validation), validation).IsNotNull().Apply();

			// Given
			const string errorMessage = "Error";
			var parameter = new Parameter<T>(parameterName, invalidValue, ExceptionHandlingMode.ThrowAll);

			// When
			var ex = Should.Throw<ParameterValidationException>(() => validation(parameter, errorMessage).Apply());

			// Then
			ex.InnerExceptions.First().Message.ShouldContain(errorMessage);
		}

		public static void ThrowsIfParameterIsNull<T>(
			Func<IParameter<T>, IValidatingParameter<T>> validation)
		{
			Require.Parameter(nameof(validation), validation).IsNotNull().Apply();

			// Given
			IParameter<T> parameter = null;

			// When/Then
			// ReSharper disable once ExpressionIsAlwaysNull
			Should.Throw<ArgumentNullException>(() => validation(parameter));
		}

		public static void ThrowsIfParameterIsNull<T>(
			Func<IParameter<T>, string, IValidatingParameter<T>> validation)
		{
			Require.Parameter(nameof(validation), validation).IsNotNull().Apply();

			// Given
			IParameter<T> parameter = null;

			// When
			// ReSharper disable once ExpressionIsAlwaysNull
			Should.Throw<ArgumentNullException>(() => validation(parameter, string.Empty));
		}
	}
}