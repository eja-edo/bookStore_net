using BookStore.Controllers;
using BookStore.Models.Data;
using BookStore.Models.Entity;
using BookStore.Models.ModelViews;
using BookStore.Utilities;
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
    public partial class eplManagement : UserControl
    {
        ListEmpController controller;
        public eplManagement()
        {
            InitializeComponent();
            controller = new ListEmpController(this);
        }



        public void SetEmpsData(List<ItemEmp> emps)
        {
            // Xóa tất cả các hàng hiện có trong DataGridView
            guna2DataGridView1.Rows.Clear();

            // Lặp qua danh sách sản phẩm và thêm vào DataGridView
            foreach (var emp in emps)
            {
                int rowIndex = guna2DataGridView1.Rows.Add();  // Thêm một hàng mới
                guna2DataGridView1.Rows[rowIndex].Cells["EplID"].Value = emp.Id;
                guna2DataGridView1.Rows[rowIndex].Cells["EplName"].Value = emp.Name;
                guna2DataGridView1.Rows[rowIndex].Cells["Role"].Value = emp.Role;
                guna2DataGridView1.Rows[rowIndex].Cells["Phone"].Value = emp.Phone;
                guna2DataGridView1.Rows[rowIndex].Cells["Salary"].Value = Format.formatPrice(emp.Salary);
                guna2DataGridView1.Rows[rowIndex].Cells["Address"].Value = emp.Address;

                guna2DataGridView1.Rows[rowIndex].Cells["info"].Value = Properties.Resources.edit;
                guna2DataGridView1.Rows[rowIndex].Cells["delete"].Value = Properties.Resources.bin;
            }
        }

        private void eplManagement_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(1);
            controller.LoadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormInfoEmp newEmploy = new FormInfoEmp();
            newEmploy.ShowDialog();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0) // Kiểm tra nếu nhấn vào cột Xóa
            {
                int rowIndex = e.RowIndex;
                // Lấy giá trị ID từ cột EplID (giả sử cột ID là cột "EplID")
                int idValue = Convert.ToInt32(guna2DataGridView1.Rows[rowIndex].Cells["EplID"].Value);

                // Hiển thị hộp thoại xác nhận
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa thông tin sản phẩm ở hàng {rowIndex + 1}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Nếu người dùng chọn Yes (Xóa)
                if (dialogResult == DialogResult.Yes)
                {
                    // Thực hiện xóa dữ liệu
                    bool isDeleted = EmployeeDAO.DeleteUserById(idValue);

                    if (isDeleted)
                    {
                        // Nếu xóa thành công, có thể làm mới DataGridView hoặc thông báo thành công
                        MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật lại DataGridView nếu cần
                        guna2DataGridView1.Rows.RemoveAt(rowIndex);
                    }
                    else
                    {
                        // Nếu không xóa thành công, thông báo lỗi
                        MessageBox.Show("Xóa người dùng không thành công. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == 6 && e.RowIndex >= 0) // Kiểm tra nếu nhấn vào cột Sửa
            {
                int rowIndex = e.RowIndex;

                // Lấy giá trị của cột ID
                var idValue = guna2DataGridView1.Rows[rowIndex].Cells["EplID"].Value;

                if (idValue != null && int.TryParse(idValue.ToString(), out int id))
                {
                    // Tạo đối tượng FormInfoEmp và truyền ID
                    FormInfoEmp newEmploy = new FormInfoEmp(id);
                    var result = newEmploy.ShowDialog();
                    
                    //if (result == DialogResult.OK) // Kiểm tra nếu form con trả về DialogResult.OK
                    // Lấy dữ liệu từ form con
                    ItemEmp item = newEmploy.getItem();
                    if (item != null)
                    {
                        // Cập nhật giá trị của các ô trong DataGridView
                        guna2DataGridView1.Rows[rowIndex].Cells["EplID"].Value = item.Id;
                        guna2DataGridView1.Rows[rowIndex].Cells["EplName"].Value = item.Name;
                        guna2DataGridView1.Rows[rowIndex].Cells["Role"].Value = item.Role;
                        guna2DataGridView1.Rows[rowIndex].Cells["Phone"].Value = item.Phone;
                        guna2DataGridView1.Rows[rowIndex].Cells["Salary"].Value = Format.formatPrice(item.Salary);
                        guna2DataGridView1.Rows[rowIndex].Cells["Address"].Value = item.Address;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu được trả về!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lấy ID từ hàng được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

