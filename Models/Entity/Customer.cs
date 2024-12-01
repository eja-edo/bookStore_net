using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? AddressLine { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? LoyaltyPoints { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
