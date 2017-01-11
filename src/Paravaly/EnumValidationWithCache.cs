using System;
using System.Collections.Generic;

namespace Paravaly
{
	internal static class EnumValidationWithCache<T>
				where T : struct, IComparable, IFormattable
	{
		private static readonly Dictionary<T, bool> validValues = new Dictionary<T, bool>();

		public static bool IsValid(T value)
		{
			if (validValues.ContainsKey(value))
			{
				return true;
			}

			// Slow!
			// Single value.
			if (Enum.IsDefined(typeof(T), value))
			{
				validValues.Add(value, true);
				return true;
			}
			else
			{
				// Slower!
				var valueAsString = value.ToString();

				// Valid flags combination.
				if (valueAsString.Length > 0 && !char.IsDigit(valueAsString[0]) && valueAsString[0] != '-')
				{
					validValues.Add(value, true);
					return true;
				}
			}

			return false;
		}
	}
}