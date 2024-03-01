using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.DataAccess
{
    public class BookImageDao
    {
        private static BookImageDao instance = null;
        private static readonly object instanceLock = new object();

        public static BookImageDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookImageDao();
                    }
                    return instance;
                }
            }
        }

        public List<BookImage> GetBookImages()
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    return context.BookImages.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving book images list: " + ex.Message);
            }
        }

        public BookImage GetBookImageById(int id)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var bookImage = context.BookImages.FirstOrDefault(x => x.ImageId == id);
                    if (bookImage == null)
                    {
                        throw new Exception("Book image doesn't exist");
                    }
                    return bookImage;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveBookImage(BookImage bookImage)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingBookImage = context.BookImages
                        .FirstOrDefault(x => x.ImageId == bookImage.ImageId);

                    if (existingBookImage != null)
                    {
                        throw new Exception("Book image already exists");
                    }

                    context.BookImages.Add(bookImage);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBookImage(BookImage bookImage)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingBookImage = context.BookImages
                        .FirstOrDefault(x => x.ImageId == bookImage.ImageId);

                    if (existingBookImage != null)
                    {
                        context.Entry(existingBookImage).CurrentValues.SetValues(bookImage);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Book image not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBookImage(BookImage bookImage)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var bookImageToDelete = context.BookImages
                        .FirstOrDefault(x => x.ImageId == bookImage.ImageId);

                    if (bookImageToDelete == null)
                    {
                        throw new Exception("Book image is null");
                    }

                    context.BookImages.Remove(bookImageToDelete);
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
