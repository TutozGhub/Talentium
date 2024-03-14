using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista;
using Vista.Lenguajes;
using Vista.Properties;

namespace Comun
{
    public static class UtilidadesForms
    {

        // Bloquea los controles de un formulario
        public static void BloquearControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Enabled = false;
                if (item is ComboBox cmb) cmb.Enabled = false;
                if (item is GroupBox | item is Panel) BloquearControles(item);
            }
        }

        // Desbloquea los controles de un formulario
        public static void DesbloquearControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Enabled = true;
                if (item is ComboBox cmb) cmb.Enabled = true;
                if (item is GroupBox | item is Panel) DesbloquearControles(item);
            }
        }

        // Limpia los controles de un formulario
        public static void LimpiarControles(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox txt) txt.Text = null;
                if (item is ComboBox cmb) cmb.Text = null;
                if (item is RichTextBox rtxt) rtxt.Text = null;
                if (item is GroupBox | item is Panel) LimpiarControles(item);
            }
        }

        public static void moverListboxRow(ListBox ls1, ListBox ls2, DataTable dt1, DataTable dt2, int selectIndex)
        {
            if (ls1.Items.Count > 0 && selectIndex >= 0 && selectIndex < dt1.Rows.Count)
            {
                DataRowView selectedRowView = (DataRowView)ls1.Items[selectIndex];

                // Obtén la fila completa de la DataRowView
                DataRow selectedRow = selectedRowView.Row;

                // Copia la fila a la nueva DataTable
                DataRow newRow = dt2.NewRow();
                newRow.ItemArray = selectedRow.ItemArray;
                dt2.Rows.Add(newRow);

                dt1.Rows.RemoveAt(selectIndex);
                ls1.Refresh();
                ls2.Refresh();
            }
        }
        public static void LimpiarDataGrid(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = null;
                }
            }
        }

        public static void CargarComboLenguajes(ComboBox cmb)
        {
            cmb.DataSource = Idioma.ObtenerIdiomas();//Cargo el Combo con la lista de la clase Idioma
            cmb.DisplayMember = "Nombre"; //Muestro el "campo" nombre de la lista
            cmb.ValueMember = "InfoCultura";//Guardo la informacion Cultural en el Combo
            cmb.SelectedValue = Settings.Default.Idioma; //Selecciono el idioma guardado por defecto
        }
        public static void checkPermiso(ToolStripMenuItem control, string permiso)
        {
            PermisosCache[] permisos = PermisosCache.GetPermisos();
            for (int i = 0, len = permisos.Length; i < len; i++)
            {
                if (permisos[i].Permiso == permiso)
                {
                    return;
                }
            }
            control.Enabled = false;
            control.BackColor = SystemColors.MenuBar;
        }
        public static void checkPermiso(List<ToolStripMenuItem> controles, string permiso)
        {
            foreach (ToolStripMenuItem control in controles)
            {
                checkPermiso(control, permiso);
            }
        }
        public static void checkPermiso(Control control, string permiso)
        {
            PermisosCache[] permisos = PermisosCache.GetPermisos();
            for (int i = 0, len = permisos.Length; i < len; i++)
            {
                if (permisos[i].Permiso == permiso)
                {
                    return;
                }
            }
            control.Enabled = false;
            control.BackColor = SystemColors.MenuBar;
        }
        public static void checkPermiso(List<Control> controles, string permiso)
        {
            foreach (Control control in controles)
            {
                checkPermiso(control, permiso);
            }
        }
        public static void checkPermiso(ToolStripMenuItem control, List<string> permisos)
        {
            PermisosCache[] permisosCache = PermisosCache.GetPermisos();
            for (int i = 0, len = permisosCache.Length; i < len; i++)
            {
                if (permisos.Contains(permisosCache[i].Permiso))
                {
                    return;
                }
            }
            control.Enabled = false;
            control.BackColor = SystemColors.MenuBar;
        }
        public static void checkPermiso(List<ToolStripMenuItem> controles, List<string> permisos)
        {
            foreach (ToolStripMenuItem control in controles)
            {
                checkPermiso(control, permisos);
            }
        }

        public static void ConfigListbox(DataTable dtLeft, ref DataTable dtListaBd, ref DataTable dtListaMem, ref ListBox lst1, ref ListBox lst2, bool def = false, DataTable dtRight = null)
        {
            dtListaBd.Clear();
            if (def)
            {
                for (int i = 0; i < dtLeft.Rows.Count; i++)
                {
                    int nLeft = (int)dtLeft.Rows[i][0];
                    for (int j = 0; j < dtRight.Rows.Count; j++)
                    {
                        if (nLeft == (int)dtRight.Rows[j][0])
                        {
                            dtLeft.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            dtListaBd.Clear();
            dtListaBd = dtLeft;
            lst1.DataSource = dtListaBd;
            lst1.Update();

            dtListaMem.Clear();
            if (def) dtListaMem = dtRight;
            lst2.DataSource = dtListaMem;
            lst2.Update();
        }
        public static void TraducirColumnasDtg(ref DataGridView dtg)
        {
            // Configurar DTG
            dtg.MultiSelect = false;
            dtg.RowHeadersVisible = false;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtg.AllowUserToAddRows = false;
            dtg.AllowUserToResizeRows = false;

            foreach (DataGridViewColumn c in dtg.Columns)
            {
                string text = Columnas.ResourceManager.GetString(c.HeaderText.ToLower());
                if (text != null)
                {
                    c.HeaderText = text;
                }
            }
        }
    }
}
