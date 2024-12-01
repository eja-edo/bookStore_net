using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.ModelViews
{
    public class ProductViewModel
    {
        public string? UrlImg { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? StockLevel { get; set; }
        public string CategoryName { get; set; }

        public static implicit operator ProductViewModel(DetailProductView v)
        {
            throw new NotImplementedException();
        }
    }
}
