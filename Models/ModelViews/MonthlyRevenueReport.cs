using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.ModelViews
{
    public class MonthlyRevenueReport
    {
        public int Month { get; set; } // Tháng (1 - 12)
        public int OrderCount { get; set; } // Số lượng đơn hàng
        public decimal TotalRevenue { get; set; } // Tổng doanh thu
    }
}
