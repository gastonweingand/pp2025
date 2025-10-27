using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoHilos.Productor_Consumidor
{
    internal class Consumidor
    {
        public void Consumir()
        {
            while (true)
            {
                int numero;

                lock (Program.lockObject) //Monitor.Enter(Program.lockObject);
                {                    
                    while (Program.cola.Count == 0)
                    {
                        //Esperamos a que el productor agregue elementos. 
                        //Cuando llegue a 10 elementos producidos, el Productor hará un Pulse.
                        Monitor.Wait(Program.lockObject);
                    }

                    numero = Program.cola.Dequeue();
                    Console.WriteLine($"Consumidor: Leído {numero}");

                    //En la mitad de los elementos leidos, notifico al productor
                    if (Program.cola.Count == 50)
                    {
                        Monitor.Pulse(Program.lockObject);
                    }
                }//Monitor.Exit(Program.lockObject);

                //Frenamos el hilos unos ms
                Thread.Sleep(100);
            }
        }

    }
}
