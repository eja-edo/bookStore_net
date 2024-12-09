using MaterialSkin;
using MaterialSkin.Controls;

namespace BookStore.Utilities
{
    public class BaseMaterialForm : MaterialForm
    {
        public BaseMaterialForm()
        {
            // Cấu hình MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);

            // Chỉ thay đổi theme và màu sắc cho thanh tiêu đề
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800,   // Màu header
                Primary.Blue900,   // Màu hover header
                Primary.Blue500,   // Màu khác trong header
                Accent.LightBlue200, // Màu accent
                TextShade.WHITE    // Màu chữ header
            );

            // Điều chỉnh thủ công cho các thành phần không cần hiệu ứng MaterialSkin
            RemoveMaterialSkinFromControls();
        }

        private void RemoveMaterialSkinFromControls()
        {
            // Duyệt qua tất cả các control và kiểm tra loại của mỗi control
            foreach (Control control in Controls)
            {
                // Kiểm tra nếu control là một trong các thành phần của MaterialSkin
                if (control is MaterialButton ||
                    control is MaterialTextBox ||
                    control is MaterialLabel ||
                    control is MaterialCheckbox ||
                    control is MaterialRadioButton)
                {
                    // Thực hiện thay đổi các thuộc tính của MaterialSkin nếu cần thiết
                    control.BackColor = SystemColors.Control; // Đặt lại màu nền mặc định cho các control này
                    control.ForeColor = SystemColors.ControlText; // Đặt lại màu chữ mặc định cho các control này
                }
                else
                {
                    // Giữ nguyên cấu hình cũ của các control không phải MaterialSkin
                    // Không thay đổi gì đối với những control này
                }
            }
        }
    }
}
