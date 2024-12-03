using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class ProductImage
{
    public int Index { get; set; }

    public string? Url { get; set; }
}
