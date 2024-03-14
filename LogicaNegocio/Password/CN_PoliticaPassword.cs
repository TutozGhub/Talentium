using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class CN_PoliticaPassword
    {
        CD_PoliticasPass accesoDatos = new CD_PoliticasPass();
        public void upPolPass(bool min_carct, bool comb_may, bool num_letras, bool caract_esp, bool datos_per)
        {
            try
            {
                accesoDatos.upPolPass(min_carct, comb_may, num_letras, caract_esp, false, datos_per);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ConsultaPoliticaPass()
        {
            try
            {
                accesoDatos.ConsultaPoliticaPass();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
