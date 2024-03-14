using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comun;
using LogicaNegocio;
using LogicaNegocio.Lenguajes;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmRecupero : Form
    {
        public frmRecupero()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (!(string.IsNullOrWhiteSpace(textBoxUsuarioRec.Text)))
            {
                CN_LogicaLogin cnRecupero = new CN_LogicaLogin();
                try
                {
                    cnRecupero.UsuarioEmail(textBoxUsuarioRec.Text);
                    string msj = cnRecupero.Message.Substring(5);
                    if (msj == "Error" || msj == "error")
                    {
                        MessageBox.Show(cnRecupero.Message);
                    }
                    else 
                    {
                        label3.Text = cnRecupero.Message;
                        label3.Visible = true;
                        lblIngreseCodigo.Visible = true;
                        codigo.Visible = true;
                        btnVerificar.Visible = true;
                        textBoxUsuarioRec.Enabled = false;
                        btnContinuar.Visible = false;
                        this.AcceptButton = btnVerificar;
                    }

           // ocultar el boton, disablear el texbox usuario y agregar visible el textbox cod email y el boton verificar cod
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Errores.UsrInvalido, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CN_LogicaLogin cnRecupero = new CN_LogicaLogin();

            bool valor = cnRecupero.ValidCode(codigo.Text);

            if (valor) 
            {
                this.Hide();
                frmCambioPass cambioDePass;
                if (UserCache.nuevo)
                {
                    cambioDePass = new frmCambioPass(true);
                }
                else
                {
                    cambioDePass = new frmCambioPass();
                }
                cambioDePass.ShowDialog();
                this.Dispose();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }
    }
}
