using libreria_MCLG.Data.Models;
using libreria_MCLG.Data.ViewModels;
using System;
//using System.Security.Policy;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using libreria_MCLG.Exceptions;

namespace libreria_MCLG.Data.Services
{
	public class PublisherService
	{
		private AppDbContext _context;

		public PublisherService(AppDbContext context)
		{
			_context = context;
		}

		public Publisher AddPublisher(PublisherVM publisher)
		{
			if (StringStarsWithNumber(publisher.Name)) throw new PublisherNameExceptions("El nombre empieza con un numero",
				publisher.Name);
			var _publisher = new Publisher()
			{
				Name = publisher.Name
				
			};
			_context.Publishers.Add(_publisher);
			_context.SaveChanges();

			return _publisher;
		}

		public Publisher GetPublisherByID(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

		public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
		{
			var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
				.Select(n => new PublisherWithBooksAndAuthorsVM()
				{
					Name = n.Name,
					BooksAuthors = n.Book.Select(n => new BookAuthorVM()
					{
						BookName = n.Titulo,
						BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
					}).ToList()
				}).FirstOrDefault();
			return _publisherData;
		}

		internal void DeletePublisherById(int id)
		{
			var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
			if(_publisher != null)
			{
				_context.Publishers.Remove(_publisher);
				_context.SaveChanges();
			}
			else
			{
				throw new Exception($"La editora con ese id: {id} no existe");
			}
		}

		private bool StringStarsWithNumber(string name) => Regex.IsMatch(name, @"^\d");
			/*
		{
			if(Regex.IsMatch(name, @"^\d")) return true;
			return false;

		}*/
	}
}
