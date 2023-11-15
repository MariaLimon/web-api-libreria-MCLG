using libreria_MCLG.Data.Models;
using libreria_MCLG.Data.ViewModels;
using System;
using System.Linq;

namespace libreria_MCLG.Data.Services
{
	public class AuthorService
	{
		private AppDbContext _context;

		public AuthorService(AppDbContext context)
		{
			_context = context;
		}

		public void AddAuthor(AuthorVM author)
		{
			var _author = new Author()
			{
				FullName = author.FullName
				
			};
			_context.Authors.Add(_author);
			_context.SaveChanges();
		}

		public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
		{
			var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
			{
				FullName = n.FullName,
				BookTitles = n.Book_Authors.Select(n => n.Book.Titulo).ToList()
			}).FirstOrDefault();
			return _author;
		}
	}
}
