using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class BookDTO
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public int? AuthorId { get; set; }

    public int? PublisherId { get; set; }

    public int? GenreId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual Author? Author { get; set; }


}
