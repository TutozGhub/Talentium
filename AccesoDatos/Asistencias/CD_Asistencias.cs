using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
namespace AccesoDatos
{

    public class CD_Asistencias : CD_EjecutarSP
    {

        public int idAsistencia;
        public int idPersona;
        public bool periodo;
        public DateTime? fecha;
        public DateTime? fecha_desde;
        public DateTime? fecha_hasta;
        public int idMotivo;
        public string otro_motivo;
        public bool justificada;
        public string observaciones;

        public int IdAsistencia
        {
            get { return idAsistencia; }
            set { idAsistencia = value; }
        }
        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public bool Periodo
        {
            get { return periodo; }
            set { periodo = value; }
        }

        public DateTime? Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public DateTime? FechaDesde
        {
            get { return fecha_desde; }
            set { fecha_desde = value; }
        }

        public DateTime? FechaHasta
        {
            get { return fecha_hasta; }
            set { fecha_hasta = value; }
        }

        public int IdMotivo
        {
            get { return idMotivo; }
            set { idMotivo = value; }
        }

        public string OtroMotivo
        {
            get { return otro_motivo; }
            set { otro_motivo = value; }
        }

        public bool Justificada
        {
            get { return justificada; }
            set { justificada = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        //traer area
        public DataTable Areas()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("consultar_areas_sp", listaParametros.ToArray());

            return resultado;
        }

        //traer puesto
        public DataTable Puestos(int id)
        {
            SqlParameter param1 = new SqlParameter("@id_areas", id) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1};
            DataTable resultado = EjecutarConsultas("consultarPuestos_sp", listaParametros.ToArray());

            return resultado;
        }
        //traer motivo
        public DataTable Motivos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("consultarMotivos_sp", listaParametros.ToArray());

            return resultado;
        }

        //el filtro de alta trae nombre, apellido, area, puesto

