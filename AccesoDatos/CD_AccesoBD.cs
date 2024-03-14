using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Comun;
using System.Linq.Expressions;

namespace AccesoDatos
{
    public class CD_AccesoBD : CD_EjecutarSP
    {
        public void CargarCodyFHRecupero( int id, string cod, DateTime fechaCaducidad )
        {
            SqlParameter param1 = new SqlParameter("@id_usuario", id) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@fh_cod_email", fechaCaducidad) { SqlDbType = SqlDbType.DateTime };
            SqlParameter param3 = new SqlParameter("@cod_email", cod) { SqlDbType = SqlDbType.NChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3 };
            
                DataTable resultado = EjecutarConsultas("upCodFechaRecupero_sp", listaParametros.ToArray(), true);
        
        }

        public void upPolPass(bool min_carct, bool comb_may, bool num_letras, bool caract_esp, bool contra_ant, bool datos_per)
        {
            SqlParameter param1 = new SqlParameter("@min_caracteres", min_carct) { SqlDbType = SqlDbType.Bit };
            SqlParameter param2 = new SqlParameter("@comb_mayus", comb_may) { SqlDbType = SqlDbType.Bit };
            SqlParameter param3 = new SqlParameter("@num_letras", num_letras) { SqlDbType = SqlDbType.Bit };
            SqlParameter param4 = new SqlParameter("@caract_especial", caract_esp) { SqlDbType = SqlDbType.Bit };
            SqlParameter param5 = new SqlParameter("@contra_anteriores", contra_ant) { SqlDbType = SqlDbType.Bit };
            SqlParameter param6 = new SqlParameter("@datos_personales", datos_per) { SqlDbType = SqlDbType.Bit };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, param6 };

            DataTable resultado = EjecutarConsultas("upPoliticaPass_sp", listaParametros.ToArray(), true);

        }
        public void ConsultaPoliticaPass()
        {
           
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("consPoliticaPass_sp", listaParametros.ToArray());

            ConfigCache.caracteres = (bool)resultado.Rows[0][1];
            ConfigCache.mayusculas = (bool)resultado.Rows[0][2];
            ConfigCache.numeros = (bool)resultado.Rows[0][3];
            ConfigCache.especiales = (bool)resultado.Rows[0][4];
            ConfigCache.passAnteriores = (bool)resultado.Rows[0][5];
            ConfigCache.noDatosPersonales = (bool)resultado.Rows[0][6];
        }


        //METODOS CATEGORIA


        //METODOS CONVENIOS




        //public void EliminarCategorias(int id_categoria)
        //{

        //    List<SqlParameter> parametros = new List<SqlParameter>();
        //    parametros.Add(new SqlParameter("@id_categoria", id_categoria));
        //    EjecutarConsultas("EliminarCategoria", parametros.ToArray(), true);
        //}


        //public void ModificarCategoria(CategoriaDto categoria, int id)
        //{

        //    List<SqlParameter> parametros = new List<SqlParameter>();
        //    parametros.Add(new SqlParameter("@id_categoria", id));
        //    parametros.Add(new SqlParameter("@nombre_categoria", categoria.categoria));
        //    parametros.Add(new SqlParameter("@jornada", categoria.jornada));
        //    parametros.Add(new SqlParameter("@sueldos", categoria.sueldo));


        //    EjecutarConsultas("ModificarCategoria", parametros.ToArray(), true);
        //}



