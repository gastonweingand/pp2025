using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFiguras.Services
{
    interface Figura
    {
        void Colisionar(dynamic figura);

        //void Colisionar(Cuadrado cuadrado);
    }
}
