using LibraryManagementApi.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApi.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
