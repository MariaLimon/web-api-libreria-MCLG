using libreria_MCLG.Data.ViewModels;
using libreria_MCLG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace libreria_MCLG.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        //metodo para agregar un nuevo libro en la BD
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherID,
          
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach(var id in book.AutorIDs)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }
        //metodo para mostrar todos los libros
        public List<Book> GetAllBook() => _context.Books.ToList();
        //metodo para mostrar un libor especifico po id
        public BookWithAuthorsVM GetBooksById(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.id == bookId).Select(book => new BookWithAuthorsVM()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AutorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;

		}
        //metodo para modofocar un libro de la base de datos
        public Book UpdateBookByID(int bookid,BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book != null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id==bookid);
            if( _book != null)
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }

    }
}
