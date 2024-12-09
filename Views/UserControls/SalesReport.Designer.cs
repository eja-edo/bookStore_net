namespace BookStore.Views.UserControls
{
    partial class SalesReport
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tableLayoutPanel1 = new TableLayoutPanel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            labOrderCount = new Label();
            label1 = new Label();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            labTotalPrice = new Label();
            label2 = new Label();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            labAvgRevegue = new Label();
            label3 = new Label();
            guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            label7 = new Label();
            tableLayoutPanel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            guna2Panel3.SuspendLayout();
            guna2Panel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(guna2Panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(guna2Panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(guna2Panel3, 2, 0);
            tableLayoutPanel1.Controls.Add(guna2Panel4, 0, 1);
            tableLayoutPanel1.Location = new Point(23, 27);
            tableLayoutPanel1.Margin = new Padding(23, 27, 23, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 27.6824036F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 72.3176F));
            tableLayoutPanel1.Size = new Size(1118, 649);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.Controls.Add(labOrderCount);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Margin = new Padding(0, 0, 11, 13);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(361, 166);
            guna2Panel1.TabIndex = 0;
            // 
            // labOrderCount
            // 
            labOrderCount.AutoSize = true;
            labOrderCount.BackColor = Color.White;
            labOrderCount.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            labOrderCount.Location = new Point(23, 85);
            labOrderCount.Margin = new Padding(23, 27, 23, 27);
            labOrderCount.Name = "labOrderCount";
            labOrderCount.Size = new Size(49, 35);
            labOrderCount.TabIndex = 1;
            labOrderCount.Text = "85";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(23, 41);
            label1.Margin = new Padding(23, 27, 23, 27);
            label1.Name = "label1";
            label1.Size = new Size(178, 24);
            label1.TabIndex = 0;
            label1.Text = "Hóa đơn hôm nay";
            // 
            // guna2Panel2
            // 
            guna2Panel2.BorderRadius = 10;
            guna2Panel2.Controls.Add(labTotalPrice);
            guna2Panel2.Controls.Add(label2);
            guna2Panel2.CustomizableEdges = customizableEdges11;
            guna2Panel2.Dock = DockStyle.Fill;
            guna2Panel2.FillColor = Color.White;
            guna2Panel2.Location = new Point(383, 0);
            guna2Panel2.Margin = new Padding(11, 0, 11, 13);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel2.Size = new Size(350, 166);
            guna2Panel2.TabIndex = 1;
            // 
            // labTotalPrice
            // 
            labTotalPrice.AutoSize = true;
            labTotalPrice.BackColor = Color.White;
            labTotalPrice.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            labTotalPrice.Location = new Point(23, 85);
            labTotalPrice.Margin = new Padding(23, 27, 23, 27);
            labTotalPrice.Name = "labTotalPrice";
            labTotalPrice.Size = new Size(167, 35);
            labTotalPrice.TabIndex = 2;
            labTotalPrice.Text = "27,000,000";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(23, 41);
            label2.Margin = new Padding(23, 27, 23, 27);
            label2.Name = "label2";
            label2.Size = new Size(195, 24);
            label2.TabIndex = 1;
            label2.Text = "Doanh thu hôm nay";
            // 
            // guna2Panel3
            // 
            guna2Panel3.BorderRadius = 10;
            guna2Panel3.Controls.Add(labAvgRevegue);
            guna2Panel3.Controls.Add(label3);
            guna2Panel3.CustomizableEdges = customizableEdges13;
            guna2Panel3.Dock = DockStyle.Fill;
            guna2Panel3.FillColor = Color.White;
            guna2Panel3.Location = new Point(755, 0);
            guna2Panel3.Margin = new Padding(11, 0, 0, 13);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges14;
            guna2Panel3.Size = new Size(363, 166);
            guna2Panel3.TabIndex = 2;
            // 
            // labAvgRevegue
            // 
            labAvgRevegue.AutoSize = true;
            labAvgRevegue.BackColor = Color.White;
            labAvgRevegue.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            labAvgRevegue.Location = new Point(23, 85);
            labAvgRevegue.Margin = new Padding(23, 27, 23, 27);
            labAvgRevegue.Name = "labAvgRevegue";
            labAvgRevegue.Size = new Size(49, 35);
            labAvgRevegue.TabIndex = 2;
            labAvgRevegue.Text = "30";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(23, 41);
            label3.Margin = new Padding(23, 27, 23, 27);
            label3.Name = "label3";
            label3.Size = new Size(226, 24);
            label3.TabIndex = 1;
            label3.Text = "TB Doanh thu/hóa đơn";
            // 
            // guna2Panel4
            // 
            guna2Panel4.BorderRadius = 10;
            tableLayoutPanel1.SetColumnSpan(guna2Panel4, 3);
            guna2Panel4.Controls.Add(cartesianChart1);
            guna2Panel4.Controls.Add(label7);
            guna2Panel4.CustomizableEdges = customizableEdges15;
            guna2Panel4.Dock = DockStyle.Fill;
            guna2Panel4.FillColor = Color.White;
            guna2Panel4.Location = new Point(0, 192);
            guna2Panel4.Margin = new Padding(0, 13, 0, 0);
            guna2Panel4.Name = "guna2Panel4";
            guna2Panel4.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2Panel4.Size = new Size(1118, 457);
            guna2Panel4.TabIndex = 3;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cartesianChart1.BackColor = Color.White;
            cartesianChart1.Location = new Point(23, 72);
            cartesianChart1.Margin = new Padding(3, 4, 3, 4);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(1075, 365);
            cartesianChart1.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label7.Location = new Point(23, 27);
            label7.Margin = new Padding(23, 27, 23, 27);
            label7.Name = "label7";
            label7.Size = new Size(248, 29);
            label7.TabIndex = 2;
            label7.Text = "Doanh thu bán hàng";
            // 
            // SalesReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 232, 245);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SalesReport";
            Size = new Size(1163, 703);
            tableLayoutPanel1.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            guna2Panel2.PerformLayout();
            guna2Panel3.ResumeLayout(false);
            guna2Panel3.PerformLayout();
            guna2Panel4.ResumeLayout(false);
            guna2Panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Label labOrderCount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labTotalPrice;
        private Label labAvgRevegue;
        private Label label7;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
    }
}
