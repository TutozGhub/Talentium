using Comun;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmCategorias : Form
    {
        
        CN_Categorias _categoria = new  CN_Categorias();

        private int id_categoria;
        public frmCategorias()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            DeshabilitarModificacion();
        }

        private void DeshabilitarModificacion()
        {
            grpModificarCategoria.Enabled = false;
       
        }

        private void HabilitarModificacion()
        {
            grpModificarCategoria.Enabled = true;
  
        }
        private void CargarGrid()
        {
 
            DataTable ObtenerCateogria = _categoria.ObtenerCategoria();

            DataTable dt = new DataTable();
            dtgCategoria.DataSource = ObtenerCateogria;
            dtgCategoria.Columns["id_categoria"].Visible = false;

        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnGuardarCrear_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txtCategoria.Text) ||
               string.IsNullOrWhiteSpace(txtSueldo.Text) ||
               string.IsNullOrWhiteSpace(txtJornada.Text))
            {
                MessageBox.Show("Por favor, asegúrate de que todos los campos estén llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CategoriaDto categoria = new CategoriaDto();
                categoria.categoria = txtCategoria.Text;
                categoria.jornada = int.Parse(txtJornada.Text);
                categoria.sueldo = Decimal.Parse(txtSueldo.Text);
                _categoria.InsertarCategoria(categoria);
                CargarGrid();
                MessageBox.Show("La categoria se han guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void LimpiarControlesAlta()
        {
            txtCategoria.Text = null;
            txtJornada.Text = null;
            txtSueldo.Text = null;
        }

        private void LimpiarControlesModificacion()
        {
            txtCategoriaModif.Text = null;
            txtJornadaModif.Text = null;
            txtSueldoModif.Text = null;
        }

        private void btnCancelarCrear_Click(object sender, EventArgs e)
        {
            LimpiarControlesAlta();
        }

        private void btnCancelarModif_Click(object sender, EventArgs e)
        {
            LimpiarControlesModificacion();
        }


        private void btnBaja_Click(object sender, EventArgs e)
        {

            try
            {

                int valor = int.Parse(dtgCategoria.SelectedCells[0].Value.ToString());
                bool eliminacionExitosa = _categoria.EliminarCategoria(valor);

                if (eliminacionExitosa)
                {
                    MessageBox.Show("La categoria se eliminó exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la categoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarGrid();
      

        }

        private void dtgCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DeshabilitarModificacion();
            LimpiarControlesModificacion();
        }

        private void btnGuardarModif_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txtCategoriaModif.Text) ||
               string.IsNullOrWhiteSpace(txtJornadaModif.Text) ||
               string.IsNullOrWhiteSpace(txtSueldoModif.Text))
            {
                MessageBox.Show("Por favor, asegúrate de que todos los campos estén llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                    CategoriaDto categoriaDto = new CategoriaDto();
                    categoriaDto.categoria = txtCategoriaModif.Text;
                    categoriaDto.jornada = int.Parse(txtJornadaModif.Text);
                    categoriaDto.sueldo = Decimal.Parse(txtSueldoModif.Text);
                    _categoria.ModificarCategoria(categoriaDto, id_categoria);
                    CargarGrid();
                    LimpiarControlesModificacion();
                    MessageBox.Show("La categoria se han modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
            }

        }

        private void txtJornadaModif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSueldoModif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtJornada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtJornada_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpModificarCategoria_Enter(object sender, EventArgs e)
        {

        }

        private void txtJornadaModif_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            id_categoria = int.Parse(dtgCategoria.SelectedCells[0].Value.ToString());
            txtCategoriaModif.Text = dtgCategoria.SelectedCells[1].Value.ToString();
            txtJornadaModif.Text = dtgCategoria.SelectedCells[2].Value.ToString();
            txtSueldoModif.Text = dtgCategoria.SelectedCells[3].Value.ToString();
            HabilitarModificacion();
        }

   

        private void dtgCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell celda = dtgCategoria.Rows[e.RowIndex].Cells[e.ColumnIndex];
                id_categoria = int.Parse(dtgCategoria.SelectedCells[0].Value.ToString());
                txtCategoriaModif.Text = dtgCategoria.SelectedCells[1].Value.ToString();
                txtJornadaModif.Text = dtgCategoria.SelectedCells[2].Value.ToString();
                txtSueldoModif.Text = dtgCategoria.SelectedCells[3].Value.ToString();
              
            }
            HabilitarModificacion();
        }

        private void dtgCategoria_Leave(object sender, EventArgs e)
        {

        }
    }
}
