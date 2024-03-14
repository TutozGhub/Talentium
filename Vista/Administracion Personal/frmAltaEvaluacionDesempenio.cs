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
using Comun;
using Vista.Lenguajes;
using LogicaNegocio.Lenguajes;

namespace Vista.Evaluacion_de_desempeño
{
    public partial class frmAltaEvaluacionDesempenio : Form
    {
        CN_LogicaEvaluacionDesempenio evaluacionDesempenio = new CN_LogicaEvaluacionDesempenio();
        CargarCombobox combos = new CargarCombobox();
        public frmAltaEvaluacionDesempenio()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
        }

        private void frmAltaEvaluacionDesempeño_Load(object sender, EventArgs e)
        {
            // cargar combo de Area
            DataTable DT = evaluacionDesempenio.ObtenerAreas();
            cmbAreas.DataSource = DT;
            cmbAreas.DisplayMember = "area";
            cmbAreas.ValueMember = "id_area";

            // cargar el combo de los años
            List<string> DTAnio = combos.CargarAnioCombobox();
            cmbAnio.DataSource = DTAnio;

            // cargar el combo de los meses
            List<string> DTMeses = combos.CargarMesCombobox();
            cmbMes.DataSource = DTMeses;

            dtgEvaluacion.RowCount = 2;
            dtgEvaluacion.AllowUserToAddRows = false;
            dtgEvaluacion.RowHeadersVisible = false;
            dtgEvaluacion.AutoGenerateColumns = false;
            dtgEvaluacion.MultiSelect = false;
            dtgEvaluacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgEvaluacion.ReadOnly = true;
            UtilidadesForms.TraducirColumnasDtg(ref dtgEvaluacion);
        }

        private void cmbAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedArea = cmbAreas.SelectedItem as DataRowView;
            int idAreaSeleccionada = Convert.ToInt32(selectedArea["id_area"]);
            DataTable DTEmpleados = evaluacionDesempenio.ObtenerPersonaConArea(idAreaSeleccionada);
            DTEmpleados.Columns.Add("NombreCompleto", typeof(string), "APELLIDOS + ', ' + NOMBRES");

            if (DTEmpleados != null && DTEmpleados.Rows.Count > 0)
            {
                cmbPersonal.DataSource = DTEmpleados;
                cmbPersonal.DisplayMember = "NombreCompleto";
            }
            else
            {
                // Si no hay empleados para mostrar, limpia el ComboBox de empleados
                cmbPersonal.DataSource = null;
                cmbPersonal.Items.Clear();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string anio = cmbAnio.SelectedValue.ToString();
            string mes = cmbMes.SelectedValue.ToString();
            int efectTareas = Convert.ToInt32(dtgEvaluacion.CurrentRow.Cells["Efectividad"].Value);
            int puntualidad = Convert.ToInt32(dtgEvaluacion.CurrentRow.Cells["Puntualidad"].Value);
            int relSup = Convert.ToInt32(dtgEvaluacion.CurrentRow.Cells["RelSuperiores"].Value);
            int disciplina = Convert.ToInt32(dtgEvaluacion.CurrentRow.Cells["Disciplina"].Value);
            int desempEquipo = Convert.ToInt32(dtgEvaluacion.CurrentRow.Cells["DesempEquipo"].Value);

            DataRowView selectedEmpleado = cmbPersonal.SelectedItem as DataRowView;
            int id_persona = Convert.ToInt32(selectedEmpleado["id_persona"]);

            DataRowView selectedArea = cmbAreas.SelectedItem as DataRowView;
            int id_area = Convert.ToInt32(selectedArea["id_area"]);

            bool algunaCeldaSinCompletar = false;

            foreach (DataGridViewRow row in dtgEvaluacion.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell is DataGridViewComboBoxCell comboBoxCell && comboBoxCell.Value == null)
                    {
                        algunaCeldaSinCompletar = true;
                        break;  
                    }
                }
                if (algunaCeldaSinCompletar)
                {
                    MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool esEvaluacionValida = evaluacionDesempenio.ValidarEvaluacion(anio, mes, efectTareas, puntualidad,
                                                                relSup, disciplina, desempEquipo, id_persona, id_area);

                if (!esEvaluacionValida)
                {
                    MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UtilidadesForms.LimpiarDataGrid(dtgEvaluacion);
                    // ya se limpia el data grid pero me faltan los otros controles.
                    // UtilidadesForms.LimpiarControles(groupBox1);
                    // UtilidadesForms.LimpiarControles(groupBox2);
                }
                else
                {
                    MessageBox.Show(Errores.DocEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            dtgEvaluacion.ReadOnly = true;
            if (cmbPersonal.SelectedItem != null)
            {
                // Obtener el ID, nombre y apellido de la persona seleccionada del ComboBox
                int id_persona = Convert.ToInt32(((DataRowView)cmbPersonal.SelectedItem)["id_persona"]);
                string nombre = ((DataRowView)cmbPersonal.SelectedItem)["nombres"].ToString();
                string apellido = ((DataRowView)cmbPersonal.SelectedItem)["apellidos"].ToString();

                // Obtener la fila actual del DataGridView
                int rowIndex = dtgEvaluacion.CurrentRow.Index;

                // Concatenar el nombre y apellido
                string nombreCompleto = $"{apellido}, {nombre}";

                // Asignar el nombre y apellido a la celda en la columna "NombreApellido"
                dtgEvaluacion.Rows[rowIndex].Cells["NombreApellido"].Value = nombreCompleto;

                btnGuardar.Enabled = true;
                dtgEvaluacion.ReadOnly = false;
            }
            UtilidadesForms.TraducirColumnasDtg(ref dtgEvaluacion);
        }

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }
    }
}
