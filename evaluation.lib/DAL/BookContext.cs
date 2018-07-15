using EvaluationLib.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaluationLib.DAL
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
