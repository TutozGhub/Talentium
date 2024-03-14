using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public static class ConfigCache
    {
        public static bool caracteres { get; set; }
        public static bool mayusculas { get; set; }
        public static bool numeros { get; set; }
        public static bool especiales { get; set; }
        public static bool passAnteriores { get; set; }
        public static bool noDatosPersonales { get; set; }

        public readonly static int Intentos = 5;
        public readonly static double LapsoBloqueo = 10;
        public readonly static DateTime FechaDefecto = Convert.ToDateTime("1900-01-01");
    }
}
