using LoggerSistema.Domain;
using System;

namespace LoggerSistema.Application
{
    public class LogService
    {
        private readonly ILogger _logger;

        public LogService(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            try
            {
                _logger.Log(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
        }
    }
}