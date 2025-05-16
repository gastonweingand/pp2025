using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DomainModel
{
    public interface ICuentaVisitor
    {
        void VisitCajaDeAhorro(CajaAhorro cuenta);
        void VisitMonederoBTC(MonederoBTC cuenta);
    }
}