        public DataTable ConsultaAsistencias(int area, int puesto, string cuil)
        {
            SqlParameter param1 = new SqlParameter("@id_area", area) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_puesto", puesto) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@cuil", cuil) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3 };
            DataTable resultado = EjecutarConsultas("FiltroAltaAsistencias_SP", listaParametros.ToArray());

            return resultado;
        }

        //el filtro para modificar y consultar trae: nombre, apellido, area, puesto, justificada
        public DataTable ConsultaAsistenciasMod( int idArea, int idPuesto, string cuil, DateTime? fecha, DateTime? fechaDesde, DateTime? fechaHasta)
        {

            SqlParameter param1 = new SqlParameter("@id_area", idArea) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_puesto", idPuesto) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@cuil", cuil) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@fecha", fecha) { SqlDbType = SqlDbType.Date };
            SqlParameter param5 = new SqlParameter("@fecha_desde", fechaDesde) { SqlDbType = SqlDbType.Date };
            SqlParameter param6 = new SqlParameter("@fecha_hasta", fechaHasta) { SqlDbType = SqlDbType.Date };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, param6 };
            DataTable resultado = EjecutarConsultas("FiltroObtenerAsistencias_SP", listaParametros.ToArray());

            return resultado;
        }
        //traer el cuil segun la persona
        /* public DataTable ConsultarCuil(string cuil)
         {
             SqlParameter param3 = new SqlParameter("@cuil", cuil) { SqlDbType = SqlDbType.NVarChar };

             List<SqlParameter> listaParametros = new List<SqlParameter>() { param3 };
             DataTable resultado = EjecutarConsultas("", listaParametros.ToArray());

             return resultado;
         }*/
        //insertar asistencia
        /* public void CargarAsistencia()
         {
             SqlParameter param1 = new SqlParameter("@id_persona", IdPersona) { SqlDbType = SqlDbType.Int };
             SqlParameter param2 = new SqlParameter("@periodo", periodo) { SqlDbType = SqlDbType.Bit };
             SqlParameter param3 = new SqlParameter("@fecha", fecha) { SqlDbType = SqlDbType.Date };
             SqlParameter param4 = new SqlParameter("@fecha_desde", fecha_desde) { SqlDbType = SqlDbType.Date };
             SqlParameter param5 = new SqlParameter("@fecha_hasta", fecha_hasta) { SqlDbType = SqlDbType.Date };
             SqlParameter param6 = new SqlParameter("@id_motivo", idMotivo) { SqlDbType = SqlDbType.Int };
             SqlParameter param7 = new SqlParameter("@otro_motivo", otro_motivo) { SqlDbType = SqlDbType.NChar};
             SqlParameter param8 = new SqlParameter("@justificada", justificada) { SqlDbType = SqlDbType.Bit };
             SqlParameter param9 = new SqlParameter("@observaciones", observaciones) { SqlDbType = SqlDbType.NVarChar};


             List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, param6, param7, param8, param9 };

             DataTable resultado = EjecutarConsultas("alta_asistencias_sp", listaParametros.ToArray(), true);
         }*/
        public void CargarAsistencias(List<Asistencia> asistencias)
        {
            // Crear una lista para almacenar los parámetros para cada asistencia
            List<SqlParameter[]> listaParametrosAsistencias = new List<SqlParameter[]>();

            // Iterar sobre la lista de asistencias
            foreach (var asistencia in asistencias)
            {
                // Crear los parámetros para la asistencia actual
                SqlParameter param1 = new SqlParameter("@id_persona", asistencia.idPersona) { SqlDbType = SqlDbType.Int };
                SqlParameter param2 = new SqlParameter("@periodo", asistencia.Periodo) { SqlDbType = SqlDbType.Bit };
                SqlParameter param3 = new SqlParameter("@fecha", asistencia.Fecha) { SqlDbType = SqlDbType.Date };
                //SqlParameter param4 = new SqlParameter("@fecha_desde", asistencia.FechaDesde) { SqlDbType = SqlDbType.Date };
               // SqlParameter param5 = new SqlParameter("@fecha_hasta", asistencia.FechaHasta) { SqlDbType = SqlDbType.Date };
                SqlParameter param6 = new SqlParameter("@id_motivo", asistencia.idMotivo) { SqlDbType = SqlDbType.Int };
                SqlParameter param7 = new SqlParameter("@otro_motivo", asistencia.OtroMotivo) { SqlDbType = SqlDbType.NChar };
                SqlParameter param8 = new SqlParameter("@justificada", asistencia.Justificada) { SqlDbType = SqlDbType.Bit };
                SqlParameter param9 = new SqlParameter("@observaciones", asistencia.Observaciones) { SqlDbType = SqlDbType.NVarChar };

                // Agregar los parámetros de la asistencia actual a la lista de parámetros
                SqlParameter[] parametrosAsistencia = new SqlParameter[] { param1, param2, param3/*, param4, param5*/, param6, param7, param8, param9 };
                listaParametrosAsistencias.Add(parametrosAsistencia);
            }

            // Ejecutar el procedimiento almacenado para cada conjunto de parámetros
            foreach (var parametrosAsistencia in listaParametrosAsistencias)
            {
                DataTable resultado = EjecutarConsultas("alta_asistencia_sp", parametrosAsistencia, true);
            }
        }
        public void ModificarAsistencia()
        {
            SqlParameter param0 = new SqlParameter("@id_asistencia", idAsistencia) { SqlDbType = SqlDbType.Int };
            SqlParameter param1 = new SqlParameter("@id_persona", IdPersona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@periodo", periodo) { SqlDbType = SqlDbType.Bit };
            SqlParameter param3 = new SqlParameter("@fecha", fecha) { SqlDbType = SqlDbType.Date };
            SqlParameter param6 = new SqlParameter("@id_motivo", idMotivo) { SqlDbType = SqlDbType.Int };
            SqlParameter param7 = new SqlParameter("@otro_motivo", otro_motivo) { SqlDbType = SqlDbType.NChar};
            SqlParameter param8 = new SqlParameter("@justificada", justificada) { SqlDbType = SqlDbType.Bit };
            SqlParameter param9 = new SqlParameter("@observaciones", observaciones) { SqlDbType = SqlDbType.NVarChar};


            List<SqlParameter> listaParametros = new List<SqlParameter>() { param0, param1, param2, param3, param6, param7, param8, param9 };

            DataTable resultado = EjecutarConsultas("upAsistencias_SP", listaParametros.ToArray(), true);
        }

        public void EliminarAsistencia(int idAsist)
        {
            SqlParameter param0 = new SqlParameter("@id_asistencia", idAsist) { SqlDbType = SqlDbType.Int };
            

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param0};

            DataTable resultado = EjecutarConsultas("EliminarAsistencias_SP", listaParametros.ToArray(), true);
        }
    }
}
