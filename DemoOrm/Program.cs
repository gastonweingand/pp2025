using DemoOrm.ORM;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOrm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario("Prueba", "p@gmail.com", "1234", true);
            ServicioOrm.Add(usuario);

            var user = ServicioOrm.GetById<Usuario>(Guid.Parse("57A84297-407C-4CA9-9FD7-3C10A2C85BBD"));
            Console.WriteLine($"ID: {user.IdUsuario}, Name: {user.Nombre}, Email: {user.Email}, IsActive: {user.Habilitado}");
    

        }
    }
}
