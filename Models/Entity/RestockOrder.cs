using System;
using System.Collections.Generic;

namespace BookStore.Models.Entity;

public partial class RestockOrder
{
    public int RestockOrderID { get; set; }
    public DateTime RestockDate { get; set; }
    public string SupplierName { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
}
