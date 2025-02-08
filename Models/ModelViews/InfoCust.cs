using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.ModelViews
{
    public class InfoCust
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public Address? Address { get; set; }
        public string? City { get; set; }
        public string? Provice { get; set; }
        public string? Create_date { get; set; }
        public string? Gender { get; set; }
        public int Score { get; set; }
    }
}
