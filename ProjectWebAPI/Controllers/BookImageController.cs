using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ObjectBussiness;
using ProjectLibrary.Repository;
using System.Net;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImageController : ControllerBase
    {
        private IBookImageRepository _response = new BookImageRepository();
        // GET: api/<NotificationController>
        [HttpGet]
        public ActionResult<IEnumerable<BookImage>> GetBookImages() => _response.GetBookImages();


        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        public ActionResult<BookImage> GetBookImageById(int id)
        {
            var BookImage = _response.GetBookImageById(id);
            if (BookImage == null)
            {
                return NotFound();
            }
            return BookImage;
        }

        // POST api/<NotificationController>
        [HttpPost]
        public IActionResult PostDiscountCoupon(BookImage BookDTO)
        {
            if (ModelState.IsValid)
            {
                var newBookImage = new BookImage
                {
                    ImageId = BookDTO.ImageId,
                    BookId = BookDTO.BookId,
                    ImageUrl = BookDTO.ImageUrl,

                };

                _response.SaveBookImage(newBookImage);

                return Ok("BookImage created successfully");
            }

            return BadRequest("Invalid BookImage data");
        }

        // PUT api/<BookImageController>/5
        [HttpPut("{id}")]
        public IActionResult PutDiscountCoupon(int id, BookImage BookDTO)
        {
            var existingBookImage = _response.GetBookImageById(id);

            if (existingBookImage == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của  existingOrder từ nDTO
            existingBookImage.ImageId = BookDTO.ImageId;
            existingBookImage.BookId = BookDTO.BookId;
            existingBookImage.ImageUrl = BookDTO.ImageUrl;

            _response.UpdateBookImage(existingBookImage);

            return Ok(" BookImage updated successfully");
        }

        // DELETE api/<BookImageController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBookImage(int id)
        {
            var temp = _response.GetBookImageById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _response.DeleteBookImage(temp);
            return Ok("BookImage dalete successfully");
        }

    }

}

