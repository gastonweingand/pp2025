using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoHilos.Padre_Hijos
{
    internal class Padre
    {
        public void Ejecutar()
        {
            Random rand = new Random(Environment.TickCount);

            while (true)
            {                               
                lock (RecursoCompartido.lockObject)
                {
                    //double dineroAñadido = RecursoCompartido.Dinero;
                    //RecursoCompartido.Dinero += rand.Next(100, 500);
                    RecursoCompartido.Dinero += 100;
                    Console.WriteLine($"Padre añadió 100. Total: {RecursoCompartido.Dinero}");
                    Monitor.Pulse(RecursoCompartido.lockObject); //Despierta al hijo en espera
                }
                //Espera a ser pulsado por un hijo
                lock (RecursoCompartido.lockObject)
                {
                    Monitor.Wait(RecursoCompartido.lockObject);
                }

                //Simula tiempo entre envíos
                Thread.Sleep(rand.Next(2000, 5000));
            }
        }

    }
}
