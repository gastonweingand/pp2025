using Patrones.Composite;
using Patrones.Memento;
using Patrones.Observer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Memento();
            Observer();

            Console.WriteLine("EJERCICIO MOTIVACIÓN COMPOSITE");

            Console.WriteLine("Ingrese la ruta del directorio a recorrer:");
            string path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Console.WriteLine("El path no existe.");
                return;
            }
            Directorio raiz = ConstruirEstructuraDirectorio(new DirectoryInfo(path));
            Console.WriteLine("Estructura del directorio:");
            raiz.Mostrar();

            Console.WriteLine("EJERCICIO MOTIVACIÓN MEMENTO");
            Memento();
            Console.WriteLine("EJERCICIO MOTIVACIÓN OBSERVER");
            Observer();
        }

        static Directorio ConstruirEstructuraDirectorio(DirectoryInfo dirInfo)
        {
            var directorio = new Directorio(dirInfo.Name);

            // Agregar archivos
            FileInfo[] archivos;
            try
            {
                archivos = dirInfo.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Acceso denegado a archivos en: {dirInfo.FullName}");
                archivos = new FileInfo[0];
            }

            foreach (var archivo in archivos)
            {
                directorio.Agregar(new Archivo(archivo.Name));
            }

            // Agregar subdirectorios recursivamente
            DirectoryInfo[] subdirs;
            try
            {
                subdirs = dirInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Acceso denegado a directorios en: {dirInfo.FullName}");
                subdirs = new DirectoryInfo[0];
            }

            foreach (var subdir in subdirs)
            {
                // LLamada recursiva para construir el directorio hijo del directorio actual
                directorio.Agregar(ConstruirEstructuraDirectorio(subdir));
            }

            return directorio;
        }

        private static void Observer()
        {
            // Crear revistas
            Revista revistaPesca = new Revista("Revista de Pesca");
            Revista revistaDeporte = new Revista("Revista de Deporte");
            // Crear suscriptores
            Suscriptor suscriptor1 = new Suscriptor("Juan");
            Suscriptor suscriptor2 = new Suscriptor("Maria");
            // Suscribir usuarios a revistas
            revistaPesca.Suscribir(suscriptor1);
            revistaDeporte.Suscribir(suscriptor2);
            revistaDeporte.Suscribir(suscriptor1); // Juan también se suscribe a la revista de deporte
                                                   // Publicar noticias
            revistaPesca.PublicarNoticia("Nuevas técnicas de pesca", "Aprende a pescar en el río Reconquista...");
            revistaDeporte.PublicarNoticia("Resultados de la copa del mundo 2026", "Los resultados de la última jornada...");
        }

        private static void Memento()
        {
            //Crear el Originator
            Personaje personajeGanador = new Personaje(7, "Ganador");
            Personaje personajeObjetivo = new Personaje(8, "Objetivo");

            //Crear el Caretaker y pasarle el Originator
            Caretaker caretakerGanador = new Caretaker(personajeGanador);
            Caretaker caretakerObjetivo = new Caretaker(personajeObjetivo);

            //Establecer el Caretaker en la Persona
            personajeGanador.EstablecerCaretaker(caretakerGanador);
            personajeObjetivo.EstablecerCaretaker(caretakerObjetivo);

            //Estado inicial antes de iniciar la lucha cuerpo a cuerpo
            personajeGanador.MostrarEstado();
            personajeObjetivo.MostrarEstado();


            //Personaje objetivo le quita salud al ganador
            personajeObjetivo.DarGolpe(personajeGanador, TipoGolpe.Fuerte);
            personajeGanador.MostrarEstado();

            // Recibir golpes
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Debil); // Golpe débil
            personajeObjetivo.MostrarEstado();
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Intermedio); // Golpe intermedio
            personajeObjetivo.MostrarEstado();
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Fuerte); // Golpe fuerte
            personajeObjetivo.MostrarEstado();

            // Recibir más golpes para activar la recuperación
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Debil);
            personajeObjetivo.MostrarEstado();
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Debil);  //Esto debería activar la recuperación
            personajeGanador.MostrarEstado(); // Debería mostrar la salud recuperada del personaje ganador
        }
    }
}
