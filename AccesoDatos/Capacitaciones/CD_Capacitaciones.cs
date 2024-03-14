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
    public class CD_Capacitaciones : CD_EjecutarSP
    {
        private int idCapacitaciones;
        private int idArea;
        private string capacitacion;
        private int idNivel;
        private int externaInterna;
        private int tiempoEstimado;
        private bool obligatorio;

        public int IdCapacitaciones
        {
            get { return idCapacitaciones; }
            set { idCapacitaciones = value; }
        }
        public int IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }
        public string Capacitacion
        {
            get { return capacitacion; }
            set { capacitacion = value; }
        }
        public int IdNivel
        {
            get { return idNivel; }
            set { idNivel = value; }
        }
        public int ExternaInterna
        {
            get { return externaInterna; }
            set { externaInterna = value; }
        }
        public int TiempoEstimado
        {
            get { return tiempoEstimado; }
            set { tiempoEstimado = value; }
        }
        public bool Obligatorio
        {
            get { return obligatorio; }
            set { obligatorio = value; }
        }

        //traer area
        public DataTable Areas()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("consultar_areas_sp", listaParametros.ToArray());

            return resultado;
        }
        public DataTable AltaCapacitaciones()
        {

            SqlParameter param1 = new SqlParameter("@id_area", idArea) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("capacitacion", capacitacion) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@nivel", idNivel) { SqlDbType = SqlDbType.Int};
            SqlParameter param4 = new SqlParameter("@externa_interna", externaInterna) { SqlDbType = SqlDbType.Int};
            SqlParameter param5 = new SqlParameter("@tiempo_estimado", tiempoEstimado) { SqlDbType = SqlDbType.Int };
            SqlParameter param6 = new SqlParameter("@obligatorio", Obligatorio) { SqlDbType = SqlDbType.Bit };

            List<SqlParameter> listaParametros = new List<SqlParameter>() {param1, param2, param3, param4, param5, param6 };
            DataTable resultado = EjecutarConsultas("alta_capacitaciones_SP", listaParametros.ToArray(), true);

            return resultado;
        }
        public DataTable ConsultaCapacitaciones()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("ConsCapacitaciones_SP", listaParametros.ToArray());

            return resultado;
        }
        public DataTable FiltrarCapacitaciones(string capacitacion)
        {
            SqlParameter param = new SqlParameter("@textoBusqueda", capacitacion) { SqlDbType = SqlDbType.NVarChar};
            List<SqlParameter> listaParametros = new List<SqlParameter>() {param};
            DataTable resultado = EjecutarConsultas("filtroCapacitaciones_SP", listaParametros.ToArray());

            return resultado;
        }
        public DataTable ModificarCapacitaciones()
        {
            SqlParameter param1 = new SqlParameter("@id_capacitaciones", idCapacitaciones) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_area", idArea) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("capacitacion", capacitacion) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@nivel", idNivel) { SqlDbType = SqlDbType.Int };
            SqlParameter param5 = new SqlParameter("@externa_interna", externaInterna) { SqlDbType = SqlDbType.Int };
            SqlParameter param6 = new SqlParameter("@tiempo_estimado", tiempoEstimado) { SqlDbType = SqlDbType.Int };
            SqlParameter param7 = new SqlParameter("@obligatorio", Obligatorio) { SqlDbType = SqlDbType.Bit };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, param6, param7 };
            DataTable resultado = EjecutarConsultas("upCapacitaciones_SP", listaParametros.ToArray(), true);

            return resultado;
        }
        public DataTable EliminarCapacitaciones()
        {
            SqlParameter param1 = new SqlParameter("@id_capacitacion", idCapacitaciones) { SqlDbType = SqlDbType.Int };
           
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1};
            DataTable resultado = EjecutarConsultas("EliminarCapacitacion_sp", listaParametros.ToArray(), true);

            return resultado;
        }



    }
}
