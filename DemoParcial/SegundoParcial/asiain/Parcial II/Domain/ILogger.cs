using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // Interfaz base para definir las operaciones del logger
    public interface ILogger
    {
        void Store(Log log); // Guarda un log
        List<Log> GetAll();  // Devuelve todos los logs
        string ListLog();    // Devuelve los logs como string
    }

}
