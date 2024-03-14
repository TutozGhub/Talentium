using Comun;
using LogicaNegocio;
using LogicaNegocio.Accesibilidad;
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

namespace Vista.Accesibilidad
{
    public partial class frmPerfiles : Form
    {
        CN_LogicaUsuarios logica = new CN_LogicaUsuarios();
        bool perfilCustom = false; // Si es un perfil personalizado es true
        int _rowIndex = -1; // Index de la fila actual
        int _index = -1; // Index del id_persona de la fila actual
        DataTable dtListaBd; // Almacena los permisos existentes en la bd
        DataTable dtListaMem = new DataTable("Permisos"); // Almacena los permisos asignados al usuario que sera dado de alta
        public frmPerfiles()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this);
            #region config

            //dtg configura el dtg
            dtgPerfiles.MultiSelect = false;
            dtgPerfiles.RowHeadersVisible = false;
            dtgPerfiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPerfiles.AllowUserToAddRows = false;
            dtgPerfiles.AllowUserToResizeRows = false;
            dtgPerfiles.ReadOnly = true;
            refreshDtg();

            //dt, crea las columnas para el dtListaMem
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = System.Type.GetType("System.Int32");
            idColumn.ColumnName = "id_permiso";
            dtListaMem.Columns.Add(idColumn);

            DataColumn fNameColumn = new DataColumn();
            fNameColumn.DataType = System.Type.GetType("System.String");
            fNameColumn.ColumnName = "funcionalidad";
            dtListaMem.Columns.Add(fNameColumn);

            DataColumn fNameColumnEng = new DataColumn();
            fNameColumnEng.DataType = System.Type.GetType("System.String");
            fNameColumnEng.ColumnName = "funcionalidad_eng";
            dtListaMem.Columns.Add(fNameColumnEng);
            //lst, carga los dt en las listBox de permisos
            lstPermisos.DataSource = null;
            dtListaBd = logica.ConsultarPermisosLst();
            lstPermisos.DataSource = dtListaBd;
            lstPermisos.ValueMember = "id_permiso";
            lstPermisos.DisplayMember = (Properties.Settings.Default.Idioma == "es-AR") ? "funcionalidad" : "funcionalidad_eng";

            lstPermisosAsignados.DataSource = null;
            lstPermisosAsignados.DataSource = dtListaMem;
            lstPermisosAsignados.ValueMember = "id_permiso";
            lstPermisosAsignados.DisplayMember = (Properties.Settings.Default.Idioma == "es-AR") ? "funcionalidad" : "funcionalidad_eng";

            #endregion
            dtgPerfiles.AutoResizeColumns();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void btnAsignarPermisos_Click(object sender, EventArgs e)
        {
            UtilidadesForms.moverListboxRow(lstPermisos, lstPermisosAsignados, dtListaBd, dtListaMem, lstPermisos.SelectedIndex);
        }
        private void lstPermisos_DoubleClick(object sender, EventArgs e)
        {
            UtilidadesForms.moverListboxRow(lstPermisos, lstPermisosAsignados, dtListaBd, dtListaMem, lstPermisos.SelectedIndex);
        }

        private void btnAsignarPermisosTodos_Click(object sender, EventArgs e)
        {

            if (lstPermisos.Items.Count > 0)
            {
                lstPermisos.SelectedIndex = 0;
                for (int i = 0, len = lstPermisos.Items.Count; i < len; i++)
                {
                    UtilidadesForms.moverListboxRow(lstPermisos, lstPermisosAsignados, dtListaBd, dtListaMem, 0);
                }
            }
        }

        private void btnDesasignarPermisos_Click(object sender, EventArgs e)
        {
            UtilidadesForms.moverListboxRow(lstPermisosAsignados, lstPermisos, dtListaMem, dtListaBd, lstPermisosAsignados.SelectedIndex);
        }

