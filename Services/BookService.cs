using LibraryManagementApi.Data;
using LibraryManagementApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace LibraryManagementApi.Repositories
{
    public class BookService : IBookService
    {
        private readonly BooksContext _context;
        public BookService(BooksContext context)
        {
                _context = context;
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
                return false;

            _context.Books.Remove(existingBook);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(string? author, string? genre)
        {
            var query = _context.Books.AsQueryable();

            if(!string.IsNullOrEmpty(author))
                query = query.Where(q => q.Author == author);
            if(!string.IsNullOrEmpty(genre))
                query = query.Where(q => q.Genre == genre);

            return await query.ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if (existingBook == null)
                return null;

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.PublishedYear = book.PublishedYear;

            await _context.SaveChangesAsync();
            return existingBook;
        }
    }
}
