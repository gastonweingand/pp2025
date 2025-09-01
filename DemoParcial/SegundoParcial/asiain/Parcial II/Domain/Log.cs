using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // modelo que representa un log, con mensaje y severidad
    public class Log
    {
        public string Message { get; set; }
        public int Severity { get; set; }
    }

}
