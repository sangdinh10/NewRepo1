using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetBooks() => BookDao.Instance.GetBooks();
        public Book GetBookById(int id) => BookDao.Instance.GetBookById(id);
        public void SaveBook(Book book) => BookDao.Instance.SaveBook(book);
        public void UpdateBook(Book book) => BookDao.Instance.UpdateBook(book);
        public void DeleteBook(Book book) => BookDao.Instance.DeleteBook(book);
    }
}
