using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoHilos.Productor_Consumidor
{
    internal class Productor
    {
        public string Nombre { get; set; }

        private static readonly Random random = new Random(Environment.TickCount);

        public void Producir()
        {
            while(true)
            { 
                int numero = random.Next(1, 11); 

                lock (Program.lockObject) //O Monitor.Enter(Program.lockObject)
                {
                    //Máximos 100 elementos en la queue
                    while (Program.cola.Count >= 100)
                    {
                        Monitor.Wait(Program.lockObject);
                    }

                    //Añadimos el número a la cola
                    Program.cola.Enqueue(numero);
                    Console.WriteLine($"Productor: Generado {numero}");

                    if(Program.cola.Count == 30)
                    {
                        Console.WriteLine($"---> Productor: Cola tiene {Program.cola.Count} elementos.");
                        //Notificar al consumidor que hay un nuevo elemento
                        Monitor.Pulse(Program.lockObject);
                    }                    

                } //Monitor.Exit(Program.lockObject)

                //Pausa del productor
                Thread.Sleep(50);
            }
        }

    }
}
