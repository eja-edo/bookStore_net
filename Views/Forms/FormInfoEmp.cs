﻿using BookStore.Controllers;
using BookStore.Models.ModelViews;
using Guna.UI2.WinForms;
using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.Forms
{
    public partial class FormInfoEmp : Form
    {
        private UserController controller;
        private InfoEmployee employee;
        public FormInfoEmp()
        {
            InitializeComponent();
            isNew = true;
            employee = new InfoEmployee();
            controller = new UserController(this, employee);
        }
        public bool isNew { get; set; }

        // Các phương thức set giá trị cho từng điều khiển
        public void SetFirstName(string firstName)
        {
            inpFirstName.Text = firstName;
        }

        public void SetLastName(string lastName)
        {
            inpLastName.Text = lastName;
        }

        public void SetUserName(string userName)
        {
            inpUserName.Text = userName;
        }

        public void SetPhone(string phone)
        {
            inpPhone.Text = phone;
        }

        public void SetEmail(string email)
        {
            inpEmail.Text = email;
        }

        public void SetSex(string sex)
        {
            ComboBoxSex.SelectedItem = sex;
        }

        public void SetDateOfBirth(DateTime birthDate)
        {
            DateOld.Value = birthDate;
        }

        public void SetRole(string role)
        {
            comboRole.SelectedItem = role;
        }

        public void SetProfilePicture(string imagePath)
        {
            try
            {
                // Tạo đường dẫn đầy đủ nếu imagePath là đường dẫn tương đối
                string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);

                // Kiểm tra nếu đường dẫn tồn tại
                if (System.IO.File.Exists(fullPath))
                {
                    // Gán ảnh vào PictureBox
                    guna2CirclePictureBox1.Image = Image.FromFile(fullPath);
                }
                else
                {
                    // Nếu không tìm thấy ảnh, có thể gán ảnh mặc định hoặc thông báo lỗi
                    MessageBox.Show("Image not found at: " + fullPath);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi nếu có vấn đề khi tải ảnh
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            inpEmail = new Guna2TextBox();
            label13 = new Label();
            guna2Button2 = new Guna2Button();
            inpFirstName = new Guna2TextBox();
            label12 = new Label();
            label11 = new Label();
            guna2Button1 = new Guna2Button();
            guna2CirclePictureBox1 = new Guna2CirclePictureBox();
            comboRole = new Guna2ComboBox();
            label9 = new Label();
            guna2TextBox6 = new Guna2TextBox();
            label8 = new Label();
            inpUserName = new Guna2TextBox();
            label7 = new Label();
            inpAddress = new Guna2TextBox();
            label6 = new Label();
            inpPhone = new Guna2TextBox();
            label5 = new Label();
            DateOld = new Guna2DateTimePicker();
            label4 = new Label();
            ComboBoxSex = new Guna2ComboBox();
            label3 = new Label();
            inpLastName = new Guna2TextBox();
            label2 = new Label();
            id = new Guna2TextBox();
            label1 = new Label();
            inpSalary = new Guna2TextBox();
            label10 = new Label();
            ((ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // inpEmail
            // 
            inpEmail.CustomizableEdges = customizableEdges1;
            inpEmail.DefaultText = "";
            inpEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            inpEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            inpEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            inpEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            inpEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            inpEmail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            inpEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            inpEmail.Location = new Point(124, 256);
            inpEmail.Margin = new Padding(4);
            inpEmail.Name = "inpEmail";
            inpEmail.Padding = new Padding(10);
            inpEmail.PasswordChar = '\0';
            inpEmail.PlaceholderText = "";
            inpEmail.SelectedText = "";
            inpEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            inpEmail.Size = new Size(417, 31);
            inpEmail.TabIndex = 54;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label13.Location = new Point(22, 263);
            label13.Name = "label13";
            label13.Size = new Size(52, 18);
            label13.TabIndex = 53;
            label13.Text = "Email:";
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 12;
            guna2Button2.CustomizableEdges = customizableEdges3;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.Green;
            guna2Button2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(658, 367);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button2.Size = new Size(154, 45);
            guna2Button2.TabIndex = 52;
            guna2Button2.Text = "lưu thông tin";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // inpFirstName
            // 
            inpFirstName.CustomizableEdges = customizableEdges5;
            inpFirstName.DefaultText = "";
            inpFirstName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            inpFirstName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            inpFirstName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            inpFirstName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            inpFirstName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            inpFirstName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            inpFirstName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            inpFirstName.Location = new Point(124, 58);
            inpFirstName.Margin = new Padding(4);
            inpFirstName.Name = "inpFirstName";
            inpFirstName.Padding = new Padding(10);
            inpFirstName.PasswordChar = '\0';
            inpFirstName.PlaceholderText = "";
            inpFirstName.SelectedText = "";
            inpFirstName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            inpFirstName.Size = new Size(417, 31);
            inpFirstName.TabIndex = 51;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label12.Location = new Point(22, 65);
            label12.Name = "label12";
            label12.Size = new Size(92, 18);
            label12.TabIndex = 50;
            label12.Text = "Họ tên đệm:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label11.Location = new Point(611, 265);
            label11.Name = "label11";
            label11.Size = new Size(185, 48);
            label11.TabIndex = 49;
            label11.Text = "Chọn các ảnh có định dạng \r\n      (.jpg, .jeg, .png, .gif)\r\n\r\n";
            // 
            // guna2Button1
            // 
            guna2Button1.CustomizableEdges = customizableEdges7;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(700, 217);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button1.Size = new Size(112, 40);
            guna2Button1.TabIndex = 48;
            guna2Button1.Text = "Thay đổi ảnh";
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.FillColor = Color.Gray;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.InitialImage = Properties.Resources.plus;
            guna2CirclePictureBox1.Location = new Point(601, 51);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges9;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(195, 195);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2CirclePictureBox1.TabIndex = 47;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // comboRole
            // 
            comboRole.BackColor = Color.Transparent;
            comboRole.CustomizableEdges = customizableEdges10;
            comboRole.DrawMode = DrawMode.OwnerDrawFixed;
            comboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRole.FocusedColor = Color.FromArgb(94, 148, 255);
            comboRole.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            comboRole.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            comboRole.ForeColor = Color.FromArgb(68, 88, 112);
            comboRole.ItemHeight = 30;
            comboRole.Items.AddRange(new object[] { "Nhân viên", "Quản lý" });
            comboRole.Location = new Point(124, 372);
            comboRole.Name = "comboRole";
            comboRole.ShadowDecoration.CustomizableEdges = customizableEdges11;
            comboRole.Size = new Size(190, 36);
            comboRole.StartIndex = 0;
            comboRole.TabIndex = 46;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label9.Location = new Point(22, 380);
            label9.Name = "label9";
            label9.Size = new Size(57, 18);
            label9.TabIndex = 45;
            label9.Text = "Vai trò:";
            // 
            // guna2TextBox6
            // 
            guna2TextBox6.CustomizableEdges = customizableEdges12;
            guna2TextBox6.DefaultText = "";
            guna2TextBox6.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox6.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox6.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox6.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox6.Enabled = false;
            guna2TextBox6.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            guna2TextBox6.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox6.Location = new Point(404, 334);
            guna2TextBox6.Margin = new Padding(4);
            guna2TextBox6.Name = "guna2TextBox6";
            guna2TextBox6.Padding = new Padding(10);
            guna2TextBox6.PasswordChar = '\0';
            guna2TextBox6.PlaceholderText = "";
            guna2TextBox6.SelectedText = "";
            guna2TextBox6.ShadowDecoration.CustomizableEdges = customizableEdges13;
            guna2TextBox6.Size = new Size(137, 31);
            guna2TextBox6.TabIndex = 44;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label8.Location = new Point(321, 341);
            label8.Name = "label8";
            label8.Size = new Size(75, 18);
            label8.TabIndex = 43;
            label8.Text = "Mật khẩu:";
            // 
            // inpUserName
            // 
            inpUserName.CustomizableEdges = customizableEdges14;
            inpUserName.DefaultText = "";
            inpUserName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            inpUserName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            inpUserName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            inpUserName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            inpUserName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            inpUserName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            inpUserName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            inpUserName.Location = new Point(124, 334);
            inpUserName.Margin = new Padding(4);
            inpUserName.Name = "inpUserName";
            inpUserName.Padding = new Padding(10);
            inpUserName.PasswordChar = '\0';
            inpUserName.PlaceholderText = "";
            inpUserName.SelectedText = "";
            inpUserName.ShadowDecoration.CustomizableEdges = customizableEdges15;
            inpUserName.Size = new Size(190, 31);
            inpUserName.TabIndex = 42;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label7.Location = new Point(22, 341);
            label7.Name = "label7";
            label7.Size = new Size(87, 18);
            label7.TabIndex = 41;
            label7.Text = "UserName:";
            // 
            // inpAddress
            // 
            inpAddress.CustomizableEdges = customizableEdges16;
            inpAddress.DefaultText = "";
            inpAddress.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            inpAddress.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            inpAddress.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            inpAddress.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            inpAddress.Enabled = false;
            inpAddress.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            inpAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            inpAddress.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            inpAddress.Location = new Point(124, 295);
            inpAddress.Margin = new Padding(4);
            inpAddress.Name = "inpAddress";
            inpAddress.Padding = new Padding(10);
            inpAddress.PasswordChar = '\0';
            inpAddress.PlaceholderText = "";
            inpAddress.SelectedText = "";
            inpAddress.ShadowDecoration.CustomizableEdges = customizableEdges17;
            inpAddress.Size = new Size(417, 31);
            inpAddress.TabIndex = 40;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label6.Location = new Point(22, 302);
            label6.Name = "label6";
            label6.Size = new Size(61, 18);
            label6.TabIndex = 39;
            label6.Text = "Địa chỉ:";
            // 
            // inpPhone
            // 
            inpPhone.CustomizableEdges = customizableEdges18;
            inpPhone.DefaultText = "";
            inpPhone.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            inpPhone.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            inpPhone.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            inpPhone.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            inpPhone.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            inpPhone.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            inpPhone.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            inpPhone.Location = new Point(124, 178);
            inpPhone.Margin = new Padding(4);
            inpPhone.Name = "inpPhone";
            inpPhone.Padding = new Padding(10);
            inpPhone.PasswordChar = '\0';
            inpPhone.PlaceholderText = "";
            inpPhone.SelectedText = "";
            inpPhone.ShadowDecoration.CustomizableEdges = customizableEdges19;
            inpPhone.Size = new Size(417, 31);
            inpPhone.TabIndex = 38;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label5.Location = new Point(22, 185);
            label5.Name = "label5";
            label5.Size = new Size(104, 18);
            label5.TabIndex = 37;
            label5.Text = "Số điện thoại:";
            // 
            // DateOld
            // 
            DateOld.BackColor = Color.White;
            DateOld.Checked = true;
            DateOld.CustomizableEdges = customizableEdges20;
            DateOld.FillColor = Color.White;
            DateOld.FocusedColor = Color.FromArgb(224, 224, 224);
            DateOld.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            DateOld.Format = DateTimePickerFormat.Short;
            DateOld.Location = new Point(376, 135);
            DateOld.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            DateOld.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            DateOld.Name = "DateOld";
            DateOld.ShadowDecoration.CustomizableEdges = customizableEdges21;
            DateOld.Size = new Size(165, 36);
            DateOld.TabIndex = 36;
            DateOld.Value = new DateTime(2024, 11, 25, 0, 48, 58, 876);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.Location = new Point(294, 143);
            label4.Name = "label4";
            label4.Size = new Size(80, 18);
            label4.TabIndex = 35;
            label4.Text = "Ngày sinh:";
            // 
            // ComboBoxSex
            // 
            ComboBoxSex.BackColor = Color.Transparent;
            ComboBoxSex.CustomizableEdges = customizableEdges22;
            ComboBoxSex.DrawMode = DrawMode.OwnerDrawFixed;
            ComboBoxSex.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSex.FocusedColor = Color.FromArgb(94, 148, 255);
            ComboBoxSex.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ComboBoxSex.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            ComboBoxSex.ForeColor = Color.FromArgb(68, 88, 112);
            ComboBoxSex.ItemHeight = 30;
            ComboBoxSex.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            ComboBoxSex.Location = new Point(124, 135);
            ComboBoxSex.Name = "ComboBoxSex";
            ComboBoxSex.ShadowDecoration.CustomizableEdges = customizableEdges23;
            ComboBoxSex.Size = new Size(164, 36);
            ComboBoxSex.StartIndex = 0;
            ComboBoxSex.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(22, 143);
            label3.Name = "label3";
            label3.Size = new Size(67, 18);
            label3.TabIndex = 33;
            label3.Text = "giới tính:";
            // 
            // inpLastName
            // 
            inpLastName.CustomizableEdges = customizableEdges24;
            inpLastName.DefaultText = "";
            inpLastName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            inpLastName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            inpLastName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            inpLastName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            inpLastName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            inpLastName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            inpLastName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            inpLastName.Location = new Point(124, 97);
            inpLastName.Margin = new Padding(4);
            inpLastName.Name = "inpLastName";
            inpLastName.Padding = new Padding(10);
            inpLastName.PasswordChar = '\0';
            inpLastName.PlaceholderText = "";
            inpLastName.SelectedText = "";
            inpLastName.ShadowDecoration.CustomizableEdges = customizableEdges25;
            inpLastName.Size = new Size(417, 31);
            inpLastName.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(22, 104);
            label2.Name = "label2";
            label2.Size = new Size(107, 18);
            label2.TabIndex = 31;
            label2.Text = "Tên nhân viên:";
            // 
            // id
            // 
            id.CustomizableEdges = customizableEdges26;
            id.DefaultText = "";
            id.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            id.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            id.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            id.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            id.Enabled = false;
            id.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            id.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            id.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            id.Location = new Point(124, 19);
            id.Margin = new Padding(4);
            id.Name = "id";
            id.Padding = new Padding(10);
            id.PasswordChar = '\0';
            id.PlaceholderText = "Tự động tạo";
            id.SelectedText = "";
            id.ShadowDecoration.CustomizableEdges = customizableEdges27;
            id.Size = new Size(417, 31);
            id.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(22, 26);
            label1.Name = "label1";
            label1.Size = new Size(103, 18);
            label1.TabIndex = 29;
            label1.Text = "Mã nhân viên:";
            // 
            // inpSalary
            // 
            inpSalary.CustomizableEdges = customizableEdges28;
            inpSalary.DefaultText = "";
            inpSalary.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            inpSalary.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            inpSalary.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            inpSalary.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            inpSalary.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            inpSalary.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            inpSalary.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            inpSalary.Location = new Point(124, 217);
            inpSalary.Margin = new Padding(4);
            inpSalary.Name = "inpSalary";
            inpSalary.Padding = new Padding(10);
            inpSalary.PasswordChar = '\0';
            inpSalary.PlaceholderText = "";
            inpSalary.SelectedText = "";
            inpSalary.ShadowDecoration.CustomizableEdges = customizableEdges29;
            inpSalary.Size = new Size(417, 31);
            inpSalary.TabIndex = 56;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label10.Location = new Point(22, 224);
            label10.Name = "label10";
            label10.Size = new Size(60, 18);
            label10.TabIndex = 55;
            label10.Text = "Lương:";
            // 
            // FormInfoEmp
            // 
            ClientSize = new Size(836, 473);
            Controls.Add(inpSalary);
            Controls.Add(label10);
            Controls.Add(inpEmail);
            Controls.Add(label13);
            Controls.Add(guna2Button2);
            Controls.Add(inpFirstName);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(guna2Button1);
            Controls.Add(guna2CirclePictureBox1);
            Controls.Add(comboRole);
            Controls.Add(label9);
            Controls.Add(guna2TextBox6);
            Controls.Add(label8);
            Controls.Add(inpUserName);
            Controls.Add(label7);
            Controls.Add(inpAddress);
            Controls.Add(label6);
            Controls.Add(inpPhone);
            Controls.Add(label5);
            Controls.Add(DateOld);
            Controls.Add(label4);
            Controls.Add(ComboBoxSex);
            Controls.Add(label3);
            Controls.Add(inpLastName);
            Controls.Add(label2);
            Controls.Add(id);
            Controls.Add(label1);
            Name = "FormInfoEmp";
            ((ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Guna.UI2.WinForms.Guna2TextBox inpEmail;
        private Label label13;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox inpFirstName;
        private Label label12;
        private Label label11;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox comboRole;
        private Label label9;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox6;
        private Label label8;
        private Guna.UI2.WinForms.Guna2TextBox inpUserName;
        private Label label7;
        private Guna.UI2.WinForms.Guna2TextBox inpAddress;
        private Label label6;
        private Guna.UI2.WinForms.Guna2TextBox inpPhone;
        private Label label5;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateOld;
        private Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxSex;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox inpLastName;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox id;
        private Label label1;
        private Guna2TextBox inpSalary;
        private Label label10;

        public string GetEmail()
        {
            return inpEmail.Text.Trim();
        }

        public string GetFirstName()
        {
            return inpFirstName.Text.Trim();
        }

        public string GetLastName()
        {
            return inpLastName.Text.Trim();
        }

        public string GetUserName()
        {
            return inpUserName.Text.Trim();
        }

        public Address GetAddress()
        {
            // Lấy nội dung từ TextBox và tách thành các phần dựa trên dấu phẩy
            var components = inpAddress.Text
                                       .Trim()
                                       .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(component => component.Trim())
                                       .ToArray();

            // Tạo đối tượng Address với các giá trị tương ứng
            return new Address
            {
                line = components.Length > 0 ? components[0] : string.Empty,
                city = components.Length > 1 ? components[1] : string.Empty,
                province = components.Length > 2 ? components[2] : string.Empty
            };
        }

        public string GetPhone()
        {
            return inpPhone.Text.Trim();
        }

        public decimal GetSalary()
        {
            return decimal.TryParse(inpSalary.Text.Trim(), out decimal salary) ? salary : 0;
        }

        public string GetRole()
        {
            return comboRole.SelectedItem != null ? comboRole.SelectedItem.ToString() : string.Empty;
        }

        public string GetSex()
        {
            return ComboBoxSex.SelectedItem != null ? ComboBoxSex.SelectedItem.ToString() : string.Empty;
        }

        public DateTime GetOldDate()
        {
            return DateOld.Value;
        }
        public string GetImg()
        {
            // Trả về đường dẫn hình ảnh, nếu hình ảnh chưa được thiết lập, trả về chuỗi rỗng
            return string.IsNullOrEmpty(guna2CirclePictureBox1.ImageLocation) ? string.Empty : guna2CirclePictureBox1.ImageLocation;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            controller.SaveUser();
        }
    }
}