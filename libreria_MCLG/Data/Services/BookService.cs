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

        //metodo para crear
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        //metodo para mostrar todos los libros
        public List<Book> GetAllBook() => _context.Books.ToList();
        //metodo para mostrar un libor especifico po id
        public Book GetBooksById(int bookId) => _context.Books.FirstOrDefault(n => n.id == bookId);
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
                _book.Autor = book.Autor;
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
