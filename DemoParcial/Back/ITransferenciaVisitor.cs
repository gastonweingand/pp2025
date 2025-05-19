using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DomainModel
{
    public interface ITransferenciaVisitor
    {
        void VisitDesdeCajaDeAhorro(CajaAhorro cuentaOrigen);
        void VisitDesdeMonederoBTC(MonederoBTC cuentaOrigen);
        Cuenta CuentaDestino { get; set; }
        decimal Monto { get; set; }
        Cliente ClienteOrigen { get; set; }
    }
}
