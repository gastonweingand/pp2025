using LoggerSistema.Application;
using LoggerSistema.Infrastructure;
using LoggerSistema.Legacy;

namespace LoggerSistema.UI.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var legacyLogger = new LegacyLogger();
            var adapter = new LoggerAdapter(legacyLogger);
            var logService = new LogService(adapter);

            logService.Log("Inicio del sistema");
        }
    }
}