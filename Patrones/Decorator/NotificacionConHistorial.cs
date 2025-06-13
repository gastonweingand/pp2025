using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Decorator
{
    internal class NotificacionConHistorial : NotificacionDecorator
    {
        public NotificacionConHistorial(INotificacion notificacion) : base(notificacion) { }

        public override void Enviar(string mensaje)
        {
            Console.WriteLine($"Registrando mensaje en historial: {mensaje}");
            base.Enviar(mensaje);
        }
    }
}

//Un decorador permite agregar funcionalidad en cualquier momento...
//1) Antes de invocar "algo" del objeto decorado
//2) Después de invocar "algo" del objeto decorado
//3) O incluso reemplazar la funcionalidad del objeto decorado
//4) O combinar las anteriores
