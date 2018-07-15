using EvaluationLib.DTO;
using EvaluationLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationLib.Services
{
    public class BookService
    {
        private readonly BookContext _context;

        public BookService(BookContext context)
        {
            _context = context;
            if (_context.Books.Count() == 0)
            {
                _context.Books.Add(new Book { Name = "Livro 1", RegistrationDate = DateTime.Now });
                _context.SaveChanges();
            }
        }

        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(int id, Book item)
        {

            var book = _context.Books.Find(id);
            if (book == null)
            {
                return; // NotFound();
            }

            book.RegistrationDate = item.RegistrationDate;
            book.Name = item.Name;

            _context.Books.Update(book);
            _context.SaveChanges();
            //return NoContent();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return; //NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            //return NoContent();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return null;// NotFound();
            }
            return book;
        }
    }
}
