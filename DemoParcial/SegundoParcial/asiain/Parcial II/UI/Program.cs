using Bll;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Leo el tipo de logger desde la config y creo el logger con el factory
            var logger = LoggerFactory.CreateLogger(ApplicationSettings.LoggerType);

            // Algunos logs de prueba
            logger.Store(new Log { Message = "Inicio del sistema", Severity = 1 });
            logger.Store(new Log { Message = "CriticalError: Fallo grave", Severity = 5 });
            logger.Store(new Log { Message = "Proceso normal", Severity = 2 });
            logger.Store(new Log { Message = "FatalError: Caída del sistema", Severity = 6 });

            // Listo todos los logs por consola
            Console.WriteLine("---- Listado de Logs ----");
            Console.WriteLine(logger.ListLog());


        }
    }

}
