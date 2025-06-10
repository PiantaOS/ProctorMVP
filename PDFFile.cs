using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP
{
    class PDFFile : IFile
    {
        public string name { get; set; }
        public byte[] data { get; set; }

    }
}
