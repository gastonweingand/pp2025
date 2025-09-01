using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    // Esta es una clase externa que no sigue nuestra interfaz
    // Solo tiene Write(string) y ReadAll()
    public class ExternalLogger
    {
        private List<string> _logs = new List<string>();

        public ExternalLogger(string conn)
        {
            Console.WriteLine($"[ExternalLogger] Creado con conexión: {conn}");
        }

        public void Write(string message)
        {
            _logs.Add(message);
        }

        public string[] ReadAll()
        {
            return _logs.ToArray();
        }
    }

}
