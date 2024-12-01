using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class Collection
{
    public int CollectionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
