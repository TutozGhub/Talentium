using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;
using Comun;
using System.Windows.Forms;
using AccesoDatos.Administracion_Personal;
using LogicaNegocio.Lenguajes;

namespace LogicaNegocio.Administracion_Del_Personal
{
    public class CN_AdministracionPersonalComboBox
    {
        CD_AccesoBDComboBox accesoDatos = new CD_AccesoBDComboBox();

        //COMBOBOXS
        public DataTable ObtenerIdioma()
        {
            DataTable idioma = accesoDatos.ListaIdioma();
            return idioma;
        }
        public DataTable ObtenerProvincia()
        {
            DataTable provincia = accesoDatos.ListaProvincias();
            return provincia;
        }

        public DataTable ObtenerPartido(int id_provincia)
        {
            DataTable partido = accesoDatos.ListaPartido( id_provincia);
            return partido;
        }

        public DataTable ObtenerLocalidades(int id_partido)
        {
            DataTable localidades = accesoDatos.ListaLocalidad(id_partido);
            return localidades;
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
        public DataTable ObtenerProgreso(ComboBox cmbEgreso)
        {
            DataTable progreso = accesoDatos.ListaProgreso();
            switch (cmbEgreso.SelectedIndex)
            {
                case 0:
                    progreso.Rows[1].Delete();
                    break;
                default:
                    progreso.Rows[0].Delete();
                    progreso.Rows[2].Delete();
                    break;
            }
            return progreso;
        }
        public DataTable ObtenerTipoDoc()
        {

            DataTable tipodoc = accesoDatos.ListarTipoDoc();
            return tipodoc;
        }
        public DataTable ObtenerConvenio()
        {

            DataTable convenio = accesoDatos.ListarConvenio();
            return convenio;
        }


     
        public DataTable ObtenerPuesto()
        {

            DataTable puesto = accesoDatos.ListarPuesto();
            return puesto;
        }
        public DataTable ObtenerArea(bool todas = false)
        {
            try
            {
                DataTable dt = accesoDatos.ListarArea();
                if (todas)
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(new Object[] { -1, Errores.Todas });
                }
                return dt;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public DataTable ObtenerCodigoPostal(int id_localidad)
        {

           return accesoDatos.ObtenerCodigoPostal(id_localidad);
    
        }




       
    }
}
