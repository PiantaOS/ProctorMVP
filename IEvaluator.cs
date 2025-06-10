using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    internal interface IEvaluator {
        public EvalResults EvaluateWordDoc(Assignment wDoc) {
            throw new NotImplementedException();
        }

        public EvalResults EvaluateImage(ImageAssignment imageAssignment) { throw new NotImplementedException(); }
    }
}
