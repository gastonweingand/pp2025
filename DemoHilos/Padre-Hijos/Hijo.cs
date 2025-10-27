using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoHilos.Padre_Hijos
{
    internal class Hijo
    {
        private readonly int id;
        public Hijo(int id)
        {
            this.id = id;
        }
        public void Ejecutar()
        {
            Random rand = new Random();

            while (true)
            {
                //Consume dinero
                lock (RecursoCompartido.lockObjectHijos)
                {       
                    //Consume 1 unidad si hay dinero
                    if (RecursoCompartido.Dinero > 0)
                    {
                        RecursoCompartido.Dinero -= 10;
                        Console.WriteLine($"Hijo {id} consumió 10. Total: {RecursoCompartido.Dinero}");
                    }

                    //Si el dinero llega a 0, pulsa al padre para que envíe más
                    if (RecursoCompartido.Dinero == 0)
                    {
                        Console.WriteLine($"Hijo {id}, pulsando al padre");
                        Monitor.Enter(RecursoCompartido.lockObject);
                        Monitor.Pulse(RecursoCompartido.lockObject); //Pulsa al padre
                        Monitor.Wait(RecursoCompartido.lockObject); //Espera a que el padre envíe más dinero
                        Monitor.Exit(RecursoCompartido.lockObject);
                    }
                }

                //Simula consumo aleatorio (tiempo entre consumos)
                Thread.Sleep(rand.Next(100, 1000));
            }
        }
    }
}
