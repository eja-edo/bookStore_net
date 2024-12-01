using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.ModelViews
{
    public class InfoEmployee
    {
        public int Id { get; set; }
        public string? urlImg { get; set; }
        public string? first_Name { get; set; }
        public string? last_Name { get; set; }
        public int? age { get; set; }
        public string sex { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public Address Address { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public decimal salary { get; set; }
        public string password { get; set; }

    }
}
