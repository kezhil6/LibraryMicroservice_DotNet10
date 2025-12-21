using LibraryManagementApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookServie;
        public BooksController(IBookService bookService)
        {
            _bookServie = bookService;
        }


    }
}
