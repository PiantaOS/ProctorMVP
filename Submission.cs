//using AndroidX.ConstraintLayout.Core.State;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProctorMVP {
    public class Submission { // TEST
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int AssignmentId { get; set; }

        public int SubmittingStudentId { get; set; }
        private EvalResults? results;

        public IFile File;
        

        public Submission() { }

    }
}
