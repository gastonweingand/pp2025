using AspectInjector.Broker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Aop
{
    [Aspect(Scope.Global)]
    [Injection(typeof(DebugAspect))]
    public class DebugAspect : Attribute
    {
        private static readonly string logPath = "debug_log.txt";

        [Advice(Kind.Before)]
        public void LogStart([Argument(Source.Name)] string methodName, [Argument(Source.Metadata)] MethodBase metodo)
        {
            string logEntry = $"[{DateTime.Now}] Inicio de método: {methodName} en la clase {metodo.DeclaringType.Name}";
            File.AppendAllText(logPath, logEntry + Environment.NewLine);
        }

        [Advice(Kind.After)]
        public void LogEnd([Argument(Source.Name)] string methodName)
        {
            string logEntry = $"[{DateTime.Now}] Fin de método: {methodName}";
            File.AppendAllText(logPath, logEntry + Environment.NewLine);
        }
    }
}
