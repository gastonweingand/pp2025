using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Composite
{
    class Directorio : ComponenteBase
    {
        private List<ComponenteBase> hijos = new List<ComponenteBase>();
        public Directorio(string nombre) : base(nombre) { }
        public void Agregar(ComponenteBase componente)
        {
            hijos.Add(componente);
        }
        public override void Mostrar(int indentacion = 0)
        {
            Console.WriteLine(new string('-', indentacion) + "Directorio " + Nombre);
            foreach (var hijo in hijos)
            {
                //En definitiva, es un método recursivo
                //Se evidencia el uso del patrón, imprimiento, elementos hijos compuestos (Directorios)
                //o hijos de tipo hoja Archivos
                hijo.Mostrar(indentacion + 2);
            }
        }
    }
}
