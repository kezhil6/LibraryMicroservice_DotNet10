using LibraryManagementApi.Model;

namespace LibraryManagementApi.Repositories
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(string? author, string? genre);
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}
