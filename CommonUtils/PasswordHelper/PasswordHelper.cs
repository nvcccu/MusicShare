using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CommonUtils.PasswordHelper {
    public static class PasswordHelper {
        private static readonly ICryptoTransform _encryptor;
        private static readonly ICryptoTransform _decryptor;
        static PasswordHelper() {
            var algorithm = Rijndael.Create();
            algorithm.Key = new byte[] {199, 185, 19, 28, 132, 198, 39, 83, 135, 245, 134, 222, 136, 104, 245, 177, 71, 193, 108, 62, 255, 109, 141, 35, 53, 33, 17, 192, 118, 113, 255, 24};
            algorithm.IV = new byte[] {110, 114, 219, 238, 23, 99, 234, 235, 150, 99, 196, 88, 50, 223, 252, 60};
            _encryptor = algorithm.CreateEncryptor();
            _decryptor = algorithm.CreateDecryptor();
        }
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
                var result = alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return Convert.ToBase64String(result);
            }
        }
        public static bool CheckPasswordEqual(string password, string salt, string hash) {
            using (var alg = SHA512.Create()) {
                var result = alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return Convert.ToBase64String(result) == hash;
            }
        }
        public static string EncryptInt(int id) {
            byte[] encrypted;
                using (var msEncrypt = new MemoryStream()) {
                    using (var csEncrypt = new CryptoStream(msEncrypt, _encryptor, CryptoStreamMode.Write)) {
                        using (var swEncrypt = new StreamWriter(csEncrypt)) {
                            swEncrypt.Write(id.ToString());
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            return Convert.ToBase64String(encrypted);
        }
        public static int DecryptInt(string encryptedInt) {
            int id;
            var bytes = Convert.FromBase64String(encryptedInt);
            using (var msDecrypt = new MemoryStream(bytes)) {
                using (var csDecrypt = new CryptoStream(msDecrypt, _decryptor, CryptoStreamMode.Read)) {
                    using (var srDecrypt = new StreamReader(csDecrypt)) {
                        id = Convert.ToInt32(srDecrypt.ReadToEnd());
                    }
                }
            }
            return id;
        }
    }
}