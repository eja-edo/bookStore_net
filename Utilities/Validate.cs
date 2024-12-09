using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookStore.Utilities
{
    internal class Validate
    {
        // Validate phone number
        public static bool ValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false; // Kiểm tra rỗng hoặc null
            return Regex.IsMatch(phone, @"^(\+84|0)(3|5|7|8|9)\d{8}$");
        }

        // Validate email format
        public static bool ValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false; // Kiểm tra rỗng hoặc null
            return Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w+$");
        }

        // Validate username
        public static bool ValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false; // Kiểm tra rỗng hoặc null
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]{5,50}$");
        }

        // Validate password
        public static bool ValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false; // Kiểm tra rỗng hoặc null
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        }

        // Validate name
        public static bool ValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false; // Kiểm tra rỗng hoặc null
            return Regex.IsMatch(name, @"^[a-zA-Z\s]{1,30}$");
        }

        // Validate salary
        public static bool ValidSalary(decimal? salary)
        {
            if (salary == null) return false; // Kiểm tra null
            return salary > 0;
        }

        // Validate address
        public static bool ValidAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return false; // Kiểm tra rỗng hoặc null
            return address.Length <= 500;
        }
    }
}
