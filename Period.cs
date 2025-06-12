using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    public class Period {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public int PeriodNumber { get; set; }
        //private List<AssignmentBase> assignments { get; set;  }

        public Period() { }
        public Period(int num) {
            this.PeriodNumber = num;
        }
    }
}
