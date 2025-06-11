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
            await Connection.CreateTableAsync<Period>();
            //await Connection.CreateTableAsync<Assignment>();
            // Add more tables as needed
        }

        public static async Task AddPeriodToTeacherAsync(Period period, Teacher teacher) {
            period.TeacherId = teacher.Id;
            await _db.InsertAsync(period);
        }

        public static async Task<List<Period>> GetPeriodsForTeacherAsync(int teacherId) {
            return await _db.Table<Period>().Where(p => p.TeacherId == teacherId).ToListAsync();
        }

    }

}
