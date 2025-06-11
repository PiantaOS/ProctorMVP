using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    public class Student {
        private List<Submission> submissions;

        public void AddSubmissions(Submission submission) {
            submissions.Add(submission);
        }

        public List<Submission> GetSubmissions() {
            return submissions;
        }
    }
}