        private void lstPermisosAsignados_DoubleClick(object sender, EventArgs e)
        {
            UtilidadesForms.moverListboxRow(lstPermisosAsignados, lstPermisos, dtListaMem, dtListaBd, lstPermisosAsignados.SelectedIndex);
        }
        private void btnDesasignarPermisosTodos_Click(object sender, EventArgs e)
        {

            if (lstPermisosAsignados.Items.Count > 0)
            {
                lstPermisosAsignados.SelectedIndex = 0;
                for (int i = 0, len = lstPermisosAsignados.Items.Count; i < len; i++)
                {
                    UtilidadesForms.moverListboxRow(lstPermisosAsignados, lstPermisos, dtListaMem, dtListaBd, 0);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int len;
            List<int> permisos = new List<int>(); // Lista permisos
            switch (btnAgregar.Name)
            {
                case "btnAgregar":
                    if (!string.IsNullOrEmpty(txtNombrePermiso.Text) && lstPermisosAsignados.Items.Count > 0)
                    {
                        // lista de permisos
                        len = dtListaMem.Rows.Count;

                        for (int i = 0; i < len; i++)
                        {
                            // carga todos los permisos del dtListaMem en la lista permisos
                            permisos.Add(Convert.ToInt32(dtListaMem.Rows[i][0]));
                        }
                        try
                        {
                            CN_LogicaPerfiles cn_perfil = new CN_LogicaPerfiles();
                            cn_perfil.AltaPerfil(txtNombrePermiso.Text, txtDescripcion.Text, permisos.ToArray());
                            CN_Bitacora.AltaBitacora($"Perfil \"{txtNombrePermiso.Text}\" dado de alta", "INSERT", this.Name);
                            UtilidadesForms.LimpiarControles(this);
                            DataTable dtPermisosDef = logica.ConsultarPermisosLst();
                            UtilidadesForms.ConfigListbox(dtPermisosDef, ref dtListaBd, ref dtListaMem, ref lstPermisos, ref lstPermisosAsignados);
                            refreshDtg();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(Errores.PerfValido, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                case "btnModificar":
                    if (!string.IsNullOrEmpty(txtNombrePermiso.Text) && lstPermisosAsignados.Items.Count > 0)
                    {
                        // lista de permisos
                        len = dtListaMem.Rows.Count;

                        for (int i = 0; i < len; i++)
                        {
                            // carga todos los permisos del dtListaMem en la lista permisos
                            permisos.Add(Convert.ToInt32(dtListaMem.Rows[i][0]));
                        }
                        try
                        {
                            CN_LogicaPerfiles cn_perfil = new CN_LogicaPerfiles();
                            cn_perfil.UpPerfil(_index, txtNombrePermiso.Text, txtDescripcion.Text, permisos.ToArray());
                            CN_Bitacora.AltaBitacora($"Perfil \"{txtNombrePermiso.Text}\" modificado", "UPDATE", this.Name);
                            UtilidadesForms.LimpiarControles(this);
                            DataTable dtPermisosDef = logica.ConsultarPermisosLst();
                            UtilidadesForms.ConfigListbox(dtPermisosDef, ref dtListaBd, ref dtListaMem, ref lstPermisos, ref lstPermisosAsignados);
                            refreshDtg();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(Errores.PerfValido, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
            }
        }
        private void dtgPerfiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndex = e.RowIndex;
            _index = Convert.ToInt32(dtgPerfiles.Rows[_rowIndex].Cells[0].Value);

            DataTable dtPermisosDef = logica.ConsultarPermisosLst();
            switch (chcModificar.Checked)
            {
                case true:
                    cargarCamposMod(dtPermisosDef);
                    break;
                case false:
                    break;
            }
        }

        private void chcModificar_CheckedChanged(object sender, EventArgs e)
        {
                DataTable dtPermisosDef = logica.ConsultarPermisosLst();
                switch (chcModificar.Checked)
                {
                    case true:
                        if (dtgPerfiles.Rows.Count > 0)
                        {
                            btnAgregar.Name = "btnModificar";
                            btnAgregar.Text = Strings.btnModificar;
                            btnBaja.Enabled = false;
                            cargarCamposMod(dtPermisosDef);
                        }
                        else
                        {
                            chcModificar.Checked = false;
                        }
                        break;
                    case false:
                        btnAgregar.Name = "btnAgregar";
                        btnAgregar.Text = Strings.btnAgregar;
                        btnBaja.Enabled = true;
                        UtilidadesForms.LimpiarControles(this);
                        UtilidadesForms.ConfigListbox(dtPermisosDef, ref dtListaBd, ref dtListaMem, ref lstPermisos, ref lstPermisosAsignados);
                    break;
                }
        }
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Evitar que se genere una nueva línea
                e.Handled = true;

                // Obtener la posición actual del cursor
                int currentPosition = txtDescripcion.SelectionStart;

                // Obtener el texto del richTextBox
                string text = txtDescripcion.Text;

                // Insertar un espacio en la posición actual del cursor
                text = text.Insert(currentPosition - 1, " ");

                // Actualizar el texto del richTextBox
                txtDescripcion.Text = text;

                // Mover el cursor a la posición siguiente
                txtDescripcion.SelectionStart = currentPosition + 1;
            }
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult msgBox = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dtgPerfiles.Rows.Count > 0 & msgBox == DialogResult.Yes)
            {
                CN_LogicaPerfiles cn_perfil = new CN_LogicaPerfiles();
                if (cn_perfil.ConsultarPerfil(_index) == 0)
                {
                    string _perfil = dtgPerfiles.Rows[_rowIndex].Cells[1].Value.ToString();
                    cn_perfil.BajaPerfil(_index);
                    CN_Bitacora.AltaBitacora($"Perfil \"{_perfil}\" eliminado", "DELETE", this.Name);
                    refreshDtg();
                }
                else
                {
                    MessageBox.Show(Errores.PerfEnUso, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #region Metodos

        private void txtDescripcion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }
        public DataTable traerPermisos()
        {
            CN_ConsultarPermisosPerfil cpp = new CN_ConsultarPermisosPerfil();
            DataTable permisosPerfil = cpp.ConsultarPermisosPerfil(_index);
            return permisosPerfil;
        }
        public void cargarCamposMod(DataTable dtPermisosDef)
        {
            txtNombrePermiso.Text = dtgPerfiles.Rows[_rowIndex].Cells[1].Value.ToString();
            txtDescripcion.Text = dtgPerfiles.Rows[_rowIndex].Cells[2].Value.ToString();
            DataTable permisosPerfil = traerPermisos();
            UtilidadesForms.ConfigListbox(dtPermisosDef, ref dtListaBd, ref dtListaMem, ref lstPermisos, ref lstPermisosAsignados, true, permisosPerfil);
        }
        public void refreshDtg()
        {
            dtgPerfiles.DataSource = null;
            dtgPerfiles.DataSource = logica.ConsultarPerfiles(false);
            dtgPerfiles.Columns[2].MinimumWidth = 200;
            dtgPerfiles.Columns[0].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgPerfiles);
            dtgPerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

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
