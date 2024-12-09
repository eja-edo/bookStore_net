namespace BookStore.Views.UserControls
{
    partial class ProductReport
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            ChartBestProduct = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            label7 = new Label();
            guna2Panel4.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel4
            // 
            guna2Panel4.BorderRadius = 10;
            guna2Panel4.Controls.Add(ChartBestProduct);
            guna2Panel4.Controls.Add(guna2ComboBox1);
            guna2Panel4.Controls.Add(label7);
            guna2Panel4.CustomizableEdges = customizableEdges3;
            guna2Panel4.Dock = DockStyle.Fill;
            guna2Panel4.FillColor = Color.White;
            guna2Panel4.Location = new Point(0, 0);
            guna2Panel4.Margin = new Padding(0, 13, 0, 0);
            guna2Panel4.Name = "guna2Panel4";
            guna2Panel4.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel4.Size = new Size(986, 739);
            guna2Panel4.TabIndex = 4;
            // 
            // ChartBestProduct
            // 
            ChartBestProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChartBestProduct.BackColor = Color.White;
            ChartBestProduct.Location = new Point(11, 87);
            ChartBestProduct.Margin = new Padding(11, 13, 11, 13);
            ChartBestProduct.Name = "ChartBestProduct";
            ChartBestProduct.Size = new Size(963, 639);
            ChartBestProduct.TabIndex = 4;
            // 
            // guna2ComboBox1
            // 
            guna2ComboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ComboBox1.BackColor = Color.Transparent;
            guna2ComboBox1.BorderColor = Color.Transparent;
            guna2ComboBox1.BorderRadius = 12;
            guna2ComboBox1.BorderThickness = 0;
            guna2ComboBox1.CustomizableEdges = customizableEdges1;
            guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox1.FillColor = Color.FromArgb(224, 224, 224);
            guna2ComboBox1.FocusedColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            guna2ComboBox1.ForeColor = Color.FromArgb(26, 43, 136);
            guna2ComboBox1.ItemHeight = 30;
            guna2ComboBox1.Items.AddRange(new object[] { "Tuần này", "Tháng này", "Năm này" });
            guna2ComboBox1.Location = new Point(837, 21);
            guna2ComboBox1.Margin = new Padding(3, 4, 3, 4);
            guna2ComboBox1.Name = "guna2ComboBox1";
            guna2ComboBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ComboBox1.Size = new Size(138, 36);
            guna2ComboBox1.StartIndex = 0;
            guna2ComboBox1.TabIndex = 3;
            guna2ComboBox1.SelectedValueChanged += PeriodSelectionChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label7.Location = new Point(23, 27);
            label7.Margin = new Padding(23, 27, 23, 27);
            label7.Name = "label7";
            label7.Size = new Size(319, 29);
            label7.TabIndex = 2;
            label7.Text = "Top 10 sản phẩm bán chạy";
            // 
            // ProductReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2Panel4);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductReport";
            Size = new Size(986, 739);
            guna2Panel4.ResumeLayout(false);
            guna2Panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart ChartBestProduct;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Label label7;
    }
}
