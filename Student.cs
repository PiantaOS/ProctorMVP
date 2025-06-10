using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    internal class Student {
        private List<Assignment> assignments;

        public void AddAssignment(Assignment assignment) {
            assignments.Add(assignment);
        }

        public List<Assignment> GetAssignments() {
            return assignments;
        }
    }
}
