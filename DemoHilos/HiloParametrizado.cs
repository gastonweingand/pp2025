using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoHilos
{
    internal class HiloParametrizado
    {
        private int delay;

        private string nombre;

        public int Retorno { get; set; }

        public HiloParametrizado(int delay, string nombre)
        {
            this.delay = delay;
            this.nombre = nombre;
        }

        public void Ejecutar()
        {
            Console.WriteLine($"Soy el hilo {nombre} con timer de {delay} ms.");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Mostrando el nro.: {i} del {nombre}");
                Thread.Sleep(delay);
            }
            //Emulamos la respuesta de una tarea X
            Retorno = 100;
        }
    }
}
