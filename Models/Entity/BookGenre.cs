﻿using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class BookGenre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
