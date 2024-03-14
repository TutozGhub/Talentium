using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public static class UserCache
    {
        public static int id { get; set; }
        public static int idPersona { get; set; }
        public static string usuario { get; set; }
        public static string password { get; set; }
        public static DateTime alta { get; set; }
        public static DateTime baja { get; set; }
        public static int cambiaCada { get; set; }
        public static DateTime ultimoCambio { get; set; }
        public static DateTime bloqueo { get; set; }
        public static string digito { get; set; }
        public static int intentos { get; set; }
        public static bool nuevo { get; set; }
        public static int idPerfil { get; set; }

        public static void Clear()
        {
            Type tipo = typeof(UserCache);

            foreach (var propiedad in tipo.GetProperties())
            {
                if (propiedad.CanWrite && propiedad.GetSetMethod() != null)
                {
                    propiedad.SetValue(null, null);
                }
            }
        }
    }
}
