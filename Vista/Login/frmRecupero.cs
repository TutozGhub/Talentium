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
    public partial class frmRecupero : Form
    {
        public frmRecupero()
        {
            InitializeComponent();
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
                    cnRecupero.usuarioEmail(textBoxUsuarioRec.Text);
                    string msj = cnRecupero.message.Substring(5);
                    if (msj == "Error" || msj == "error")
                    {
                        MessageBox.Show(cnRecupero.message);
                    }
                    else 
                    {
                        label4.Text = cnRecupero.message;
                        label4.Visible = true;
                        label6.Visible = true;
                        codigo.Visible = true;
                        Verificar.Visible = true;
                        textBoxUsuarioRec.Enabled = false;
                        btnContinuar.Visible = false;
                    }

           // ocultar el boton, disablear el texbox usuario y agregar visible el textbox cod email y el boton verificar cod
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("El campo no debe estar vacio");
            }
        }

        private void lnkRecupero_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmLogin menu = new frmLogin();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CN_LogicaLogin cnRecupero = new CN_LogicaLogin();

            bool valor = cnRecupero.validCode(codigo.Text);

            if (valor) 
            {

                
                this.Hide();
                CambioDePass cambioDePass =  new CambioDePass();
                cambioDePass.Show();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
