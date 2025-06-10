using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP
{
    public class AssignmentBase // The assignment other assignments are compared to.
    {
        public string Name { get; set; }
        public List<Assignment> SubmittedAssignments;
    }
}
