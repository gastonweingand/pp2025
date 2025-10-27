using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoHilos.Padre_Hijos
{
    internal class RecursoCompartido
    {
        public static int Dinero { get; set; } = 0; //Recurso compartido entre padre e hijos

        public static readonly object lockObject = new object(); //Objeto para sincronización padre con hijo

        public static readonly object lockObjectHijos = new object(); //Objeto para sincronización hijo con hijo     

    }
}
