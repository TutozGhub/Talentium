using LogicaNegocio.Bitacora;
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

namespace Vista.Bitacora
{
    public partial class frmBitacora : Form
    {
        public frmBitacora()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario

            // Configurar DTG
            dtgBitacora.MultiSelect = false;
            dtgBitacora.RowHeadersVisible = false;
            dtgBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgBitacora.AllowUserToAddRows = false;
            dtgBitacora.AllowUserToResizeRows = false;
            dtgBitacora.ReadOnly = true;

            dtgBitacora.DataSource = null;
            dtgBitacora.DataSource = CN_Bitacora.ConsultarBitacora();
        }

        private void lnkAtras_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }
    }
}
