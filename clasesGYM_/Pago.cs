using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clasesGYM_
{
    public class Pago
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        // public Cliente ClientePago { get; set; }    
        // luego activar esto y hacer la relacion con la clase Cliente
        // public Suscripcion SuscripcionPago { get; set; }
    }
}
