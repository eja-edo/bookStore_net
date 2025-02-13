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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            menu = new MaterialSkin.Controls.MaterialTabControl();
            Product = new TabPage();
            productView1 = new Views.Forms.productView();
            bill = new TabPage();
            listOrder1 = new Views.Forms.ListOrder();
            wareHouse = new TabPage();
            listRestock1 = new Views.Forms.ListRestock();
            Customer = new TabPage();
            ctmManagement1 = new Views.Forms.ctmManagement();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            imageList1 = new ImageList(components);
            menu.SuspendLayout();
            Product.SuspendLayout();
            bill.SuspendLayout();
            wareHouse.SuspendLayout();
            Customer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menu
            // 
            menu.Controls.Add(Product);
            menu.Controls.Add(bill);
            menu.Controls.Add(wareHouse);
            menu.Controls.Add(Customer);
            menu.Depth = 0;
            menu.Dock = DockStyle.Fill;
            menu.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            menu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            menu.Location = new Point(3, 54);
            menu.MouseState = MaterialSkin.MouseState.HOVER;
            menu.Multiline = true;
            menu.Name = "menu";
            menu.SelectedIndex = 0;
            menu.Size = new Size(1087, 663);
            menu.TabIndex = 3;
            // 
            // Product
            // 
            Product.BackColor = Color.FromArgb(242, 242, 242);
            Product.Controls.Add(productView1);
            Product.ImageKey = "supplier.png";
            Product.Location = new Point(4, 25);
            Product.Name = "Product";
            Product.Padding = new Padding(3);
            Product.Size = new Size(1079, 634);
            Product.TabIndex = 1;
            Product.Text = "Hàng hóa";
            // 
            // productView1
            // 
            productView1.Dock = DockStyle.Fill;
            productView1.Location = new Point(3, 3);
            productView1.Margin = new Padding(3, 2, 3, 2);
            productView1.Name = "productView1";
            productView1.Size = new Size(1073, 628);
            productView1.TabIndex = 0;
            // 
            // bill
            // 
            bill.BackColor = Color.FromArgb(242, 242, 242);
            bill.Controls.Add(listOrder1);
            bill.ImageKey = "bill.png";
            bill.Location = new Point(4, 46);
            bill.Name = "bill";
            bill.Size = new Size(192, 50);
            bill.TabIndex = 2;
            bill.Text = "Hóa đơn";
            // 
            // listOrder1
            // 
            listOrder1.Dock = DockStyle.Fill;
            listOrder1.Location = new Point(0, 0);
            listOrder1.Name = "listOrder1";
            listOrder1.Size = new Size(192, 50);
            listOrder1.TabIndex = 0;
            // 
            // wareHouse
            // 
            wareHouse.BackColor = Color.FromArgb(242, 242, 242);
            wareHouse.Controls.Add(listRestock1);
            wareHouse.ImageKey = "logistics.png";
            wareHouse.Location = new Point(4, 46);
            wareHouse.Name = "wareHouse";
            wareHouse.Size = new Size(192, 50);
            wareHouse.TabIndex = 3;
            wareHouse.Text = "Nhập hàng";
            // 
            // listRestock1
            // 
            listRestock1.Dock = DockStyle.Fill;
            listRestock1.Location = new Point(0, 0);
            listRestock1.Name = "listRestock1";
            listRestock1.Size = new Size(192, 50);
            listRestock1.TabIndex = 0;
            // 
            // Customer
            // 
            Customer.Controls.Add(ctmManagement1);
            Customer.Location = new Point(4, 46);
            Customer.Name = "Customer";
            Customer.Padding = new Padding(3);
            Customer.Size = new Size(192, 50);
            Customer.TabIndex = 4;
            Customer.Text = "Khách hàng";
            Customer.UseVisualStyleBackColor = true;
            // 
            // ctmManagement1
            // 
            ctmManagement1.Dock = DockStyle.Fill;
            ctmManagement1.Location = new Point(3, 3);
            ctmManagement1.Name = "ctmManagement1";
            ctmManagement1.Size = new Size(186, 44);
            ctmManagement1.TabIndex = 0;
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2CirclePictureBox1.BackColor = Color.Transparent;
            guna2CirclePictureBox1.FillColor = Color.Transparent;
            guna2CirclePictureBox1.Image = Properties.Resources.user_interface;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(1052, 27);
            guna2CirclePictureBox1.Margin = new Padding(3, 2, 3, 2);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(35, 32);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2CirclePictureBox1.TabIndex = 4;
            guna2CirclePictureBox1.TabStop = false;
            guna2CirclePictureBox1.Click += guna2CirclePictureBox1_Click;
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
            imageList1.Images.SetKeyName(5, "door.png");
            // 
            // NhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 720);
            Controls.Add(guna2CirclePictureBox1);
            Controls.Add(menu);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = menu;
            FormStyle = FormStyles.ActionBar_48;
            MinimumSize = new Size(1090, 680);
            Name = "NhanVien";
            Padding = new Padding(3, 54, 3, 3);
            Text = "NhanVien (DALL store)";
            menu.ResumeLayout(false);
            Product.ResumeLayout(false);
            bill.ResumeLayout(false);
            wareHouse.ResumeLayout(false);
            Customer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl menu;
        private TabPage Product;
        private Views.Forms.productView productView1;
        private TabPage bill;
        private Views.Forms.ListOrder listOrder1;
        private TabPage wareHouse;
        private Views.Forms.ListRestock listRestock1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private ImageList imageList1;
        private TabPage Customer;
        private Views.Forms.ctmManagement ctmManagement1;
    }
}