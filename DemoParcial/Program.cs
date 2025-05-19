﻿using DemoParcial.BLL;
using DemoParcial.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.BLL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TransferService service = new TransferService();

            Cliente cliente = new Cliente("20312437210", "Pepe");
            CajaAhorro cajaAhorro = new CajaAhorro("1234567890123456789000");
            cajaAhorro.Depositar(1000000);
            cliente.AgregarCuenta(cajaAhorro);

            MonederoBTC mon = new MonederoBTC("YYYY-YYYY");
            cliente.AgregarCuenta(mon);

            Console.WriteLine("Antes de convertir de $ a BTC");
            Console.WriteLine($"Caja Ahorro $: {cajaAhorro.Saldo}");
            Console.WriteLine($"Monedero BTC: {mon.Saldo}");

            service.Transferir(cajaAhorro, mon, 10000);

            Console.WriteLine("Luego de hacer la conversión");
            Console.WriteLine($"Caja Ahorro $: {cajaAhorro.Saldo}");
            Console.WriteLine($"Monedero BTC: {mon.Saldo}");

            service.Transferir(mon, cajaAhorro, (decimal)0.00008338);

            Console.WriteLine("Luego de hacer la conversión a saldo inicial");
            Console.WriteLine($"Caja Ahorro $: {cajaAhorro.Saldo}");
            Console.WriteLine($"Monedero BTC: {mon.Saldo}");

            Cliente cliente2 = new Cliente("27312437210", "María");
            CajaAhorro cajaAhorro2 = new CajaAhorro("6664567890123456789000");
            cliente2.AgregarCuenta(cajaAhorro2);

            Console.WriteLine("Antes de transferir de $ a $");
            Console.WriteLine($"Caja Ahorro 1 $: {cajaAhorro.Saldo}");
            Console.WriteLine($"Caja Ahorro 2 $: {cajaAhorro2.Saldo}");

            service.Transferir(cajaAhorro, cajaAhorro2, 50000);

            Console.WriteLine("Después de transferir de $ a $");
            Console.WriteLine($"Caja Ahorro 1 $: {cajaAhorro.Saldo}");
            Console.WriteLine($"Caja Ahorro 2 $: {cajaAhorro2.Saldo}");

            Console.Read();
        }
    }
}

