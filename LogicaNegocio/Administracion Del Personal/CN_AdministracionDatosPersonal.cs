using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Data;
using System.Data.SqlClient;
using Comun;
using AccesoDatos.Administracion_Personal;
using LogicaNegocio.Lenguajes;
using System.Windows.Forms;

namespace LogicaNegocio.Administracion_Del_Personal
{
    public class CN_AdministracionDatosPersonal
    {
        private CD_AccesoBDPersonacs AccesoDatos = new CD_AccesoBDPersonacs();

        public void InsertarTelefono (Persona insert,int id_persona)
        {
            
            AccesoDatos.InsertarTelefono(id_persona,insert.telefono,insert.id_tipo,true);
            AccesoDatos.InsertarTelefono(id_persona, insert.telefono_alternativo, insert.id_tipo_alternativo, false ,insert.contacto);
        }

        public void InsertIdioma(Persona insert, int id_persona)
        {
            //AccesoDatos.InsertarIdioma(id_persona, 2, insert.nivel_Es);
            //AccesoDatos.InsertarIdioma(id_persona, 1,insert.nivel_En );
        }

        public int InsertarPersona(Persona insert /*int infoLaborales, int infoAcademicos*/)
        {
            try
            {
                DataTable dt = AccesoDatos.InsertarPersona(insert);
                int id_persona = Convert.ToInt32(dt.Rows[0][0]);
                asignarCapacitacionesObligatorias(id_persona, insert.id_area);
                InsertarTelefono(insert, id_persona);

                return id_persona;
    
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error al insertar persona en la base de datos: " + ex.Message);
            }

        }

        public void InsertarInformacionLaboral (Persona insert,int id_persona,int cantidad)
        {
          
        }
        public void InsertarInformacionAcademica (Persona insert, int id_persona, int cantidad)
        {
        }

