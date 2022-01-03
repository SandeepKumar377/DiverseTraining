using System.Threading.Tasks;
using DiverseTraining.DTOs;
using DiverseTraining.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiverseTraining.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //Get all books endpoint
        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        //Get book by id endpoint
        [HttpGet("{bookId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBook([FromRoute] int bookId)
        {
            var book = await _bookService.GetBookById(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //Add book endpoint
        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookDto bookDto, [FromHeader] int userId)
        {
            var bookId = await _bookService.AddNewBook(bookDto, userId);
            return CreatedAtAction(nameof(GetBook), new { id = bookId, controller = "book" }, bookId);
        }

        //Update book endpoint
        [Authorize]
        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookDto bookDto, [FromRoute] int bookId, [FromHeader] int userId)
        {
            var result = await _bookService.UpdateBook(bookId, bookDto, userId);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}