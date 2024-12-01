using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class Author
{
    public int AuthorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Bio { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}
