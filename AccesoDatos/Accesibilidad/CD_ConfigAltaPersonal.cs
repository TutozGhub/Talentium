using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Accesibilidad
{
    public class CD_ConfigAltaPersonal : CD_EjecutarSP
    {
        // Tipo de documento
        public DataTable InsertarTipoDoc (string tipoDoc)
        {
            SqlParameter param1 = new SqlParameter("@tipo_doc", tipoDoc) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("insertar_tipoDoc_sp", listaParametros.ToArray(), true);

            return resultado;
        }
        public bool ConsultarTipoDocRepetido(string tipoDocRepetido)
        {
            SqlParameter param1 = new SqlParameter("@tipoDocRepetido", tipoDocRepetido) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoTipoDoc = EjecutarConsultas("consultar_tipoDoc_repetido_sp", listaParametros.ToArray());

            return resultadoTipoDoc.Rows.Count != 0;
        }
        public DataTable ObtenerTipoDoc()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("obtener_tipoDoc_sp", listaParametros.ToArray());
            return resultado;
        }
        public bool ModificarTipoDoc(int id_tipo_doc, string tipo_doc)
        {
            SqlParameter param1 = new SqlParameter("@id_tipo_doc", id_tipo_doc) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@tipo_doc", tipo_doc) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultadoModifTipoDoc = EjecutarConsultas("modificar_tipoDoc_sp", listaParametros.ToArray());
            return resultadoModifTipoDoc.Rows.Count != 0;
        }
        public bool EliminarTipoDoc(int id_tipo_doc)
        {
            SqlParameter param1 = new SqlParameter("@id_tipo_doc", id_tipo_doc) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoEliminarTipoDoc = EjecutarConsultas("eliminar_tipoDoc_sp", listaParametros.ToArray());
            return resultadoEliminarTipoDoc.Rows.Count != 0;
        }
        public bool ConsultarTipoDocConPersona(int id_tipo_doc)
        {
            SqlParameter param1 = new SqlParameter("@id_tipo_doc", id_tipo_doc) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPersonaTipoDoc = EjecutarConsultas("consultar_persona_tipoDoc_sp", listaParametros.ToArray());
            return resultadoPersonaTipoDoc.Rows.Count != 0;
        }

        // Tipo de teléfono
        public DataTable ObtenerTipoTel()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("obtener_tipoTel_sp", listaParametros.ToArray());
            return resultado;
        }
        public bool ConsultarTipoTelRepetido(string tipoTelRepetido)
        {
            SqlParameter param1 = new SqlParameter("@tipoTelRepetido", tipoTelRepetido) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoTipoTel = EjecutarConsultas("consultar_tipoTel_repetido_sp", listaParametros.ToArray());

            return resultadoTipoTel.Rows.Count != 0;
        }
        public DataTable InsertarTipoTel(string tipoTel)
        {
            SqlParameter param1 = new SqlParameter("@tipo", tipoTel) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("insertar_tipoTel_sp", listaParametros.ToArray(), true);

            return resultado;
        }
        public bool ModificarTipoTel(int id_tipo, string tipo)
        {
            SqlParameter param1 = new SqlParameter("@id_tipo", id_tipo) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@tipo", tipo) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultadoModifTipoTel = EjecutarConsultas("modificar_tipoTel_sp", listaParametros.ToArray());
            return resultadoModifTipoTel.Rows.Count != 0;
        }
        public bool EliminarTipoTel(int id_tipo)
        {
            SqlParameter param1 = new SqlParameter("@id_tipo", id_tipo) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoEliminarTipoTel = EjecutarConsultas("eliminar_tipoTel_sp", listaParametros.ToArray());
            return resultadoEliminarTipoTel.Rows.Count != 0;
        }
        public bool ConsultarTipoTelConPersona(int id_tipo)
        {
            SqlParameter param1 = new SqlParameter("@id_tipo", id_tipo) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPersonaTipoTel = EjecutarConsultas("consultar_persona_tipoTel_sp", listaParametros.ToArray());
            return resultadoPersonaTipoTel.Rows.Count != 0;
        }
        // Nacionalidad
        public DataTable ObtenerNacionalidad()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("obtener_nacionalidad_sp", listaParametros.ToArray());
            return resultado;
        }
        public bool ConsultarNacionalidadRepetida(string nacionalidadRepetida)
        {
            SqlParameter param1 = new SqlParameter("@nacionalidadRepetida", nacionalidadRepetida) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoNacionalidad = EjecutarConsultas("consultar_nacionalidad_repetida_sp", listaParametros.ToArray());

            return resultadoNacionalidad.Rows.Count != 0;
        }
        public DataTable InsertarNacionalidad(string nacionalidad)
        {
            SqlParameter param1 = new SqlParameter("@nacionalidad", nacionalidad) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("insertar_nacionalidad_sp", listaParametros.ToArray(), true);

            return resultado;
        }
        public bool ModificarNacionalidad(int id_nacionalidad, string nacionalidad)
        {
            SqlParameter param1 = new SqlParameter("@id_nacionalidad", id_nacionalidad) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@nacionalidad", nacionalidad) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultadoModifNacionalidad = EjecutarConsultas("modificar_nacionalidad_sp", listaParametros.ToArray());
            return resultadoModifNacionalidad.Rows.Count != 0;
        }
        public bool EliminarNacionalidad(int id_nacionalidad)
        {
            SqlParameter param1 = new SqlParameter("@id_nacionalidad", id_nacionalidad) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoEliminarNacionalidad = EjecutarConsultas("eliminar_nacionalidad_sp", listaParametros.ToArray());
            return resultadoEliminarNacionalidad.Rows.Count != 0;
        }
        public bool ConsultarNacionalidadConPersona(int id_nacionalidad)
        {
            SqlParameter param1 = new SqlParameter("@id_nacionalidad", id_nacionalidad) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPersonaNacionalidad = EjecutarConsultas("consultar_persona_nacionalidad_sp", listaParametros.ToArray());
            return resultadoPersonaNacionalidad.Rows.Count != 0;
        }
        // Género
        public DataTable ObtenerGenero()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("obtener_genero_sp", listaParametros.ToArray());
            return resultado;
        }
        public bool ConsultarGeneroRepetido(string generoRepetido)
        {
            SqlParameter param1 = new SqlParameter("@generoRepetido", generoRepetido) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoGenero = EjecutarConsultas("consultar_genero_repetido_sp", listaParametros.ToArray());

            return resultadoGenero.Rows.Count != 0;
        }
        public DataTable InsertarGenero(string genero)
        {
            SqlParameter param1 = new SqlParameter("@genero", genero) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("insertar_genero_sp", listaParametros.ToArray(), true);

            return resultado;
        }
        public bool ModificarGenero(int id_genero, string genero)
        {
            SqlParameter param1 = new SqlParameter("@id_genero", id_genero) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@genero", genero) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultadoModifGenero = EjecutarConsultas("modificar_genero_sp", listaParametros.ToArray());
            return resultadoModifGenero.Rows.Count != 0;
        }
        public bool EliminarGenero(int id_genero)
        {
            SqlParameter param1 = new SqlParameter("@id_genero", id_genero) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoEliminarGenero = EjecutarConsultas("eliminar_genero_sp", listaParametros.ToArray());
            return resultadoEliminarGenero.Rows.Count != 0;
        }
        public bool ConsultarGeneroConPersona(int id_genero)
        {
            SqlParameter param1 = new SqlParameter("@id_genero", id_genero) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPersonaGenero = EjecutarConsultas("consultar_persona_genero_sp", listaParametros.ToArray());
            return resultadoPersonaGenero.Rows.Count != 0;
        }
        // Idiomas
        public DataTable ObtenerIdioma()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("obtener_idioma_sp", listaParametros.ToArray());
            return resultado;
        }
        public bool ConsultarIdiomaRepetido(string idiomaRepetido)
        {
            SqlParameter param1 = new SqlParameter("@idiomaRepetido", idiomaRepetido) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoIdioma = EjecutarConsultas("consultar_idioma_repetido_sp", listaParametros.ToArray());

            return resultadoIdioma.Rows.Count != 0;
        }
        public DataTable InsertarIdioma(string idioma)
        {
            SqlParameter param1 = new SqlParameter("@idioma", idioma) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("insertar_idioma_sp", listaParametros.ToArray(), true);

            return resultado;
        }
        public bool ModificarIdioma(int id_idioma, string idioma)
        {
            SqlParameter param1 = new SqlParameter("@id_idioma", id_idioma) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@idioma", idioma) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultadoModifIdioma = EjecutarConsultas("modificar_idioma_sp", listaParametros.ToArray());
            return resultadoModifIdioma.Rows.Count != 0;
        }
        public bool EliminarIdioma(int id_idioma)
        {
            SqlParameter param1 = new SqlParameter("@id_idioma", id_idioma) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoEliminarIdioma = EjecutarConsultas("eliminar_idioma_sp", listaParametros.ToArray());
            return resultadoEliminarIdioma.Rows.Count != 0;
        }
        public bool ConsultarIdiomaConPersona(int id_idioma)
        {
            SqlParameter param1 = new SqlParameter("@id_idioma", id_idioma) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPersonaIdioma = EjecutarConsultas("consultar_persona_idioma_sp", listaParametros.ToArray());
            return resultadoPersonaIdioma.Rows.Count != 0;
        }
        // Área
        public DataTable ObtenerArea()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("consultar_areas_sp", listaParametros.ToArray());
            return resultado;
        }
        public bool ConsultarAreaRepetido(string areaRepetido)
        {
            SqlParameter param1 = new SqlParameter("@area", areaRepetido) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoArea = EjecutarConsultas("consultar_area_repetida_sp", listaParametros.ToArray());

            return resultadoArea.Rows.Count != 0;
        }
        public DataTable InsertarArea(string area)
        {
            SqlParameter param1 = new SqlParameter("@area", area) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("alta_area_sp", listaParametros.ToArray(), true);

            return resultado;
        }
        public bool ModificarArea(int id_area, string area)
        {
            SqlParameter param1 = new SqlParameter("@id_area", id_area) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@area", area) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultadoModifArea = EjecutarConsultas("modificar_area_sp", listaParametros.ToArray());
            return resultadoModifArea.Rows.Count != 0;
        }
        public bool EliminarArea(int id_area)
        {
            SqlParameter param1 = new SqlParameter("@id_area", id_area) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoEliminarArea = EjecutarConsultas("eliminar_area_sp", listaParametros.ToArray());
            return resultadoEliminarArea.Rows.Count != 0;
        }
        public bool ConsultarAreaConPersona(int id_area)
        {
            SqlParameter param1 = new SqlParameter("@id_area", id_area) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPersonaArea = EjecutarConsultas("consultar_persona_area_sp", listaParametros.ToArray());
            return resultadoPersonaArea.Rows.Count != 0;
        }
        // Puesto
        public DataTable ObtenerPuesto()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("consultar_puestos_sp", listaParametros.ToArray());
            return resultado;
        }
        public bool ConsultarPuestoRepetido(string puestoRepetido)
        {
            SqlParameter param1 = new SqlParameter("@puesto", puestoRepetido) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPuesto = EjecutarConsultas("consultar_puesto_repetido_sp", listaParametros.ToArray());

            return resultadoPuesto.Rows.Count != 0;
        }
        public DataTable InsertarPuesto(string puesto)
        {
            SqlParameter param1 = new SqlParameter("@puesto", puesto) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("alta_puesto_sp", listaParametros.ToArray(), true);

            return resultado;
        }
        public bool ModificarPuesto(int id_puesto, string puesto)
        {
            SqlParameter param1 = new SqlParameter("@id_puesto", id_puesto) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@puesto", puesto) { SqlDbType = SqlDbType.NVarChar };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultadoModifPuesto = EjecutarConsultas("modificar_puesto_sp", listaParametros.ToArray());
            return resultadoModifPuesto.Rows.Count != 0;
        }
        public bool EliminarPuesto(int id_puesto)
        {
            SqlParameter param1 = new SqlParameter("@id_puesto", id_puesto) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoEliminarPuesto = EjecutarConsultas("eliminar_puesto_sp", listaParametros.ToArray());
            return resultadoEliminarPuesto.Rows.Count != 0;
        }
        public bool ConsultarPuestoConPersona(int id_puesto)
        {
            SqlParameter param1 = new SqlParameter("@id_puesto", id_puesto) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPersonaPuesto = EjecutarConsultas("consultar_persona_puesto_sp", listaParametros.ToArray());
            return resultadoPersonaPuesto.Rows.Count != 0;
        }
    }
}
