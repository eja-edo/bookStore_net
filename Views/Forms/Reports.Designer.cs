namespace BookStore.Views.Forms
{
    partial class Reports
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
        public void LoadData()
        {

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
            guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            tabControl1 = new TabControl();
            reportOrder = new TabPage();
            salesReport1 = new UserControls.SalesReport();
            reportProduct = new TabPage();
            productReport1 = new UserControls.ProductReport();
            tabControl1.SuspendLayout();
            reportOrder.SuspendLayout();
            reportProduct.SuspendLayout();
            SuspendLayout();
            // 
            // guna2ComboBox1
            // 
            guna2ComboBox1.BackColor = Color.Transparent;
            guna2ComboBox1.BorderThickness = 0;
            guna2ComboBox1.CustomizableEdges = customizableEdges1;
            guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox1.FillColor = SystemColors.Control;
            guna2ComboBox1.FocusedColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            guna2ComboBox1.ForeColor = Color.Black;
            guna2ComboBox1.ItemHeight = 30;
            guna2ComboBox1.Items.AddRange(new object[] { "Báo cáo tài chính", "Báo cáo sản phẩm" });
            guna2ComboBox1.Location = new Point(21, 15);
            guna2ComboBox1.Name = "guna2ComboBox1";
            guna2ComboBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ComboBox1.Size = new Size(257, 36);
            guna2ComboBox1.StartIndex = 0;
            guna2ComboBox1.TabIndex = 0;
            guna2ComboBox1.UseWaitCursor = true;
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(reportOrder);
            tabControl1.Controls.Add(reportProduct);
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Location = new Point(0, 51);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(843, 508);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 1;
            // 
            // reportOrder
            // 
            reportOrder.Controls.Add(salesReport1);
            reportOrder.Location = new Point(4, 5);
            reportOrder.Name = "reportOrder";
            reportOrder.Padding = new Padding(3);
            reportOrder.Size = new Size(835, 499);
            reportOrder.TabIndex = 0;
            reportOrder.Text = "tabPage1";
            reportOrder.UseVisualStyleBackColor = true;
            // 
            // salesReport1
            // 
            salesReport1.BackColor = Color.FromArgb(226, 232, 245);
            salesReport1.Dock = DockStyle.Fill;
            salesReport1.Location = new Point(3, 3);
            salesReport1.Margin = new Padding(3, 4, 3, 4);
            salesReport1.Name = "salesReport1";
            salesReport1.Size = new Size(829, 493);
            salesReport1.TabIndex = 0;
            // 
            // reportProduct
            // 
            reportProduct.Controls.Add(productReport1);
            reportProduct.Location = new Point(4, 5);
            reportProduct.Name = "reportProduct";
            reportProduct.Padding = new Padding(3);
            reportProduct.Size = new Size(835, 499);
            reportProduct.TabIndex = 1;
            reportProduct.Text = "tabPage2";
            reportProduct.UseVisualStyleBackColor = true;
            // 
            // productReport1
            // 
            productReport1.Dock = DockStyle.Fill;
            productReport1.Location = new Point(3, 3);
            productReport1.Margin = new Padding(3, 5, 3, 5);
            productReport1.Name = "productReport1";
            productReport1.Size = new Size(829, 493);
            productReport1.TabIndex = 0;
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(guna2ComboBox1);
            Name = "Reports";
            Size = new Size(843, 561);
            tabControl1.ResumeLayout(false);
            reportOrder.ResumeLayout(false);
            reportProduct.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private TabControl tabControl1;
        private TabPage reportOrder;
        private TabPage reportProduct;
        private UserControls.ProductReport productReport1;
        private UserControls.SalesReport salesReport1;
    }
}
