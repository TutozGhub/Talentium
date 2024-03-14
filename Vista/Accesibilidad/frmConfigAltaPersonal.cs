using Comun;
using DocumentFormat.OpenXml.Wordprocessing;
using LogicaNegocio.Accesibilidad;
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

namespace Vista.Accesibilidad
{
    public partial class frmConfigAltaPersonal : Form
    {
        CN_ConfigAltaPersonal config = new CN_ConfigAltaPersonal();
        public frmConfigAltaPersonal()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            // tab Tipo de Documento
            grpModificar.Enabled = false;
            grpModificarTel.Enabled = false;
            grpNacioMod.Enabled = false;
            grpModificarGenero.Enabled = false;
            grpModificarIdioma.Enabled = false;
            // Cargo todos los Data Grid View
            CargarDataGrid();
            CargarDataGridTipoTel();
            CargarDataGridNacionalidad();
            CargarDataGridGenero();
            CargarDataGridIdioma();
            CargarDataGridArea();
            CargarDataGridPuesto();
            // Configuraciones para todos los Data Grid View
            ConfigurarDataGridView(dtgDocumento);
            ConfigurarDataGridView(dtgTelefono);
            ConfigurarDataGridView(dtgNacionalidad);
            ConfigurarDataGridView(dtgGenero);
            ConfigurarDataGridView(dtgIdiomas);
            ConfigurarDataGridView(dtgArea);
            ConfigurarDataGridView(dtgPuesto);
        }
        private void ConfigurarDataGridView(DataGridView dtg)
        {
            dtg.AutoGenerateColumns = false;
            dtg.AllowUserToAddRows = false;
            dtg.MultiSelect = false;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.ReadOnly = true;
            dtg.RowHeadersVisible = false;
        }
        private void NavigateTabs(int offset)
        {
            int currentIndex = tabConfigAltaPersonal.SelectedIndex;
            int newIndex = currentIndex + offset;
            if (newIndex >= 0 && newIndex < tabConfigAltaPersonal.TabCount)
            {
                tabConfigAltaPersonal.SelectedIndex = newIndex;
            }
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            NavigateTabs(-1);
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            NavigateTabs(1);
        }
        // tab Tipo de documento
        private void btnGuardarMod_Click(object sender, EventArgs e)
        {
            if (dtgDocumento.SelectedRows.Count > 0)
            {
                int id_tipo_doc = Convert.ToInt32(dtgDocumento.SelectedRows[0].Cells["ID"].Value);

                if (string.IsNullOrWhiteSpace(txtDocumentoMod.Text))
                {
                    MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!config.ModificarTipoDoc(id_tipo_doc, txtDocumentoMod.Text))
                    {
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGrid();
                        txtDocumentoMod.Clear();
                        grpModificar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDocumentoMod.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show(Errores.RegNoSelec, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnGuardarAlta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(!config.ValidarTipoDoc(txtDocumento.Text))
            {
                CargarDataGrid();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumento.Clear();
            } else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Clear();
            }
        }
        private void btnCancelarAlta_Click(object sender, EventArgs e)
        {
            txtDocumento.Clear();
        }
        public void CargarDataGrid()
        {
            DataTable tipoDoc = config.ObtenerTipoDoc();
            dtgDocumento.DataSource = tipoDoc;
            for (int i = 0; i < tipoDoc.Rows.Count; i++)
            {
                dtgDocumento.Rows[i].Cells["Nombre"].Value = tipoDoc.Rows[i]["tipo_doc"];
            }
            dtgDocumento.Columns["ID"].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgDocumento);
        }

        private void dtgDocumento_SelectionChanged(object sender, EventArgs e)
        {
            txtDocumentoMod.Clear();
            grpModificar.Enabled = false;
        }
        private void dtgDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                grpModificar.Enabled = true;
                int rowIndex = e.RowIndex;
                DataGridViewRow selectedRow = dtgDocumento.Rows[rowIndex];
                txtDocumentoMod.Text = selectedRow.Cells["Nombre"].Value.ToString();
            }
        }
        private void btnCancelarMod_Click(object sender, EventArgs e)
        {
            txtDocumentoMod.Clear();
            grpModificar.Enabled = false;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            grpModificar.Enabled = true;
            if (dtgDocumento.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dtgDocumento.SelectedRows[0];

                if (filaSeleccionada.Cells["Nombre"].Value != null)
                {
                    string valorCelda = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    txtDocumentoMod.Text = valorCelda;
                }
            }
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dtgDocumento.SelectedRows.Count > 0)
            {
                int id_tipo_doc = Convert.ToInt32(dtgDocumento.SelectedRows[0].Cells[0].Value);
                if (config.TipoDocAsociadoAPersona(id_tipo_doc))
                {
                    MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult resultado = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        config.EliminarTipoDoc(id_tipo_doc);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGrid();
                    }
                }
            }
        }
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void txtDocumentoMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void dtgDocumento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgDocumento.Rows[e.RowIndex].Selected = true;
                btnModificar.Enabled = true;
                btnBaja.Enabled = true;
            }
        }

        // tab tipo de teléfono 
        private void btnCancelarAltaTel_Click(object sender, EventArgs e)
        {
            txtTelefonoAlta.Clear();
        }
        private void btnGuardarAltaTel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefonoAlta.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ValidarTipoTel(txtTelefonoAlta.Text))
            {
                CargarDataGridTipoTel();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTelefonoAlta.Clear();
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefonoAlta.Clear();
            }
        }
        private void dtgTelefono_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgTelefono.Rows[e.RowIndex].Selected = true;
                btnModificarTel.Enabled = true;
                btnBajaTel.Enabled = true;
            }
        }
        public void CargarDataGridTipoTel()
        {
            DataTable tipoTel = config.ObtenerTipoTel();
            dtgTelefono.DataSource = tipoTel;
            for (int i = 0; i < tipoTel.Rows.Count; i++)
            {
                dtgTelefono.Rows[i].Cells["NombreTel"].Value = tipoTel.Rows[i]["tipo"];
            }
            dtgTelefono.Columns["IDTel"].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgTelefono);
        }
        private void btnGuardarTelMod_Click(object sender, EventArgs e)
        {
            int id_tipo_tel = (int)dtgTelefono.SelectedCells[0].Value;
            if (string.IsNullOrWhiteSpace(txtTipoTelMod.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ModificarTipoTel(id_tipo_tel, txtTipoTelMod.Text))
            {
                CargarDataGridTipoTel();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTipoTelMod.Clear();
                grpModificarTel.Enabled = false;
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoTelMod.Clear();
            }
        }
        private void btnCancelarTelMod_Click(object sender, EventArgs e)
        {
            txtTipoTelMod.Clear();
            grpModificarTel.Enabled = false;
        }
        private void dtgTelefono_SelectionChanged(object sender, EventArgs e)
        {
            txtTipoTelMod.Clear();
            grpModificarTel.Enabled = false;
        }
        private void dtgTelefono_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            grpModificarTel.Enabled = true;
            if (e.RowIndex >= 0)
            {
                txtTipoTelMod.Text = dtgTelefono.SelectedCells[1].Value.ToString();
            }
        }
        private void btnModificarTel_Click(object sender, EventArgs e)
        {
            grpModificarTel.Enabled = true;
            if (dtgTelefono.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dtgTelefono.SelectedRows[0];

                if (filaSeleccionada.Cells["NombreTel"].Value != null)
                {
                    string valorCelda = filaSeleccionada.Cells["NombreTel"].Value.ToString();
                    txtTipoTelMod.Text = valorCelda;
                }
            }
        }
        private void btnBajaTel_Click(object sender, EventArgs e)
        {
            if (dtgTelefono.SelectedRows.Count > 0)
            {
                int id_tel = Convert.ToInt32(dtgTelefono.SelectedCells[0].Value);
                if (config.TipoTelAsociadoAPersona(id_tel) == true)
                {
                    MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult resultado = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        config.EliminarTipoTel(id_tel);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGridTipoTel();
                    }
                }

            }
        }
        private void txtTelefonoAlta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void txtTipoTelMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // tab Nacionalidad
        private void btnCancelarNacioAlta_Click(object sender, EventArgs e)
        {
            txtNacionalidad.Clear();
        }
        private void dtgNacionalidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgNacionalidad.Rows[e.RowIndex].Selected = true;
                btnNacionalidadMod.Enabled = true;
                btnBajaNacionalidad.Enabled = true;
            }
        }
        private void btnNacioGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ValidarNacionalidad(txtNacionalidad.Text))
            {
                CargarDataGridNacionalidad();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNacionalidad.Clear();
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNacionalidad.Clear();
            }
        }

        private void btnNacioCancelarMod_Click(object sender, EventArgs e)
        {
            txtNacioMod.Clear();
            grpNacioMod.Enabled = false;
        }

        private void btnNacioGuardarMod_Click(object sender, EventArgs e)
        {
            int id_nacionalidad = (int)dtgNacionalidad.SelectedCells[0].Value;
            if (string.IsNullOrWhiteSpace(txtNacioMod.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ModificarNacionalidad(id_nacionalidad, txtNacioMod.Text))
            {
                CargarDataGridNacionalidad();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNacioMod.Clear();
                grpNacioMod.Enabled = false;
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNacioMod.Clear();
            }
        }

        private void btnNacionalidadMod_Click(object sender, EventArgs e)
        {
            grpNacioMod.Enabled = true;
            if (dtgNacionalidad.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dtgNacionalidad.SelectedRows[0];

                if (filaSeleccionada.Cells["NombreNac"].Value != null)
                {
                    string valorCelda = filaSeleccionada.Cells["NombreNac"].Value.ToString();
                    txtNacioMod.Text = valorCelda;
                }
            }
        }

        private void btnBajaNacionalidad_Click(object sender, EventArgs e)
        {
            if (dtgNacionalidad.SelectedRows.Count > 0)
            {
                int id_nacionalidad = Convert.ToInt32(dtgNacionalidad.SelectedCells[0].Value);
                if (config.NacionalidadAsociadaAPersona(id_nacionalidad) == true)
                {
                    MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult resultado = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        config.EliminarNacionalidad(id_nacionalidad);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGridNacionalidad();
                    }
                }
            }
        }
        private void txtNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void txtNacioMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void dtgNacionalidad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            grpNacioMod.Enabled = true;
            if (e.RowIndex >= 0)
            {
                txtNacioMod.Text = dtgNacionalidad.SelectedCells[1].Value.ToString();
            }
        }
        private void dtgNacionalidad_SelectionChanged(object sender, EventArgs e)
        {
            txtNacioMod.Clear();
            grpNacioMod.Enabled = false;
        }
        public void CargarDataGridNacionalidad()
        {
            DataTable nacionalidad = config.ObtenerNacionalidad();
            dtgNacionalidad.DataSource = nacionalidad;
            for (int i = 0; i < nacionalidad.Rows.Count; i++)
            {
                dtgNacionalidad.Rows[i].Cells["NombreNac"].Value = nacionalidad.Rows[i]["nacionalidad"];
            }
            dtgNacionalidad.Columns["IDNac"].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgNacionalidad);
        }

        // tab Genero
        private void btnGeneroCancelarAlta_Click(object sender, EventArgs e)
        {
            txtGenero.Clear();
        }

        private void btnGeneroGuardarAlta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGenero.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ValidarGenero(txtGenero.Text))
            {
                CargarDataGridGenero();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGenero.Clear();
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGenero.Clear();
            }
        }
        private void btnGeneroCancelarMod_Click(object sender, EventArgs e)
        {
            txtGeneroMod.Clear();
            grpModificarGenero.Enabled = false;
        }
        private void btnGuardarGeneroMod_Click(object sender, EventArgs e)
        {
            int id_genero = (int)dtgGenero.SelectedCells[0].Value;
            if (string.IsNullOrWhiteSpace(txtGeneroMod.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ModificarGenero(id_genero, txtGeneroMod.Text))
            {
                CargarDataGridGenero();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGeneroMod.Clear();
                grpModificarGenero.Enabled = false;
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGeneroMod.Clear();
            }
        }
        private void btnGeneroMod_Click(object sender, EventArgs e)
        {
            grpModificarGenero.Enabled = true;
            if (dtgGenero.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dtgGenero.SelectedRows[0];

                if (filaSeleccionada.Cells["NombreGen"].Value != null)
                {
                    string valorCelda = filaSeleccionada.Cells["NombreGen"].Value.ToString();
                    txtGeneroMod.Text = valorCelda;
                }
            }
        }
        private void dtgGenero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgGenero.Rows[e.RowIndex].Selected = true;
                btnGeneroMod.Enabled = true;
                btnBajaGenero.Enabled = true;
            }
        }
        private void btnBajaGenero_Click(object sender, EventArgs e)
        {
            if (dtgGenero.SelectedRows.Count > 0)
            {
                int id_genero = Convert.ToInt32(dtgGenero.SelectedCells[0].Value);
                if (config.GeneroAsociadoAPersona(id_genero) == true)
                {
                    MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult resultado = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        config.EliminarGenero(id_genero);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGridGenero();
                    }
                }
            }
        }
        private void txtGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void dtgGenero_SelectionChanged(object sender, EventArgs e)
        {
            txtGeneroMod.Clear();
            grpModificarGenero.Enabled = false;
        }
        private void dtgGenero_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            grpModificarGenero.Enabled = true;
            if (e.RowIndex >= 0)
            {
                txtGeneroMod.Text = dtgGenero.SelectedCells[1].Value.ToString();
            }
        }
        public void CargarDataGridGenero()
        {
            DataTable genero = config.ObtenerGenero();
            dtgGenero.DataSource = genero;
            for (int i = 0; i < genero.Rows.Count; i++)
            {
                dtgGenero.Rows[i].Cells["NombreGen"].Value = genero.Rows[i]["genero"];
            }
            dtgGenero.Columns["IDGen"].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgGenero);
        }

        // tab Idiomas
        private void btnCancelarAltaIdioma_Click(object sender, EventArgs e)
        {
            txtIdiomasAlta.Clear();
        }
        private void dtgIdiomas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgIdiomas.Rows[e.RowIndex].Selected = true;
                btnModIdiomas.Enabled = true;
                btnBajaIdiomas.Enabled = true;
            }
        }
        public void CargarDataGridIdioma()
        {
            DataTable idioma = config.ObtenerIdioma();
            dtgIdiomas.DataSource = idioma;
            for (int i = 0; i < idioma.Rows.Count; i++)
            {
                dtgIdiomas.Rows[i].Cells["NombreIdioma"].Value = idioma.Rows[i]["idioma"];
            }
            dtgIdiomas.Columns["IDIdioma"].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgIdiomas);
        }

        private void btnCancelarIdiomaMod_Click(object sender, EventArgs e)
        {
            txtIdiomaMod.Clear();
            grpModificarIdioma.Enabled = false;
        }

        private void btnGuardarAltaIdioma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdiomasAlta.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ValidarIdioma(txtIdiomasAlta.Text))
            {
                CargarDataGridIdioma();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdiomasAlta.Clear();
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdiomasAlta.Clear();
            }
        }

        private void btnGuardarIdiomaMod_Click(object sender, EventArgs e)
        {
            int id_idioma = (int)dtgIdiomas.SelectedCells[0].Value;
            if (string.IsNullOrWhiteSpace(txtIdiomaMod.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ModificarIdioma(id_idioma, txtIdiomaMod.Text))
            {
                CargarDataGridIdioma();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdiomaMod.Clear();
                grpModificarIdioma.Enabled = false;
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdiomaMod.Clear();
            }
        }

        private void btnModIdiomas_Click(object sender, EventArgs e)
        {
            grpModificarIdioma.Enabled = true;
            if (dtgIdiomas.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dtgIdiomas.SelectedRows[0];

                if (filaSeleccionada.Cells["NombreIdioma"].Value != null)
                {
                    string valorCelda = filaSeleccionada.Cells["NombreIdioma"].Value.ToString();
                    txtIdiomaMod.Text = valorCelda;
                }
            }
        }

        private void dtgIdiomas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtgIdiomas_SelectionChanged(object sender, EventArgs e)
        {
            txtIdiomaMod.Clear();
            grpModificarIdioma.Enabled=false;
        }

        private void txtIdiomasAlta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtIdiomaMod_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtIdiomaMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void dtgIdiomas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            grpModificarIdioma.Enabled = true;
            if (e.RowIndex >= 0)
            {
                txtIdiomaMod.Text = dtgIdiomas.SelectedCells[1].Value.ToString();
            }
        }

        private void btnBajaIdiomas_Click(object sender, EventArgs e)
        {
            if (dtgIdiomas.SelectedRows.Count > 0)
            {
                int id_idiomas = Convert.ToInt32(dtgIdiomas.SelectedCells[0].Value);
                if (config.IdiomaAsociadoAPersona(id_idiomas) == true)
                {
                    MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult resultado = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        config.EliminarIdioma(id_idiomas);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGridIdioma();
                    }
                }
            }
        }

        // tab Área
        private void btnCancelarAltaArea_Click(object sender, EventArgs e)
        {
            txtAreaAlta.Clear();
        }
        private void dtgArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgArea.Rows[e.RowIndex].Selected = true;
                btnModificarArea.Enabled = true;
                btnBajaArea.Enabled = true;
            }
        }
        private void btnGuardarAltaArea_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAreaAlta.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ValidarArea(txtAreaAlta.Text))
            {
                CargarDataGridArea();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAreaAlta.Clear();
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaAlta.Clear();
            }
        }

        private void btnCancelarModArea_Click(object sender, EventArgs e)
        {
            txtAreaMod.Clear();
            grpModificarArea.Enabled = false;
        }

        private void btnGuardarModArea_Click(object sender, EventArgs e)
        {
            int id_area = (int)dtgArea.SelectedCells[0].Value;
            if (string.IsNullOrWhiteSpace(txtAreaMod.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ModificarArea(id_area, txtAreaMod.Text))
            {
                CargarDataGridArea();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAreaMod.Clear();
                grpModificarArea.Enabled = false;
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaMod.Clear();
            }
        }

        private void btnBajaArea_Click(object sender, EventArgs e)
        {
            if (dtgArea.SelectedRows.Count > 0)
            {
                int id_area = Convert.ToInt32(dtgArea.SelectedCells[0].Value);
                if (config.AreaAsociadoAPersona(id_area) == true)
                {
                    MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult resultado = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        config.EliminarArea(id_area);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGridArea();
                    }
                }
            }
        }

        private void btnModificarArea_Click(object sender, EventArgs e)
        {
            grpModificarArea.Enabled = true;
            if (dtgArea.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dtgArea.SelectedRows[0];

                if (filaSeleccionada.Cells["NombreArea"].Value != null)
                {
                    string valorCelda = filaSeleccionada.Cells["NombreArea"].Value.ToString();
                    txtAreaMod.Text = valorCelda;
                }
            }
        }

        private void dtgArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            grpModificarArea.Enabled = true;
            if (e.RowIndex >= 0)
            {
                txtAreaMod.Text = dtgArea.SelectedCells[1].Value.ToString();
            }
        }

        private void dtgArea_SelectionChanged(object sender, EventArgs e)
        {
            txtAreaMod.Clear();
            grpModificarArea.Enabled = false;
        }

        private void txtAreaAlta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtAreaMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        public void CargarDataGridArea()
        {
            DataTable area = config.ObtenerArea();
            dtgArea.DataSource = area;
            for (int i = 0; i < area.Rows.Count; i++)
            {
                dtgArea.Rows[i].Cells["NombreArea"].Value = area.Rows[i]["area"];
            }
            dtgArea.Columns["IDArea"].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgArea);
        }
        // tabPuesto
        private void btnCancelarPuestoAlta_Click(object sender, EventArgs e)
        {
            txtPuestoAlta.Clear();
        }

        private void btnGuardarPuestoAlta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPuestoAlta.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ValidarPuesto(txtPuestoAlta.Text))
            {
                CargarDataGridPuesto();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPuestoAlta.Clear();
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPuestoAlta.Clear();
            }
        }

        private void btnCancelarPuestoMod_Click(object sender, EventArgs e)
        {
            txtPuestoModificar.Clear();
            grpModificarPuesto.Enabled = false;
        }

        private void btnGuardarPuestoMod_Click(object sender, EventArgs e)
        {
            int id_puesto = (int)dtgPuesto.SelectedCells[0].Value;
            if (string.IsNullOrWhiteSpace(txtPuestoModificar.Text))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!config.ModificarPuesto(id_puesto, txtPuestoModificar.Text))
            {
                CargarDataGridPuesto();
                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPuestoModificar.Clear();
                grpModificarPuesto.Enabled = false;
            }
            else
            {
                MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPuestoModificar.Clear();
            }
        }

        private void btnModificarPuesto_Click(object sender, EventArgs e)
        {
            grpModificarPuesto.Enabled = true;
            if (dtgPuesto.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dtgPuesto.SelectedRows[0];

                if (filaSeleccionada.Cells["NombrePuesto"].Value != null)
                {
                    string valorCelda = filaSeleccionada.Cells["NombrePuesto"].Value.ToString();
                    txtPuestoModificar.Text = valorCelda;
                }
            }
        }

        private void btnBajaPuesto_Click(object sender, EventArgs e)
        {
            if (dtgPuesto.SelectedRows.Count > 0)
            {
                int id_puesto = Convert.ToInt32(dtgPuesto.SelectedCells[0].Value);
                if (config.PuestoAsociadoAPersona(id_puesto) == true)
                {
                    MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult resultado = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        config.EliminarPuesto(id_puesto);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGridPuesto();
                    }
                }
            }
        }

        private void txtPuestoAlta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPuestoModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void dtgPuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            grpModificarPuesto.Enabled = true;
            if (e.RowIndex >= 0)
            {
                txtPuestoModificar.Text = dtgPuesto.SelectedCells[1].Value.ToString();
            }
        }
        private void dtgPuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgPuesto.Rows[e.RowIndex].Selected = true;
                btnModificarPuesto.Enabled = true;
                btnBajaPuesto.Enabled = true;
            }
        }
        private void dtgPuesto_SelectionChanged(object sender, EventArgs e)
        {
            txtPuestoModificar.Clear();
            grpModificarPuesto.Enabled = false;
        }
        public void CargarDataGridPuesto()
        {
            DataTable puesto = config.ObtenerPuesto();
            dtgPuesto.DataSource = puesto;
            for (int i = 0; i < puesto.Rows.Count; i++)
            {
                dtgPuesto.Rows[i].Cells["NombrePuesto"].Value = puesto.Rows[i]["puesto"];
            }
            dtgPuesto.Columns["IDPuesto"].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgPuesto);
        }

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void dtgDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        
    }
}
