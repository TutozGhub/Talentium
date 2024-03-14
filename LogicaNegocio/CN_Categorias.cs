using AccesoDatos;
using Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class CN_Categorias
    {
        CD_Categorias _CDAcceso = new CD_Categorias();

        public DataTable ObtenerCategoria()
        {
            return _CDAcceso.ObtenerCategorias();
        }


        public void InsertarCategoria (CategoriaDto categorias)
        {
            _CDAcceso.InsertarCategorias (categorias);
        }

        public bool EliminarCategoria (int id_categoria)
        {

            try
            {
                // Llamar al método de la capa de datos para eliminar el convenio.
                DataTable resultado = _CDAcceso.EliminarCategoria(id_categoria);
                if (Convert.ToInt32(resultado.Rows[0][0]) == 0)
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
                throw new Exception("Error al eliminar la categoria: " + ex.Message);
            }
            
        }

        public void ModificarCategoria (CategoriaDto categoria, int id)
        {
            _CDAcceso.ModificarCategoria(categoria,id);
        }
    }
}
