using Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CD_Categorias : CD_EjecutarSP
    {

        public DataTable ObtenerCategorias()
        {
            DataTable resultado = EjecutarConsultasSinParam("SelectCategoria_Sp");

            return resultado;
        }

        public void InsertarCategorias(CategoriaDto categoria)
        {
            SqlParameter param1 = new SqlParameter("@nombre_categoria", categoria.categoria) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@jornada", categoria.jornada) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@sueldos", categoria.sueldo) { SqlDbType = SqlDbType.Decimal };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, };
            EjecutarConsultas("InsertCategoria_sp", listaParametros.ToArray(), true);
        }

        //public void EliminarCategorias(int id_categoria)
        //{
        //    List<SqlParameter> parametros = new List<SqlParameter>();
        //    parametros.Add(new SqlParameter("@id_categoria", id_categoria));
        //    EjecutarConsultas("EliminarCategoria", parametros.ToArray(), true);
        //}

        public DataTable EliminarCategoria(int id_categoria)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_categoria", id_categoria));
            DataTable dt = EjecutarConsultas("EliminarCategoria_sp", parametros.ToArray());
            return dt;
        }


        public void ModificarCategoria(CategoriaDto categoria, int id)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_categoria", id));
            parametros.Add(new SqlParameter("@nombre_categoria", categoria.categoria));
            parametros.Add(new SqlParameter("@jornada", categoria.jornada));
            parametros.Add(new SqlParameter("@sueldos", categoria.sueldo));


            EjecutarConsultas("ModificarCategoria", parametros.ToArray(), true);
        }
    }
}
