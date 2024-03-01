using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class BookReviewDTO
{
    public int ReviewId { get; set; }

    public int? BookId { get; set; }

    public int? UserId { get; set; }

    public int? Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? ReviewDate { get; set; }

  
}
