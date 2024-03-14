using Comun;
using DocumentFormat.OpenXml.Drawing;
using LogicaNegocio;
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
    public partial class frmAsignarCapacitaciones : Form
    {
        DataTable dtListaBd; // Almacena las capacitaciones existentes en la bd
        DataTable dtListaMem = new DataTable("Capacitaciones"); // Almacena las capacitaciones asignadas al empleado
        private object _idPersona;

        CN_AsignarCapacitaciones cn_asignar = new CN_AsignarCapacitaciones();
        public frmAsignarCapacitaciones()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario

            #region config
            //dtg configura el dtg
            dtgPersonas.MultiSelect = false;
            dtgPersonas.RowHeadersVisible = false;
            dtgPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgPersonas.AllowUserToAddRows = false;
            dtgPersonas.AllowUserToResizeRows = false;
            dtgPersonas.ReadOnly = true;
            dtgPersonas.DataSource = null;

            //lblDatos
            lblPersona.Text = "";
            //cmb area
            cmbArea.DataSource = null;
            cmbArea.DataSource = cn_asignar.ConsultarAreas();
            cmbArea.ValueMember = "id_area";
            cmbArea.DisplayMember = "area";
            cmbArea.SelectedValue = -1;
            //dt, crea las columnas para el dtListaMem
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = System.Type.GetType("System.Int32");
            idColumn.ColumnName = "id_capacitaciones";
            dtListaMem.Columns.Add(idColumn);

            DataColumn fNameColumn = new DataColumn();
            fNameColumn.DataType = System.Type.GetType("System.String");
            fNameColumn.ColumnName = "capacitacion";
            dtListaMem.Columns.Add(fNameColumn);
            //lst, carga los dt en las listBox de capacitaciones
            lstCapacitaciones.DataSource = null;
            cn_asignar.IdArea = -1;
            dtListaBd = cn_asignar.ConsultarCapacitaciones();
            lstCapacitaciones.DataSource = dtListaBd;
            lstCapacitaciones.ValueMember = "id_capacitaciones";
            lstCapacitaciones.DisplayMember = "capacitacion";

            lstCapacitacionesAsignadas.DataSource = null;
            lstCapacitacionesAsignadas.DataSource = dtListaMem;
            lstCapacitacionesAsignadas.ValueMember = "id_capacitaciones";
            lstCapacitacionesAsignadas.DisplayMember = "capacitacion";
            #endregion
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCuit.Text) && string.IsNullOrEmpty(txtNombre.Text)
                && string.IsNullOrEmpty(txtApellido.Text) && (int)cmbArea.SelectedValue == -1)
            // Entra si los campos de filtrado estan todos en su estado por defecto
            {
                MessageBox.Show("Utilice al menos un filtro");
            }
            else
            {
                DataTable dt = cn_asignar.ConsultarPersonal(txtCuit.Text, txtNombre.Text, txtApellido.Text, cmbArea.SelectedValue);

                if (dt.Rows.Count == 0)
                {
                    // Si el dtg es ejecutado y el filtrado no devuelve registros aparece un messagebox
                    MessageBox.Show("Ningun registro coinside");
                }
                else
                {
                    // Carga los registros en el dtg
                    dtgPersonas.DataSource = null;
                    dtgPersonas.DataSource = dt;
                    dtgPersonas.Columns[0].Visible = false;
                    dtgPersonas.Columns[6].Visible = false;
                    UtilidadesForms.LimpiarControles(grpFiltro);
                    cmbArea.SelectedValue = -1;
                }
            }
        }

        private void dtgPersonas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _idPersona = dtgPersonas.Rows[e.RowIndex].Cells[0].Value;

            lblPersona.Text = $"{dtgPersonas.Rows[e.RowIndex].Cells[1].Value.ToString()} " +
                $"{dtgPersonas.Rows[e.RowIndex].Cells[2].Value.ToString()} " +
                $"          Puesto:  {dtgPersonas.Rows[e.RowIndex].Cells[5].Value.ToString()}";

            cn_asignar.IdArea = dtgPersonas.Rows[e.RowIndex].Cells[6].Value;
            DataTable dtLeft = cn_asignar.ConsultarCapacitaciones();
            cn_asignar.IdPersona = _idPersona;
            DataTable dtRight = cn_asignar.ConsultarCapacitaciones(true);
            UtilidadesForms.ConfigListbox(dtLeft, ref dtListaBd, ref dtListaMem, ref lstCapacitaciones, ref lstCapacitacionesAsignadas, true, dtRight);
        }

        private void btnAsignarCapacitacion_Click(object sender, EventArgs e)
        {
            UtilidadesForms.moverListboxRow(lstCapacitaciones, lstCapacitacionesAsignadas, dtListaBd, dtListaMem, lstCapacitaciones.SelectedIndex);
        }
        private void lstCapacitaciones_DoubleClick(object sender, EventArgs e)
        {
            UtilidadesForms.moverListboxRow(lstCapacitaciones, lstCapacitacionesAsignadas, dtListaBd, dtListaMem, lstCapacitaciones.SelectedIndex);
        }

        private void btnDesasignarCapacitacion_Click(object sender, EventArgs e)
        {
            UtilidadesForms.moverListboxRow(lstCapacitacionesAsignadas, lstCapacitaciones, dtListaMem, dtListaBd, lstCapacitacionesAsignadas.SelectedIndex);
        }
        private void lstCapacitacionesAsignadas_DoubleClick(object sender, EventArgs e)
        {
            UtilidadesForms.moverListboxRow(lstCapacitacionesAsignadas, lstCapacitaciones, dtListaMem, dtListaBd, lstCapacitacionesAsignadas.SelectedIndex);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dtgPersonas.Rows.Count > 0)
            {
                cn_asignar.Capacitaciones = null;
                cn_asignar.Capacitaciones = dtListaMem;

                dtgPersonas.Refresh();
                cn_asignar.IdPersona = _idPersona;
                cn_asignar.AsignarCapacitaciones();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario");
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
