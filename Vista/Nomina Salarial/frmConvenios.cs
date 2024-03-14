using Comun;
using LogicaNegocio;
using System;
using System.Data;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{

    public partial class frmConvenios : Form
    {
        CN_Convenio _convenio = new CN_Convenio();
        CN_Categorias _categoria = new CN_Categorias();
        private bool inicial = true;
        private int id_convenio;


        public frmConvenios()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario

            txtSueldo.Enabled = false;
            txtJornada.Enabled = false;
            txtSueldoModif.Enabled = false;
            txtJornadaModif.Enabled = false;
            DeshabilitarModificaciones();

            CargarGrid();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicial)
            {
                return;
            }
            if (cmbCategoria.SelectedIndex != -1)
            {
                string seleccion = cmbCategoria.SelectedValue.ToString();
                DataTable categoria = _convenio.ObtenerCategoriaID(int.Parse(seleccion));
                txtJornada.Text = categoria.Rows[0]["jornada"].ToString();
                txtSueldo.Text = categoria.Rows[0]["sueldos"].ToString();
            }
            
            
          
        }

        private void CargarGrid()
        {

            var ObtenerConvenio = _convenio.ObtenerConvenio();

            dtgConvenio.DataSource = ObtenerConvenio;
            dtgConvenio.Columns["id_convenio"].Visible = false;
            dtgConvenio.Columns["id_convenio1"].Visible = false;
            dtgConvenio.Columns["id_categoria"].Visible = false;



        }

        private void frmConvenios_Load(object sender, EventArgs e)
        {
            var ObtenerCateogria = _categoria.ObtenerCategoria();
            cmbCategoria.DataSource = ObtenerCateogria;
            cmbCategoria.DisplayMember = "nombre_categoria";
            cmbCategoria.SelectedIndex = -1;
            cmbCategoria.ValueMember = "id_categoria";
            cmbCateModif.DataSource = ObtenerCateogria.Copy();
            cmbCateModif.DisplayMember = "nombre_categoria";
            cmbCateModif.SelectedIndex = -1;
            cmbCateModif.ValueMember = "id_categoria";
            inicial = false;



        }


        private void btnGuardarCrear_Click(object sender, EventArgs e)
        {

            if ((string.IsNullOrWhiteSpace(txtConvenio.Text) ||
              string.IsNullOrWhiteSpace(txtObraSocial.Text) ||
              string.IsNullOrWhiteSpace(txtSeguridadSalud.Text))
              || cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, asegúrate de que todos los campos estén llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConvenioDto convenio = new ConvenioDto();
                convenio.convenio = txtConvenio.Text;
                convenio.seguridad_salud = txtSeguridadSalud.Text;
                convenio.obra_social = txtObraSocial.Text;
                convenio.id_categoria = int.Parse(cmbCategoria.SelectedValue.ToString());
                _convenio.InsertarConvenio(convenio);
                CargarGrid();
                MessageBox.Show("Se agrego el convenio correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }


        private void btnGuardarModif_Click(object sender, EventArgs e)
        {

            if ((string.IsNullOrWhiteSpace(txtConvenioModif.Text) ||
         string.IsNullOrWhiteSpace(txtObraSocialModif.Text) ||
         string.IsNullOrWhiteSpace(txtSeguridadSaludModif.Text))
         || cmbCateModif.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, asegúrate de que todos los campos estén llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConvenioDto convenioDto = new ConvenioDto();
                convenioDto.convenio = txtConvenioModif.Text;
                convenioDto.obra_social = txtObraSocialModif.Text;
                convenioDto.seguridad_salud = txtSeguridadSaludModif.Text;
                convenioDto.id_categoria = int.Parse(cmbCateModif.SelectedValue.ToString()); ;
                
                _convenio.ModificarConvenio(convenioDto, id_convenio);
                CargarGrid();
                MessageBox.Show("Se Modifico el convenio correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void dtgConvenio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DeshabilitarModificaciones();
            LimpiarControlesModif();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {

                int valor = int.Parse(dtgConvenio.SelectedCells[0].Value.ToString());
                bool eliminacionExitosa = _convenio.EliminarConvenio(valor);

                if (eliminacionExitosa)
                {
                    MessageBox.Show("El convenio se eliminó exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el convenio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el convenio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarGrid();
        }

        private void cmbCateModif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicial)
            {
                return;
            }
            if (cmbCateModif.SelectedIndex != -1)
            {
                string seleccion = cmbCateModif.SelectedValue.ToString();
                DataTable categoria = _convenio.ObtenerCategoriaID(int.Parse(seleccion));
                txtJornadaModif.Text = categoria.Rows[0]["jornada"].ToString();
                txtSueldoModif.Text = categoria.Rows[0]["sueldos"].ToString();
            }
          
            
        }

        private void txtConvenio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;

            }
        }

        private void txtSeguridadSalud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;

            }
        }

        private void txtObraSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;

            }
        }

        private void txtConvenioModif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;

            }
        }

        private void txtSeguridadSaludModif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;

            }
        }

        private void txtObraSocialModif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void cmbCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbCateModif_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LimpiarControles()
        {
            txtConvenio.Text = null;
            cmbCategoria.SelectedIndex = -1;
            txtObraSocial.Text = null;
            txtSeguridadSalud.Text = null;
            txtJornada.Text = null;
            txtSueldo.Text = null;
        }

        private void LimpiarControlesModif()
        {
            txtConvenioModif.Text = null;
            cmbCateModif.SelectedIndex = -1;
            txtObraSocialModif.Text = null;
            txtSeguridadSaludModif.Text = null;
            txtJornadaModif.Text = null;
            txtSueldoModif.Text = null;
        }


        private void btnCancelarCrear_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void btnCancelarModif_Click(object sender, EventArgs e)
        {
            LimpiarControlesModif();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            grpModificarConvenio.Enabled = true;
            id_convenio = int.Parse(dtgConvenio.SelectedCells[0].Value.ToString());
            txtConvenioModif.Text = dtgConvenio.SelectedCells[1].Value.ToString();
            txtSeguridadSaludModif.Text = dtgConvenio.SelectedCells[2].Value.ToString();
            txtObraSocialModif.Text = dtgConvenio.SelectedCells[3].Value.ToString();
            txtSueldoModif.Text = dtgConvenio.SelectedCells[7].Value.ToString();
            txtJornadaModif.Text = dtgConvenio.SelectedCells[8].Value.ToString();
            cmbCateModif.SelectedValue = int.Parse(dtgConvenio.SelectedCells[4].Value.ToString());
        }

        private void dtgConvenio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell celda = dtgConvenio.Rows[e.RowIndex].Cells[e.ColumnIndex];
                id_convenio = int.Parse(dtgConvenio.SelectedCells[0].Value.ToString());
                txtConvenioModif.Text = dtgConvenio.SelectedCells[1].Value.ToString();
                txtSeguridadSaludModif.Text = dtgConvenio.SelectedCells[2].Value.ToString();
                txtObraSocialModif.Text = dtgConvenio.SelectedCells[3].Value.ToString();
                txtSueldoModif.Text = dtgConvenio.SelectedCells[7].Value.ToString();
                txtJornadaModif.Text = dtgConvenio.SelectedCells[8].Value.ToString();
                cmbCateModif.SelectedValue = int.Parse(dtgConvenio.SelectedCells[4].Value.ToString());
            }
            HabilitarModificaciones();

        }

        public void HabilitarModificaciones()
        {
         grpModificarConvenio.Enabled = true;
        }

        public void DeshabilitarModificaciones()
        {

            grpModificarConvenio.Enabled = false;
       
        }
    }
}
