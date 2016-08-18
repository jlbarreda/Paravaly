namespace Paravaly
{
	internal static class ObjectExtensions
	{
		public static string ToPrettyString(this object obj)
		{
			if (obj == null)
			{
				return "[null]";
			}

			return obj.ToString();
		}
	}
}