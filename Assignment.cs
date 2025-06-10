using AndroidX.ConstraintLayout.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    internal abstract class Assignment {
        private int id;
        private string name;

        private EvalResults? results;

        public Assignment(string name) {
            this.name = name;
            //this.id = idmanager?.GenerateID();
        }

        public abstract void Evaluate() {

        }

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
