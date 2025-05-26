using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFiguras.Services
{
    internal class Cuadrado : Figura
    {
        public void Colisionar(dynamic figura)
        {
            ColisionarCon(figura);
        }
        private void ColisionarCon(Circulo circulo)
        {
            Console.WriteLine("Soy cuadrado y colisiono con un círculo");
        }

        private void ColisionarCon(Cuadrado circulo)
        {
            Console.WriteLine("Soy cuadrado y colisiono con un cuadrado");
        }

        private void ColisionarCon(Figura circulo)
        {
            Console.WriteLine("Es una implementación no válida");
        }
    }
}
