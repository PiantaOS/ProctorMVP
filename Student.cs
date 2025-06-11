using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    internal class Student {
        private List<Submission> assignments;

        public void AddAssignment(Submission assignment) {
            assignments.Add(assignment);
        }

        public List<Submission> GetAssignments() {
            return assignments;
        }
    }
}
