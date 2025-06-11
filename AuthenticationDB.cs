using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ProctorMVP {
    public static class AuthenticationDB {

       
        public static async Task<bool> RegisterAsync(string username, string password) {
            var existing = await AppAuth.Connection.Table<Teacher>().Where(t => t.Username == username).FirstOrDefaultAsync();
            if (existing != null) return false;

            Teacher teacher = new Teacher {
                Username = username,
                PasswordHash = HashPassword(password)
            };

            await AppAuth.Connection.InsertAsync(teacher);
            return true;
        }
        public static async Task<Teacher?> LoginAsync(string username, string password) {
            var teacher = await AppAuth.Connection
                .Table<Teacher>()
                .Where(t => t.Username == username)
                .FirstOrDefaultAsync();

            if (teacher != null && VerifyPassword(password, teacher.PasswordHash))
                return teacher;

            return null;
        }
        private static string HashPassword(string password) {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        private static bool VerifyPassword(string password, string storedHash) =>
        HashPassword(password) == storedHash;
    }
}
