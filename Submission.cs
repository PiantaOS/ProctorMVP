//using AndroidX.ConstraintLayout.Core.State;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProctorMVP {
    public abstract class Submission { // TEST
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }

        private string name;

        private EvalResults? results;
        private AssignmentBase reference;

        private IFile file;

        public void Setup(string name, IFile file) {
            this.name = name;
            this.file = file;
        }
        public abstract void Evaluate();

        public Submission() { }

        public EvalResults GetResults() {
            if(results == null) { throw new ArgumentNullException(); }

            return results;
        }

        public int GetID() {
            return id;
        }

        public string GetName() {
            return name;
        }
    }
}
