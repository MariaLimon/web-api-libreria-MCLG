using libreria_MCLG.Data.Services;
using libreria_MCLG.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace libreria_MCLG.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private AuthorService _authorService;
		public AuthorsController(AuthorService authorService)
		{
			_authorService = authorService;
		}

		[HttpPost("add-author")]
		public IActionResult AddAuthor([FromBody] AuthorVM author)
		{
			_authorService.AddAuthor(author);
			return Ok();
		}

		[HttpGet("get-author-with-book-by-id/{id}")]
		public IActionResult GetAuthorWithBooks(int id)
		{
			var response = _authorService.GetAuthorWithBooks(id);
			return Ok(response);
		}
	}
}
