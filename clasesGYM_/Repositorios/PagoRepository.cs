using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clasesGYM_.Repositorios
{
    public class PagoRepository
    {
        public static void RegistrarPago(Pagos pago)
        {
            using (AplicationDbContext context = new AplicationDbContext())
            {
                context.Pagos.Add(pago);
                context.SaveChanges();
            }
        }
    }
}
