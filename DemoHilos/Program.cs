using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoHilos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejecutando proceso principal");

            //Hilos parametrizables
            HiloParametrizado hilo1 = new HiloParametrizado(20, "Hilo 1");
            Thread hiloParametrizado1 = new Thread(hilo1.Ejecutar);
            hiloParametrizado1.Start();

            //1) Opción de atarme a una variable...
            //while(hilo1.Retorno == 0)
            //{
            //    Thread.Sleep(100);
            //    Console.WriteLine("Estoy esperando la finalización del hilo lanzado...");                
            //}

            //2) Opción de atarme al estado del hilo...
            //while(hiloParametrizado1.IsAlive)
            //{
            //    Thread.Sleep(100);
            //    Console.WriteLine("Estoy esperando la finalización del hilo lanzado...");
            //}

            //3) Opción de atarme a la finalización del hilo...
            hiloParametrizado1.Join(); //El proceso principal espera la finalización del hilo hijo
            Console.WriteLine($"El hilo finalizó con retorno: {hilo1.Retorno}");



            //HilosEnLaMismaClase();

            Console.WriteLine("Finalizando proceso principal");
            Console.WriteLine("Presione una tecla para finalizar...");
            Console.ReadLine();
        }

        private static void HilosEnLaMismaClase()
        {
            for (int i = 1; i < 11; i++)
            {
                Thread hilo = new Thread(Hilo);
                hilo.Name = $"Hilo DEMO {i}";
                hilo.Priority = ThreadPriority.Highest;
                hilo.IsBackground = true; //Si es true, el hilo se detiene cuando el proceso principal finaliza
                Console.WriteLine("Ingrese los ms. de espera del próximo hilo...");
                int ms = int.Parse(Console.ReadLine());

                Parametro parametro = new Parametro()
                {
                    ms = ms,
                    Name = hilo.Name
                };


                hilo.Start(parametro);
                //hilo.Join();
            }
        }

        /// <summary>
        /// Ejemplo de método que se ejecuta en un hilo aparte
        /// </summary>
        //private static void Hilo(object obj)
        private static void Hilo(object obj)
        {
            //Cuando recibo argumentos en el método del hilo, debo castearlos
            //Acá tengo que establecer el tipo de dato que espero recibir
            Parametro parametro = (Parametro)obj;

            Console.WriteLine($"Soy el hilo {parametro.Name} con timer de {parametro.ms} ms.");

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Hilo {Thread.CurrentThread.Name} - Nro.: {i}");
                Thread.Sleep(parametro.ms); //Simular que el hilo está haciendo un trabajo

                if(i == 50)
                {
                    Console.WriteLine("Finalizando el hilo forzadamente");
                    return;
                }
            }

            Console.WriteLine($"Finalizando el hilo {parametro.Name}");
        }
    }
}
