using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Data;
using System.Data.SqlClient;

namespace LogicaNegocio
{

    public class CN_LogicaAdministracionPersonal
    {
        CD_AccesoBD accesoDatos = new CD_AccesoBD();

        //COMBOBOXS
        public DataTable ObtenerLocalidades()
        {
 
            DataTable localidades = accesoDatos.ListaLocalidad();
            return localidades;
        }   
        
       public DataTable ObtenerProvincia()
        {
           
            DataTable provincia = accesoDatos.ListaProvincias();
            return provincia;
        }

        public DataTable ObtenerPartido()
        {
           
            DataTable partido = accesoDatos.ListaPartido();
            return partido;
        }   
        public DataTable ObtenerGenero()
        {
           
            DataTable genero = accesoDatos.ListaGenero();
            return genero;
        }
        
        public DataTable ObtenerTipoTel()
        {
           
            DataTable tipotel = accesoDatos.ListaTipoTel();
            return tipotel;
        } 
        public DataTable ObtenerNivelAcademico()
        {
           
            DataTable nivelacademico = accesoDatos.ListaNivelAcademico();
            return nivelacademico;
        }
        public DataTable ObtenerEstadoCivil()
        {
           
            DataTable estadocivil = accesoDatos.ListaEstadoCivil();
            return estadocivil;
        }
        public DataTable ObtenerNacionalidad()
        {

            DataTable nacionalidad = accesoDatos.ListaNacionalidad();
            return nacionalidad;
        }



        public void InsertarPersona(
      string apellidos, string nombres, string nro_doc, string cuit_cuil, string calle,
      int nro, string dpto, string piso, int id_localidad, string email, int id_nacionalidad,
      int id_genero,DateTime fecha_nacimiento, int id_estado_civil, int hijos,
      string telefono, string tipo, string telefono_alternativo, string tipo2,
      string contacto, string codigo_postal, string partido, string provincia, string institucion, string carrera, int 
            año_ingreso, int año_egreso, string titulo)
        {
            try
            {
                // Crear un array de parámetros para el procedimiento almacenado
                SqlParameter[] parametros = new SqlParameter[]
                {
                new SqlParameter("@apellidos", apellidos),
                new SqlParameter("@nombres", nombres),
                new SqlParameter("@nro_doc", nro_doc),
                new SqlParameter("@cuit_cuil", cuit_cuil),
                new SqlParameter("@calle", calle),
                new SqlParameter("@nro", nro),
                new SqlParameter("@dpto", dpto),
                new SqlParameter("@piso", piso),
                new SqlParameter("@id_localidad", id_localidad),
                new SqlParameter("@email", email),
                new SqlParameter("@id_nacionalidad", id_nacionalidad),
                new SqlParameter("@id_genero", id_genero),
               new SqlParameter ( "@fecha_nacimiento", fecha_nacimiento),
                new SqlParameter("@id_estado_civil", id_estado_civil),
                new SqlParameter("@hijos", hijos),
                new SqlParameter("@telefono", telefono),
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@telefono_alternativo", telefono_alternativo),
                new SqlParameter("@tipo2", tipo2),
                new SqlParameter("@contacto", contacto),
                new SqlParameter("@codigo_postal", codigo_postal),
                new SqlParameter("@partido", partido),
                new SqlParameter("@provincia", provincia),
                new SqlParameter("institucion", institucion),
                new SqlParameter("carrera", carrera),
                new SqlParameter("año_ingreso" , año_ingreso),
                new SqlParameter("año_egreso", año_egreso),
                new SqlParameter("titulo", titulo),


                };

                // Llamar al método EjecutarConsultas de la capa de datos para ejecutar el procedimiento almacenado
                CD_EjecutarSP capaDatos = new CD_EjecutarSP();
                capaDatos.EjecutarConsultas("InsertarTodo", parametros);

                // Realizar cualquier otra lógica después de la inserción si es necesario
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la inserción
                // Puedes registrar el error, lanzar una excepción personalizada, etc.
                throw new Exception("Error al insertar persona en la base de datos: " + ex.Message);
            }
        }  
      //  public void InsertarInformacionAcademica(
      //int id_nivel, string institucion, string carrera,
      //      DateTime año_ingreso, DateTime año_egreso, /*string año_cursado,*/ string titulo)
      //  {
      //      try
      //      {
      //          // Crear un array de parámetros para el procedimiento almacenado
      //          SqlParameter[] parametros = new SqlParameter[]
      //          {
      //          new SqlParameter("@id_nivel", id_nivel),
      //          new SqlParameter("@institucion", institucion),
      //          new SqlParameter("@carrera", carrera),
      //          new SqlParameter("@año_ingreso", año_ingreso),
      //          new SqlParameter("@año_egreso", año_egreso),
      //         // new SqlParameter("@año_cursado", año_cursado),
      //          new SqlParameter("@titulo", titulo),
       
      //          };

      //          // Llamar al método EjecutarConsultas de la capa de datos para ejecutar el procedimiento almacenado
      //          CD_EjecutarSP capaDatos = new CD_EjecutarSP();
      //          capaDatos.EjecutarConsultas("InsertarTodo", parametros);

      //          // Realizar cualquier otra lógica después de la inserción si es necesario
      //      }
      //      catch (Exception ex)
      //      {
      //          // Manejar cualquier excepción que pueda ocurrir durante la inserción
      //          // Puedes registrar el error, lanzar una excepción personalizada, etc.
      //          throw new Exception("Error al insertar persona en la base de datos: " + ex.Message);
      //      }
      //  }
       


    }



}
