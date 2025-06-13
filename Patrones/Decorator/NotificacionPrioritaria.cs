using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Decorator
{
    internal class NotificacionPrioritaria : NotificacionDecorator
    {
        public NotificacionPrioritaria(INotificacion notificacion) : base(notificacion) { }

        public override void Enviar(string mensaje)
        {
            Console.WriteLine($"[Alta prioridad] Procesando antes de envío...");
            base.Enviar(mensaje);
        }
    }

}
