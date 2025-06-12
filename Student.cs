using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    public class Student {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int PeriodId { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
