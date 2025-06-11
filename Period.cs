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
        private List<Student> students;

        public Period() { }
        public Period(int num) {
            this.PeriodNumber = num;
        }
        public void AddStudent(Student student) {
            students.Add(student);
        }

        public void RemoveStudent(Student student) {
            students.Remove(student);
        }
    }
}
