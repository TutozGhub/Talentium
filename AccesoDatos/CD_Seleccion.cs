using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AccesoDatos.Accesibilidad;

namespace AccesoDatos
{
    public class CD_Seleccion : CD_EjecutarSP
    {
        public DataTable ConsultarCandidato(int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoCandidatoRepetido = EjecutarConsultas("consultar_candidato_id_sp", listaParametros.ToArray());

            return resultadoCandidatoRepetido;
        }

        public void IngresarCandidato(string cuil, string nombres, string apellidos, string tel_celular, string tel_alternativo,
            string correo, DateTime fecha_nacimiento, int id_localidad, string calle, int nro, string dpto, string piso,
            int id_puesto)
        {
            SqlParameter param1 = new SqlParameter("@cuil", cuil) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@nombres", nombres) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@apellidos", apellidos) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@tel_celular", tel_celular) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param5 = new SqlParameter("@tel_alternativo", tel_alternativo) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param6 = new SqlParameter("@correo", correo) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param7 = new SqlParameter("@fecha_nacimiento", fecha_nacimiento) { SqlDbType = SqlDbType.Date };
            SqlParameter param8 = new SqlParameter("@id_localidad", id_localidad) { SqlDbType = SqlDbType.Int };
            SqlParameter param9 = new SqlParameter("@calle", calle) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param10 = new SqlParameter("@nro", nro) { SqlDbType = SqlDbType.Int };
            SqlParameter param11 = new SqlParameter("@dpto", dpto) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param12 = new SqlParameter("@piso", piso) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param13 = new SqlParameter("@id_puesto", id_puesto) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5,
                param6, param7, param8, param9, param10, param11, param12, param13 };

            EjecutarConsultas("alta_candidato_sp", listaParametros.ToArray(), true);
        }

        public bool ModificarCandidato(string cuil, string nombres, string apellidos, string tel_celular, string tel_alternativo,
            string correo, DateTime fecha_nacimiento, int id_localidad, string calle, int nro, string dpto, string piso,
            int id_puesto)
        {
            SqlParameter param1 = new SqlParameter("@cuil_original", cuil) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@nombres", nombres) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@apellidos", apellidos) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@tel_celular", tel_celular) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param5 = new SqlParameter("@tel_alternativo", tel_alternativo) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param6 = new SqlParameter("@correo", correo) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param7 = new SqlParameter("@fecha_nacimiento", fecha_nacimiento) { SqlDbType = SqlDbType.Date };
            SqlParameter param8 = new SqlParameter("@id_localidad", id_localidad) { SqlDbType = SqlDbType.Int };
            SqlParameter param9 = new SqlParameter("@calle", calle) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param10 = new SqlParameter("@nro", nro) { SqlDbType = SqlDbType.Int };
            SqlParameter param11 = new SqlParameter("@dpto", dpto) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param12 = new SqlParameter("@piso", piso) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param13 = new SqlParameter("@id_puesto", id_puesto) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5,
                param6, param7, param8, param9, param10, param11, param12, param13 };

            DataTable modifCandidato = EjecutarConsultas("modificar_candidato_sp", listaParametros.ToArray(), true);
            return modifCandidato.Rows.Count != 0;
        }
        public DataTable ConsultarCandidatoFiltros(string cuil)
        {
            SqlParameter param1 = new SqlParameter("@cuit_cuil", cuil) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1};
            DataTable candidatos = EjecutarConsultas("consultar_candidato_filtros_sp", listaParametros.ToArray());

            return candidatos;
        }
        public bool ModificarEstado(int id_candidato, string estado, string patologias)
        {
            SqlParameter param1 = new SqlParameter("@id_candidato", id_candidato) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@nuevoEstado", estado) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            if (!string.IsNullOrEmpty(patologias))
            {
                SqlParameter param3 = new SqlParameter("@patologias", patologias) { SqlDbType = SqlDbType.NVarChar };
                listaParametros.Add(param3);
            }
            DataTable modifEstado = EjecutarConsultas("modificar_estado_entrevista_sp", listaParametros.ToArray());

            return modifEstado.Rows.Count != 0;
        }

        public bool InsertarEtapa(int id_candidato, int id_entrevista, DateTime fecha_etapa, string entrevistador,
            string estado, string patologias)
        {
            SqlParameter param1 = new SqlParameter("@id_candidato", id_candidato) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_entrevista", id_entrevista) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@fecha_etapa", fecha_etapa) { SqlDbType = SqlDbType.DateTime };
            SqlParameter param4 = new SqlParameter("@entrevistador", entrevistador) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param5 = new SqlParameter("@estado", estado) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param6 = new SqlParameter("@patologias", patologias) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, param6 };
            DataTable insertfEtapa = EjecutarConsultas("insertar_etapa_sp", listaParametros.ToArray(), true);

            return insertfEtapa.Rows.Count != 0;
        }
        public DataTable ConsultarDatosEtapas(int id)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable datosEtapas = EjecutarConsultas("obtener_datos_etapas_sp", listaParametros.ToArray());

            return datosEtapas;
        }
        public int ConsultarIDporCuil(string cuil)
        {
            SqlParameter param1 = new SqlParameter("@cuil", cuil) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable idPersona = EjecutarConsultas("obtener_idPersona_cuil_sp", listaParametros.ToArray());

            return Convert.ToInt32(idPersona.Rows[0]["id_persona"]);
        }
    }
}
