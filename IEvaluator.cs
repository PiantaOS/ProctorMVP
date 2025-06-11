using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    internal interface IEvaluator {
        public EvalResults EvaluateWordDoc(Submission wDoc);
        public EvalResults EvaluateImage(ImageAssignment imageAssignment);

        public EvalResults EvaluatePDF(Submission pdf);
    }
}
