using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    // Logger que simula guardar en un archivo
    public class FileLogger : ILogger
    {
        private List<Log> _logs = new List<Log>();

        public void Store(Log log)
        {
            Console.WriteLine("[FILE] Guardando log: " + log.Message);
            _logs.Add(log);
        }

        public List<Log> GetAll()
        {
            return _logs.ToList();
        }

        public string ListLog()
        {
            return string.Join("\n", _logs.Select(l => $"[FILE] {l.Message} (Severity: {l.Severity})"));
        }
    }


}
