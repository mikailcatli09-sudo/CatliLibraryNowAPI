using CatliLibraryNowAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ObjectiveC;

namespace CatliLibraryNowAPI.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
        new Book { Id = 1, Title = "Don Quiote", Author = "Lewis Carroll", Genre ="Fiction" , Available = true, PublishedYear = 1886},
        new Book { Id = 2,  Title = "The adventures Lily", Author ="Mark Twain" , Genre ="Historical", Available = true,PublishedYear = 1935},
        };

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(new { status = "success", data = books, message = "Books retrieved." });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { status = "error", data = (object?)null, message = "Books not found" });
            return Ok(new { status = "success", data = book, message = "Book retrieved." });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book newBook)
        {
            newBook.Id = books.Count + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetbyId), new { id = newBook.Id },
                new { status = "success", data = newBook, message = "Book created." });
        }
        [HttpPost("{id}")]

        public IActionResult Update(int id, [FromBody] Book updateBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { status = "error", data = (object)null, message = "Book not found." });

            book.Title = updateBook.Title;
            book.Author = updateBook.Author;
            book.Genre = updateBook.Genre;
            book.Available = updateBook.Available;
            book.PublishedYear = updateBook.PublishedYear;

            return Ok(new { status = "success", data = book, message = "Book update." });

        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(book => book.Id == id);
            return NotFound(new { status = "error", data = (object?)null, message = "Book not Found" });

            books.Remove(book);
            return Ok(new { status = "success", date = (object?)null, message = "Books Removed" });
        }
    }
}

