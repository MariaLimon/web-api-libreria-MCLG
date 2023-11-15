using libreria_MCLG.Data.Services;
using libreria_MCLG.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace libreria_MCLG.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		public BookService _bookService;

		public BookController(BookService bookService)
		{
			_bookService = bookService;
		}
		[HttpGet("get-all-books")]
		public IActionResult GetAllBooks()
		{
			var allbook = _bookService.GetAllBook();
			return Ok(allbook);
		}

		[HttpGet("get-books-by-id/{id}")]
		public IActionResult GetAllBooksById(int id)
		{
			var book = _bookService.GetBooksById(id);
			return Ok(book);
		}

		[HttpPost("add-book-with-authors")]
		public IActionResult AddBook([FromBody]BookVM book)
		{
			_bookService.AddBookWithAuthors(book);
			return Ok();
		}

		[HttpPut("update-book-by-id/{id}")]
		public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
		{
			var updatebook = _bookService.UpdateBookByID(id, book);
			return Ok(updatebook);
		}

		[HttpDelete("delete-book-by-id/{id}")]
		public IActionResult DeleteBookById(int id)
		{
			_bookService.DeleteBookById(id);
			return Ok();
		}
	}
}
