using BookStore.Models.ModelViews;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LiveChartsCore.SkiaSharpView.WinForms;
using BookStore.Models.Data;

namespace BookStore.Views.UserControls
{
    public partial class ProductReport : UserControl
    {
        public ProductReport()
        {
            InitializeComponent();
            
            List<BestSellingProduct> bestSellingProducts = GetBestSellingProducts("Tuần này");
            LoadChart(bestSellingProducts, ChartBestProduct);
        }

        public void ProductReport_loadData()
        {
            List<BestSellingProduct> bestSellingProducts = GetBestSellingProducts("Tuần này");
            if (bestSellingProducts != null && bestSellingProducts.Any())
            {
                // Load dữ liệu vào biểu đồ nếu có sản phẩm bán chạy
                LoadChart(bestSellingProducts, ChartBestProduct);
            }
        }

        private void PeriodSelectionChanged(object sender, EventArgs e)
        {
            string selectedPeriod = guna2ComboBox1.SelectedItem.ToString(); // Lấy giá trị từ ComboBox

            // Lấy danh sách sản phẩm bán chạy từ DAO
            List<BestSellingProduct> bestSellingProducts = GetBestSellingProducts(selectedPeriod);
            if (bestSellingProducts != null && bestSellingProducts.Any())
            {
                // Load dữ liệu vào biểu đồ nếu có sản phẩm bán chạy
                LoadChart(bestSellingProducts, ChartBestProduct);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu cho khoảng thời gian đã chọn.");
            }
        }

        public static void LoadChart(List<BestSellingProduct> bestSellingProducts, CartesianChart chart)
        {
            // Tạo danh sách các điểm dữ liệu cho biểu đồ
            var values = new List<ObservableValue>();
            var labels = new List<string>();

            foreach (var product in bestSellingProducts)
            {
                values.Add(new ObservableValue(product.TotalQuantitySold));
                labels.Add(product.ProductName);
            }

            // Tạo chuỗi biểu đồ với các giá trị đã tạo
            var columnSeries = new ColumnSeries<ObservableValue>
            {
                Values = values,
                Name = "Sản phẩm bán chạy"
            };

            // Cập nhật dữ liệu cho chart
            chart.Series = new[] { columnSeries };

            // Thiết lập các nhãn cho trục X (tên sản phẩm)
            chart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels
                }
            };
        }

        // Phương thức lấy danh sách sản phẩm bán chạy theo khoảng thời gian
        public List<BestSellingProduct> GetBestSellingProducts(string period)
        {
            // Chuyển "Tuần này", "Tháng này", "Năm này" thành WEEK, MONTH, YEAR
            string periodValue = ConvertPeriodToSqlValue(period);

            // Đây là nơi bạn thực hiện truy vấn cơ sở dữ liệu để lấy sản phẩm bán chạy
            // Phương thức này sẽ cần kết nối với DAO và gọi thủ tục SQL đã được viết trước đó
            // Giả sử bạn có DAO để lấy danh sách sản phẩm bán chạy.

            List<BestSellingProduct> bestSellingProducts = ReportDAO.GetBestSellingProducts(periodValue);

            return bestSellingProducts;
        }

        // Phương thức chuyển đổi tên khoảng thời gian thành giá trị SQL
        private string ConvertPeriodToSqlValue(string period)
        {
            switch (period)
            {
                case "Tuần này":
                    return "WEEK";
                case "Tháng này":
                    return "MONTH";
                case "Năm này":
                    return "YEAR";
                default:
                    return "WEEK"; // Mặc định là tuần này
            }
        }
    }
}
