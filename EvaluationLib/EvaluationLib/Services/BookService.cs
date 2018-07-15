using EvaluationLib.Models;
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
        }

        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book UpdateBook(int id, Book item)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return null;
            }

            book.RegistrationDate = item.RegistrationDate;
            book.Name = item.Name;

            _context.Books.Update(book);
            _context.SaveChanges();
            return book;
        }

        public string DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return "Livro não encontrado";
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return "Livro excluído";
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.OrderBy(b => b.Name).ToList();
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
