using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ObjectBussiness;
using ProjectLibrary.Repository;
using System.Net;
using System.Security.Policy;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository _response = new BookRepository();
        // GET: api/<NotificationController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetDiscountCoupons() => _response.GetBooks();


        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var Book = _response.GetBookById(id);
            if (Book == null)
            {
                return NotFound();
            }
            return Book;
        }

        // POST api/<NotificationController>
        [HttpPost]
        public IActionResult PostBook(Book BookDTO)
        {
            if (ModelState.IsValid)
            {
                var newBook = new Book
                {
                    BookId = BookDTO.BookId,
                    Title = BookDTO.Title,
                    AuthorId = BookDTO.AuthorId,
                    PublisherId = BookDTO.PublisherId,
                    GenreId = BookDTO.GenreId,
                    Price = BookDTO.Price,
                    Quantity = BookDTO.Quantity

                };

                _response.SaveBook(newBook);

                return Ok("book created successfully");
            }

            return BadRequest("Invalid book data");
        }

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, BookDTO BookDTO)
        {
            var existingBook = _response.GetBookById(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của  existingOrder từ nDTO
            existingBook.BookId = BookDTO.BookId;
            existingBook.Title = BookDTO.Title;
            existingBook.AuthorId = BookDTO.AuthorId;
            existingBook.PublisherId = BookDTO.PublisherId;
            existingBook.GenreId = BookDTO.GenreId;
            existingBook.Price = BookDTO.Price;
            existingBook.Quantity = BookDTO.Quantity;

            _response.UpdateBook(existingBook);

            return Ok("book updated successfully");
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var temp = _response.GetBookById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _response.DeleteBook(temp);
            return Ok("book dalete successfully");
        }

    }

}

