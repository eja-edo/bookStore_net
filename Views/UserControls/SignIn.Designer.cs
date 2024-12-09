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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            checkBox1.Location = new Point(6, 274);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(81, 24);
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
            inpIdentifier.Location = new Point(33, 176);
            inpIdentifier.Margin = new Padding(3, 4, 0, 7);
            inpIdentifier.Name = "inpIdentifier";
            inpIdentifier.PlaceholderText = "Username, phone or email";
            inpIdentifier.Size = new Size(298, 18);
            inpIdentifier.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(219, 275);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(109, 20);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(0, 200);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 1);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.Image = Properties.Resources.user__1_;
            pictureBox1.Location = new Point(3, 174);
            pictureBox1.Margin = new Padding(3, 4, 3, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(23, 24);
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
            inpPass.Location = new Point(33, 238);
            inpPass.Margin = new Padding(3, 4, 0, 7);
            inpPass.Name = "inpPass";
            inpPass.PasswordChar = '*';
            inpPass.PlaceholderText = "Password";
            inpPass.Size = new Size(298, 18);
            inpPass.TabIndex = 6;
            inpPass.UseSystemPasswordChar = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Left;
            pictureBox2.Image = Properties.Resources.padlock;
            pictureBox2.Location = new Point(3, 235);
            pictureBox2.Margin = new Padding(3, 4, 3, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(23, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(0, 262);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(331, 1);
            panel2.TabIndex = 8;
            // 
            // Login
            // 
            Login.Anchor = AnchorStyles.None;
            Login.BorderRadius = 15;
            Login.CustomizableEdges = customizableEdges3;
            Login.DisabledState.BorderColor = Color.DarkGray;
            Login.DisabledState.CustomBorderColor = Color.DarkGray;
            Login.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Login.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Login.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Login.ForeColor = Color.White;
            Login.Location = new Point(33, 327);
            Login.Margin = new Padding(3, 4, 3, 4);
            Login.Name = "Login";
            Login.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Login.Size = new Size(255, 47);
            Login.TabIndex = 9;
            Login.Text = "Đăng nhập";
            Login.Click += Login_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            textBox1.Location = new Point(0, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(331, 23);
            textBox1.TabIndex = 10;
            textBox1.Text = "Đăng nhập hệ thống DALL";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "SignIn";
            Size = new Size(331, 595);
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
