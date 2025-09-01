using LoggerSistema.Domain;
using LoggerSistema.Legacy;

namespace LoggerSistema.Infrastructure
{
    public class LoggerAdapter : ILogger
    {
        private readonly LegacyLogger _legacyLogger;

        public LoggerAdapter(LegacyLogger legacyLogger)
        {
            _legacyLogger = legacyLogger;
        }

        public void Log(string message)
        {
            _legacyLogger.WriteLog(message);
        }
    }
}