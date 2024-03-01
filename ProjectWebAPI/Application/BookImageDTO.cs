using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class BookImageDTO
{
    public int ImageId { get; set; }

    public int? BookId { get; set; }

    public string? ImageUrl { get; set; }

 
}
