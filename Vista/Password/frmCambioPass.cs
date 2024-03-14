using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comun;
using DocumentFormat.OpenXml.Wordprocessing;
using LogicaNegocio;
using LogicaNegocio.Bitacora;
using LogicaNegocio.Lenguajes;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmCambioPass : Form
    {
        CN_CambiarPassword pass = new CN_CambiarPassword();
        private string rta;
        private bool allow = false;
        private bool _esNuevo = false;
        public frmCambioPass(bool esNuevo = false)
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            _esNuevo = esNuevo;
            CN_PoliticaPassword config = new CN_PoliticaPassword();
            config.ConsultaPoliticaPass();
        }
        private void CambioDePass_Load(object sender, EventArgs e)
        {
            DataTable preguntas;
            switch (_esNuevo)
            {
                default:
                    cmbPreguntas.DroppedDown = false;
                    preguntas = pass.ObtenerPregutasUsuarios();
                    break;

                case true:
                    preguntas = pass.ObtenerTodasPregutasSeg();
                    break;
            }
            cmbPreguntas.ValueMember = "id_pregunta";
            cmbPreguntas.DisplayMember = (Properties.Settings.Default.Idioma == "es-AR") ? "pregunta" : "pregunta_eng";
            cmbPreguntas.DataSource = preguntas;
            txtContra1.Focus();

        }
        private void continuar_Click(object sender, EventArgs e)
        {
            if (pass.ValidarPass(_esNuevo, allow, txtContra1.Text, txtContra2.Text, txtRespuesta.Text, cmbPreguntas.SelectedValue))
            {
                CN_Bitacora.AltaBitacora("Cambio de contraseña", "Update", this.Name);
                this.Dispose();
            }
        }

        private void tbContra1_Leave(object sender, EventArgs e)
        {
            allow = (CN_Validaciones.ValCar(txtContra1.Text, ConfigCache.caracteres, ConfigCache.mayusculas,
                ConfigCache.numeros, ConfigCache.especiales, ConfigCache.passAnteriores, ConfigCache.noDatosPersonales));
            if (allow)
            {
                lblError.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "";
                foreach (string error in CN_Validaciones.GetMensajeErrorLabel())
                {
                    lblError.Text = lblError.Text + error + "\n";
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMostrar_MouseDown(object sender, MouseEventArgs e)
        {
            txtContra1.PasswordChar = '\0';
        }

        private void btnMostrar_MouseUp(object sender, MouseEventArgs e)
        {
            txtContra1.PasswordChar = '*';
        }

        private void btnMostrar2_MouseDown(object sender, MouseEventArgs e)
        {
            txtContra2.PasswordChar = '\0';
        }

        private void btnMostrar2_MouseUp(object sender, MouseEventArgs e)
        {
            txtContra2.PasswordChar = '*';
        }
    }
}
