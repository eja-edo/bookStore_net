using BookStore.Models.Entity;
using BookStore.Test;
using BookStore.Utilities;
using BookStore.Views.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookStore
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Đăng ký sự kiện khi UserChanged
            CurrentUser.UserChanged += OnUserChanged;

            // Cấu hình ứng dụng
            ApplicationConfiguration.Initialize();

            // Khởi tạo LoginForm và chạy nó
            //LoginForm loginForm = new LoginForm();
            Application.Run(new LoginForm()); // Chạy LoginForm thay vì QuanLy
        }

        // Lưu trữ các form đang mở
        private static List<Form> openForms = new List<Form>();

        // Hàm xử lý khi CurrentUser.Current thay đổi
        private static void OnUserChanged(User newUser)
        {
            // Lấy form LoginForm hiện tại
            LoginForm loginForm = Application.OpenForms["LoginForm"] as LoginForm;
            if (loginForm != null)
            {
                loginForm.Hide(); // Ẩn LoginForm thay vì đóng
            }
            MessageBox.Show(CurrentUser.Current.Role);
            if (CurrentUser.Current.Role == "Quản lý" || CurrentUser.Current.Role == "Admin")
            {
                var homePage = new QuanLy(); // Trang chủ sau khi đăng nhập
                homePage.Show(); // Hiển thị trang chủ
                openForms.Add(homePage);
            }
            else if(CurrentUser.Current.Role == "Nhân viên")
            {
                var homePage = new NhanVien(); // Trang chủ sau khi đăng nhập
                homePage.Show(); // Hiển thị trang chủ
                openForms.Add(homePage);
            }
        }

        // Mở form trang chủ
        private static void OpenHomePage()
        {
            var homePage = new QuanLy(); // Trang chủ sau khi đăng nhập
            homePage.Show(); // Hiển thị trang chủ
            openForms.Add(homePage); // Thêm form vào danh sách các form đang mở
        }

        // Hàm mở form và lưu trữ các form đang mở
        public static void OpenForm(Form form)
        {
            form.Show();
            openForms.Add(form); // Thêm form vào danh sách các form đang mở
        }

        // Khi form bị đóng, cần phải loại bỏ khỏi danh sách các form đang mở
        public static void CloseForm(Form form)
        {
            form.Close();
            openForms.Remove(form); // Loại bỏ form khỏi danh sách
        }
    }
}
