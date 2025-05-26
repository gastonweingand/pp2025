using DemoFiguras.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFiguras
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Figura circulo = new Circulo();
            Figura cuadrado = new Cuadrado();

            circulo.Colisionar(cuadrado);
            cuadrado.Colisionar(circulo);


        }
    }
}
