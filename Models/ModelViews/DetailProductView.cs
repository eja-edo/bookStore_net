using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.ModelViews
{
    public class DetailProductView
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int? StockLevel { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public List<string> ListUrl { get; set; }
        public string? CategoryName { get; set; }
        public string? description { get; set; }
        public DateTime? old { get; set; }
    }

}
