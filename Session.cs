using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    public static class Session {
        public static Teacher? CurrentTeacher { get; set; }
        public static Period? CurrentViewingPeriod { get; set; } // The currently viewed period
        public static AssignmentBase? CurrentViewingAssignment { get; set; }   //Currenly viewing dashboard assignment

        public static AssignmentBase? CreatedAssignment { get; set; }  //The assignment creator made assignment, added to current periods assignments then deleted
    }
}
