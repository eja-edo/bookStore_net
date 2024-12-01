using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? Discount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
