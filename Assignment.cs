//using AndroidX.ConstraintLayout.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProctorMVP {
    public abstract class Assignment {
        private int id;
        private string name;

        private EvalResults? results;
        private AssignmentBase reference;

        private IFile file;

        public Assignment(string name, IFile file) {
            this.name = name;
            this.file = file;
            //this.id = idmanager?.GenerateID();    
        }

        public abstract void Evaluate();

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
