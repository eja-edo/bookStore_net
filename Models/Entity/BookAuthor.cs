using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class BookAuthor
{
    public int AuthorID { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}
