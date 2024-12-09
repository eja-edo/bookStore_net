using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.ModelViews
{
    public class Order
    {
        public int? IdOrder { get; set; }
        public DateTime cretateDate { get; set; }
        public int? IdCustomer { get; set; }
        public string CustomerName { get; set; }
        public string paymentMethod  { get; set; }
        public decimal discount {  get; set; }
        public decimal total { get; set; }
        public string note {  get; set; }

    }
}
