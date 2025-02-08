using BookStore.Controllers;
using BookStore.Models.Data;
using BookStore.Models.ModelViews;
using Guna.UI2.AnimatorNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.UserControls
{
    public partial class AddCtm : UserControl
    {
        private UserController controller;
        private InfoCust customer;
        public AddCtm()
        {
            InitializeComponent();
            //isNew = true;
            customer = new InfoCust();
            //isUpdate = true;
        }

        public ItemCust getItem()
        {
            // Kiểm tra nếu thông tin customer hoặc các trường cần thiết là null hoặc không hợp lệ
            if (customer == null)
            {
                // Trường hợp customer không tồn tại
                throw new InvalidOperationException("customer data is not available.");
            }

            // Nếu tất cả kiểm tra hợp lệ, tạo và trả về ItemEmp
            return new ItemCust
            {
                Id = customer.Id,
                Name = customer.Name,
                //Gender = customer.Gender,
                Address = customer.Address?.line, // Nếu Address là null, sẽ không xảy ra lỗi
                Phone = customer.Phone,
                Score = customer.Score,
                Create_date = customer.Create_date,
            };
        }
        private void Guna2CircleButton1_Click(object sender, EventArgs e)
        {
            // Close the parent form
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (CustDAO.AddCustomer(inpName.Text, inpPhoneNum.Text, inpAddress.Text, inpCity.Text, inpCity.Text))
            {
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
