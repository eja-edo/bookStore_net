using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class RestockOrder
{
    public int RestockOrderId { get; set; }

    public int SupplierId { get; set; }

    public DateTime? RestockDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<RestockItem> RestockItems { get; set; } = new List<RestockItem>();

    public virtual Supplier Supplier { get; set; } = null!;
}
