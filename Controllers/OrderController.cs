using BookStore.Models.Data;
using BookStore.Models.Entity;
using BookStore.Models.ModelViews;
using BookStore.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    internal class OrderController
    {
        private CreateOrder _view;
        private Models.ModelViews.Order order;
        private List<OrderItem> orderItems;
        

        public OrderController(CreateOrder view )
        {
            _view = view;
            order = new Models.ModelViews.Order();
        }

        public void ClickOrder()
        {
            try
            {
                // Lấy thông tin đơn hàng từ view
                order.paymentMethod = _view.GetPaymentMethod();
                order.discount = _view.getInpDiscount();
                order.total = _view.getInpTotal();
                order.note = _view.getNote();

                // Gọi DAO để thêm đơn hàng và nhận kết quả
                var result = OrderDAO.AddOrder(order);

                // Kiểm tra xem result có hợp lệ hay không
                if (result.OrderID != 0)
                {
                    order.cretateDate = DateTime.Now;
                    order.IdCustomer = result.CustomerID;
                    order.IdOrder = result.OrderID;

                    // Lấy danh sách sản phẩm từ view
                    orderItems = _view.GetListItem();

                    // Thông báo ID đơn hàng
                    MessageBox.Show($"{order.IdOrder}", "Total Items", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Thêm các sản phẩm vào đơn hàng
                    OrderDAO.AddOrderItems((int)order.IdOrder, orderItems);

                    // Cập nhật dữ liệu lên view
                    _view.setDataList(order);
                    _view.setDelete();
                }
                else
                {
                    // Nếu result là null hoặc không hợp lệ, thông báo lỗi
                    MessageBox.Show("An error occurred while processing the order. The order could not be added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi đặt hàng
                MessageBox.Show($"An error occurred while processing the order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
