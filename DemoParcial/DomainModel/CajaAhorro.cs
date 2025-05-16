using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DomainModel
{
    public class CajaAhorro : Cuenta
    {
        public string CBU { get; }

        public CajaAhorro(string cbu, string cuit)
        {
            CBU = cbu;
            Identificador = cbu;
            Saldo = 0m;
        }

        public override void Accept(ICuentaVisitor visitor)
        {
            visitor.VisitCajaDeAhorro(this);
        }

        public override void AcceptOrigen(ITransferenciaVisitor visitor)
        {
            visitor.VisitDesdeCajaDeAhorro(this);
        }
    }
}
