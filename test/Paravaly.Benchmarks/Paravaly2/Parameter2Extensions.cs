using System;

namespace Paravaly.Benchmarks.Paravaly2
{
	public static class Parameter2Extensions
	{
		public static Parameter2<string> IsNotEmpty(this Parameter2<string> parameter)
		{
			return parameter.IsNotEmpty("ErrorMessage.ForEmpty");
		}

		public static Parameter2<string> IsNotEmpty(this Parameter2<string> parameter, string errorMessage)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			return parameter.IsValid(
				p =>
				{
					if (p.Value?.Length < 1)
					{
						p.Handle(new ArgumentException(errorMessage, p.Name));
					}
				});
		}

	}
}