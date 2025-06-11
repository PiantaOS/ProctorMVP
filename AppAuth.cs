using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    public static class AppAuth {
        private static SQLiteAsyncConnection _db;

        public static SQLiteAsyncConnection Connection =>
         _db ??= new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "app.db"));

        public static async Task InitAsync() {
            await Connection.CreateTableAsync<Teacher>();
            //await Connection.CreateTableAsync<Assignment>();
            // Add more tables as needed
        }
    }

}
