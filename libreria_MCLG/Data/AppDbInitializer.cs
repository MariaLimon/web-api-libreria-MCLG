using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using libreria_MCLG.Data.Models;
using System;

namespace libreria_MCLG.Data
{
	public class AppDbInitializer
	{
		//Metodo para agregar datos a la  BD
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

				if (!context.Books.Any())
				{
					context.Books.AddRange(new Book()
					{
						Titulo = "1st Book Title",
						Descripcion = "1st Book Descripcion",
						IsRead = true,
						DateRead = DateTime.Now.AddDays(-10),
						Rate = 4,
						Genero = "Biography",
						CoverUrl = "https...",
						DateAdded = DateTime.Now,


					},
					new Book()
					{
						Titulo = "2nd Book Title",
						Descripcion = "2nd Book Descripcion",
						IsRead = true,
						DateRead = DateTime.Now.AddDays(-10),
						Rate = 4,
						Genero = "Biography",
						CoverUrl = "https...",
						DateAdded = DateTime.Now,


					});
					context.SaveChanges();
				}
			}
		}
	}
}
