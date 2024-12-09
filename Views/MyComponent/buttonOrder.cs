using BookStore.Controllers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Views.MyComponent
{
    public partial class buttonOrder : Guna2Button
    {
        // Event tùy chỉnh
        public event EventHandler Click_Image;

        public int index { get; set; }
        
        public buttonOrder()
        {
            InitializeComponent();
            
        }
        public buttonOrder(int index): this()
        {
            this.index = index;
            Text = $"Hóa đơn {index}";
        }   

        public buttonOrder(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            //base.OnMouseClick(e);

            // Tính toán vùng chứa hình ảnh
            int imageX = this.Width - this.ImageSize.Width - 12 -this.Padding.Right; // Vị trí X của hình ảnh (căn phải)
            int imageY = (this.Height - this.ImageSize.Height) / 2; // Vị trí Y của hình ảnh (căn giữa dọc)
            Rectangle imageBounds = new Rectangle(
                imageX,
                imageY,
                this.ImageSize.Width,
                this.ImageSize.Height
            );

            // Kiểm tra nếu vị trí click nằm trong vùng hình ảnh
            if (imageBounds.Contains(e.Location))
            {
                // Kích hoạt sự kiện Click_Image nếu có
                Click_Image?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // Nếu không click vào hình ảnh, gọi sự kiện click mặc định của Guna2Button
                base.OnMouseClick(e);
            }
        }
    }
}
