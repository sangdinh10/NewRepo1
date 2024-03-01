using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        void SaveBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
