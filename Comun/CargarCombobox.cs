using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class CargarCombobox
    {
        public List<string> CargarAnioCombobox()
        {
            int anioVigente = DateTime.Now.Year;
            List<string> listaAnios = new List<string>();

            for (int i = 1900; i <= anioVigente; i++)
            {
                listaAnios.Add(i.ToString());
            }
            listaAnios.Reverse();
            return listaAnios;
        }
        public List<string> CargarMesCombobox()
        {
            List<string> listaMeses = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                DateTime mes = new DateTime(2023, i, 1);
                string nombreMes = mes.ToString("MMMM").ToUpper();
                listaMeses.Add(nombreMes);
            }
            return listaMeses;
        }
    }
}
