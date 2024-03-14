using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Accesibilidad
{
    public class CD_Entrevista : CD_EjecutarSP
    {
        public DataTable InsertarEntrevista(int instancia, string entrevista)
        {
            SqlParameter param1 = new SqlParameter("@instancia", instancia) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@entrevista", entrevista) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultado = EjecutarConsultas("alta_entrevista_sp", listaParametros.ToArray(), true);

            return resultado;
        }
        public DataTable ConsultarEntrevistaRepetida(int instancia, string entrevista)
        {
            SqlParameter param1 = new SqlParameter("@instancia", instancia) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@entrevista", entrevista) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultadoEntrevista = EjecutarConsultas("consultar_entrevista_repetida_sp", listaParametros.ToArray());

            return resultadoEntrevista; //si es !=0 quiere decir que ya hay un registro que coincide
        }
        public DataTable ConsultarEntrevistaRepetidaMod(int instancia, string entrevista, int idEntrevista)
        {
            SqlParameter param1 = new SqlParameter("@instancia", instancia) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@entrevista", entrevista) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@id_entrevista", idEntrevista) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3 };
            DataTable resultadoEntrevista = EjecutarConsultas("consultar_entrevista_repetida_mod_sp", listaParametros.ToArray());

            return resultadoEntrevista; //si es !=0 quiere decir que ya hay un registro que coincide
        }
        public DataTable ConsultarEntrevistas()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("consultar_entrevistas_sp", listaParametros.ToArray());
            return resultado;
        }
        public bool ModificarEntrevista(int idRegistroSeleccionado, int etapa, string nuevaEntrevista)
        {
            SqlParameter param1 = new SqlParameter("@id_entrevista", idRegistroSeleccionado) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@etapa", etapa) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@entrevista", nuevaEntrevista) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3 };
            DataTable resultadoModifEntrevista = EjecutarConsultas("modificar_entrevista_sp", listaParametros.ToArray());
            return resultadoModifEntrevista.Rows.Count != 0;
        }
        public bool EliminarEntrevista(int id_entrevista)
        {
            SqlParameter param1 = new SqlParameter("@id_entrevista", id_entrevista) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoEliminarEntrevista = EjecutarConsultas("eliminar_entrevista_sp", listaParametros.ToArray());
            return resultadoEliminarEntrevista.Rows.Count != 0;
        }
        public bool ConsultarEntrevistaConPersona(int id_entrevista)
        {
            SqlParameter param1 = new SqlParameter("@id_entrevista", id_entrevista) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPersonaEntrevista = EjecutarConsultas("consultar_persona_entrevista_sp", listaParametros.ToArray());
            return resultadoPersonaEntrevista.Rows.Count != 0;
        }
        public int ConsultarCantidadEntrevistas()
        {
            DataTable resultadoEntrevista = EjecutarConsultasSinParam("obtener_cantidad_entrevistas_sp");
            return Convert.ToInt32(resultadoEntrevista.Rows[0]["CantidadRegistros"]);
        }
        public int ObtenerIDEntrevistas(string entrevista)
        {
            SqlParameter param1 = new SqlParameter("@entrevista", entrevista) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable id_entrevista = EjecutarConsultas("obtener_id_entrevista_sp", listaParametros.ToArray());
            return Convert.ToInt32(id_entrevista.Rows[0]["id_entrevista"]);
        }
        public bool ModificarEtapa(int id_persona, int id_entrevista, DateTime fechaEntrevista, string entrevistador, string estado, string patologias)
        {
            SqlParameter param1 = new SqlParameter("@id_entrevista", id_entrevista) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@fecha", fechaEntrevista) { SqlDbType = SqlDbType.Date };
            SqlParameter param4 = new SqlParameter("@entrevistador", entrevistador) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param5 = new SqlParameter("@estado", estado) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5 };
            DataTable resultadoModificar = EjecutarConsultas("modificar_etapa_sp", listaParametros.ToArray());
            return resultadoModificar.Rows.Count != 0;
        }
        public bool VerificarExistenciaEntrevista(int id_persona, int id_entrevista)
        {
            bool entrevistaExiste = false;
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_entrevista", id_entrevista) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@existe", SqlDbType.Bit) { Direction = ParameterDirection.Output };
            List<SqlParameter> listaParametrosVerificar = new List<SqlParameter>() { param1, param2, param3 };
            EjecutarConsultas("verificar_existencia_entrevista_sp", listaParametrosVerificar.ToArray());

            entrevistaExiste = (bool)param3.Value;

            return entrevistaExiste;
        }

    }
}
