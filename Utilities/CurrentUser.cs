using BookStore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utilities
{
    internal class CurrentUser
    {
        // Định nghĩa sự kiện
        public static event Action<User> UserChanged;

        private static User? _current;
        public static User? Current
        {
            get => _current;
            set
            {
                if (_current != value) // Kiểm tra nếu giá trị thay đổi
                {
                    _current = value;
                    // Phát sự kiện khi có sự thay đổi
                    UserChanged?.Invoke(_current);
                }
            }
        }
    }
}