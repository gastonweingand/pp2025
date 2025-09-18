using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Prototype
{
    public class FileProxy : IFile
    {
        private RealFile _realFile;
        private User _user;
        public FileProxy(string fileName, User user)
        {
            _realFile = new RealFile(fileName);
            _user = user;
        }

        public void Read()
        {
            if (_user.HasPermission("read"))
            {
                _realFile.Read();
            }
            else
            {
                Console.WriteLine($"Acceso denegado para leer archivo a usuario {_user.Username}");
            }
        }

        public void Write(string content)
        {
            if (_user.HasPermission("write"))
            {
                _realFile.Write(content);
            }
            else
            {
                Console.WriteLine($"Acceso denegado para escribir archivo a usuario {_user.Username}");
            }
        }
        public void Delete()
        {
            if (_user.HasPermission("delete"))
            {
                _realFile.Delete();
            }
            else
            {
                Console.WriteLine($"Acceso denegado para eliminar archivo a usuario {_user.Username}");
            }
        }
    }
}
