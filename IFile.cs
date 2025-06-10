using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProctorMVP
{
    public interface IFile {
        public byte[] data {  get; set; }

        public string name { get; set; }
    }
}
