using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Analisis_y_reportes
{
    public class CD_CertificacionServicios: CD_EjecutarSP
    {
        private int idEmpleado;
        private int idCertificacion;
        private DateTime fecha;
        private int fechaIndex;

        public int IdEmpleado
        {
            get => idEmpleado;
            set => idEmpleado = value;
        }
        public int IdCertificacion
        {
            get => idCertificacion;
            set => idCertificacion = value;
        }
        public DateTime Fecha
        {
            get => fecha;
            set => fecha = value;
        }
        public int FechaIndex
        {
            get => fechaIndex;
            set => fechaIndex = value;
        }
        public DataTable ConsultaCertificacionServicios(string cuit, string nombre, string apellido, int etapa)
        {
            SqlParameter param1 = new SqlParameter("@cuit", cuit) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@nombre", nombre) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@apellido", apellido) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@etapa", etapa) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4 };

            DataTable resultado = EjecutarConsultas("consultar_certificacion_sp", listaParametros.ToArray());
            return resultado;
        }
        public DataTable ConsultaPersonalCertificacion(string cuit, string nombre, string apellido, bool estado)
        {
            SqlParameter param1 = new SqlParameter("@cuit", cuit) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@nombre", nombre) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@apellido", apellido) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@estado", !estado) { SqlDbType = SqlDbType.Bit };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4 };

            DataTable resultado = EjecutarConsultas("consultar_personal_certificacion_sp", listaParametros.ToArray());
            return resultado;
        }
        public void AltaCertificacion()
        {
            SqlParameter param1 = new SqlParameter("@id_persona", idEmpleado) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@fecha_solicitud", fecha) { SqlDbType = SqlDbType.Date };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };

            EjecutarConsultas("alta_certificacion_sp", listaParametros.ToArray(), true);
        }
        public DataTable ConsultaFechaUltimaCertificacion(int idEmpleado)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", idEmpleado) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };

            DataTable resultado = EjecutarConsultas("consultar_fecha_ultima_certificacion_sp", listaParametros.ToArray());
            return resultado;
        }
        public DataTable ConsultaPersonaCertificacion(int idCertificacion)
        {
            SqlParameter param1 = new SqlParameter("@id_certificacion", idCertificacion) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };

            DataTable resultado = EjecutarConsultas("consultar_persona_certificacion_sp", listaParametros.ToArray());
            return resultado;
        }
        public void UpFechaCertificacion()
        {
            SqlParameter param1 = new SqlParameter("@id_certificacion", idCertificacion) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@fecha", fecha) { SqlDbType = SqlDbType.Date };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };

            switch (fechaIndex)
            {
                case 0:
                    EjecutarConsultas("up_fecha_0_certificacion_sp", listaParametros.ToArray(), true);
                    break;
                case 1:
                    EjecutarConsultas("up_fecha_1_certificacion_sp", listaParametros.ToArray(), true);
                    break;
                case 2:
                    EjecutarConsultas("up_fecha_2_certificacion_sp", listaParametros.ToArray(), true);
                    break;
            }
        }
    }
}
