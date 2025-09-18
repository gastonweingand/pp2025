using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Prototype
{
    public class RealFile : IFile
    {
        private string _fileName;
        private string _content = "";
        public RealFile(string fileName)
        {
            _fileName = fileName;
        }
        public void Read()
        {
            Console.WriteLine($"Leyendo archivo {_fileName}: {_content}");
        }
        public void Write(string content)
        {
            _content = content;
            Console.WriteLine($"Escribiendo en archivo {_fileName}: {_content}");
        }
        public void Delete()
        {
            _content = null;
            Console.WriteLine($"Archivo {_fileName} eliminado.");
        }
    }
}
