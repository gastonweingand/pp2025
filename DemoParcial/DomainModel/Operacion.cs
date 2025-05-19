﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DomainModel
{
    public class Operacion
    {
        // Propiedades
        public Cuenta CuentaOrigen { get; set; }
        public Cuenta CuentaDestino { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public TipoOperacion TipoOperacion { get; set; }

        // Constructor
        public Operacion(Cuenta cuentaOrigen, Cuenta cuentaDestino, DateTime fecha, decimal monto, TipoOperacion tipoOperacion)
        {
            CuentaOrigen = cuentaOrigen;
            CuentaDestino = cuentaDestino;
            Fecha = fecha;
            Monto = monto;
            TipoOperacion = tipoOperacion;
        }

        // Método para mostrar la información de la operación
        public void MostrarInformacion()
        {
            Console.WriteLine($"Operación: {TipoOperacion}");
            Console.WriteLine($"Cliente Origen: {CuentaOrigen.Cliente.CUIT}");
            Console.WriteLine($"Cliente Destino: {CuentaDestino.Cliente.CUIT}");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Monto: {Monto}");
        }
    }

}
