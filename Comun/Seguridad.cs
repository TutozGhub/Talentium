using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public static class Seguridad
    {
        // Encripta
        public static string Encriptar(this string _cadenaAencriptar)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            string result = Convert.ToBase64String(encryted);
            return result;
        }

        // Desencripta
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            string result = Encoding.Unicode.GetString(decryted);
            return result;
        }

        // Hashea
        public static string Hash(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        // Realiza el algoritmo de Lhun para crear un digito verificador en base a un string
        public static int DigVerif(string Hexa) // Digito verificador
        {
            int[] decimales = new int[Hexa.Length];
            int i = 0;

            foreach (char caracter in Hexa)
            {
                decimales[i] = Convert.ToInt32(caracter.ToString(), 16); //Convierto los hexa en decimal
                i++;
            }

            // ALGORITMO DE LHUN
            // PASO 1 - Invertir los numeros
            Array.Reverse(decimales);

            // PASO 2 - Multiplicar por 2 las posiciones pares comenzando por la 0
            int[] decimalesxDos = new int[decimales.Length];
            for (int x = 0; x <= decimales.Length - 1; x++)
            {
                if (x % 2 == 0)
                {
                    decimalesxDos[x] = decimales[x] * 2;
                }
                else
                {
                    decimalesxDos[x] = decimales[x];
                }
            }

            // PASO 3 - Sumar los digitos de los nros que quedaron con mas de un digito
            for (int x = 0; x <= decimalesxDos.Length - 1; x++)
            {
                if (Convert.ToString(decimalesxDos[x]).Length > 1)
                {
                    int a = Convert.ToInt32(Convert.ToString(decimalesxDos[x]).Substring(0, 1));
                    int b = Convert.ToInt32(Convert.ToString(decimalesxDos[x]).Substring(1, 1));
                    decimalesxDos[x] = a + b;
                    if (Convert.ToString(decimalesxDos[x]).Length > 1)
                    {
                        a = Convert.ToInt32(Convert.ToString(decimalesxDos[x]).Substring(0, 1));
                        b = Convert.ToInt32(Convert.ToString(decimalesxDos[x]).Substring(1, 1));
                        decimalesxDos[x] = a + b;
                    }
                }
            }

            // PASO 4 - Sumar todos los digitos del array
            int SubTotal = decimalesxDos.Sum();

            // PASO 5 - Multiplicamos por 9 el resultado de la suma anterior
            int Total = SubTotal * 9;

            // Paso 6 - Al resultado anterior le calculamos el MOD 10
            int Resultado = Total % 10;

            return Resultado;
        }
        public static string GenerarStringAleatorio(int largo = 8)
        {
            int longitudCodigo = largo; // Longitud del código alfanumérico
            string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            char[] codigoAlfanumerico = new char[longitudCodigo];

            for (int i = 0; i < longitudCodigo; i++)
            {
                int indiceCaracter = random.Next(caracteresPermitidos.Length);
                codigoAlfanumerico[i] = caracteresPermitidos[indiceCaracter];
            }

            string codigoGenerado = new string(codigoAlfanumerico);

            return codigoGenerado;
        }
        public static bool VerificarCuiCuil(string cuiCuil)
        {
            if (cuiCuil.Length != 11)
            {
                return false;
            }

            int[] coeficientes = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;

            for (int i = 0; i < coeficientes.Length; i++)
            {
                suma += int.Parse(cuiCuil[i].ToString()) * coeficientes[i];
            }

            int resto = suma % 11;
            int digitoVerificador = 11 - resto;

            if (resto == 0)
            {
                return int.Parse(cuiCuil[10].ToString()) == 0;
            }
            else if (resto == 1)
            {
                return int.Parse(cuiCuil[10].ToString()) == 1;
            }
            else
            {
                return int.Parse(cuiCuil[10].ToString()) == digitoVerificador;
            }
        }
    }
}
