using BookStore.Models.Data;
using BookStore.Models.ModelViews;
using BookStore.Views.UserControls;

namespace BookStore.Views.Forms
{
    public partial class ListOrder : UserControl
    {

        public ListOrder()
        {
            InitializeComponent();
            orders = new List<Order>(); 
            BindDataGridView();
        }
        public void AddData(Order order)
        {
            orders.Add(order);
            bindingSource.ResetBindings(false);  // Làm mới lại BindingSource
        }

        private List<Order> orders;
        BindingSource bindingSource = new BindingSource();
        private void BindDataGridView()
        {
            // Lấy danh sách đơn hàng từ DAO
            orders = OrderDAO.GetOrderDetails();


            // Gán danh sách đơn hàng vào BindingSource
            bindingSource.DataSource = orders;

            // Gán BindingSource làm DataSource cho DataGridView
            guna2DataGridView1.DataSource = bindingSource;

            // Tùy chỉnh tiêu đề cột
            guna2DataGridView1.Columns["IdOrder"].HeaderText = "Mã đơn hàng";
            guna2DataGridView1.Columns["cretateDate"].HeaderText = "Ngày tạo";
            guna2DataGridView1.Columns["IdCustomer"].HeaderText = "Mã khách hàng";
            guna2DataGridView1.Columns["CustomerName"].HeaderText = "Tên khách hàng";
            guna2DataGridView1.Columns["paymentMethod"].HeaderText = "Phương thức thanh toán";
            guna2DataGridView1.Columns["note"].HeaderText = "Ghi chú";
            guna2DataGridView1.Columns["total"].HeaderText = "Thành tiền";
            // Định dạng cột giá trị "Price" trong DataGridView
            guna2DataGridView1.Columns["total"].DefaultCellStyle.Format = "#,##0 đ";

        }



        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = guna2TextBox1.Text.Trim().ToLower();

            // Nếu không có từ khóa tìm kiếm, hiển thị toàn bộ danh sách đơn hàng
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                bindingSource.DataSource = orders; // Gán lại toàn bộ dữ liệu
                return;
            }

            // Lọc dữ liệu với LINQ
            var filteredOrders = orders
                .Where(order =>
                    order.IdOrder.ToString().Contains(searchValue) ||
                    order.cretateDate.ToString("dd/MM/yyyy").Contains(searchValue) ||
                    order.IdCustomer.ToString().Contains(searchValue) ||
                    order.CustomerName.ToLower().Contains(searchValue) ||
                    order.paymentMethod.ToLower().Contains(searchValue) ||
                    order.note.ToLower().Contains(searchValue) ||
                    order.total.ToString().Contains(searchValue)
                ).ToList();

            // Gán lại dữ liệu đã lọc vào BindingSource
            bindingSource.DataSource = filteredOrders;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            createOrders CreateOrders = new createOrders(this)
            {
                Dock = DockStyle.Fill,           // Đặt Dock để lấp đầy container
                Location = new Point(0, 0),      // Vị trí bắt đầu
                Name = "CreateOrders",          // Tên của UserControl
                Size = new Size(889, 574),       // Kích thước (nếu cần)
                TabIndex = 10                    // TabIndex (nếu cần)
            };
            this.Controls.Add(CreateOrders);
            CreateOrders.BringToFront();
        }
    }
}
