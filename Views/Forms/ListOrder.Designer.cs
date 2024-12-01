namespace BookStore.Views.Forms
{
    partial class ListOrder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            productID = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            stock = new DataGridViewTextBoxColumn();
            categories = new DataGridViewTextBoxColumn();
            info = new DataGridViewImageColumn();
            delete = new DataGridViewImageColumn();
            guna2NumericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(10, 10);
            label1.Margin = new Padding(10);
            label1.Name = "label1";
            label1.Size = new Size(112, 29);
            label1.TabIndex = 3;
            label1.Text = "Hóa đơn";
            label1.Click += label1_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2Button1.BorderRadius = 15;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(25, 135, 69);
            guna2Button1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(592, 10);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(174, 36);
            guna2Button1.TabIndex = 7;
            guna2Button1.Text = "+ Thêm sản phẩm";
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(guna2DataGridView1);
            guna2Panel1.Controls.Add(guna2NumericUpDown1);
            guna2Panel1.Controls.Add(guna2TextBox1);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Location = new Point(10, 67);
            guna2Panel1.Margin = new Padding(10);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(756, 515);
            guna2Panel1.TabIndex = 8;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            guna2DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 47;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.Columns.AddRange(new DataGridViewColumn[] { productID, ProductName, price, stock, categories, info, delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.White;
            guna2DataGridView1.Location = new Point(10, 64);
            guna2DataGridView1.Margin = new Padding(15);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 100;
            guna2DataGridView1.RowTemplate.Height = 50;
            guna2DataGridView1.ScrollBars = ScrollBars.Vertical;
            guna2DataGridView1.Size = new Size(736, 436);
            guna2DataGridView1.TabIndex = 13;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.Gray;
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 47;
            guna2DataGridView1.ThemeStyle.ReadOnly = true;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 50;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // productID
            // 
            productID.FillWeight = 17.7664967F;
            productID.HeaderText = "Mã sản phẩm";
            productID.Name = "productID";
            productID.ReadOnly = true;
            // 
            // ProductName
            // 
            ProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ProductName.FillWeight = 486.802063F;
            ProductName.HeaderText = "Tên sản phẩm";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            ProductName.Width = 137;
            // 
            // price
            // 
            price.FillWeight = 17.7664967F;
            price.HeaderText = "Đơn giá";
            price.Name = "price";
            price.ReadOnly = true;
            // 
            // stock
            // 
            stock.FillWeight = 17.7664967F;
            stock.HeaderText = "Số lượng";
            stock.Name = "stock";
            stock.ReadOnly = true;
            // 
            // categories
            // 
            categories.FillWeight = 17.7664967F;
            categories.HeaderText = "thể loại";
            categories.Name = "categories";
            categories.ReadOnly = true;
            // 
            // info
            // 
            info.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            info.FillWeight = 71.06599F;
            info.HeaderText = "";
            info.Name = "info";
            info.ReadOnly = true;
            info.Resizable = DataGridViewTriState.True;
            info.SortMode = DataGridViewColumnSortMode.Automatic;
            info.Width = 30;
            // 
            // delete
            // 
            delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            delete.FillWeight = 71.0659943F;
            delete.HeaderText = "";
            delete.Name = "delete";
            delete.ReadOnly = true;
            delete.Resizable = DataGridViewTriState.True;
            delete.SortMode = DataGridViewColumnSortMode.Automatic;
            delete.Width = 30;
            // 
            // guna2NumericUpDown1
            // 
            guna2NumericUpDown1.BackColor = Color.Transparent;
            guna2NumericUpDown1.BorderRadius = 5;
            guna2NumericUpDown1.CustomizableEdges = customizableEdges3;
            guna2NumericUpDown1.Font = new Font("Segoe UI", 9F);
            guna2NumericUpDown1.Location = new Point(10, 10);
            guna2NumericUpDown1.Name = "guna2NumericUpDown1";
            guna2NumericUpDown1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2NumericUpDown1.Size = new Size(102, 36);
            guna2NumericUpDown1.TabIndex = 12;
            guna2NumericUpDown1.UpDownButtonFillColor = Color.Silver;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2TextBox1.BorderRadius = 15;
            guna2TextBox1.CustomizableEdges = customizableEdges5;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.IconRight = Properties.Resources.Search;
            guna2TextBox1.IconRightOffset = new Point(10, 0);
            guna2TextBox1.Location = new Point(453, 10);
            guna2TextBox1.Margin = new Padding(10);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "Tìm kiếm theo mã phiếu nhập";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2TextBox1.Size = new Size(293, 36);
            guna2TextBox1.TabIndex = 10;
            // 
            // ListOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2Panel1);
            Controls.Add(guna2Button1);
            Controls.Add(label1);
            Name = "ListOrder";
            Size = new Size(776, 592);
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private DataGridViewTextBoxColumn productID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn stock;
        private DataGridViewTextBoxColumn categories;
        private DataGridViewImageColumn info;
        private DataGridViewImageColumn delete;
    }
}
