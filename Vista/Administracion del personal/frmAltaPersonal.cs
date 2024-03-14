using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;

namespace Vista
{

    public partial class frmAltaPersonal : Form
    {
        
        public frmAltaPersonal()
        {
            InitializeComponent();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            grbSuperior.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            grbSuperior.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            grbExp1.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            grbExp1.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            grbExp2.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            grbExp2.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            grbExp3.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            grbExp3.Visible = false;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            grbExp2.Visible = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {


           
            
                string codigoPostal = cmbLocalidad.SelectedValue.ToString();
                txtCodigoPostal.Text = codigoPostal;
            


        }

        private void frmAltaPersonal_Load(object sender, EventArgs e)
        {
            CN_LogicaAdministracionPersonal logica = new CN_LogicaAdministracionPersonal();
            
           DataTable localidades = logica.ObtenerLocalidades();
            cmbLocalidad.DataSource = localidades;
            cmbLocalidad.DisplayMember = "localidad"; 
            cmbLocalidad.ValueMember = "id_localidad";
          

            if (cmbLocalidad.SelectedItem != null)
            {
                string codigoPostal = cmbLocalidad.SelectedValue.ToString();
                txtCodigoPostal.Text = codigoPostal;
            }
       


            DataTable provincia = logica.ObtenerProvincia();

            cmbProvincia.DataSource = provincia;
            
            cmbProvincia.DisplayMember = "provincia";
             cmbProvincia.ValueMember = "id_provincia";
            cmbProvincia.SelectedIndex = -1;


            DataTable partido = logica.ObtenerPartido();
            cmbPartido.DataSource = partido;
            cmbPartido.DisplayMember = "partido"; 
             cmbPartido.ValueMember = "id_partido"; 

             DataTable genero = logica.ObtenerGenero();
            cmbGenero.DataSource = genero;
            cmbGenero.DisplayMember = "genero"; 
             cmbGenero.ValueMember = "id_genero"; 
            
            DataTable tipotel = logica.ObtenerTipoTel();
            cmbTipoTelAlternativo.DataSource = tipotel;
            cmbTipoTelAlternativo.DisplayMember = "tipo"; 
             cmbTipoTelAlternativo.ValueMember = "id_tipo";

            cmbTipoTel.DataSource = tipotel;
            cmbTipoTel.DisplayMember = "tipo";
            cmbTipoTel.ValueMember = "id_tipo";


            DataTable nivelacademico = logica.ObtenerNivelAcademico();
            cmbNivelAcademico.DataSource = nivelacademico;
            cmbNivelAcademico.DisplayMember = "nivel";
            cmbNivelAcademico.ValueMember = "id_nivel";
            cmbNivelAcademico2.DataSource = nivelacademico;
            cmbNivelAcademico2.DisplayMember = "nivel";
            cmbNivelAcademico2.ValueMember = "id_nivel";

            DataTable estadocivil = logica.ObtenerEstadoCivil();
            cmbEstadoCivil.DataSource = estadocivil;
            cmbEstadoCivil.DisplayMember = "estado_civil";
            cmbEstadoCivil.ValueMember = "id_estado_civil";


             DataTable nacionalidad = logica.ObtenerNacionalidad();
            cmbNacionalidad.DataSource = nacionalidad;
            cmbNacionalidad.DisplayMember = "nacionalidad";
            cmbNacionalidad.ValueMember = "id_nacionalidad";





            // Agrega los años desde 1900 hasta el año actual a la lista
            int anioActual = DateTime.Now.Year;
            List<string> listaDeAnios = new List<string>();

            for (int i = 1900; i <= anioActual; i++)
            {
                listaDeAnios.Add(i.ToString());
            }
            // Selecciona el ComboBox en el cual se cargan los años
                 cmbIngreso.Items.AddRange(listaDeAnios.ToArray());
            //ComboBox Solapa Academico
            cmbEgreso.Items.AddRange(listaDeAnios.ToArray());
            cmbIngreso1.Items.AddRange(listaDeAnios.ToArray());
            cmbEgreso2.Items.AddRange(listaDeAnios.ToArray());
            cmbEgreso3.Items.AddRange(listaDeAnios.ToArray());

            //ComboBox Solapa Laboral

            cmbLaboralIngreso.Items.AddRange(listaDeAnios.ToArray());
            cmbLaboralEgreso.Items.AddRange(listaDeAnios.ToArray());
            cmbLaboralIngreso1.Items.AddRange(listaDeAnios.ToArray());
            cmbLaboralEgreso1.Items.AddRange(listaDeAnios.ToArray());
            cmbLaboralIngreso2.Items.AddRange(listaDeAnios.ToArray());
            cmbLaboralEgreso2.Items.AddRange(listaDeAnios.ToArray());
            cmbLaboralIngreso3.Items.AddRange(listaDeAnios.ToArray());
            cmbLaboralEgreso3.Items.AddRange(listaDeAnios.ToArray());
            
        
        }



        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {

          




        }

        private void button9_Click(object sender, EventArgs e)
        {
       
            CN_LogicaAdministracionPersonal logicaPersona = new CN_LogicaAdministracionPersonal();

            string apellidos = txtApellidos.Text;
            string nombres = txtNombres.Text;
            string nro_doc = txtDni.Text;
            string cuit_cuil = txtCuitCuil.Text;
            string  calle = txtCalle.Text;
            int nro = txtNro.Text.Length;
            string dpto = txtDpto.Text;
            string piso = txtPiso.Text; 
            int id_localidad = int.Parse (cmbLocalidad.SelectedValue.ToString());
            string email = txtEmail.Text;
            int id_nacionalidad = int.Parse(cmbNacionalidad.SelectedValue.ToString());
           
            int id_genero = int.Parse (cmbGenero.SelectedValue.ToString());
            DateTime fecha_nacimiento = dtpFechaNacimiento.Value;
            

            
            int id_estado_civil = int.Parse (cmbEstadoCivil.SelectedValue.ToString());
            int hijos = nupHijos.Text.Length;
            string telefono = txtTelefono.Text;
            string tipo = cmbTipoTel.Text;
            string telefono_alternativo = txtTelefonoAlternativo.Text;
            string tipo2 = cmbTipoTel.Text;
            string contacto = txtContacto.Text;
            string codigo_postal = txtCodigoPostal.Text;
            string partido = cmbPartido.Text;
            string provincia = cmbProvincia.Text;


            //ACADEMICOS
            //int id_nivel = cmbNivelAcademico.Text.Length;
            string institucion = txtInstitucion.Text;
            string carrera = txtCarrera.Text;
            int año_ingreso = cmbIngreso.Text.Length;
            int año_egreso = cmbEgreso.Text.Length;
            // string año_cursado = txtApellidos.Text;
            string titulo = txtTitulo.Text;

            try
            {
                // Llamar al método de la capa de lógica de negocio para insertar una persona
                logicaPersona.InsertarPersona(apellidos, nombres, nro_doc, cuit_cuil,
                    calle, nro, dpto, piso, id_localidad, email, id_nacionalidad, id_genero, fecha_nacimiento,
                    id_estado_civil, hijos, telefono, tipo, telefono_alternativo, tipo2, contacto
                    , codigo_postal, partido, provincia,institucion,carrera,año_ingreso,año_egreso,titulo);
     //           logicaPersona.InsertarInformacionAcademica(id_nivel, institucion, carrera,
     //año_ingreso, año_egreso, /*año_cursado,*/ titulo);

                MessageBox.Show("La persona se ha insertado correctamente.");
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                MessageBox.Show("Se produjo un error al insertar la persona: " + ex.Message);
            }




          //  /*try
          //  {
          //       Llamar al método de la capa de lógica de negocio para insertar una persona
          //      logicaPersona.InsertarInformacionAcademica( id_nivel, institucion, carrera,
          //año_ingreso,  año_egreso,  año_cursado, titulo);
          //      MessageBox.Show("La persona se ha insertado correctamente.");
          //  }
          //  catch (Exception ex)
          //  {
          //       Manejar cualquier excepción que pueda ocurrir
          //      MessageBox.Show("Se produjo un error al insertar la persona: " + ex.Message);
          //  }*/




        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }



    
}
