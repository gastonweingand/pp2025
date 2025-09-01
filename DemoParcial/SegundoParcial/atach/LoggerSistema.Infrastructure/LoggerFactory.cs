
using LoggerSistema.Domain;
using LoggerSistema.Legacy;

namespace LoggerSistema.Infrastructure
{
    public static class LoggerFactory
    {
        public static ILogger CreateLogger()
        {
            return new LoggerAdapter(LegacyLogger.Instance);
        }
    }
}
