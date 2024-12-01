using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public virtual ICollection<RestockOrder> RestockOrders { get; set; } = new List<RestockOrder>();
}
