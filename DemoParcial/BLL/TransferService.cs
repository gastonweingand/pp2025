using DemoParcial.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.BLL
{
    public class TransferService
    {
        public void Transferir(Cuenta cuentaOrigen, Cuenta cuentaDestino, decimal monto)
        {
            if (cuentaOrigen == null) throw new ArgumentNullException(nameof(cuentaOrigen));
            if (cuentaDestino == null) throw new ArgumentNullException(nameof(cuentaDestino));
            if (monto <= 0) throw new ArgumentException("El monto debe ser mayor a cero.", nameof(monto));
            if (cuentaOrigen.Saldo < monto) throw new InvalidOperationException("Saldo insuficiente en la cuenta origen.");

            bool mismoTitular = cuentaOrigen.Cliente.CUIT == cuentaDestino.Cliente.CUIT;
            bool esConversion = cuentaOrigen.GetType() != cuentaDestino.GetType();

            if (esConversion && !mismoTitular)
            {
                throw new InvalidOperationException("Conversiones sólo permitidas entre cuentas del mismo titular.");
            }

            // Retirar saldo primero para evitar problemas
            cuentaOrigen.Retirar(monto);

            // Creamos el visitante para la cuenta origen con toda la info necesaria
            var visitanteTransferencia = new VisitanteTransferencia()
            {
                CuentaDestino = cuentaDestino,
                Monto = monto,
                ClienteOrigen = cuentaOrigen.Cliente
            };

            // Iniciamos doble despacho: cuenta origen acepta este visitante
            cuentaOrigen.AcceptOrigen(visitanteTransferencia);

            // En este momento el visitante tendrá llamado el Accept de cuentaDestino para depositar con conversión
        }

        // Clase visitante que trabaja con la cuenta origen, y luego hace doble despacho a cuenta destino
        private class VisitanteTransferencia : ITransferenciaVisitor, ICuentaVisitor
        {
            public Cuenta CuentaDestino { get; set; }
            public decimal Monto { get; set; }
            public Cliente ClienteOrigen { get; set; }

            // Estos campos se usan temporalmente para tipo de cuenta origen
            private Cuenta cuentaOrigen;

            // Primera llamada - cuando cuenta origen acepta este visitante
            public void VisitDesdeCajaDeAhorro(CajaAhorro cuentaOrigen)
            {
                this.cuentaOrigen = cuentaOrigen;
                // Doble dispatch: cuentaDestino acepta este mismo visitante para depositar según origen
                CuentaDestino.Accept(this);
            }

            public void VisitDesdeMonederoBTC(MonederoBTC cuentaOrigen)
            {
                this.cuentaOrigen = cuentaOrigen;
                CuentaDestino.Accept(this);
            }

            // Segunda llamada - cuenta destino acepta el visitante

            // Caso cuenta destino es CajaDeAhorro
            public void VisitCajaDeAhorro(CajaAhorro cuentaDestino)
            {
                // Logica de conversion segun cuentaOrigen y cuentaDestino

                if (cuentaOrigen is CajaAhorro)
                {
                    // Mismo tipo pesos a pesos
                    cuentaDestino.Depositar(Monto);
                }
                else if (cuentaOrigen is MonederoBTC)
                {
                    // BTC a pesos
                    decimal montoConvertido = ConvertirBTCAPesos(Monto);
                    cuentaDestino.Depositar(montoConvertido);
                }
                else
                {
                    throw new InvalidOperationException("Tipo de cuenta origen no soportado en destino CajaDeAhorro.");
                }
            }

            // Caso cuenta destino es MonederoBTC
            public void VisitMonederoBTC(MonederoBTC cuentaDestino)
            {
                if (cuentaOrigen is CajaAhorro)
                {
                    // pesos a BTC
                    decimal montoConvertido = ConvertirPesosABTC(Monto);
                    cuentaDestino.Depositar(montoConvertido);
                }
                else if (cuentaOrigen is MonederoBTC)
                {
                    // BTC a BTC
                    cuentaDestino.Depositar(Monto);
                }
                else
                {
                    throw new InvalidOperationException("Tipo de cuenta origen no soportado en destino MonederoBTC.");
                }
            }

            private decimal ConvertirPesosABTC(decimal montoPesos)
            {
                const decimal tasaPesosABtc = 0.000022m; // tasa fija ejemplo
                return montoPesos * tasaPesosABtc;
            }

            private decimal ConvertirBTCAPesos(decimal montoBtc)
            {
                const decimal tasaBtcAPesos = 45000m; // tasa fija ejemplo
                return montoBtc * tasaBtcAPesos;
            }
        }
    }
}
