﻿using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class Genre
{
    public int GenreId { get; set; }

    public string? GenreName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
