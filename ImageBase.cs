using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP
{
    class ImageBase : AssignmentBase
    {
        public string Name { get; set; }
        /*
        private SQLiteAsyncConnection _db;

        public ImageBase(string dbPath) {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<ImageAssignment>().Wait();
        }

        public Task<List<ImageAssignment>> GetAssignmentsAsync() {
            return _db.Table<ImageAssignment>().ToListAsync();
        }

        public Task<int> SaveAssignmentAsync(Submission submission) {
            if (submission.GetID() != 0)
                return _db.UpdateAsync(submission);
            else
                return _db.InsertAsync(submission);
        }

        public Task<int> DeleteAssignmentAsync(Submission assignment) {
            return _db.DeleteAsync(assignment);
        }
        */
    }
}
