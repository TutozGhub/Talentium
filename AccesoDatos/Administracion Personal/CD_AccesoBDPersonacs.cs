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
    public class CD_AccesoBDPersonacs : CD_EjecutarSP
    {
        public DataTable InsertarPersona(Persona insert)
        {
            SqlParameter param1 = new SqlParameter("@apellidos", insert.apellidos) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@nombres", insert.nombres) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@id_tipo_doc", insert.id_tipo_doc) { SqlDbType = SqlDbType.Int };
            SqlParameter param4 = new SqlParameter("@nro_doc", insert.nro_doc) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param5 = new SqlParameter("@cuit_cuil", insert.cuit_cuil) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param6 = new SqlParameter("@calle", insert.calle) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param7 = new SqlParameter("@nro", insert.nro) { SqlDbType = SqlDbType.Int };
            SqlParameter param8 = new SqlParameter("@dpto", insert.dpto) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param9 = new SqlParameter("@piso", insert.piso) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param10 = new SqlParameter("@id_localidad", insert.id_localidad) { SqlDbType = SqlDbType.Int };
            SqlParameter param11 = new SqlParameter("@id_puesto", insert.id_puesto) { SqlDbType = SqlDbType.Int };
            SqlParameter param12 = new SqlParameter("@id_area", insert.id_area) { SqlDbType = SqlDbType.Int };
            SqlParameter param13 = new SqlParameter("@email", insert.email) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param14 = new SqlParameter("@id_nacionalidad", insert.id_nacionalidad) { SqlDbType = SqlDbType.Int };
            SqlParameter param15 = new SqlParameter("@id_genero", insert.id_genero) { SqlDbType = SqlDbType.Int };
            SqlParameter param16 = new SqlParameter("@fecha_nacimiento", insert.fecha_nacimiento) { SqlDbType = SqlDbType.DateTime };
            SqlParameter param17 = new SqlParameter("@id_estado_civil", insert.id_estado_civil) { SqlDbType = SqlDbType.Int };
            SqlParameter param18 = new SqlParameter("@hijos", insert.hijos) { SqlDbType = SqlDbType.Int };
            SqlParameter param19 = new SqlParameter("@id_convenio", insert.id_convenio) { SqlDbType = SqlDbType.Int };
            SqlParameter param20 = new SqlParameter("@foto_perfil", insert.foto_perfil) { SqlDbType = SqlDbType.VarBinary };
            SqlParameter param21 = new SqlParameter("@fecha_alta", insert.fecha_alta) { SqlDbType = SqlDbType.DateTime };
            SqlParameter param22 = new SqlParameter("@es_candidato", insert.es_candidato) { SqlDbType = SqlDbType.Bit };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4,param5,param6,
                param7,param8,param9,param10,param11,param12,param13
                ,param14,param15,param16,param17,param18,param19,param20,param21, param22};
         
            DataTable resultado = EjecutarConsultas("InsertarPersonas_sp", listaParametros.ToArray());
            return resultado;
        }

        public void InsertarInformacionLaboral( int id_persona,string puesto, string empresa, int fecha_ingreso,
            int fecha_egreso, int personal_a_cargo)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@puesto", puesto) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@empresa", empresa) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@fecha_ingreso", fecha_ingreso) { SqlDbType = SqlDbType.Int };
            SqlParameter param5 = new SqlParameter("@fecha_egreso", fecha_egreso) { SqlDbType = SqlDbType.Int };
            SqlParameter param6 = new SqlParameter("@personal_a_cargo", personal_a_cargo) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, param6 };

            DataTable resultado = EjecutarConsultas("InsertarInformacionLaboral_sp", listaParametros.ToArray(), true);
        }



        public void InsertarInformacionAcademica(int id_persona, int? id_nivel, string institucion,
            int año_ingreso, int? año_egreso, string titulo, int? id_progreso)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_nivel", id_nivel) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@institucion", institucion) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@año_ingreso", año_ingreso) { SqlDbType = SqlDbType.Int };
            SqlParameter param5 = new SqlParameter("@año_egreso", año_egreso);
            SqlParameter param6 = new SqlParameter("@titulo", titulo) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param7 = new SqlParameter("@id_progreso", id_progreso) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, param6, param7 };
            DataTable resultado = EjecutarConsultas("InsertarInformacionAcademica_sp", listaParametros.ToArray(), true);

        }

        public void InsertarIdioma(int id_persona, int id_idiomas, int nivel_idioma)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_idioma", id_idiomas) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@nivel_idioma", nivel_idioma) { SqlDbType = SqlDbType.Int };
            
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3};
            EjecutarConsultas("InsertarIdioma_sp", listaParametros.ToArray(), true);

        }




        //Este metodo del SP devuelve un bool (true o false) por lo que va a necesitar del retorno.
        public bool ValidarCuit(string cuit_cuil)
        {
            //En esta linea le envio el parametro cuit_cuil para validarlo en el SP.
            SqlParameter param1 = new SqlParameter("@cuit_cuil", cuit_cuil) { SqlDbType = SqlDbType.NVarChar };
            //Se arma una lista de los parametros para enviarlo luego al SP (en este caso solo hay un parametro)
            List<SqlParameter> listaParametros = new List<SqlParameter>() {param1};
            //En esta linea se ejecuta el sp y los parametros que admite son: nombre de SP,parametro y
            //si va a ser un insert/update (true) o consulta (no se le envia ni true ni false, se elimina el ultimo parametro)
            DataTable resultado = EjecutarConsultas("VerificarCuil_sp", listaParametros.ToArray());

            //Si "resultado" no contiene filas es porque el cuit no existe. De lo contrario si contiene filas el cuit existe
            
            if (resultado.Rows.Count > 0)
            {
                // El CUIT existe en la base de datos
               
                return true ;
            }
            else
            {
                // El CUIT no existe en la base de datos
                return false;
            }
        }



        public void InsertarTelefono (int id_persona,string telefono, int id_tipo, bool tel_primario,string contacto = "")
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@telefono", telefono) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@id_tipo_telefono", id_tipo) { SqlDbType = SqlDbType.Int};
            SqlParameter param4 = new SqlParameter("@tel_primario", tel_primario) { SqlDbType = SqlDbType.Bit };
            SqlParameter param5 = new SqlParameter("@contacto", contacto) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3,param4,param5 };

            DataTable resultado = EjecutarConsultas("InsertarTelefono_sp", listaParametros.ToArray(), true);
        }







        //consultas

        public DataTable ObtenerPersona()
        {
            DataTable resultado = EjecutarConsultasSinParam("ObtenerPersona_sp");

            return resultado;
        }

        public DataTable ObtenerTodosCand(string cuil)
        {
            SqlParameter param1 = new SqlParameter("@cuil", cuil) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("consultar_todos_candidatos_sp", listaParametros.ToArray());

            return resultado;
        }
        public DataTable ObtenerPersona(int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1};
            DataTable resultado = EjecutarConsultas("ObtenerPersonaDetalle",listaParametros.ToArray());

            return resultado;
        }

        public DataTable ObtenerDatosAcademicos(int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("ObtenerInformacionAcademica_sp", listaParametros.ToArray());

            return resultado;
        }

        public DataTable ObtenerDatosLaborales(int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("ObtenerInfomacionLabora_sp", listaParametros.ToArray());

            return resultado;
        }

        public DataTable ObtenerTelefono(int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("ObtenerTelefonos_sp", listaParametros.ToArray());

            return resultado;
        }

        public DataTable ObtenerIdioma(int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("ObtenerIdioma_sp", listaParametros.ToArray());

            return resultado;
        }

        public DataTable ObtenerDescripcionIdioma (int id_idioma)
        {
            SqlParameter param1 = new SqlParameter("@id_idioma", id_idioma) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("ObtenerDescripcionIdioma_sp", listaParametros.ToArray());

            return resultado;
        }

        public DataTable ObtenerDescripcionProgresoNivel (int id_nivel, int id_progreso)
        {
            SqlParameter param1 = new SqlParameter("@id_nivel", id_nivel) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_progreso", id_progreso) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultado = EjecutarConsultas("ObtenerDescripcionProgresoNivel_sp", listaParametros.ToArray());

            return resultado;

        }

        //Modificar
        public DataTable ActualizarDatos (Persona modify )
        {
            SqlParameter param1 = new SqlParameter("@id_persona", modify.id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@apellidos", modify.apellidos) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@nombres", modify.nombres) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@id_tipo_doc", modify.id_tipo_doc) { SqlDbType = SqlDbType.Int };
            SqlParameter param5 = new SqlParameter("@nro_doc", modify.nro_doc) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param6 = new SqlParameter("@calle", modify.calle) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param7 = new SqlParameter("@nro", modify.nro) { SqlDbType = SqlDbType.Int };
            SqlParameter param8 = new SqlParameter("@dpto", modify.dpto) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param9 = new SqlParameter("@piso", modify.piso) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param10 = new SqlParameter("@id_localidad", modify.id_localidad) { SqlDbType = SqlDbType.Int };
            SqlParameter param11 = new SqlParameter("@id_puesto", modify.id_puesto) { SqlDbType = SqlDbType.Int };
            SqlParameter param12 = new SqlParameter("@id_area", modify.id_area) { SqlDbType = SqlDbType.Int };
            SqlParameter param13 = new SqlParameter("@email", modify.email) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param14 = new SqlParameter("@id_nacionalidad", modify.id_nacionalidad) { SqlDbType = SqlDbType.Int };
            SqlParameter param15 = new SqlParameter("@id_genero", modify.id_genero) { SqlDbType = SqlDbType.Int };
            SqlParameter param16 = new SqlParameter("@fecha_nacimiento", modify.fecha_nacimiento) { SqlDbType = SqlDbType.DateTime };
            SqlParameter param17 = new SqlParameter("@id_estado_civil", modify.id_estado_civil) { SqlDbType = SqlDbType.Int };
            SqlParameter param18 = new SqlParameter("@hijos", modify.hijos) { SqlDbType = SqlDbType.Int };
            SqlParameter param19 = new SqlParameter("@id_convenio", modify.id_convenio) { SqlDbType = SqlDbType.Int };
            SqlParameter param20 = new SqlParameter("@foto_perfil", modify.foto_perfil) { SqlDbType = SqlDbType.VarBinary };
            SqlParameter param21 = new SqlParameter("@fecha_alta", modify.fecha_alta) { SqlDbType = SqlDbType.DateTime };
            SqlParameter param22 = new SqlParameter("@es_candidato", modify.es_candidato) { SqlDbType = SqlDbType.Bit};
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4,param5,param6,
                param7,param8,param9,param10,param11,param12,param13
                ,param14,param15,param16,param17,param18,param19,param20,param21, param22};

            DataTable resultado = EjecutarConsultas("ActualizarDatos_sp", listaParametros.ToArray());
            return resultado;
        }



        public void ActualizarDatosAcademicos(int id_informacion_academica, int? id_nivel, string institucion,
            int año_ingreso, int año_egreso, string titulo, int? id_progreso)
        {

            SqlParameter param1 = new SqlParameter("@id_informacion_academica", id_informacion_academica) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_nivel", id_nivel) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@institucion", institucion) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@año_ingreso", año_ingreso) { SqlDbType = SqlDbType.Int };
            SqlParameter param5 = new SqlParameter("@año_egreso", año_egreso) { SqlDbType = SqlDbType.Int };
            SqlParameter param6 = new SqlParameter("@titulo", titulo) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param7 = new SqlParameter("@id_progreso", id_progreso) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, param6, param7};
            DataTable resultado = EjecutarConsultas("ActualizarDatosAcademicos_sp", listaParametros.ToArray(), true);


        }

        public void ActualizarDatosLaborales (int id_persona, string puesto, string empresa, int fecha_ingreso,
            int fecha_egreso, int personal_a_cargo)
        {
            SqlParameter param1 = new SqlParameter("@id_informacion_laboral", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@puesto", puesto) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@empresa", empresa) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param4 = new SqlParameter("@fecha_ingreso", fecha_ingreso) { SqlDbType = SqlDbType.Int };
            SqlParameter param5 = new SqlParameter("@fecha_egreso", fecha_egreso) { SqlDbType = SqlDbType.Int };
            SqlParameter param6 = new SqlParameter("@personal_a_cargo", personal_a_cargo) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, param6 };

            DataTable resultado = EjecutarConsultas("ActualizarDatosLaboral_sp", listaParametros.ToArray(), true);
        }


        public void ActualizarTelefono(int id_persona, string telefono, int id_tipo, bool tel_primario, string contacto = "")
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@telefono", telefono) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@id_tipo_telefono", id_tipo) { SqlDbType = SqlDbType.Int };
            SqlParameter param4 = new SqlParameter("@tel_primario", tel_primario) { SqlDbType = SqlDbType.Bit };
            SqlParameter param5 = new SqlParameter("@contacto", contacto) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5 };

            DataTable resultado = EjecutarConsultas("ActualizarTelefono_sp", listaParametros.ToArray(), true);
        }

        public void ActualizarIdioma(int id_persona, int id_idiomas, int nivel_idioma)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@id_idiomas", id_idiomas) { SqlDbType = SqlDbType.Int };
            SqlParameter param3 = new SqlParameter("@nivel_idioma", nivel_idioma) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3 };
            EjecutarConsultas("ActualizarIdioma_sp", listaParametros.ToArray(), true);

        }

        public void BorrarIdioma (int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            EjecutarConsultas("BorrarIdioma_sp", listaParametros.ToArray(), true);

        }


        public void BorrarInfoAcademica(int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            EjecutarConsultas("BorrarInfoAcademico_sp", listaParametros.ToArray(), true);

        }

        public void BorrarInfoLaboral(int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            EjecutarConsultas("BorrarInfoLaboral_sp", listaParametros.ToArray(), true);

        }

        //eliminacion

        public DataTable BajaPersona(int id_persona)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_persona", id_persona));
            DataTable dt = EjecutarConsultas("BajaPersona_sp", parametros.ToArray());
            return dt;
        }


        public DataTable ReactivarPersona(int id_persona)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_persona", id_persona));
            DataTable dt = EjecutarConsultas("ReactivarPersona_sp", parametros.ToArray());
            return dt;
        }
    }
}
