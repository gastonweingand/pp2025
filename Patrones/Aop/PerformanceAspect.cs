using AspectInjector.Broker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Aop
{
    [Aspect(Scope.Global)]
    [Injection(typeof(PerformanceAspect))]
    public class PerformanceAspect : Attribute
    {
        private Stopwatch _stopwatch;
        private static readonly string logPath = "performance_log.txt";

        [Advice(Kind.Before)]
        public void StartTimer()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        [Advice(Kind.After)]
        public void StopTimer([Argument(Source.Name)] string methodName)
        {
            _stopwatch.Stop();
            string logEntry = $"[{DateTime.Now}] Método: {methodName} Tiempo: {_stopwatch.ElapsedMilliseconds} ms";
            File.AppendAllText(logPath, logEntry + Environment.NewLine);
        }
       }
}

