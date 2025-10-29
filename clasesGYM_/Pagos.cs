using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clasesGYM_
{
    public class Pagos
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public int ClienteId { get; set; }
        public Cliente ClientePago { get; set; }
        public MetodoDePago Metodo { get; set; }

        public enum MetodoDePago
        {
            Efectivo,
            TarjetaCredito,
            TarjetaDebito,
            TransferenciaBancaria,
            PayPal
        }
    }
}
