using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    // Lee valores del app.config
    public static class ApplicationSettings
    {
        public static string LoggerType => ConfigurationManager.AppSettings["LoggerType"] ?? "FILE";

        public static string ConnString => ConfigurationManager.AppSettings["ConnString"] ?? "Conexion_Default";
    }
}
