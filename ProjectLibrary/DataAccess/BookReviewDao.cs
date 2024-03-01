using Microsoft.EntityFrameworkCore;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.DataAccess
{
    public class BookReviewDAO
    {
        private static BookReviewDAO instance = null;
        private static readonly object instanceLock = new object();

        public static BookReviewDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookReviewDAO();
                    }
                    return instance;
                }
            }
        }

        // Get all book reviews
        public List<BookReview> GetAllBookReviews()
        {
            var reviews = new List<BookReview>();
            try
            {
                using (var context = new DoAnWedSachContext()) // Replace YourDbContext with the actual DbContext for your application
                {
                    reviews = context.BookReviews.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving BookReviews list: " + ex.Message);
            }
            return reviews;
        }

        // Get book reviews by book id
        public List<BookReview> GetBookReviews(int bookId)
        {
            var reviews = new List<BookReview>();
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    reviews = context.BookReviews
                        .Where(r => r.BookId == bookId)
                        .Include(r => r.User)
                        .OrderByDescending(r => r.ReviewId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving BookReviews list: " + ex.Message);
            }
            return reviews;
        }

        // Find book review by review id
        public BookReview FindReviewById(int reviewId)
        {
            BookReview review = new BookReview();
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    review = context.BookReviews.FirstOrDefault(x => x.ReviewId == reviewId);
                }
                if (review == null)
                {
                    throw new Exception("Review not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return review;
        }

        // Insert book review
        public void SaveReview(BookReview review)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingReview = context.BookReviews.FirstOrDefault(x => x.ReviewId == review.ReviewId);
                    if (existingReview != null)
                    {
                        throw new Exception("Review already exists");
                    }

                    context.BookReviews.Add(review);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error saving changes to the database. See inner exception for details.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the entity changes. See the inner exception for details.", ex);
            }
        }

        // Update book review
        public void UpdateReview(BookReview review)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingReview = context.BookReviews.FirstOrDefault(x => x.ReviewId == review.ReviewId);

                    if (existingReview != null)
                    {
                        context.Entry(existingReview).CurrentValues.SetValues(review);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Review not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete book review
        public void DeleteReview(BookReview review)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var reviewToDelete = context.BookReviews.FirstOrDefault(x => x.ReviewId == review.ReviewId);
                    if (reviewToDelete == null)
                    {
                        throw new Exception("Review not found");
                    }
                    else
                    {
                        context.BookReviews.Remove(reviewToDelete);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }



}


