using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProctorMVP
{
    public class AssignmentBase // The assignment other assignments are compared to.
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int PeriodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public byte[] Data { get; set; }
       // private SQLiteAsyncConnection _db;
        
    }
}
