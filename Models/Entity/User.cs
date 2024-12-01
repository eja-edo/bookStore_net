using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Role { get; set; }

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public string? AddressLine { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
