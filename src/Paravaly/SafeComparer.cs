using System;

namespace Paravaly
{
	internal static class SafeComparer
	{
		public static int Compare<T>(IComparable<T> a, T b)
			where T : IComparable<T>
		{
			if (ReferenceEquals(a, b))
			{
				return 0;
			}

			if (a == null)
			{
				return -1;
			}

			return a.CompareTo(b);
		}
	}
}