using System;

namespace LoggerSistema.Legacy
{
    public class LegacyLogger
    {
        public void WriteLog(string msg)
        {
            Console.WriteLine($"[LEGACY] {msg}");
        }
    }
}