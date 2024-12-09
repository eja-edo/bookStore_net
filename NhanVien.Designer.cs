namespace BookStore
{
    partial class NhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhanVien));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            Product = new TabPage();
            productView1 = new Views.Forms.productView();
            bill = new TabPage();
            listOrder1 = new Views.Forms.ListOrder();
            wareHouse = new TabPage();
            listRestock1 = new Views.Forms.ListRestock();
            imageList1 = new ImageList(components);
            materialTabControl1.SuspendLayout();
            Product.SuspendLayout();
            bill.SuspendLayout();
            wareHouse.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(Product);
            materialTabControl1.Controls.Add(bill);
            materialTabControl1.Controls.Add(wareHouse);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            materialTabControl1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(3, 72);
            materialTabControl1.Margin = new Padding(3, 4, 3, 4);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1025, 619);
            materialTabControl1.TabIndex = 3;
            // 
            // Product
            // 
            Product.BackColor = Color.FromArgb(242, 242, 242);
            Product.Controls.Add(productView1);
            Product.ImageKey = "supplier.png";
            Product.Location = new Point(4, 39);
            Product.Margin = new Padding(3, 4, 3, 4);
            Product.Name = "Product";
            Product.Padding = new Padding(3, 4, 3, 4);
            Product.Size = new Size(1017, 576);
            Product.TabIndex = 1;
            Product.Text = "Hàng hóa";
            // 
            // productView1
            // 
            productView1.Dock = DockStyle.Fill;
            productView1.Location = new Point(3, 4);
            productView1.Name = "productView1";
            productView1.Size = new Size(1011, 568);
            productView1.TabIndex = 0;
            // 
            // bill
            // 
            bill.BackColor = Color.FromArgb(242, 242, 242);
            bill.Controls.Add(listOrder1);
            bill.ImageKey = "bill.png";
            bill.Location = new Point(4, 50);
            bill.Margin = new Padding(3, 4, 3, 4);
            bill.Name = "bill";
            bill.Size = new Size(192, 46);
            bill.TabIndex = 2;
            bill.Text = "Hóa đơn";
            // 
            // listOrder1
            // 
            listOrder1.Dock = DockStyle.Fill;
            listOrder1.Location = new Point(0, 0);
            listOrder1.Margin = new Padding(3, 4, 3, 4);
            listOrder1.Name = "listOrder1";
            listOrder1.Size = new Size(192, 46);
            listOrder1.TabIndex = 0;
            // 
            // wareHouse
            // 
            wareHouse.BackColor = Color.FromArgb(242, 242, 242);
            wareHouse.Controls.Add(listRestock1);
            wareHouse.ImageKey = "logistics.png";
            wareHouse.Location = new Point(4, 50);
            wareHouse.Margin = new Padding(3, 4, 3, 4);
            wareHouse.Name = "wareHouse";
            wareHouse.Size = new Size(192, 46);
            wareHouse.TabIndex = 3;
            wareHouse.Text = "Nhập hàng";
            // 
            // listRestock1
            // 
            listRestock1.Dock = DockStyle.Fill;
            listRestock1.Location = new Point(0, 0);
            listRestock1.Margin = new Padding(3, 4, 3, 4);
            listRestock1.Name = "listRestock1";
            listRestock1.Size = new Size(192, 46);
            listRestock1.TabIndex = 0;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "report.png");
            imageList1.Images.SetKeyName(1, "logistics.png");
            imageList1.Images.SetKeyName(2, "bill.png");
            imageList1.Images.SetKeyName(3, "supplier.png");
            imageList1.Images.SetKeyName(4, "Users.png");
            // 
            // NhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1031, 695);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            FormStyle = FormStyles.ActionBar_48;
            Margin = new Padding(3, 4, 3, 4);
            Name = "NhanVien";
            Padding = new Padding(3, 72, 3, 4);
            Text = "NhanVien (DALL store)";
            materialTabControl1.ResumeLayout(false);
            Product.ResumeLayout(false);
            bill.ResumeLayout(false);
            wareHouse.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage Product;
        private Views.Forms.productView productView1;
        private TabPage bill;
        private Views.Forms.ListOrder listOrder1;
        private TabPage wareHouse;
        private Views.Forms.ListRestock listRestock1;
        private ImageList imageList1;
    }
}