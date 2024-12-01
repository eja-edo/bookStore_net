using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.ModelViews
{
    public class ItemEmp
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? Phone { get; set; }
        public decimal Salary {  get; set; }
        public string? Address {  get; set; }
    }
}
