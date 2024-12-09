using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class OrderItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

}
