namespace BookStore.Views.UserControls
{
    partial class SignIn
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
            checkBox1 = new CheckBox();
            inpIdentifier = new TextBox();
            linkLabel1 = new LinkLabel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            inpPass = new TextBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            Login = new Guna.UI2.WinForms.Guna2Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(5, 206);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(67, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "ghi nhớ";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // inpIdentifier
            // 
            inpIdentifier.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inpIdentifier.BackColor = Color.White;
            inpIdentifier.BorderStyle = BorderStyle.None;
            inpIdentifier.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            inpIdentifier.Location = new Point(29, 132);
            inpIdentifier.Margin = new Padding(3, 3, 0, 5);
            inpIdentifier.Name = "inpIdentifier";
            inpIdentifier.PlaceholderText = "Username, phone or email";
            inpIdentifier.Size = new Size(302, 14);
            inpIdentifier.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(233, 206);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(89, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(0, 150);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 1);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.Image = Properties.Resources.user__1_;
            pictureBox1.Location = new Point(3, 130);
            pictureBox1.Margin = new Padding(3, 3, 3, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(20, 18);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // inpPass
            // 
            inpPass.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inpPass.BackColor = Color.White;
            inpPass.BorderStyle = BorderStyle.None;
            inpPass.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            inpPass.Location = new Point(29, 178);
            inpPass.Margin = new Padding(3, 3, 0, 5);
            inpPass.Name = "inpPass";
            inpPass.PasswordChar = '*';
            inpPass.PlaceholderText = "Password";
            inpPass.Size = new Size(302, 14);
            inpPass.TabIndex = 6;
            inpPass.UseSystemPasswordChar = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Left;
            pictureBox2.Image = Properties.Resources.padlock;
            pictureBox2.Location = new Point(3, 176);
            pictureBox2.Margin = new Padding(3, 3, 3, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(20, 18);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(0, 196);
            panel2.Name = "panel2";
            panel2.Size = new Size(331, 1);
            panel2.TabIndex = 8;
            // 
            // Login
            // 
            Login.Anchor = AnchorStyles.None;
            Login.BorderRadius = 15;
            Login.CustomizableEdges = customizableEdges1;
            Login.DisabledState.BorderColor = Color.DarkGray;
            Login.DisabledState.CustomBorderColor = Color.DarkGray;
            Login.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Login.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Login.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Login.ForeColor = Color.White;
            Login.Location = new Point(49, 245);
            Login.Name = "Login";
            Login.ShadowDecoration.CustomizableEdges = customizableEdges2;
            Login.Size = new Size(223, 35);
            Login.TabIndex = 9;
            Login.Text = "Đăng nhập";
            Login.Click += Login_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            textBox1.Location = new Point(0, 81);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(290, 19);
            textBox1.TabIndex = 10;
            textBox1.Text = "Đăng nhập hệ thống DALL";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(textBox1);
            Controls.Add(Login);
            Controls.Add(inpPass);
            Controls.Add(pictureBox2);
            Controls.Add(panel2);
            Controls.Add(inpIdentifier);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(linkLabel1);
            Controls.Add(checkBox1);
            Name = "SignIn";
            Size = new Size(331, 446);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox checkBox1;
        private TextBox inpIdentifier;
        private LinkLabel linkLabel1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TextBox inpPass;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button Login;
        private TextBox textBox1;
    }
}
