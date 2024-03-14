using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Bitacora
{
    public class CD_Bitacora : CD_EjecutarSP
    {
        public string tipo { get; set; }
        public int? idUsuario { get; set; }
        public string mensaje { get; set; }
        public string accion { get; set; }
        public string lugar { get; set; }

        public void AltaBitacora()
        {
            SqlParameter param1 = new SqlParameter("@tipo", tipo) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@usuario", idUsuario);
            SqlParameter param3 = new SqlParameter("@mensaje", mensaje) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@accion", accion) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param5 = new SqlParameter("@lugar", lugar) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5 };

            EjecutarConsultas("alta_bitacora_sp", listaParametros.ToArray(), true);
        }
        public DataTable ConsultarBitacora()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("consultar_bitacora_sp", listaParametros.ToArray());
            return resultado;
        }
    }

}
