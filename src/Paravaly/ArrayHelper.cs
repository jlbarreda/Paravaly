namespace Paravaly
{
	internal static class ArrayHelper
	{
		public static T[] Empty<T>()
		{
			return EmptyArrays<T>.Empty;
		}

		private static class EmptyArrays<T>
		{
			public static readonly T[] Empty = new T[0];
		}
	}
}