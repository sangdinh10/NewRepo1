using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public class BookImageRepository : IBookImageRepository
    {
        public List<BookImage> GetBookImages() => BookImageDao.Instance.GetBookImages();
        public BookImage GetBookImageById(int id) => BookImageDao.Instance.GetBookImageById(id);
        public void SaveBookImage(BookImage bookImage) => BookImageDao.Instance.SaveBookImage(bookImage);
        public void UpdateBookImage(BookImage bookImage) => BookImageDao.Instance.UpdateBookImage(bookImage);
        public void DeleteBookImage(BookImage bookImage) => BookImageDao.Instance.DeleteBookImage(bookImage);
    }
}
