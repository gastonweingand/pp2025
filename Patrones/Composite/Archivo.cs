using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Composite
{
    class Archivo : ComponenteBase
    {
        public Archivo(string nombre) : base(nombre) { }
        public override void Mostrar(int indentacion = 0)
        {
            Console.WriteLine(new string(' ', indentacion) + "Archivo " + Nombre);
        }
    }
}
