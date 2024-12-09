namespace BookStore.Views.UserControls
{
    partial class ItemProductOrder
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
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            labMaxStrock = new Label();
            lab = new Label();
            label6 = new Label();
            label5 = new Label();
            button1 = new Button();
            labTotal = new Label();
            labCurPrice = new Label();
            upDownQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            LabName = new Label();
            LabID = new Label();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)upDownQuantity).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderRadius = 12;
            guna2Panel1.Controls.Add(labMaxStrock);
            guna2Panel1.Controls.Add(lab);
            guna2Panel1.Controls.Add(label6);
            guna2Panel1.Controls.Add(label5);
            guna2Panel1.Controls.Add(button1);
            guna2Panel1.Controls.Add(labTotal);
            guna2Panel1.Controls.Add(labCurPrice);
            guna2Panel1.Controls.Add(upDownQuantity);
            guna2Panel1.Controls.Add(LabName);
            guna2Panel1.Controls.Add(LabID);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Margin = new Padding(3, 4, 3, 4);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(632, 118);
            guna2Panel1.TabIndex = 0;
            // 
            // labMaxStrock
            // 
            labMaxStrock.AutoSize = true;
            labMaxStrock.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            labMaxStrock.ForeColor = Color.Gray;
            labMaxStrock.Location = new Point(181, 60);
            labMaxStrock.Name = "labMaxStrock";
            labMaxStrock.Size = new Size(36, 19);
            labMaxStrock.TabIndex = 10;
            labMaxStrock.Text = "100";
            // 
            // lab
            // 
            lab.AutoSize = true;
            lab.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lab.ForeColor = Color.Gray;
            lab.Location = new Point(123, 60);
            lab.Name = "lab";
            lab.Size = new Size(65, 19);
            lab.TabIndex = 9;
            lab.Text = "Còn lại:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label6.Location = new Point(422, 12);
            label6.Name = "label6";
            label6.Size = new Size(93, 19);
            label6.TabIndex = 8;
            label6.Text = "Tổng cộng";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.Location = new Point(287, 12);
            label5.Name = "label5";
            label5.Size = new Size(71, 19);
            label5.TabIndex = 7;
            label5.Text = "Đơn giá";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.png;
            button1.Location = new Point(595, 0);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(33, 44);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = true;
            // 
            // labTotal
            // 
            labTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labTotal.AutoSize = true;
            labTotal.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            labTotal.ForeColor = Color.Black;
            labTotal.Location = new Point(422, 51);
            labTotal.Name = "labTotal";
            labTotal.Size = new Size(71, 24);
            labTotal.TabIndex = 5;
            labTotal.Text = "50,000";
            // 
            // labCurPrice
            // 
            labCurPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labCurPrice.AutoSize = true;
            labCurPrice.Enabled = false;
            labCurPrice.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            labCurPrice.ForeColor = Color.Gray;
            labCurPrice.Location = new Point(287, 51);
            labCurPrice.Name = "labCurPrice";
            labCurPrice.Size = new Size(71, 24);
            labCurPrice.TabIndex = 4;
            labCurPrice.Text = "50,000";
            // 
            // upDownQuantity
            // 
            upDownQuantity.BackColor = Color.Transparent;
            upDownQuantity.CustomizableEdges = customizableEdges1;
            upDownQuantity.FocusedState.BorderColor = Color.Green;
            upDownQuantity.FocusedState.UpDownButtonFillColor = Color.White;
            upDownQuantity.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            upDownQuantity.ForeColor = Color.FromArgb(192, 0, 0);
            upDownQuantity.Location = new Point(17, 51);
            upDownQuantity.Margin = new Padding(3, 5, 3, 5);
            upDownQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            upDownQuantity.Name = "upDownQuantity";
            upDownQuantity.ShadowDecoration.CustomizableEdges = customizableEdges2;
            upDownQuantity.Size = new Size(99, 39);
            upDownQuantity.TabIndex = 2;
            upDownQuantity.UpDownButtonFillColor = Color.Silver;
            upDownQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            upDownQuantity.ValueChanged += guna2NumericUpDown1_ValueChanged;
            // 
            // LabName
            // 
            LabName.AutoSize = true;
            LabName.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            LabName.Location = new Point(88, 12);
            LabName.Name = "LabName";
            LabName.Size = new Size(65, 19);
            LabName.TabIndex = 1;
            LabName.Text = "Bút chì";
            // 
            // LabID
            // 
            LabID.AutoSize = true;
            LabID.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            LabID.Location = new Point(17, 12);
            LabID.Name = "LabID";
            LabID.Size = new Size(18, 19);
            LabID.TabIndex = 0;
            LabID.Text = "1";
            // 
            // ItemProductOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2Panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ItemProductOrder";
            Size = new Size(632, 118);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)upDownQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2NumericUpDown upDownQuantity;
        private Label LabName;
        private Label LabID;
        private Label labTotal;
        private Label labCurPrice;
        private Button button1;
        private Label label6;
        private Label label5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Label labMaxStrock;
        private Label lab;
    }
}
