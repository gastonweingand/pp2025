using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoOrm.ORM
{
    internal static class ServicioOrm
    {
        private static string _connectionString;

        static ServicioOrm()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityString"].ConnectionString;
            _connectionString = connectionString;
        }

        public static void Add(object obj)
        {
            var tipo = obj.GetType();
            var propiedades = ObtenerPropiedadesPrimitivas(tipo);
            var nombresColumnas = string.Join(", ", propiedades.Select(p => p.Name));
            var parametros = string.Join(", ", propiedades.Select(p => $"@{p.Name}"));

            //Para caso de identity insert con int clasico utilizar instrucción similar a la siguiente,
            //En caso de utilizar GUID, recordar que SQL no retorna OUTPUT INSERTED.IdXXXX de manera 
            //nativa, por lo tanto mirar ejemplo en CustomerRepository.cs del proyecto Dal
            //var sql = $"INSERT INTO {tipo.Name} ({nombresColumnas}) OUTPUT INSERTED.Id{tipo.Name} VALUES ({parametros})";
            var sql = $"INSERT INTO {tipo.Name} ({nombresColumnas}) VALUES ({parametros})";

            using (var conexion = new SqlConnection(_connectionString))
            {
                using (var comando = new SqlCommand(sql, conexion))
                {
                    conexion.Open();
                    //Agregar los parámetros al comando
                    foreach (var prop in propiedades)
                    {
                        comando.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(obj) ?? DBNull.Value);
                    }

                    //Recordar que los Insert utilizan ExecuteSacalar para obtener el ID generado por el motor de DB
                    //var nuevoId = comando.ExecuteScalar();
                    //tipo.GetProperty("Id")?.SetValue(obj, nuevoId);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static T GetById<T>(Guid id)
        {
            var tipo = typeof(T);
            var propiedades = ObtenerPropiedadesPrimitivas(tipo, true);
            var sql = $"SELECT * FROM {tipo.Name} WHERE Id{tipo.Name} = @Id{tipo.Name}";

            using (var conexion = new SqlConnection(_connectionString))
            {
                using (var comando = new SqlCommand(sql, conexion))
                {
                    //Agregar el parámetro del ID
                    comando.Parameters.AddWithValue($"@Id{tipo.Name}", id);
                    conexion.Open();

                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            //Crear una instancia del tipo T
                            var instancia = Activator.CreateInstance<T>();
                            foreach (var prop in propiedades)
                            {
                                //Manejar valores nulos de la base de datos
                                var valor = lector[prop.Name] is DBNull ? null : lector[prop.Name];
                                prop.SetValue(instancia, valor);
                            }
                            return instancia;
                        }
                    }
                }
            }
            return default;
        }

        private static IEnumerable<PropertyInfo> ObtenerPropiedadesPrimitivas(Type tipo, bool withID = false)
        {
            return tipo.GetProperties()
                .Where(p => EsTipoPrimitivo(p.PropertyType) && (withID || p.Name != $"Id{tipo.Name}"));
        }

        private static bool EsTipoPrimitivo(Type tipo)
        {
            //Lista de tipos primitivos y comunes de base de datos
            return tipo.IsPrimitive ||
                   tipo == typeof(string) ||
                   tipo == typeof(DateTime) ||
                   tipo == typeof(Decimal) ||
                   tipo == typeof(Guid) ||
                   tipo == typeof(TimeSpan) ||
                   tipo == typeof(DateTimeOffset) ||
                   tipo.IsEnum;
        }
    }
}
