using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class RestockItem
{
    public int RestockItemId { get; set; }

    public int? RestockOrderId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitCost { get; set; }

    public virtual Product? Product { get; set; }

    public virtual RestockOrder? RestockOrder { get; set; }
}
