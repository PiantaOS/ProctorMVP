using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ProctorMVP {
    public class AuthenticationDB {
        private readonly SQLiteAsyncConnection _db;

        public AuthenticationDB(string dbPath) {
            _db = new SQLiteAsyncConnection(dbPath);
        }
        public async Task<bool> RegisterAsync(string username, string password) {
            var existing = await AppAuth.Connection.Table<Teacher>() .Where(t => t.Username == username)  .FirstOrDefaultAsync();

            if (existing != null) return false;

            Teacher teacher = new Teacher {
                Username = username,
                PasswordHash = HashPassword(password)
            };

            await _db.InsertAsync(teacher);
            return true;
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
