using Comun;
using LogicaNegocio;
using LogicaNegocio.Bitacora;
using LogicaNegocio.Lenguajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;
using Vista.Properties;

namespace Vista
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            KeyPreview = true;
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            UtilidadesForms.CargarComboLenguajes(cmbLenguaje);//Llamo al metodo que cargara el ComboBox
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CN_LogicaLogin.Terminal();
            if (LogicaNegocio.Properties.Terminal.Default.Estado_terminal == true &&
                CN_LogicaLogin.LogIn(txtUsername.Text, txtPassword.Text))
            {
                if (UserCache.nuevo)
                {
                    //llamar al form que cambia la contraseña.
                    this.Hide();
                    frmCambioPass cambioPass = new frmCambioPass(true);
                    cambioPass.ShowDialog();
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    this.Show();
                    txtUsername.Focus();
                }
                else if (UserCache.cambiaCada != 0 && DateTime.Today >= UserCache.ultimoCambio.AddDays(Convert.ToDouble(UserCache.cambiaCada)))
                {
                    //llamar al form que cambia la contraseña.
                    MessageBox.Show(Errores.UsrCambiaCadaVencido, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmCambioPass cambioPass = new frmCambioPass();
                    cambioPass.ShowDialog();
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    this.Show();
                    txtUsername.Focus();
                }
                else
                {
                    if (UserCache.cambiaCada != 0 && DateTime.Today >= UserCache.ultimoCambio.AddDays(UserCache.cambiaCada - 7))
                    {
                        MessageBox.Show(Errores.UsrCambiaCadaPorVencer, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    CN_TraerPermisos tp = new CN_TraerPermisos();
                    tp.TraerPermisos();
                    this.Hide();
                    CN_Bitacora.AltaBitacora("Login exitoso", "LogIn", this.Name);
                    frmMenu menu = new frmMenu();
                    menu.ShowDialog();
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    this.Show();
                    txtUsername.Focus();
                }
            }
        }

        private void btnMostrar_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void btnMostrar_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void lnkRecupero_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmRecupero recupero = new frmRecupero();
            recupero.ShowDialog();
            this.Show();
        }

        private void cmbLenguaje_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Settings.Default.Idioma = cmbLenguaje.SelectedValue.ToString();//Cargo el idioma seleccionado por el combo
            Settings.Default.Save(); //Guardo el idioma seleccionado para que quede grabado
            Idioma.CargarIdioma(this.Controls, this);//Llamo al metodo que cambiara el idioma en los formularios
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (LogicaNegocio.Properties.Terminal.Default.Estado_terminal == false &&
                e.Control && e.Alt && e.KeyCode == Keys.OemMinus)
            {
                DialogResult resultado = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (resultado)
                {
                    case DialogResult.Yes:
                        CN_LogicaLogin.RestoreTerminal();
                        break;
                }
            }
        }
    }
}