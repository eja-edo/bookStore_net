using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CategoryId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<RestockItem> RestockItems { get; set; } = new List<RestockItem>();
}