        //se crea instancia y se almacena en "AccesoDatos"
        public bool ValidarCuit(string cuit_cuil)
        {
            if (cuit_cuil.Length != 11)
            {
                MessageBox.Show(Errores.CampoMinimo11, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Seguridad.VerificarCuiCuil(cuit_cuil))
            {
                MessageBox.Show(Errores.CuilIncorrecto, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (AccesoDatos.ValidarCuit(cuit_cuil))
            {
                MessageBox.Show(Errores.CuitEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //CONSULTAS

        public DataTable ObtenerPersona()
        {

            return AccesoDatos.ObtenerPersona();
        }

        public DataTable ObtenerTodosCand(string cuil)
        {
            cuil.Trim();
            if (string.IsNullOrEmpty(cuil)) {
                cuil = null;
            }
            return AccesoDatos.ObtenerTodosCand(cuil);
        } 
        public DataTable ObtenerIdioma(int id_persona)
        {
            return AccesoDatos.ObtenerIdioma(id_persona);
        }
        public string ObtenerDescripcionIdioma(int id_idioma)
        {
            string idioma = null;
            DataTable idiomaResult = AccesoDatos.ObtenerDescripcionIdioma(id_idioma);
            return idioma = idiomaResult.Rows[0]["idioma"].ToString();
                
        }
        public  NivelProgresoMostrar ObtenerDescripcionProgresoNivel(int id_nivel, int id_progreso)
        {
           
            NivelProgresoMostrar nivelProgresoMostrar = new NivelProgresoMostrar();
            DataTable progresoResult = AccesoDatos.ObtenerDescripcionProgresoNivel(id_nivel,id_progreso);
            nivelProgresoMostrar.Nivel = progresoResult.Rows[0]["descripcion_nivel"].ToString();
            nivelProgresoMostrar.Progreso = progresoResult.Rows[0]["estado_progreso"].ToString();
            return nivelProgresoMostrar;
        }


        public void ObtenerPersona(Persona insert, int id_persona, ref int _infoAcademicos, ref int _infoLaborales)
        {
           
            DataTable persona = AccesoDatos.ObtenerPersona(id_persona);
            DataTable academicos = AccesoDatos.ObtenerDatosAcademicos(id_persona);
            DataTable laborales  =AccesoDatos.ObtenerDatosLaborales(id_persona);
            DataTable telefono = AccesoDatos.ObtenerTelefono(id_persona);
            DataTable idioma = AccesoDatos.ObtenerIdioma(id_persona);
            

            int infoAcademicos = academicos.Rows.Count;
            int infoLaborales = laborales.Rows.Count;
            _infoAcademicos = infoAcademicos;
            _infoLaborales = infoLaborales;

            #region Mapeo
            
            insert.apellidos = persona.Rows[0]["apellidos"].ToString();
            insert.nombres = persona.Rows[0]["nombres"].ToString();
            insert.id_tipo_doc = (int)persona.Rows[0]["id_tipo_doc"];
            insert.nro_doc = persona.Rows[0]["nro_doc"].ToString();
            insert.cuit_cuil = persona.Rows[0]["cuit_cuil"].ToString();
            insert.calle = persona.Rows[0]["calle"].ToString();
            insert.nro = (int)persona.Rows[0]["nro"];
            insert.dpto = persona.Rows[0]["dpto"].ToString();
            insert.piso = persona.Rows[0]["piso"].ToString();
            insert.id_provincia = (int)persona.Rows[0]["id_provincia"];
            insert.id_partido = (int)persona.Rows[0]["id_partido"];
            insert.id_localidad = (int)persona.Rows[0]["id_localidad"];
            insert.id_puesto = (int)persona.Rows[0]["id_puesto"];
            insert.id_area = (int)persona.Rows[0]["id_area"];
            insert.email = persona.Rows[0]["email"].ToString();
            insert.id_nacionalidad = (int)persona.Rows[0]["id_nacionalidad"];
            insert.id_genero = (int)persona.Rows[0]["id_genero"];
            insert.fecha_nacimiento = Convert.ToDateTime(persona.Rows[0]["fecha_nacimiento"]);
            insert.id_estado_civil = (int)persona.Rows[0]["id_estado_civil"];
            insert.hijos = (int)persona.Rows[0]["hijos"];
            insert.id_convenio = (int)persona.Rows[0]["id_convenio"];
            insert.fecha_alta = Convert.ToDateTime(persona.Rows[0]["fecha_alta"]);


            insert.foto_perfil = (byte[])persona.Rows[0]["foto_perfil"];

            //Telefono
            insert.telefono = telefono.Rows[0]["telefono"].ToString();
            insert.id_tipo = (int)telefono.Rows[0]["id_tipo_telefono"];
            insert.telefono_alternativo = telefono.Rows[1]["telefono"].ToString();
            insert.id_tipo_alternativo = (int)telefono.Rows[1]["id_tipo_telefono"];
            insert.contacto = telefono.Rows[1]["contacto"].ToString();


            #endregion
        }
        public DataTable ObtenerInfoAcademico( int id_persona)
        {

     
            DataTable academicos = AccesoDatos.ObtenerDatosAcademicos(id_persona);
            return academicos;

        }

        public DataTable ObtenerInfoLaboral (int id_persona)

        {
            DataTable laborales = AccesoDatos.ObtenerDatosLaborales(id_persona);
            return laborales;
        }



        //Modificacion

        public DataTable ActualizarDatos(Persona modify)
        {
            DataTable resultado = AccesoDatos.ActualizarDatos(modify);
            ActualizarTelefono(modify, modify.id_persona);
            return resultado;
        }

        public void ActualizarDatosAcademicos(Persona modify, int cantidad)
        {
        }


        public void InsertarInfo(int id_persona,/*List<Persona> infoacademico , List<Persona> infolaboral, List<Persona> listaidioma, */List<IdiomaDto> infoidioma, List<infoLaboralDto> infolabora, List<InfoAcademicoDto>infoacademic)
        {

            LogicaNegocio.Administracion_Del_Personal.CN_AdministracionPersonalComboBox logica = new LogicaNegocio.Administracion_Del_Personal.CN_AdministracionPersonalComboBox();

            AccesoDatos.BorrarInfoAcademica(id_persona);
            foreach (var item in infoacademic)
            {
                int? id_nivel = item.Nivel;
                string institucion = item.Institucion;
                int año_ingreso = item.Ingreso;
                int? año_egreso = item.Egreso;
                string titulo = item.Titulo;
                int? id_progreso = item.Progreso;

                AccesoDatos.InsertarInformacionAcademica(id_persona, id_nivel, institucion, año_ingreso, año_egreso, titulo, id_progreso);
            }

            AccesoDatos.BorrarInfoLaboral(id_persona);
            foreach (var item in infolabora)
            {

                string _puesto = item.Puesto;
                string _empresa = item.Empresa;
                int _fecha_ingreso = item.Fecha_Ingreso;
                int _fecha_egreso = item.Fecha_Egreso;
                int _personal_a_cargo = item.Personal_A_Cargo;
                AccesoDatos.InsertarInformacionLaboral(id_persona, _puesto, _empresa, _fecha_ingreso, _fecha_egreso, _personal_a_cargo);
            }
            AccesoDatos.BorrarIdioma(id_persona);
            foreach (var item in infoidioma)
            {

                int id_idioma = item.Idioma;
                int nivel = item.Nivel;


                AccesoDatos.InsertarIdioma(id_persona, id_idioma, nivel);
            }



        }



        public void ActualizarDatosLaborales(Persona modify, int cantidad)
        {
        }

        public void ActualizarTelefono(Persona modify, int id_persona)
        {
            AccesoDatos.ActualizarTelefono(id_persona, modify.telefono, modify.id_tipo, true);
            AccesoDatos.ActualizarTelefono(id_persona, modify.telefono_alternativo, modify.id_tipo_alternativo, false, modify.contacto);
        }


        public void ActualizarIdioma(Persona modify ,int id_persona )
        {
        }


        //eliminacion


        public void BajaPersona (int id_persona)
        {
            AccesoDatos.BajaPersona(id_persona);
        }
        public void ReactivarPersona(int id_persona)
        {
            AccesoDatos.ReactivarPersona(id_persona);
        }

        public void asignarCapacitacionesObligatorias(int idPersona, int idArea)
        {
            CN_AsignarCapacitaciones cap = new CN_AsignarCapacitaciones();
            cap.IdArea = idArea;
            DataTable dt = cap.ConsultaCapacitacionesObligatorias();
            if (dt.Rows.Count > 0)
            {
                cap.IdPersona = idPersona;
                cap.Capacitaciones = dt;
                cap.AsignarCapacitaciones();
            }
        }

    }

}
