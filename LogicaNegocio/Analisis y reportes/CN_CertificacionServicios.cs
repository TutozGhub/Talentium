using AccesoDatos.Analisis_y_reportes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Analisis_y_reportes
{
    public class CN_CertificacionServicios
    {
        #region Atributos
        private int idEmpleado;
        private int idCertificacion;
        private DateTime fecha;
        private int fechaIndex;
        #endregion

        #region Propiedades
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
        #endregion

        CD_CertificacionServicios cs = new CD_CertificacionServicios();
        #region Consultas
        public DataTable ConsultaCertificacionServicios(string cuit, string nombre, string apellido, int etapa)
        {
            if (string.IsNullOrEmpty(cuit)) cuit = "\0";
            if (string.IsNullOrEmpty(nombre)) nombre = "\0";
            if (string.IsNullOrEmpty(apellido)) apellido = "\0";

            DataTable dt = cs.ConsultaCertificacionServicios(cuit, nombre, apellido, etapa);
            return dt;
        }
        public DataTable ConsultaPersonalCertificacion(string cuit, string nombre, string apellido, bool estado)
        {
            if (string.IsNullOrEmpty(cuit)) cuit = "\0";
            if (string.IsNullOrEmpty(nombre)) nombre = "\0";
            if (string.IsNullOrEmpty(apellido)) apellido = "\0";

            DataTable dt = cs.ConsultaPersonalCertificacion(cuit, nombre, apellido, estado);
            return dt;
        }
        public DateTime? ConsultaFechaUltimaCertificacion(int idEmpleado)
        {
            DataTable resultado = cs.ConsultaFechaUltimaCertificacion(idEmpleado);
            switch (resultado.Rows.Count)
            {
                default:
                    return Convert.ToDateTime(resultado.Rows[0][0]);
                case 0:
                    return null;
            }

        }
        public DataTable ConsultaPersonaCertificacion(int idCertificacion)
        {
            DataTable dt = cs.ConsultaPersonaCertificacion(idCertificacion);
            return dt;
        }
        #endregion
        #region Alta
        public void AltaCertificacion()
        {
            cs.IdEmpleado = idEmpleado;
            cs.Fecha = fecha;
            cs.AltaCertificacion();
        }
        #endregion
        #region Modificacion
        public void UpFechaCertificacion()
        {
            cs.IdCertificacion = idCertificacion;
            cs.Fecha = fecha;
            cs.FechaIndex = fechaIndex;
            cs.UpFechaCertificacion();
        }
        #endregion
    }
}
