using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using LogicaNegocio.Bitacora;

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
                CN_Bitacora.AltaBitacora("Politicas de password modificadas", "UPDATE", "Seguridad");
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
