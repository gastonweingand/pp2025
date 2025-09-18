using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Prototype
{
    public interface IFile
    {
        void Read();
        void Write(string content);
        void Delete();
    }
}
