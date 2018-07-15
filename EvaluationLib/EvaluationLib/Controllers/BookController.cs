using EvaluationLib.DTO;
using EvaluationLib.Models;
using EvaluationLib.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public List<Book> GetAll()
        {
            return _service.GetAllBooks();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public Book GetById(int id)
        {
            return _service.GetBookById(id);
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
            _service.UpdateBook(id, book);
            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        public void DeleteBookById(int id)
        {
            _service.DeleteBook(id);
        }
    }
}