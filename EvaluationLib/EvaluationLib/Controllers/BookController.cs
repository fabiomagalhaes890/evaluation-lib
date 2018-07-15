using EvaluationLib.Models;
using EvaluationLib.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationLib.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {        
        private readonly BookService _service;

        public BookController(BookContext context)
        {
            _service = new BookService(context);
        }

        [HttpGet(Name = "GetAllBooks")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllBooks());
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetById(int id)
        {
            var book = _service.GetBookById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            _service.CreateBook(book);
            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut("{id}", Name = "UpdateBook")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var bookUpdated = _service.UpdateBook(id, book);
            if (bookUpdated == null)
                return NotFound();

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        public IActionResult DeleteBookById(int id)
        {
            var bookDeleted = _service.DeleteBook(id);
            if (bookDeleted == null)
                return NotFound();

            return NoContent();
        }
    }
}