using BookStore.Models.Data;
using BookStore.Models.ModelViews;
using BookStore.Utilities;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookStore.Views.UserControls
{
    public partial class SalesReport : UserControl
    {
        public SalesReport()
        {
            InitializeComponent();
            SalesReport_loadData();
        }

        public void SalesReport_loadData()
        {
            int currentYear = DateTime.Now.Year;
            // Gọi thủ tục với năm hiện tại
            var reports = ReportDAO.GetMonthlyRevenueReport(currentYear);

            // Hiển thị trên giao diện
            LoadcartesianChart1(reports);

            var todayRevenue = ReportDAO.GetTodayRevenue();

            LoadRevenue(todayRevenue.OrderCount, todayRevenue.TotalRevenue); 
        }

        private void LoadRevenue(int orderCount , Decimal TotalPrice)
        {
            labOrderCount.Text = orderCount.ToString();
            labTotalPrice.Text = Format.formatPrice(TotalPrice);
            labAvgRevegue.Text = Format.formatPrice(TotalPrice/orderCount);
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void LoadcartesianChart1(List<MonthlyRevenueReport> reports)
        {
            // Chuẩn bị dữ liệu cho biểu đồ
            var months = reports.Select(r => $"Tháng {r.Month}").ToArray();
            var revenues = reports.Select(r => (double)r.TotalRevenue).ToArray();
            var orders = reports.Select(r => (double)r.OrderCount).ToArray();

            // Cấu hình Series cho biểu đồ
            cartesianChart1.Series = new ISeries[]
            {
                // Cột doanh thu
                new ColumnSeries<double>
                {
                    Name = "Doanh thu",
                    Values = revenues,
                    Fill = new SolidColorPaint(SKColors.Blue),
                    ScalesYAt = 0 // Gắn với trục Y đầu tiên
                },
                // Đường số đơn hàng
                new LineSeries<double>
                {
                    Name = "Số đơn hàng",
                    Values = orders,
                    GeometrySize = 10,
                    Stroke = new SolidColorPaint(SKColors.Red, 2),
                    GeometryStroke = new SolidColorPaint(SKColors.Red, 2),
                    GeometryFill = new SolidColorPaint(SKColors.White),
                    ScalesYAt = 1 // Gắn với trục Y thứ hai
                }
            };

            // Cấu hình trục X (Tháng)
            cartesianChart1.XAxes = new[]
            {
                new Axis
                {
                    Name = "Tháng",
                    Labels = months,
                    TextSize = 14,
                }
            };

            // Cấu hình trục Y (Doanh thu - trục Y đầu tiên)
            cartesianChart1.YAxes = new[]
            {
                new Axis
                {
                    Name = "Doanh thu (VND)",
                    Labeler = value => value.ToString("N0"), // Định dạng tiền tệ
                    TextSize = 14
                },
                // Cấu hình trục Y cho số đơn hàng (trục Y thứ hai)
                new Axis
                {
                    Name = "Số đơn hàng",
                    Position = LiveChartsCore.Measure.AxisPosition.End, // Đặt trục Y thứ hai ở phía bên phải
                    Labeler = value => value.ToString("N0"), // Hiển thị số lượng đơn hàng
                    TextSize = 14
                }
            };
        }
    }
}
