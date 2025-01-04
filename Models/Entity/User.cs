using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;
    public string? UrlImg { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime old { get; set; }

    public string Sex {  get; set; }
    public string Role { get; set; }
    public decimal Salary { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? AddressLine { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }
}
