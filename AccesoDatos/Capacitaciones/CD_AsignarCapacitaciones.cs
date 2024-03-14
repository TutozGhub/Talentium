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
    public class CD_AsignarCapacitaciones: CD_EjecutarSP
    {
        public int IdPersona { get; set; }
        public int IdCapacitacion { get; set; }
        public int IdArea { get; set; }

        public DataTable ConsultarCapacitacionesLst()
        {
            SqlParameter param1 = new SqlParameter("@id_area", IdArea) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };

            DataTable resultado = EjecutarConsultas("consultar_capacitaciones_sp", listaParametros.ToArray());
            return resultado;
        }
        public DataTable ConsultarCapacitacionesPersona()
        {
            SqlParameter param1 = new SqlParameter("@id_persona", IdPersona) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };

            DataTable resultado = EjecutarConsultas("consultar_capacitaciones_persona_sp", listaParametros.ToArray());
            return resultado;
        }
        public DataTable ConsultarPersonal(string cuit, string nombre, string apellido, int area)
        {
            SqlParameter param1 = new SqlParameter("@cuil", cuit) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@nombre", nombre) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@apellido", apellido) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@id_area", area) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4 };

            DataTable resultado = EjecutarConsultas("consultar_personal_asignar_capacitaciones_sp", listaParametros.ToArray());
            return resultado;
        }
        public void AsignarCapacitaciones()
        {
            SqlParameter param1 = new SqlParameter("@id_persona", IdPersona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_capacitacion", IdCapacitacion) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };

            DataTable resultado = EjecutarConsultas("alta_capacitacion_persona_sp", listaParametros.ToArray());
        }
        public void BorrarCapacitacionPersona()
        {
            SqlParameter param1 = new SqlParameter("@id_persona", IdPersona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_capacitacion", IdCapacitacion) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };

            DataTable resultado = EjecutarConsultas("borrar_capacitaciones_persona_sp", listaParametros.ToArray());
        }
    }
}
