using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.DataAccess
{
    public class BookDao
    {
        private static BookDao instance = null;
        private static readonly object instanceLock = new object();

        public static BookDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookDao();
                    }
                    return instance;
                }
            }
        }

        public List<Book> GetBooks()
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    return context.Books.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving books list: " + ex.Message);
            }
        }

        public Book GetBookById(int id)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var book = context.Books.FirstOrDefault(x => x.BookId == id);
                    if (book == null)
                    {
                        throw new Exception("Book doesn't exist");
                    }
                    return book;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveBook(Book book)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingBook = context.Books
                        .FirstOrDefault(x => x.BookId == book.BookId);

                    if (existingBook != null)
                    {
                        throw new Exception("Book already exists");
                    }

                    context.Books.Add(book);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBook(Book book)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingBook = context.Books
                        .FirstOrDefault(x => x.BookId == book.BookId);

                    if (existingBook != null)
                    {
                        context.Entry(existingBook).CurrentValues.SetValues(book);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Book not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBook(Book book)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var bookToDelete = context.Books
                        .FirstOrDefault(x => x.BookId == book.BookId);

                    if (bookToDelete == null)
                    {
                        throw new Exception("Book is null");
                    }

                    context.Books.Remove(bookToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
