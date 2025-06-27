﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bll.Interfaces;
using Bll.Services;
using DomainModel;
using Services.DomainModel;
using Services.Facade;
using Services.Facade.Extensions;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string hashValue = CryptographyService.HashMd5("pepe");

                Console.WriteLine($"Hash MD5: {hashValue}");

                string original = "Texto original";

                string encrypted = CryptographyService.Encrypt(original);

                Console.WriteLine($"Texto encriptado: {encrypted}");

                string decrypted = CryptographyService.Decrypt(encrypted);

                Console.WriteLine($"Texto desencriptado: {decrypted}");

                LoggerService.GetLogger().Information("Estamos probando el logger");

                try
                {
                    throw new Exception("Probando alguna Exception");
                }
                catch (Exception ex)
                {
                    LoggerService.GetLogger().Error("Mensaje de error", ex);
                    throw;
                }
                new CustomerService().IsActive(null);
                

                //foreach (var item in CultureInfo.GetCultures(CultureTypes.AllCultures).ToList())
                //{
                //    if (item.Name.Contains("en"))
                //    {
                //        Console.WriteLine($"{item.Name} {item.DisplayName} {item.TwoLetterISOLanguageName}");
                //    }
                //}

                Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);

                string bienvenidos = "bienvenidos".Traducir();

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                Console.WriteLine(Thread.CurrentThread.CurrentCulture.DisplayName);

                bienvenidos = "bienvenidos".Traducir();

                Console.WriteLine(bienvenidos);

                //IProductRepository productoRepository = Repository.GetProductInstance();

                Console.WriteLine("GET ALL");
                ICustomerService servicio = new CustomerService();

                foreach (var item in servicio.GetAll())
                {
                    Console.WriteLine($"ID: {item.IdCustomer}, Name: {item.Name}");
                }

                Console.WriteLine("GET BY ID");

                Customer customerGabriel = servicio.GetById(Guid.Parse("385A8787-011F-F011-AF4E-B81EA4D48094"));

                Console.WriteLine($"ID: {customerGabriel.IdCustomer}, Name: {customerGabriel.Name}");

                Console.WriteLine("Agregando un CUSTOMER");

                Customer newCustomer = new Customer();
                newCustomer.Name = "Lionel";
                servicio.Add(newCustomer);

                if (newCustomer.IdCustomer != Guid.Empty)
                    Console.WriteLine("Insertamos correctamente");


                Console.WriteLine("UPDATE");

                newCustomer.Name = "Agustín";
                servicio.Update(newCustomer);

                Console.WriteLine($"Cliente actualizado: {newCustomer.Name}");

                try
                {
                    //User user1 = User.GetInstance();
                    //user1.Name = "Fernando";
                    //Console.WriteLine($"El nombre de user1 es {user1.Name}");

                    //User user2 = User.GetInstance();
                    //user2.Name = "Melina";
                    //Console.WriteLine($"El nombre de user2 es {user2.Name}");


                    //Console.WriteLine($"El nombre de user1 es {user1.Name}");

                    //Console.WriteLine(user1 == user2); //true Por qué???, Puntero es igual

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
