namespace Paravaly
{
	internal static class StringExtensions
	{
		public static bool IsWhiteSpace(this string text)
		{
			if (text == null)
			{
				return false;
			}

			for (int i = 0; i < text.Length; i++)
			{
				if (!char.IsWhiteSpace(text[i]))
				{
					return false;
				}
			}

			return true;
		}
	}
}