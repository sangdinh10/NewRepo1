using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ObjectBussiness;
using ProjectLibrary.Repository;
using System.Net;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        private IBookReviewRepository repository = new BookReviewRepository(); // Assuming you have a BookReviewRepository

        // GET: api/<BookReviewController> 
        [HttpGet]
        public ActionResult<IEnumerable<BookReview>> GetAllBookReviews() => repository.GetAllBookReviews();

        // GET: api/<BookReviewController> get review by reviewId
        [HttpGet("ReviewById/{reviewId}")]
        public ActionResult<BookReview> GetReviewById(int reviewId)
        {
            var review = repository.GetReviewById(reviewId);
            if (review == null)
            {
                return NotFound(); // Return 404 if the review is not found
            }
            return review;
        }

        // GET api/<BookReviewController>/5
        [HttpGet("{reviewId}")]
        public ActionResult<IEnumerable<BookReview>> GetBookReviews(int reviewId) => repository.GetBookReviews(reviewId);

        // POST api/<BookReviewController>
        [HttpPost]
        public IActionResult CreateReview([FromBody] BookReview reviewDTO)
        {
            if (reviewDTO == null)
            {
                return BadRequest("Invalid review data");
            }

            var newReview = new BookReview()
            {
                ReviewId = reviewDTO.ReviewId,
                BookId = reviewDTO.BookId,
                UserId = reviewDTO.UserId,
                Rating = reviewDTO.Rating,
                ReviewText = reviewDTO.ReviewText,
                ReviewDate = reviewDTO.ReviewDate
            };

            // Call the service to add the review to the database
            repository.SaveReview(newReview);

            // Return a success message or other necessary information
            return Ok("Review created successfully");
        }

        // PUT api/<BookReviewController>/5
        [HttpPut("{reviewId}")]
        public IActionResult UpdateReview(int reviewId, [FromBody] BookReviewDTO updatedReviewDTO)
        {
            if (updatedReviewDTO == null || reviewId != updatedReviewDTO.ReviewId)
            {
                return BadRequest("Invalid review data");
            }

            // Check if the review exists
            var existingReview = repository.GetReviewById(reviewId);
            if (existingReview == null)
            {
                return NotFound("Review not found");
            }

            // Update review information
            existingReview.BookId = updatedReviewDTO.BookId;
            existingReview.UserId = updatedReviewDTO.UserId;
            existingReview.Rating = updatedReviewDTO.Rating;
            existingReview.ReviewText = updatedReviewDTO.ReviewText;
            existingReview.ReviewDate = updatedReviewDTO.ReviewDate;

            // Call the service to save changes to the database
            repository.UpdateReview(existingReview);

            // Return a success message or other necessary information
            return Ok("Review updated successfully");
        }

        // DELETE api/<BookReviewController>/5
        [HttpDelete("{reviewId}")]
        public IActionResult DeleteReview(int reviewId)
        {
            var review = repository.GetReviewById(reviewId);
            if (review == null)
            {
                return NotFound();
            }
            repository.DeleteReview(review);

            // Return a success message or other necessary information
            return Ok("Review deleted successfully");
        }
    }
}



