using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP {
    class ImageAssignment : Assignment {

        private ImageFile file;

        public override void Evaluate() {
            throw new NotImplementedException();
        }

        public ImageAssignment(string name, IFile file) : base(name, file) {
        }


    }
}
