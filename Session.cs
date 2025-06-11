using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    public static class Session {
        public static Teacher? CurrentTeacher { get; set; }
        public static Period? CurrentViewingPeriod { get; set; } // Maybe remove
    }
}
