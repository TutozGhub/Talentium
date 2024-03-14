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
using LogicaNegocio.Accesibilidad;
using LogicaNegocio.Lenguajes;
using Vista.Lenguajes;

namespace Vista.Accesibilidad
{
    public partial class frmConfigEntrevistas : Form
    {
        CN_LogicaEntrevista logicaEntrevista = new CN_LogicaEntrevista();
        public frmConfigEntrevistas()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            CargarDataGrid();
            dtgEntrevistas.AllowUserToAddRows = false;
            dtgEntrevistas.AutoGenerateColumns = false;
            dtgEntrevistas.MultiSelect = false;
            dtgEntrevistas.ReadOnly = true;
            dtgEntrevistas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgEntrevistas.RowHeadersVisible = false;
            grpModEntrevista.Enabled = false;
            dtgEntrevistas.Columns["id_entrevista"].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombreEntrevista.Text.Trim()) && string.IsNullOrWhiteSpace(txtInstancia.Text.Trim()))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string entrevista = txtNombreEntrevista.Text.Trim();
                int instancia = Convert.ToInt32(txtInstancia.Text.Trim());
                bool esEntrevistaValida = logicaEntrevista.ValidarEntrevista(instancia, entrevista);

                if (!esEntrevistaValida)
                {
                    MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombreEntrevista.Clear();
                    txtInstancia.Clear();
                    CargarDataGrid();
                }
                else
                {
                    MessageBox.Show(Errores.EntYaIngresada, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreEntrevista.Clear();
                    txtInstancia.Clear();
                }
            }
        }

        private void CargarDataGrid()
        {
            dtgEntrevistas.DataSource = logicaEntrevista.ConsultarEntrevistas();
            dtgEntrevistas.Columns["etapa"].DataPropertyName = "etapa";
            dtgEntrevistas.Columns["entrevista"].DataPropertyName = "entrevista";
            UtilidadesForms.TraducirColumnasDtg(ref dtgEntrevistas);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            grpModEntrevista.Enabled = true;
            if (dtgEntrevistas.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dtgEntrevistas.SelectedRows[0];

                if (filaSeleccionada.Cells["Entrevista"].Value != null)
                {
                    string valorCelda = filaSeleccionada.Cells["etapa"].Value.ToString();
                    string valorCelda2 = filaSeleccionada.Cells["Entrevista"].Value.ToString();
                    txtInstanciaMod.Text = valorCelda;
                    txtModNombre.Text = valorCelda2;
                }
            }
        }

        private void btnModCancelar_Click(object sender, EventArgs e)
        {
            txtModNombre.Clear();
            txtInstanciaMod.Clear();
            grpModEntrevista.Enabled = false;
            grpAltaEntrevista.Enabled = true;
        }

        private void dtgEntrevistas_DoubleClick(object sender, EventArgs e)
        {
            grpModEntrevista.Enabled = true;
            grpAltaEntrevista.Enabled = false;
            txtInstanciaMod.Text = dtgEntrevistas.SelectedCells[1].Value.ToString();
            txtModNombre.Text = dtgEntrevistas.SelectedCells[2].Value.ToString();
        }

        private void btnModGuardar_Click(object sender, EventArgs e)
        {
            if (dtgEntrevistas.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dtgEntrevistas.SelectedRows[0];

                if (filaSeleccionada.DataBoundItem is DataRowView registroSeleccionado)
                {
                    int idRegistroSeleccionado = Convert.ToInt32(registroSeleccionado["id_entrevista"]);
                    if (int.TryParse(txtInstanciaMod.Text.Trim(), out int etapa))
                    {
                        string nuevaEntrevista = txtModNombre.Text.Trim();

                        if (string.IsNullOrWhiteSpace(nuevaEntrevista) || string.IsNullOrWhiteSpace(etapa.ToString()))
                        {
                            MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            bool modificacionExitosa = logicaEntrevista.ModificarEntrevista(idRegistroSeleccionado, etapa, nuevaEntrevista);

                            if (!modificacionExitosa)
                            {
                                MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtModNombre.Clear();
                                txtInstanciaMod.Clear();
                                CargarDataGrid();
                            }
                            else
                            {
                                MessageBox.Show(Errores.EntYaIngresada, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtInstanciaMod.Text = dtgEntrevistas.SelectedCells[1].Value.ToString();
                                txtModNombre.Text = dtgEntrevistas.SelectedCells[2].Value.ToString();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Errores.EtapNoValida, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombreEntrevista.Clear();
            txtInstancia.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgEntrevistas.SelectedRows.Count > 0)
            {
                int id_entrevista = Convert.ToInt32(dtgEntrevistas.SelectedCells[0].Value);
                if (logicaEntrevista.EntrevistaAsociadaAPersona(id_entrevista) == true)
                {
                    MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult resultado = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        logicaEntrevista.EliminarEntrevista(id_entrevista);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGrid();
                    }
                }
            }
        }

        private void dtgEntrevistas_SelectionChanged(object sender, EventArgs e)
        {
            txtInstanciaMod.Clear();
            txtModNombre.Clear();
            grpAltaEntrevista.Enabled = true;
            grpModEntrevista.Enabled = false;
        }

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void dtgEntrevistas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgEntrevistas.Rows[e.RowIndex].Selected = true;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancela la entrada de caracteres no numéricos

            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
    }
}
