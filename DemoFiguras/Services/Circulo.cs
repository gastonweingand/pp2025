using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFiguras.Services
{
    internal class Circulo : Figura
    {
        public void Colisionar(dynamic figura)
        {
            //figura.MeQuieroIr();
            //figura.Edad = 89;

            ColisionarCon(figura);            
        }

        private void ColisionarCon(Circulo circulo)
        {
            Console.WriteLine("Soy círculo y colisiono con un círculo");
        }

        private void ColisionarCon(Cuadrado circulo)
        {
            Console.WriteLine("Soy circulo y colisiono con un cuadrado");
        }

        private void ColisionarCon(Figura circulo)
        {
            Console.WriteLine("Es una implementación no válida");
        }
    }
}
