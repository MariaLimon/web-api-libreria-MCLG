using System.Collections.Generic;

namespace libreria_MCLG.Data.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string FullName { get; set; }

		//propiedades de navegacion

		public List<Book_Author> Book_Authors { get; set; }
	}
}
