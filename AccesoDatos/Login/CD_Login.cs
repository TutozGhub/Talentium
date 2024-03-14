using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;

namespace AccesoDatos.Login
{
    public class CD_Login: CD_EjecutarSP
    {
        public DataTable Buscar(string usuario)
        {
            SqlParameter param1 = new SqlParameter("@usuario", usuario) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("loginConsulta2_sp", listaParametros.ToArray());
            return resultado;
        }
        public void Bloquear(int id, DateTime? hBloqueo)
        {
            List<SqlParameter> listaParametros;
            SqlParameter param1 = new SqlParameter("@ID", id) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@bloqueo", hBloqueo) { SqlDbType = SqlDbType.DateTime };
            listaParametros = new List<SqlParameter>() { param1, param2 };

            EjecutarConsultas("bloqueo_usuario_sp", listaParametros.ToArray(), true);
        }
        public void RestarIntento(int id)
        {
            SqlParameter param1 = new SqlParameter("@ID", id) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            EjecutarConsultas("intento_usuario_sp", listaParametros.ToArray(), true);
        }
        public void RestaurarIntentos(int id, int intentos)
        {
            SqlParameter param1 = new SqlParameter("@ID", id) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@intentos", intentos) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };

            EjecutarConsultas("restablecimiento_de_intentos_sp", listaParametros.ToArray(), true);
        }
        public DataTable EmailDeRecupero(string usuario)
        {
            SqlParameter param1 = new SqlParameter("@usuario", usuario) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("ConsEmailRecupero_sp", listaParametros.ToArray());
            return resultado;
        }
        public DataTable ValidCode(int id)
        {
            SqlParameter param1 = new SqlParameter("@id_usuario", id) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("ValidarCodEmail_sp", listaParametros.ToArray());
            return resultado;
        }
        public DataTable TraerDatosPersonales()
        {
            SqlParameter param1 = new SqlParameter("@id_usuario", UserCache.id) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("consultar_datos_verifpass_sp", listaParametros.ToArray());
            return resultado;
        }
    }
}
