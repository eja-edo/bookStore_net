using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class Book
{
    public int BookId { get; set; }

    public string? Isbn { get; set; }

    public string? Author { get; set; }

    public string? Publisher { get; set; }

    public int? PublishYear { get; set; }

    public int? PageCount { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public virtual Product BookNavigation { get; set; } = null!;

    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();

    public virtual ICollection<BookGenre> Genres { get; set; } = new List<BookGenre>();
}
