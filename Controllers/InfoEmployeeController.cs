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

        public void Load_data(int id)
        {
            // Lấy thông tin nhân viên từ DAO
            InfoEmployee fetchedEmployee = DetailEmpDAO.GetUserById(id);
            userView.setNotUpdate();
            if (fetchedEmployee != null)
            {
                // Cập nhật từng thuộc tính của đối tượng model
                model.Id = fetchedEmployee.Id;
                model.urlImg = fetchedEmployee.urlImg;
                model.first_Name = fetchedEmployee.first_Name;
                model.last_Name = fetchedEmployee.last_Name;
                model.age = fetchedEmployee.age;
                model.sex = fetchedEmployee.sex;
                model.email = fetchedEmployee.email;
                model.phone = fetchedEmployee.phone;
                model.username = fetchedEmployee.username;
                model.role = fetchedEmployee.role;
                model.salary = fetchedEmployee.salary;
                model.password = null;

                // Cập nhật thông tin địa chỉ
                if (fetchedEmployee.Address != null)
                {
                    model.Address = model.Address ?? new Address();
                    model.Address.line = fetchedEmployee.Address.line;
                    model.Address.city = fetchedEmployee.Address.city;
                    model.Address.province = fetchedEmployee.Address.province;
                }

                // Cập nhật các thông tin khác vào View
                userView.setID(id);
                userView.SetFirstName(model.first_Name);
                userView.SetSalary(model.salary);
                userView.SetRole(model.role);
                userView.SetLastName(model.last_Name);
                userView.SetDateOfBirth(model.age);
                userView.SetSex(model.sex);
                userView.SetEmail(model.email);
                userView.SetPhone(model.phone);
                userView.setPass("");
                userView.setAddress(model.Address);
                userView.SetRole(model.role);
                userView.SetUsername(model.username);
                userView.SetSalary(model.salary);
                userView.SetProfilePicture(model.urlImg);


            }
            else
            {
                Console.WriteLine("Employee not found!");
                // Xử lý trường hợp không tìm thấy nhân viên
            }
        }

        public void SaveUser()
        {
            if(userView.isUpdate)
            {
                try
                {   string errorMessage; // Khai báo biến để nhận thông báo lỗi
                    userView.setNotUpdate();
                    // Tạo đối tượng InfoEmployee và gán các giá trị từ giao diện người dùng
                    model.email = userView.GetEmail();
                    model.first_Name = userView.GetFirstName();
                    model.last_Name = userView.GetLastName();
                    model.username = userView.GetUserName();
                    model.age = userView.GetOldDate();
                    model.Address = userView.GetAddress();
                    model.phone = userView.GetPhone();
                    model.salary = userView.GetSalary();
                    model.role = userView.GetRole();
                    model.sex = userView.GetSex();
                    model.password = (userView.getPass()=="")?null:userView.getPass(); // Mật khẩu mặc định hoặc có thể tạo mật khẩu động


                    if (userView.isNew)
                    {
                        int id ;
                        // Nếu là người dùng mới, gọi DAO để thêm vào cơ sở dữ liệu
                        bool result = DetailEmpDAO.InsertUser(model , out id);
                        if (result)
                        {
                            MessageBox.Show("User added successfully!");
                            userView.setID(id);
                            userView.isNew = false;
                        }
                        else
                        {
                            MessageBox.Show("Failed to add user.");
                        }
                    }
                    else
                    {
                    
                        bool result = DetailEmpDAO.UpdateUser(model, out errorMessage);

                        if (result)
                        {
                            MessageBox.Show("User updated successfully!");
                        }
                        else
                        {
                            // Hiển thị thông báo lỗi nếu cập nhật thất bại
                            MessageBox.Show($"Failed to update user. Error: {errorMessage}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                userView.setUpdate();
            }
        }
    }
}
