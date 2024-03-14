using Comun;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CD_TraerPermisos: CD_EjecutarSP
    {
        public DataTable TraerPermisos(int idUsuario)
        {
            SqlParameter param1 = new SqlParameter("@id_usuario", idUsuario) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };

            DataTable dt = EjecutarConsultas("consultar_permisos_usuario_sp", listaParametros.ToArray());
            return dt;

        }
        public DataTable TraerPermisos()
        {
            SqlParameter param1 = new SqlParameter("@id_perfil", UserCache.idPerfil) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };

            DataTable dt = EjecutarConsultas("consultar_permisos_usuario_perfil_sp", listaParametros.ToArray());
            return dt;

        }
    }
}
