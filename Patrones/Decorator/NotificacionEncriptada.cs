using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Decorator
{
    internal class NotificacionEncriptada : NotificacionDecorator
    {
        public NotificacionEncriptada(INotificacion notificacion) : base(notificacion) { }

        public override void Enviar(string mensaje)
        {
            mensaje = $"[Encriptado] {mensaje}";
            base.Enviar(mensaje);
        }
    }
}
