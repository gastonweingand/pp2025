using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoHilos.CarreraCaballos
{
    internal class Caballo
    {
        #region Miembros de clase

        private static readonly object bloqueo = new object();

        private static int posicion = 0;

        #endregion

        public int Numero { get; private set; }

        public static Dictionary<Caballo, int> posiciones = new Dictionary<Caballo, int>();

        public Caballo(int numero)
        {
            Numero = numero;
        }

        public void CorrerCarrera()
        {
            Random random = new Random(Environment.TickCount + Numero); // Numero es el ID del caballo

            int tiempoTotal = 0;
            for (int i = 0; i < 10; i++) // Simular que cada caballo corre 10 tramos
            {
                int tiempoTramo = random.Next(100, 1000); 
                //Thread.Sleep(tiempoTramo); // Simular el tiempo que tarda en correr el tramo
                tiempoTotal += tiempoTramo;
            }

            // Cuando un caballo termina, se agrega al diccionario
            lock (bloqueo)
            {
                posicion++;
                posiciones.Add(this, tiempoTotal);
                Console.WriteLine($"El caballo {Numero} ha terminado en la posición {posicion} asignada por S.O. con un tiempo de {tiempoTotal} ms.");
            }
        }
    }
}
