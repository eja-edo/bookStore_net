using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utilities
{
    using System.Security.Cryptography;

    public static class SecurePasswordHasher
    {
        private const int SaltSize = 16; // Kích thước của Salt (16 bytes)
        private const int HashSize = 32; // Kích thước của Hash (32 bytes)
        private const int Iterations = 100000; // Số vòng lặp, tăng khi cần bảo mật cao hơn

        public static string HashPassword(string password, out string salt)
        {
            // Tạo Salt ngẫu nhiên
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            salt = Convert.ToBase64String(saltBytes);

            // Sử dụng PBKDF2 để tạo Hash
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string salt, string hashedPassword)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            // Sử dụng lại PBKDF2 để tạo Hash từ mật khẩu nhập
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);
                string computedHash = Convert.ToBase64String(hashBytes);
                return computedHash == hashedPassword;
            }
        }
    }
}
