using System;

namespace libreria_MCLG.Exceptions
{
	public class PublisherNameExceptions : Exception
	{
		public string PublisherName { get; set; }

		public PublisherNameExceptions()
		{

		}

		public PublisherNameExceptions(string message): base(message)
		{

		}

		public PublisherNameExceptions(string message, Exception inner) : base(message, inner)
		{

		}

		public PublisherNameExceptions(string message, string publisherName) : this(message)
		{
			PublisherName = publisherName;
		}
	}
}
