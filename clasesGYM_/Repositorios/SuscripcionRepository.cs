using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clasesGYM_;

namespace clasesGYM_.Repositorios
{
    public class SuscripcionRepository
    {
        // METODO: Crear nueva suscripcion en la base de datos
        public static void AgregarSuscripcion(Suscripcion suscripcion)
        {
            using (var context = new AplicationDbContext())
            {
                // Garantizar que la suscripción se cree como activa
                suscripcion.EstaActivo = true;
                
                context.Suscripciones.Add(suscripcion);
                context.SaveChanges();
            }
        }


        // METODO: Obtener todas las suscripciones disponibles
        public static List<Suscripcion> ObtenerSuscripciones()
        {
            using (var context = new AplicationDbContext())
            {
                return context.Suscripciones.ToList();
            }
        }

        // METODO: Obtener solo suscripciones activas
        public static List<Suscripcion> ObtenerSuscripcionesActivas()
        {
            using (var context = new AplicationDbContext())
            {
                return context.Suscripciones.Where(s => s.EstaActivo == true).ToList();
            }
        }

        // METODO: Obtener una suscripcion especifica por su ID
        public static Suscripcion ObtenerSuscripcion(int suscripcionId)
        {
            using (var context = new AplicationDbContext())
            {
                return context.Suscripciones.Find(suscripcionId);
            }
        }
        public static decimal ObtenerPrecioSuscripcion(int suscripcionId)
        {
            using (var context = new AplicationDbContext())
            {
                var suscripcion = context.Suscripciones.Find(suscripcionId);
                return suscripcion != null ? suscripcion.Precio : 0m;
            }
        }

        // METODO: Eliminar una suscripcion (eliminación lógica - desactivar)
        public static void EliminarSuscripcion(int id)
        {
            using (var context = new AplicationDbContext())
            {
                var suscripcion = context.Suscripciones.Find(id);
                if (suscripcion != null)
                {
                    // Eliminación lógica: solo desactivar la suscripción
                    suscripcion.EstaActivo = false;
                    context.SaveChanges();
                }
            }
        }

        // METODO: Actualizar los datos de una suscripcion existente
        public static void ActualizarSuscripcion(Suscripcion suscripcion)
        {
            using (var context = new AplicationDbContext())
            {
                var suscripcionExistente = context.Suscripciones.Find(suscripcion.Id);
                if (suscripcionExistente != null)
                {
                    suscripcionExistente.Nombre = suscripcion.Nombre;
                    suscripcionExistente.Precio = suscripcion.Precio;
                    suscripcionExistente.EstaActivo = suscripcion.EstaActivo;
                    context.SaveChanges();
                }
            }
        }

    }
}
