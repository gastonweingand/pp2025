using Dal;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    // Crea el logger que corresponda, según la configuración
    public static class LoggerFactory
    {
        public static ILogger CreateLogger(string type)
        {
            ILogger baseLogger;

            if (type == "SQL")
                baseLogger = new SqlLogger();
            else if (type == "FILE")
                baseLogger = new FileLogger();
            else if (type == "EXTERNAL")
                baseLogger = new AdapterLogger(ApplicationSettings.ConnString);
            else
                throw new Exception("Tipo de logger no soportado");

            return new EmailLogger(baseLogger); // siempre lo decoramos con el EmailLogger
        }
    }


}

