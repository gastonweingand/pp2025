using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    // Adaptador que convierte ExternalLogger en ILogger
    public class AdapterLogger : ILogger
    {
        private readonly ExternalLogger _externalLogger;

        public AdapterLogger(string connString)
        {
            _externalLogger = new ExternalLogger(connString);
        }

        public void Store(Log log)
        {
            string formatted = $"{log.Message} (Severity: {log.Severity})";
            _externalLogger.Write(formatted);
        }

        public List<Log> GetAll()
        {
            return _externalLogger.ReadAll()
                .Select(msg => new Log { Message = msg, Severity = 0 }) // No tenemos el severity original
                .ToList();
        }

        public string ListLog()
        {
            return string.Join("\n", _externalLogger.ReadAll());
        }
    }

}
