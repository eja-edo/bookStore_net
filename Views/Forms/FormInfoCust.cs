using BookStore.Controllers;
using BookStore.Models.Entity;
using BookStore.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.Forms
{
    public partial class FormInfoCust : Form
    {
        private UserController controller;
        private InfoCust customer;

        public FormInfoCust()
        {
            InitializeComponent();
            /*isNew = true;
            customer = new InfoCust();
            controller = new UserController(this, customer);
            isUpdate = true;*/
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

    }
}
