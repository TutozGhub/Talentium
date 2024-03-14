using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Comun;


namespace AccesoDatos.Administracion_Personal
{
    public class CD_AccesoBDComboBox : CD_EjecutarSP
    {

        public DataTable ListaIdioma()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("ListarIdioma_sp", listaParametros.ToArray());
            return resultado;
        }

        public DataTable ListaProvincias()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("ListarProvincia_sp", listaParametros.ToArray());
            return resultado;
        }

        public DataTable ListaPartido( int id_provincia)
        {
            SqlParameter param1 = new SqlParameter("@id_provincia", id_provincia) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() {param1 };
            DataTable resultado = EjecutarConsultas("ListarPartido_sp", listaParametros.ToArray());
            return resultado;
        }

        public DataTable ListaLocalidad(int id_partido)
        {
            SqlParameter param1 = new SqlParameter("@id_partido", id_partido) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("ListarLocalidad_sp", listaParametros.ToArray());
            return resultado;
        }

        public DataTable ListaGenero()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("ListarGenero_sp", listaParametros.ToArray());
            return resultado;
        }

        public DataTable ListaTipoTel()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("ListarTipoTel_sp", listaParametros.ToArray());
            return resultado;
        }

        public DataTable ListaNivelAcademico()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("ListarNivelAcademico_sp", listaParametros.ToArray());
            return resultado;
        }

        public DataTable ListaEstadoCivil()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("EstadoCivil_sp", listaParametros.ToArray());
            return resultado;
        }

        public DataTable ListaNacionalidad()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("ListarNacionalidad_sp", listaParametros.ToArray());
            return resultado;
        }
             public DataTable ListaProgreso()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas("ListarProgreso_sp", listaParametros.ToArray());
            return resultado;
        }

        public DataTable ListarTipoDoc ()
        {
            List <SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas ("ListarTipoDoc_sp", listaParametros.ToArray());
            return resultado;
        }
          public DataTable ListarConvenio ()
        {
            List <SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas ("ListarConvenio_sp", listaParametros.ToArray());
            return resultado;
        }

     
        public DataTable ListarPuesto ()
        {
            List <SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas ("ListarPuesto_sp", listaParametros.ToArray());
            return resultado;
        }   
        public DataTable ListarArea ()
        {
            List <SqlParameter> listaParametros = new List<SqlParameter>() { };
            DataTable resultado = EjecutarConsultas ("ListarArea_sp", listaParametros.ToArray());
            return resultado;
        }


        public DataTable ObtenerCodigoPostal(int id_localidad)
        {
            
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_localidad", id_localidad));
           var respuesta = EjecutarConsultas("ObtenerCodigoPostal_sp", parametros.ToArray(), true);
            return respuesta;
        }








    }
}
