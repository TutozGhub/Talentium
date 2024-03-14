using AccesoDatos;
using Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
   public class CN_Convenio
    {
        CD_Convenios _CDAcceso = new CD_Convenios();
        public void InsertarConvenio(ConvenioDto convenio)
        {
            _CDAcceso.InsertarConvenios(convenio);
        }
        public DataTable ObtenerConvenio()
        {
            return _CDAcceso.ObtenerConvenios();
        }
        public DataTable area()
        {
            return _CDAcceso.Areas();
        }
        public DataTable puesto(int id)
        {
            return _CDAcceso.Puestos(id);
        }
        public DataTable ObtenerCategoriaID(int id)
        {
           return _CDAcceso.ObtenerCategoriaPorId(id);
        }

        public void ModificarConvenio(ConvenioDto convenio, int id)
        {
            _CDAcceso.ModificarConvenio(convenio, id);
        }
        public bool EliminarConvenio(int id_convenio)
        {
            try
            {
                // Llamar al método de la capa de datos para eliminar el convenio.
                DataTable resultado = _CDAcceso.EliminarConvenio(id_convenio);
                if(Convert.ToInt32(resultado.Rows[0][0]) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                 
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la operación.
                // Puedes registrar el error o mostrar un mensaje de error genérico.
                throw new Exception("Error al eliminar el convenio: " + ex.Message);
            }
        }

        public DataTable ConsultarConveniosPersonas(int id_area, int id_puesto, int id_convenio, string cuil) 
        {
            return _CDAcceso.ConsultarConveniosPersonas(id_area, id_puesto, id_convenio, cuil);

        }

    }
}