        public DataTable ConsultaAreas()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("consultar_areas_sp", listaParametros.ToArray());
            return resultado;
        }
        public DataTable ConsultarPerfiles()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>() { };

            DataTable resultado = EjecutarConsultas("consultar_perfiles_sp", listaParametros.ToArray());
            return resultado;
        }
        public DataTable ConsultarTodasPregSeg()
        {
            DataTable resultado = EjecutarConsultasSinParam("consultarPreguntas_sp");

            return resultado;
        }
        public DataTable ConsultaRtaSeg(int usuario)
        {
            SqlParameter param1 = new SqlParameter("@id_usuario", usuario) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("consultarRespuestas_sp", listaParametros.ToArray());

            return resultado;
        }
        public DataTable Consulta1PgtaSeg(int pgtas)
        {
            SqlParameter param1 = new SqlParameter("@id_pregunta", pgtas) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultado = EjecutarConsultas("consultarPreg_sp", listaParametros.ToArray());

            return resultado;
        }

        public void InsertarNuevaPass( string user, string pass, string dig, bool nueva)
        {
            SqlParameter param1 = new SqlParameter("@usuario", user) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param2 = new SqlParameter("@password", pass) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param3 = new SqlParameter("@digitoVerf", dig) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param4 = new SqlParameter("@nuevo", nueva) { SqlDbType = SqlDbType.Bit };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4 };

            DataTable resultado = EjecutarConsultas("upPassword_sp", listaParametros.ToArray(), true);

        }
        public void InsertarRespuestaSeg( int idUs, string rta, int idPregunta)
        {
            SqlParameter param1 = new SqlParameter("@id_usuario", idUs) { SqlDbType = SqlDbType.Int };
            SqlParameter param2 = new SqlParameter("@respuesta", rta) { SqlDbType = SqlDbType.VarChar };
            SqlParameter param3 = new SqlParameter("@id_pregunta", idPregunta) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3 };

            DataTable resultado = EjecutarConsultas("InsRespuesta_sp", listaParametros.ToArray(), true);

        }
        public string ConsultarMailPersona(int id_persona) //Este metodo no tiene referencias hay que ver que onda
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };

            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };

            DataTable email = EjecutarConsultas("consultar_mail_persona_sp", listaParametros.ToArray());
            return email.Rows[0][0].ToString();
        }

        /******************** FORM ALTA EVALUACION DE DESEMPEÑO ********************/
        public DataTable ConsultarPersonaConArea(int idArea)
        {
            SqlParameter param1 = new SqlParameter("@id_area", idArea) { SqlDbType = SqlDbType.NVarChar };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoPersonaArea = EjecutarConsultas("consultar_persona_area_sp", listaParametros.ToArray());
            return resultadoPersonaArea;
        }

        public void InsertarEvaluacionDesempenio(string anio, string mes, int efectTareas, int puntualidad, int relSup, 
            int disciplina, int desempEquipo, int id_persona, int id_area)
        {
            SqlParameter param1 = new SqlParameter("@anio", anio) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@mes", mes) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@efectTareas", efectTareas) { SqlDbType = SqlDbType.Int };
            SqlParameter param4 = new SqlParameter("@puntualidad", puntualidad) { SqlDbType = SqlDbType.Int };
            SqlParameter param5 = new SqlParameter("@relSup", relSup) { SqlDbType = SqlDbType.Int };
            SqlParameter param6 = new SqlParameter("@disciplina", disciplina) { SqlDbType = SqlDbType.Int };
            SqlParameter param7 = new SqlParameter("@desempEquipo", desempEquipo) { SqlDbType = SqlDbType.Int };
            SqlParameter param8 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            SqlParameter param9 = new SqlParameter("@id_area", id_area) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3, param4, param5, 
                param6, param7, param8, param9 };

            EjecutarConsultas("insertar_evaluacion_desempenio_sp", listaParametros.ToArray(), true);
        }
        public bool ConsultarEvaluacionRepetida(string anio, string mes, int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@anio", anio) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@mes", mes) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param3 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2, param3 };
            DataTable resultadoEvaluacionRepetida = EjecutarConsultas("consultar_evaluacion_repetida_sp", listaParametros.ToArray());

            return resultadoEvaluacionRepetida.Rows.Count != 0;
        }

        public DataTable ConsultarEvaluacion(string anio, int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@anio", anio) { SqlDbType = SqlDbType.NVarChar };
            SqlParameter param2 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1, param2 };
            DataTable resultadoEvaluacion = EjecutarConsultas("consultar_evaluacion_sp", listaParametros.ToArray());

            return resultadoEvaluacion;
        }

        public DataTable ConsultarEvaluacionSoloPersona(int id_persona)
        {
            SqlParameter param1 = new SqlParameter("@id_persona", id_persona) { SqlDbType = SqlDbType.Int };
            List<SqlParameter> listaParametros = new List<SqlParameter>() { param1 };
            DataTable resultadoEvaluacionPersona = EjecutarConsultas("consultar_evaluacion_persona_sp", listaParametros.ToArray());

            return resultadoEvaluacionPersona;
        }
    }
}

