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
            await Connection.CreateTableAsync<AssignmentBase>();
            await Connection.CreateTableAsync<Student>();
            await Connection.CreateTableAsync<Submission>();
            //await Connection.CreateTableAsync<WordAssignment>();
            //await Connection.CreateTableAsync<PDFAssignment>();
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

        public static async Task AddAssignmentToPeriodAsync(AssignmentBase assignment, int periodId) {
            assignment.PeriodId = periodId;
            await _db.InsertAsync(assignment);
        }
        public static async Task<List<AssignmentBase>> GetAssignmentsForPeriodAsync(int periodId) {
            return await _db.Table<AssignmentBase>()
                            .Where(a => a.PeriodId == periodId)
                            .ToListAsync();
        }

        public static async Task AddStudentToPeriodAsync(Student student, int periodId) {
            student.PeriodId = periodId;
            await _db.InsertAsync(student);
        }

        public static async Task<List<Student>> GetStudentsFromPeriodAsync(int periodId) {
            return await _db.Table<Student>().Where(a => a.PeriodId == periodId).ToListAsync();
        }

        public static async Task<Student> GetSpecificStudentAsync(int periodId, int studentId) {
            return await _db.Table<Student>().Where(a => a.PeriodId == periodId && a.Id == studentId).FirstOrDefaultAsync();
        }

        public static async Task AddSubmissionToAssignmentAsync(Submission submission, int assignmentId) {
            submission.AssignmentId = assignmentId;
            await _db.InsertAsync(submission);
        }
        public static async Task<List<Submission>> GetSubmissionsFromAssignmentAsync(int assignmentId) {
            return await _db.Table<Submission>().Where(a => a.AssignmentId == assignmentId).ToListAsync();
        }
    }

}
