using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProctorMVP
{
    public interface AssignmentBase // The assignment other assignments are compared to.
    {
        public string Name { get; set; }

       // private SQLiteAsyncConnection _db;
        
    }
}
