using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    class Period {
        private List<Student> students;

        public void AddStudent(Student student) {
            students.Add(student);
        }

        public void RemoveStudent(Student student) {
            students.Remove(student);
        }
    }
}
