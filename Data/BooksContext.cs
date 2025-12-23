using LibraryManagementApi.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApi.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
