using System;
using System.Security.Cryptography;
using System.Text;

namespace CommonUtils.PasswordHelper {
    public static class PasswordHelper {
        public static string GenerateSalt() {
            return Guid.NewGuid().ToString();
        }
        public static string HashPassword(string password, string salt) {
            if (String.IsNullOrEmpty(password)) {
                throw new Exception("Password should not be empty");
            }
            if (String.IsNullOrEmpty(salt)) {
                throw new Exception("Salt should not be empty");
            }
            using (var alg = SHA512.Create()) {
                var q = Encoding.UTF8.GetBytes(password + salt);
                var result = alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                var a = BitConverter.ToString(result);
                return Encoding.UTF8.GetString(result);
            }
        }
    }
}