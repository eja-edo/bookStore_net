using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class Inventory
{
    public int ProductId { get; set; }

    public int StockLevel { get; set; }

    public int ReorderLevel { get; set; }

    public virtual Product Product { get; set; } = null!;
}
