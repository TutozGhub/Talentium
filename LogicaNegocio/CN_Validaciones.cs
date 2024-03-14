using AccesoDatos;
using AccesoDatos.Login;
using Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public static class CN_Validaciones
    {

        private static List<string> mensajeErrorLabel = new List<string>(); // NOTA: mover a otra clase mas adelante
        public static string[] GetMensajeErrorLabel() { return mensajeErrorLabel.ToArray(); }

        // VALIDA SI TIENE MINIMO 8 CARACTERES.
        private static bool minimoDeCaracteres(string str)
        {
            if (str.Length >= 8) return true;
            mensajeErrorLabel.Add(Lenguajes.Errores.PasMinimo8);
            return false;
        }
        // VALIDA SI TIENE MAYUSCULAS.
        private static bool tieneMayuscula(string str)
        {
            string mayusculas = @"[A-Z]";
            if (Regex.IsMatch(str, mayusculas)) return true;
            mensajeErrorLabel.Add(Lenguajes.Errores.PasMinimoMay);
            return false;
        }
        // VALIDA SI TIENE MINUSCULAS.
        private static bool tieneMinuscula(string str)
        {
            string minusculas = @"[a-z]";
            if (Regex.IsMatch(str, minusculas)) return true;
            mensajeErrorLabel.Add(Lenguajes.Errores.PasMinimoMin);
            return false;
        }
        // VALIDA SI TIENE NUMEROS.
        private static bool tieneNumero(string str)
        {
            string numeros = @"[0-9]";
            if (Regex.IsMatch(str, numeros)) return true;
            mensajeErrorLabel.Add(Lenguajes.Errores.PasMinimoNum);
            return false;
        }
        // VALIDA SI TIENE CARACTERES ESPECIALES.
        private static bool tieneCaracterEspecial(string str)
        {
            string especiales = @"[^\w \-]";
            if (Regex.IsMatch(str, especiales)) return true;
            mensajeErrorLabel.Add(Lenguajes.Errores.PasMinimoEsp);
            return false;
        }
        // VALIDA SI TIENE DATOS PERSONALES.
        private static bool tieneDatosPersonales(string str)
        {
            CD_Login login = new CD_Login();
            DataTable datos = login.TraerDatosPersonales();
            List<string> palabras = new List<string>();
            if (datos.Rows.Count > 0)
            {
                separarPalabras(datos.Rows[0][0].ToString(), ref palabras);
                separarPalabras(datos.Rows[0][1].ToString(), ref palabras);
                palabras.Add(datos.Rows[0][2].ToString().Trim().ToLower());
                palabras.Add(datos.Rows[0][4].ToString().Trim());
            }

            str = str.ToLower();
            foreach (string palabra in palabras)
            {
                if (str.Contains(palabra))
                {
                    mensajeErrorLabel.Add(Lenguajes.Errores.PasDatos);
                    return false;
                }
            }
            return true;
        }
        private static void separarPalabras(string str, ref List<string> palabras)
        {
            string[] separadores = { " " };

            string[] _palabras = str.Split(separadores, StringSplitOptions.RemoveEmptyEntries);

            foreach (string palabra in _palabras)
            {
                palabras.Add(palabra.ToLower().Trim());
            }
        }
            // VALIDACION FINAL DE CARACTERES: SE ELIGE QUE VALIDACIONES SE USAN, Y SI LAS SELECCIONADAS SON true DEVUELVE true.
            public static bool ValCar(string str, bool minCaracteres, bool mayusculas, bool numeros, bool especiales, bool passAnteriores, bool noDatosPersonales)
        {
            mensajeErrorLabel.Clear();
            bool minCar, may, num, min, esp, noDat;

            if (!tieneMinuscula(str)) min = false; else min = true;
            if (minCaracteres) minCar = minimoDeCaracteres(str); else minCar = true;
            if (mayusculas) may = tieneMayuscula(str); else may = true;
            if (numeros) num = tieneNumero(str); else num = true;
            if (especiales) esp = tieneCaracterEspecial(str); else esp = true;
            if (noDatosPersonales) noDat = tieneDatosPersonales(str); else noDat = true;

            return minCar && may && num && min && esp && noDat;
        }
    }
}
