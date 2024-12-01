using BookStore.Models.Data;
using BookStore.Models.ModelViews;
using BookStore.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class UserController
    {
        private readonly InfoEmployee model;
        private readonly FormInfoEmp userView;

        public UserController(FormInfoEmp view, InfoEmployee empl)
        {
            this.userView = view;
            model = empl;
        }

        public void SaveUser()
        {
            try
            {
                // Tạo đối tượng InfoEmployee và gán các giá trị từ giao diện người dùng
                InfoEmployee employee = new InfoEmployee
                {
                    email = userView.GetEmail(),
                    first_Name = userView.GetFirstName(),
                    last_Name = userView.GetLastName(),
                    username = userView.GetUserName(),
                    Address = userView.GetAddress(),
                    phone = userView.GetPhone(),
                    salary = userView.GetSalary(),
                    role = userView.GetRole(),
                    sex = userView.GetSex(),
                    password = "defaultPassword", // Mật khẩu mặc định hoặc có thể tạo mật khẩu động
                    urlImg = userView.GetImg()
                };

                // Kiểm tra xem là người dùng mới hay không
                bool isNewUser = userView.isNew;

                if (isNewUser)
                {
                    // Nếu là người dùng mới, gọi DAO để thêm vào cơ sở dữ liệu
                    bool result = DetailEmpDAO.InsertUser(employee);
                    if (result)
                    {
                        MessageBox.Show("User added successfully!");
                        isNewUser = false;
                    }
                    else
                    {
                        MessageBox.Show("Failed to add user.");
                    }
                }
                else
                {
                    //// Nếu không phải người dùng mới, gọi DAO để cập nhật
                    //bool result = userDAO.UpdateUser(employee.username, employee.urlImg, employee.first_Name, employee.last_Name, employee.email,
                    //                                  employee.sex, employee.role, employee.phone, employee.salary,
                    //                                  employee.Address.line, employee.Address.city, employee.Address.province);
                    //if (result)
                    //{
                    //    MessageBox.Show("User updated successfully!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Failed to update user.");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }

}
