using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;
using LogicaNegocio;
using LogicaNegocio.Lenguajes;
using Comun;

namespace Vista.Gestion_de_Talento
{
    public partial class frmABMCapacitaciones : Form
    {
        CN_Capacitaciones cnCapacitaciones = new CN_Capacitaciones();
        int _rowIndex = -1;
        int _idCapacitacion = -1;
        public frmABMCapacitaciones()
        {
            InitializeComponent();
            //idiomas
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            Niveles.Culture = Thread.CurrentThread.CurrentUICulture;
            cmbNivelAlta.Items.AddRange(new string[] { Niveles.cmbNivel0, Niveles.cmbNivel1, Niveles.cmbNivel2 });
            cmbNivelMod.Items.AddRange(new string[] { Niveles.cmbNivel0, Niveles.cmbNivel1, Niveles.cmbNivel2 });
            cmbExternaInternaAlta.Items.AddRange(new string[] { Niveles.cmbExternaInterna0, Niveles.cmbExternaInterna1 });
            cmbExternaInternaMod.Items.AddRange(new string[] { Niveles.cmbExternaInterna0, Niveles.cmbExternaInterna1 });
            cmbNivelAlta.SelectedIndex = 0;
            cmbNivelMod.SelectedIndex = 0;
            cmbExternaInternaAlta.SelectedIndex = 0;
            cmbExternaInternaMod.SelectedIndex = 0;
            //cmbArea
            DataTable cnCapa = cnCapacitaciones.area();
            cmbAreaAlta.ValueMember = "id_area";
            cmbAreaAlta.DisplayMember = "area";
            cmbAreaAlta.DataSource = cnCapa.Copy();
            cmbAreaMod.ValueMember = "id_area";
            cmbAreaMod.DisplayMember = "area";
            cmbAreaMod.DataSource = cnCapa.Copy();
            //dtg
            dtgCapacitacion.Columns.Clear();
        }
        public void CleanCtrls(bool ctlAlta) {
            if (ctlAlta == true)
            {
                txtNombreAlta.Clear();
                txtTiempoEstimadoAlta.Clear();
                cmbNivelAlta.SelectedIndex = 0;
                cmbAreaAlta.SelectedIndex = 0;
                cmbExternaInternaAlta.SelectedIndex = 0;
                chcObligatorioAlta.Checked = false;
            }
            else {
                txtNombreMod.Clear();
                txtTiempoEstimadoMod.Clear();
                cmbAreaMod.SelectedIndex = 0;
                cmbNivelMod.SelectedIndex = 0;
                cmbExternaInternaMod.SelectedIndex = 0;
                chcObligatorioMod.Checked = false;
                bloquearGroupBox(grpModificacion, grpAlta);
            }
           
        }
        public void evalHrs(string hr) {
            
        }
        public void limpiarControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Text = null;
                if (item is MaskedTextBox mtxt) mtxt.Text = null;
                if (item is ComboBox cmb) cmb.SelectedIndex = -1;
                if (item is GroupBox | item is Panel) limpiarControles(item);
            }
        }
        public void cargarDTG(bool like)
        {
            DataTable cap;
            //traer capacitaciones al dtg
            if (like == false)
            {
                cap = cnCapacitaciones.ConsultaCapacitaciones();
            }
            else
            {
                cap = cnCapacitaciones.filtrarCapacitaciones(txtFiltro.Text);

            }
            dtgCapacitacion.DataSource = null;
            dtgCapacitacion.DataSource = cap;
            dtgCapacitacion.AllowUserToAddRows = false;
            dtgCapacitacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCapacitacion.MultiSelect = false;
            dtgCapacitacion.RowHeadersVisible = false;
            dtgCapacitacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgCapacitacion.AllowUserToAddRows = false;
            dtgCapacitacion.AllowUserToResizeRows = false;
            dtgCapacitacion.ReadOnly = true;

            // Ocultar las demás columnas

            dtgCapacitacion.Columns[0].Visible = false;
            dtgCapacitacion.Columns[2].Visible = false;
            dtgCapacitacion.Columns[4].Visible = false;
            dtgCapacitacion.Columns[5].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgCapacitacion);
        }
        private void frmABMCapacitaciones_Load(object sender, EventArgs e)
        {

            cargarDTG(false);
            bloquearGroupBox(grpModificacion, grpAlta);
        }


        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreAlta.Text) || string.IsNullOrWhiteSpace(txtTiempoEstimadoAlta.Text)
                || cnCapacitaciones.esCero(txtTiempoEstimadoAlta.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cnCapacitaciones.IdArea = cmbAreaAlta.SelectedValue;
            cnCapacitaciones.Capacitacion = txtNombreAlta.Text.Trim();
            cnCapacitaciones.IdNivel = cmbNivelAlta.SelectedIndex;
            cnCapacitaciones.ExternaInterna = cmbExternaInternaAlta.SelectedIndex;
            cnCapacitaciones.TiempoEstimado = txtTiempoEstimadoAlta.Text;
            cnCapacitaciones.Obligatorio = chcObligatorioAlta.Checked;
            cnCapacitaciones.AltaCapacitaciones();
            cargarDTG(false);
            limpiarControles(grpAlta);
            chcObligatorioAlta.Checked = false;
            chcObligatorioMod.Checked = false;
        }

        private void dtgCapacitacion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndex = e.RowIndex;
            _idCapacitacion = Convert.ToInt32(dtgCapacitacion.Rows[_rowIndex].Cells[0].Value);

        }
        public void cargaCtrMod()
        {
            txtNombreMod.Text = dtgCapacitacion.Rows[_rowIndex].Cells[1].Value.ToString();
            cmbNivelMod.SelectedIndex = (int)dtgCapacitacion.Rows[_rowIndex].Cells[2].Value;
            if (dtgCapacitacion.Rows[_rowIndex].Cells[4].Value.ToString() == "")
            {
                cmbAreaMod.SelectedValue = -1;
            }
            else
            {
                cmbAreaMod.SelectedValue = (int)dtgCapacitacion.Rows[_rowIndex].Cells[4].Value;
            }
            cmbExternaInternaMod.SelectedIndex = (int)dtgCapacitacion.Rows[_rowIndex].Cells[5].Value;
            txtTiempoEstimadoMod.Text = dtgCapacitacion.Rows[_rowIndex].Cells[6].Value.ToString();
            chcObligatorioMod.Checked = (bool)dtgCapacitacion.Rows[_rowIndex].Cells[7].Value;


        }
        private void btnDtgMod_Click(object sender, EventArgs e)
        {

            if (dtgCapacitacion.SelectedRows == null || dtgCapacitacion.SelectedRows.Count == 0)
            {
                MessageBox.Show(Errores.RegNoSelec, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cargaCtrMod();
            bloquearGroupBox(grpAlta, grpModificacion);

        }

        private void dtgCapacitacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargaCtrMod();
            bloquearGroupBox(grpAlta, grpModificacion);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMod.Text) || string.IsNullOrWhiteSpace(txtTiempoEstimadoMod.Text)
                || cnCapacitaciones.esCero(txtTiempoEstimadoMod.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cnCapacitaciones.IdCapacitacionesMod = dtgCapacitacion.Rows[_rowIndex].Cells[0].Value;
            cnCapacitaciones.IdArea = cmbAreaMod.SelectedValue;
            cnCapacitaciones.Capacitacion = txtNombreMod.Text.Trim();
            cnCapacitaciones.IdNivel = cmbNivelMod.SelectedIndex;
            cnCapacitaciones.ExternaInterna = cmbExternaInternaMod.SelectedIndex;
            cnCapacitaciones.TiempoEstimado = txtTiempoEstimadoMod.Text;
            cnCapacitaciones.Obligatorio = chcObligatorioMod.Checked;
            cnCapacitaciones.ModificarCapacitaciones();

            cargarDTG(false);
            limpiarControles(grpModificacion);
            bloquearGroupBox(grpModificacion, grpAlta);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cargarDTG(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtgCapacitacion.SelectedRows == null || dtgCapacitacion.SelectedRows.Count == 0)
            {
                MessageBox.Show(Errores.RegNoSelec, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                try
                {
                    cnCapacitaciones.IdCapacitacionesMod = dtgCapacitacion.Rows[_rowIndex].Cells[0].Value;
                    cnCapacitaciones.EliminarCapacitaciones();
                    cargarDTG(false);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarAlta_Click(object sender, EventArgs e)
        {
            limpiarControles(grpAlta);
        }

        private void btnCancelarMod_Click(object sender, EventArgs e)
        {
            limpiarControles(grpModificacion);

        }
        private void bloquearGroupBox(GroupBox grpActual, GroupBox grpBloqueado)
        {
            grpActual.Enabled = false;
            grpBloqueado.Enabled = true;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void dtgCapacitacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgCapacitacion.Rows[e.RowIndex].Selected = true;
                btnModificar.Enabled = true;
                btnBaja.Enabled = true;
            }
        }

        private void dtgCapacitacion_SelectionChanged(object sender, EventArgs e)
        {
            grpModificacion.Enabled = false;
            limpiarControles(grpModificacion);
        }

        private void txtNombreAlta_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargarDTG(false);

        }
    }
}
