using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    // Decorador que envía mail si el log es crítico
    public class EmailLogger : ILogger
    {
        private readonly ILogger _wrappedLogger;

        public EmailLogger(ILogger wrappedLogger)
        {
            _wrappedLogger = wrappedLogger;
        }

        public void Store(Log log)
        {
            if (log.Severity >= 5 || log.Message.Contains("CriticalError") || log.Message.Contains("FatalError"))
            {
                EnviarCorreo(log);
            }

            _wrappedLogger.Store(log);
        }

        public List<Log> GetAll()
        {
            return _wrappedLogger.GetAll();
        }

        public string ListLog()
        {
            return _wrappedLogger.ListLog();
        }

        private void EnviarCorreo(Log log)
        {
            Console.WriteLine("[EMAIL] Enviando alerta: " + log.Message);
        }
    }

}
