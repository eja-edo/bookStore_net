namespace BookStore
{
    partial class QuanLy
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLy));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            imageList1 = new ImageList(components);
            menu = new MaterialSkin.Controls.MaterialTabControl();
            Employee = new TabPage();
            eplManagement1 = new Views.Forms.eplManagement();
            Product = new TabPage();
            productView1 = new Views.Forms.productView();
            bill = new TabPage();
            listOrder1 = new Views.Forms.ListOrder();
            wareHouse = new TabPage();
            listRestock1 = new Views.Forms.ListRestock();
            report = new TabPage();
            reports1 = new Views.Forms.Reports();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            menu.SuspendLayout();
            Employee.SuspendLayout();
            Product.SuspendLayout();
            bill.SuspendLayout();
            wareHouse.SuspendLayout();
            report.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
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
            // menu
            // 
            menu.Controls.Add(Employee);
            menu.Controls.Add(Product);
            menu.Controls.Add(bill);
            menu.Controls.Add(wareHouse);
            menu.Controls.Add(report);
            menu.Depth = 0;
            menu.Dock = DockStyle.Fill;
            menu.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            menu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            menu.ImageList = imageList1;
            menu.Location = new Point(0, 72);
            menu.Margin = new Padding(3, 4, 3, 4);
            menu.MouseState = MaterialSkin.MouseState.HOVER;
            menu.Multiline = true;
            menu.Name = "menu";
            menu.SelectedIndex = 0;
            menu.Size = new Size(1238, 613);
            menu.TabIndex = 2;
            menu.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
            // 
            // Employee
            // 
            Employee.BackColor = Color.FromArgb(242, 242, 242);
            Employee.Controls.Add(eplManagement1);
            Employee.ImageKey = "Users.png";
            Employee.Location = new Point(4, 39);
            Employee.Margin = new Padding(3, 4, 3, 4);
            Employee.Name = "Employee";
            Employee.Padding = new Padding(3, 4, 3, 4);
            Employee.Size = new Size(1230, 570);
            Employee.TabIndex = 0;
            Employee.Text = "Nhân viên";
            // 
            // eplManagement1
            // 
            eplManagement1.Dock = DockStyle.Fill;
            eplManagement1.Location = new Point(3, 4);
            eplManagement1.Margin = new Padding(3, 4, 3, 4);
            eplManagement1.Name = "eplManagement1";
            eplManagement1.Size = new Size(1224, 562);
            eplManagement1.TabIndex = 0;
            // 
            // Product
            // 
            Product.BackColor = Color.FromArgb(242, 242, 242);
            Product.Controls.Add(productView1);
            Product.ImageKey = "supplier.png";
            Product.Location = new Point(4, 73);
            Product.Margin = new Padding(3, 4, 3, 4);
            Product.Name = "Product";
            Product.Padding = new Padding(3, 4, 3, 4);
            Product.Size = new Size(192, 23);
            Product.TabIndex = 1;
            Product.Text = "Hàng hóa";
            // 
            // productView1
            // 
            productView1.Dock = DockStyle.Fill;
            productView1.Location = new Point(3, 4);
            productView1.Name = "productView1";
            productView1.Size = new Size(186, 15);
            productView1.TabIndex = 0;
            // 
            // bill
            // 
            bill.BackColor = Color.FromArgb(242, 242, 242);
            bill.Controls.Add(listOrder1);
            bill.ImageKey = "bill.png";
            bill.Location = new Point(4, 73);
            bill.Margin = new Padding(3, 4, 3, 4);
            bill.Name = "bill";
            bill.Size = new Size(192, 23);
            bill.TabIndex = 2;
            bill.Text = "Hóa đơn";
            // 
            // listOrder1
            // 
            listOrder1.Dock = DockStyle.Fill;
            listOrder1.Location = new Point(0, 0);
            listOrder1.Margin = new Padding(3, 4, 3, 4);
            listOrder1.Name = "listOrder1";
            listOrder1.Size = new Size(192, 23);
            listOrder1.TabIndex = 0;
            // 
            // wareHouse
            // 
            wareHouse.BackColor = Color.FromArgb(242, 242, 242);
            wareHouse.Controls.Add(listRestock1);
            wareHouse.ImageKey = "logistics.png";
            wareHouse.Location = new Point(4, 73);
            wareHouse.Margin = new Padding(3, 4, 3, 4);
            wareHouse.Name = "wareHouse";
            wareHouse.Size = new Size(192, 23);
            wareHouse.TabIndex = 3;
            wareHouse.Text = "Nhập hàng";
            // 
            // listRestock1
            // 
            listRestock1.Dock = DockStyle.Fill;
            listRestock1.Location = new Point(0, 0);
            listRestock1.Margin = new Padding(3, 4, 3, 4);
            listRestock1.Name = "listRestock1";
            listRestock1.Size = new Size(192, 23);
            listRestock1.TabIndex = 0;
            // 
            // report
            // 
            report.BackColor = Color.FromArgb(242, 242, 242);
            report.Controls.Add(reports1);
            report.ImageKey = "report.png";
            report.Location = new Point(4, 73);
            report.Margin = new Padding(3, 4, 3, 4);
            report.Name = "report";
            report.Size = new Size(192, 23);
            report.TabIndex = 4;
            report.Text = "Báo cáo";
            // 
            // reports1
            // 
            reports1.Dock = DockStyle.Fill;
            reports1.Location = new Point(0, 0);
            reports1.Name = "reports1";
            reports1.Size = new Size(192, 23);
            reports1.TabIndex = 0;
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.BackColor = Color.Transparent;
            guna2CirclePictureBox1.FillColor = Color.Transparent;
            guna2CirclePictureBox1.Image = Properties.Resources.user_interface;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(1172, 33);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(32, 32);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2CirclePictureBox1.TabIndex = 3;
            guna2CirclePictureBox1.TabStop = false;
            guna2CirclePictureBox1.Click += guna2CirclePictureBox1_Click;
            // 
            // QuanLy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1241, 688);
            Controls.Add(guna2CirclePictureBox1);
            Controls.Add(menu);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = menu;
            FormStyle = FormStyles.ActionBar_48;
            Margin = new Padding(3, 4, 3, 4);
            Name = "QuanLy";
            Padding = new Padding(0, 72, 3, 3);
            Text = "DALL STORE";
            Load += Form1_Load;
            menu.ResumeLayout(false);
            Employee.ResumeLayout(false);
            Product.ResumeLayout(false);
            bill.ResumeLayout(false);
            wareHouse.ResumeLayout(false);
            report.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialTabControl menu;
        private TabPage Employee;
        private TabPage Product;
        private TabPage bill;
        private TabPage wareHouse;
        private TabPage report;
        private Views.Forms.eplManagement eplManagement1;
        private Views.Forms.productView productView1;
        private Views.Forms.ListOrder listOrder1;
        private Views.Forms.ListRestock listRestock1;
        private Views.Forms.Reports reports1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}
