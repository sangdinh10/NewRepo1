using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public int? AuthorId { get; set; }

    public int? PublisherId { get; set; }

    public int? GenreId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<BookImage> BookImages { get; set; } = new List<BookImage>();

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual Genre? Genre { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Publisher? Publisher { get; set; }
}
