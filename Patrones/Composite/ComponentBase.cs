using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Composite
{
    abstract class ComponenteBase
    {
        public string Nombre { get; private set; }
        protected ComponenteBase(string nombre)
        {
            Nombre = nombre;
        }
        public abstract void Mostrar(int indentacion = 0);
    }
}
