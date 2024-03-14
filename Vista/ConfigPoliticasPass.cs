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
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{
    public partial class ConfigPoliticasPass : Form
    {
        CN_PoliticaPassword config = new CN_PoliticaPassword();
        CN_Backup bk = new CN_Backup();
        public ConfigPoliticasPass()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            config.ConsultaPoliticaPass();

            chcChar.Checked = ConfigCache.caracteres;
            chcMay.Checked = ConfigCache.mayusculas;
            chcNum.Checked = ConfigCache.numeros;
            chcEsp.Checked = ConfigCache.especiales;
            chcDatos.Checked = ConfigCache.noDatosPersonales;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.upPolPass(chcChar.Checked, chcMay.Checked, chcNum.Checked, chcEsp.Checked, chcDatos.Checked);
        }

        private void ConfigPoliticasPass_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearBakup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult ms = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ms == DialogResult.Yes)
                {
                    bk.HacerBackup();
                    CN_Bitacora.AltaBitacora("Backup de la bd creado", "Backup", this.Name);
                    MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarBakup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult ms = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ms == DialogResult.Yes)
                {
                    opnBackup.InitialDirectory = bk.Path;
                    DialogResult resultado = opnBackup.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        bk.CargarBackup(opnBackup.FileName);
                        CN_Bitacora.AltaBitacora("Backup de la bd cargado", "Backup", this.Name);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
