using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DomainModel;

namespace Services.DomainModel
{
    public class Usuario
    {       
        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        private string password;

        /// <summary>
        /// Para gestionar el patrón composite debemos utilizar una lista de Component
        /// </summary>
        ///
        public List<Component> Privilegios { get; set; }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = CryptographyService.HashMd5(value);
            }
        }

        public bool Habilitado { get; set; }

        public Usuario(string nombre, string email, string password, bool habilitado = true)
        {
            Nombre = nombre;
            Email = email;
            Password = password;
            Habilitado = habilitado;
        }

        public Usuario(Guid idUsuario, string nombre, string email, string password, bool habilitado = true) : this(nombre, email, password, habilitado)
        {
            IdUsuario = idUsuario;
        }
    }
}

