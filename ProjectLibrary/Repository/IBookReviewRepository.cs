using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{

    public interface IBookReviewRepository
    {
        List<BookReview> GetAllBookReviews();
        List<BookReview> GetBookReviews(int bookId);
        void SaveReview(BookReview review);
        BookReview GetReviewById(int id);
        void DeleteReview(BookReview review);
        void UpdateReview(BookReview review);
    }


}
