namespace BookStore.Views.Forms
{
    partial class ListRestock
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2NumericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            dataGridRestocks = new Guna.UI2.WinForms.Guna2DataGridView();
            RestockID = new DataGridViewTextBoxColumn();
            RestockDate = new DataGridViewTextBoxColumn();
            Supplier = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            label1 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridRestocks).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel1.Controls.Add(guna2TextBox1);
            guna2Panel1.Controls.Add(guna2NumericUpDown1);
            guna2Panel1.Controls.Add(dataGridRestocks);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(11, 72);
            guna2Panel1.Margin = new Padding(11, 13, 11, 13);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(841, 695);
            guna2Panel1.TabIndex = 0;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2TextBox1.BorderRadius = 15;
            guna2TextBox1.CustomizableEdges = customizableEdges1;
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
            guna2TextBox1.Location = new Point(489, 21);
            guna2TextBox1.Margin = new Padding(3, 5, 3, 5);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "Tìm kiếm theo mã phiếu nhập";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(335, 48);
            guna2TextBox1.TabIndex = 8;
            // 
            // guna2NumericUpDown1
            // 
            guna2NumericUpDown1.BackColor = Color.Transparent;
            guna2NumericUpDown1.BorderRadius = 5;
            guna2NumericUpDown1.CustomizableEdges = customizableEdges3;
            guna2NumericUpDown1.Font = new Font("Segoe UI", 9F);
            guna2NumericUpDown1.Location = new Point(17, 21);
            guna2NumericUpDown1.Margin = new Padding(3, 5, 3, 5);
            guna2NumericUpDown1.Name = "guna2NumericUpDown1";
            guna2NumericUpDown1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2NumericUpDown1.Size = new Size(117, 48);
            guna2NumericUpDown1.TabIndex = 7;
            guna2NumericUpDown1.UpDownButtonFillColor = Color.Silver;
            // 
            // dataGridRestocks
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridRestocks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridRestocks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridRestocks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridRestocks.ColumnHeadersHeight = 47;
            dataGridRestocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridRestocks.Columns.AddRange(new DataGridViewColumn[] { RestockID, RestockDate, Supplier, TotalAmount, Status });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridRestocks.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridRestocks.GridColor = Color.White;
            dataGridRestocks.Location = new Point(17, 93);
            dataGridRestocks.Margin = new Padding(17, 20, 17, 20);
            dataGridRestocks.Name = "dataGridRestocks";
            dataGridRestocks.ReadOnly = true;
            dataGridRestocks.RowHeadersVisible = false;
            dataGridRestocks.RowHeadersWidth = 100;
            dataGridRestocks.RowTemplate.Height = 50;
            dataGridRestocks.ScrollBars = ScrollBars.Vertical;
            dataGridRestocks.Size = new Size(807, 556);
            dataGridRestocks.TabIndex = 5;
            dataGridRestocks.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dataGridRestocks.ThemeStyle.AlternatingRowsStyle.Font = null;
            dataGridRestocks.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dataGridRestocks.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dataGridRestocks.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dataGridRestocks.ThemeStyle.BackColor = Color.White;
            dataGridRestocks.ThemeStyle.GridColor = Color.White;
            dataGridRestocks.ThemeStyle.HeaderStyle.BackColor = Color.Gray;
            dataGridRestocks.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridRestocks.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dataGridRestocks.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dataGridRestocks.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridRestocks.ThemeStyle.HeaderStyle.Height = 47;
            dataGridRestocks.ThemeStyle.ReadOnly = true;
            dataGridRestocks.ThemeStyle.RowsStyle.BackColor = Color.White;
            dataGridRestocks.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridRestocks.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dataGridRestocks.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dataGridRestocks.ThemeStyle.RowsStyle.Height = 50;
            dataGridRestocks.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridRestocks.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // RestockID
            // 
            RestockID.HeaderText = "Mã đơn hàng";
            RestockID.MinimumWidth = 6;
            RestockID.Name = "RestockID";
            RestockID.ReadOnly = true;
            // 
            // RestockDate
            // 
            RestockDate.HeaderText = "Thời gian";
            RestockDate.MinimumWidth = 6;
            RestockDate.Name = "RestockDate";
            RestockDate.ReadOnly = true;
            // 
            // Supplier
            // 
            Supplier.HeaderText = "Nhà cung cấp";
            Supplier.MinimumWidth = 6;
            Supplier.Name = "Supplier";
            Supplier.ReadOnly = true;
            // 
            // TotalAmount
            // 
            TotalAmount.HeaderText = "Tổng tiền";
            TotalAmount.MinimumWidth = 6;
            TotalAmount.Name = "TotalAmount";
            TotalAmount.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Trạng thái";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(11, 13);
            label1.Margin = new Padding(11, 13, 11, 13);
            label1.Name = "label1";
            label1.Size = new Size(169, 35);
            label1.TabIndex = 1;
            label1.Text = "Nhập hàng";
            // 
            // guna2Button1
            // 
            guna2Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2Button1.BorderRadius = 15;
            guna2Button1.CustomizableEdges = customizableEdges7;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(25, 135, 69);
            guna2Button1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(622, 13);
            guna2Button1.Margin = new Padding(3, 4, 3, 4);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button1.Size = new Size(199, 48);
            guna2Button1.TabIndex = 6;
            guna2Button1.Text = "+ Thêm sản phẩm";
            // 
            // ListRestock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(guna2Button1);
            Controls.Add(guna2Panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ListRestock";
            Size = new Size(864, 767);
            Load += ListRestock_Load;
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridRestocks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown1;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridRestocks;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private DataGridViewTextBoxColumn RestockID;
        private DataGridViewTextBoxColumn RestockDate;
        private DataGridViewTextBoxColumn Supplier;
        private DataGridViewTextBoxColumn TotalAmount;
        private DataGridViewTextBoxColumn Status;
    }
}
