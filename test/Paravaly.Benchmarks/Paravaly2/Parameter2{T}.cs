using System;
using System.Collections.Generic;

namespace Paravaly.Benchmarks.Paravaly2
{
	public class Parameter2<T>
	{
		private readonly string name;
		private readonly T value;
		private readonly List<Exception> exceptions;

		internal Parameter2(string name, T value)
			: this(name, value, new List<Exception>())
		{
		}

		internal Parameter2(string name, T value, List<Exception> exceptions)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			if (string.IsNullOrWhiteSpace(name))
			{
				if (string.IsNullOrEmpty(name))
				{
					throw new ArgumentException("ErrorMessage.ForEmpty", nameof(name));
				}

				throw new ArgumentException("ErrorMessage.ForWhiteSpace", nameof(name));
			}

			if (exceptions == null)
			{
				throw new ArgumentNullException(nameof(exceptions));
			}

			this.value = value;
			this.name = name;
			this.exceptions = exceptions;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public T Value
		{
			get
			{
				return this.value;
			}
		}

		public Parameter2<T> IsValid(Action<Parameter2<T>> validate)
		{
			if (validate == null)
			{
				throw new ArgumentNullException(nameof(validate));
			}

			validate(this);

			return this;
		}

		public void Handle(Exception exception)
		{
			this.exceptions.Add(exception);
		}

		public IEnumerable<Exception> ThenGetExceptions()
		{
			return this.exceptions;
		}
	}
}