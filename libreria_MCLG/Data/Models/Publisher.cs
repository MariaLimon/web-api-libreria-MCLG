using System.Collections.Generic;

namespace libreria_MCLG.Data.Models
{
	public class Publisher
	{
		public int Id { get; set; }
		public string Name { get; set; }

		//propiedades de navegacion
		public List<Book> Book {get; set;}

	}
}
