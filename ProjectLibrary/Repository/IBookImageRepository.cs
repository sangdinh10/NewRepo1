using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public interface IBookImageRepository
    {
        List<BookImage> GetBookImages();
        BookImage GetBookImageById(int id);
        void SaveBookImage(BookImage bookImage);
        void UpdateBookImage(BookImage bookImage);
        void DeleteBookImage(BookImage bookImage);
    }
}
