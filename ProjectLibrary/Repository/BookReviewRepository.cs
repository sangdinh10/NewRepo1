using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public class BookReviewRepository : IBookReviewRepository
    {
        public List<BookReview> GetAllBookReviews() => BookReviewDAO.Instance.GetAllBookReviews();

        public List<BookReview> GetBookReviews(int bookId) => BookReviewDAO.Instance.GetBookReviews(bookId);

        public void SaveReview(BookReview review) => BookReviewDAO.Instance.SaveReview(review);

        public BookReview GetReviewById(int id) => BookReviewDAO.Instance.FindReviewById(id);

        public void DeleteReview(BookReview review) => BookReviewDAO.Instance.DeleteReview(review);

        public void UpdateReview(BookReview review) => BookReviewDAO.Instance.UpdateReview(review);


    }


}
