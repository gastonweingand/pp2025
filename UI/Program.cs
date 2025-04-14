using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll.Interfaces;
using Bll.Services;
using DomainModel;
using Services.DomainModel;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    User user1 = User.GetInstance();
                    user1.Name = "Fernando";
                    Console.WriteLine($"El nombre de user1 es {user1.Name}");

                    User user2 = User.GetInstance();
                    user2.Name = "Melina";
                    Console.WriteLine($"El nombre de user2 es {user2.Name}");


                    Console.WriteLine($"El nombre de user1 es {user1.Name}");

                    //Console.WriteLine(user1 == user2); //true Por qué???, Puntero es igual


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //IProductRepository productoRepository = Repository.GetProductInstance();

                ICustomerService servicio = new CustomerService();

                foreach (var item in servicio.GetAll())
                {
                    Console.WriteLine($"ID: {item.Id}, Name: {item.Name}");
                }




                /*ICustomerRepository customerRepo = Repository.GetCustomerInstance();

                foreach (var item in customerRepo.GetAll())
                {
                    Console.WriteLine($"ID: {item.Id}, Name: {item.Name}");
                }

                Customer customer = new Customer();
                customer.Name = "Test de objeto 3";
                customerRepo.Add(customer);

                customerRepo.Delete(3);

                Console.WriteLine("Luego de agregar un objeto:");

                foreach (var item in customerRepo.GetAll())
                {
                    Console.WriteLine($"ID: {item.Id}, Name: {item.Name}");
                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine("Acá estamos si un backend tiene problemas");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }
}
