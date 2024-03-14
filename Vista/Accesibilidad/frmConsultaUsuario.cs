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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmConsultaUsuario : Form
    {
        private int _idUsuario = -1; // El id_usuario del registro seleccionado
        private bool _void = false; // Determina si el dtg puede cargar un dtg vacio
        private string _usr = "";
        private string _nom = "";
        private string _ape = "";
        private int _area = -1;
        private bool _estado = true; // si estan puestos los registros activos o los inactivos

        CN_LogicaUsuarios cn_usuario = new CN_LogicaUsuarios();
        public frmConsultaUsuario()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            // dtg, configura el dtg
            dtgPersonas.MultiSelect = false;
            dtgPersonas.RowHeadersVisible = false;
            dtgPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPersonas.AllowUserToAddRows = false;
            dtgPersonas.AllowUserToResizeRows = false;
            dtgPersonas.ReadOnly = true;
            dtgPersonas.DataSource = null;
            // cmb area, configura el cmb area
            cmbArea.DataSource = null;
            CN_LogicaUsuarios usuario = new CN_LogicaUsuarios();
            cmbArea.DataSource = usuario.ConsultarAreas();
            cmbArea.ValueMember = "id_area";
            cmbArea.DisplayMember = "area";
            cmbArea.SelectedValue = -1;
        }

        private void frmAltaUsuario_Load(object sender, EventArgs e)
        {

        }

        private void tbcAltaUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbpUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) && string.IsNullOrEmpty(txtNombre.Text)
                && string.IsNullOrEmpty(txtApellido.Text) && (int)cmbArea.SelectedValue == -1 && _void == false)
            // Entra si los campos de filtrado estan todos en su estado por defecto
            {
                MessageBox.Show(Errores.FiltroIncompleto, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            //Entra si se usa al menos uno de los filtros
            {
                if (_void == false)
                // Si el dtg es ejecutado directamente por el usuario carga las variables con los campos de filtrado
                {
                    _usr = txtUsuario.Text;
                    _nom = txtNombre.Text;
                    _ape = txtApellido.Text;
                    _area = (int)cmbArea.SelectedValue;
                }
                DataTable dt = cn_usuario.ConsultarUsuario(_usr, _nom, _ape, _area,_estado);

                if (dt.Rows.Count == 0 && _void == false)
                // Si el dtg es ejecutado y el filtrado no devuelve registros aparece un messagebox
                {
                    MessageBox.Show(Errores.RegNoCoincide, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Carga los registros en el dtg
                    dtgPersonas.DataSource = null;
                    dtgPersonas.DataSource = dt;
                    dtgPersonas.Columns[0].Visible = false;
                    UtilidadesForms.TraducirColumnasDtg(ref dtgPersonas);
                    dtgPersonas.AutoResizeColumns();
                    if (_void == false)
                    {
                        UtilidadesForms.LimpiarControles(grpFiltro);
                        cmbArea.SelectedValue = -1;
                    }
                }
            }
        }

        private void dtgPersonas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Cada vez que se selecciona un registro guarda el id_usuario de este
            _idUsuario = Convert.ToInt32(dtgPersonas.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult msgBox;
            if (dtgPersonas.Rows.Count > 0 && rdbActivos.Checked && btnBaja.Name == "btnBaja")
            {
                msgBox = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgBox == DialogResult.Yes)
                {
                    // Si el boton esta en modo baja: elimina de forma logica al usuario seleccionado

                    cn_usuario.IdUsuario = _idUsuario;
                    cn_usuario.BajaUsuario();
                    CN_Bitacora.AltaBitacora($"Usuario dado de baja ID: {_idUsuario}", "UPDATE", this.Name);
                    dtgRefresh(sender, e);
                }
            }
            if (dtgPersonas.Rows.Count > 0 && rdbInactivos.Checked && btnBaja.Name == "btnReactivar")
            {
                msgBox = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgBox == DialogResult.Yes)
                {
                    // Si el boton esta en modo reactivar: reactiva al usuario seleccionado
                    cn_usuario.IdUsuario = _idUsuario;
                    cn_usuario.ReactivarUsuario();
                    CN_Bitacora.AltaBitacora($"Usuario reactivado ID: {_idUsuario}", "UPDATE", this.Name);
                    dtgRefresh(sender, e);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Abre el formulario de alta de usuario
            this.Hide();
            frmAltaUsuario alta = new frmAltaUsuario();
            alta.ShowDialog();
            this.Show();
            dtgRefresh(sender, e);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_estado && dtgPersonas.Rows.Count > 0 && _idUsuario > 0)
            {
                // Abre el formulario de alta de usuario
                this.Hide();
                frmAltaUsuario mod = new frmAltaUsuario(_idUsuario);
                mod.ShowDialog();
                this.Show();
                dtgRefresh(sender, e);
            }
            else
            {
                MessageBox.Show(Errores.RegSelecNoActivo, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rdbActivos_CheckedChanged(object sender, EventArgs e)
        {
            // Configura los controles cuando se checkea el rdb activos
            if (rdbActivos.Checked)
            {
                btnAgregar.Enabled = true;
                btnModificar.Enabled = true;
                btnBaja.Name = "btnBaja";
                btnBaja.Text = Strings.btnBaja;

                _estado = true;
                if (dtgPersonas.DataSource != null)
                {
                    dtgRefresh(sender, e);
                    rdbActivos.Checked = _estado;
                    rdbInactivos.Checked = !_estado;
                }
            }
        }

        private void rdbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            // Configura los controles cuando se checkea el rdb inactivos
            if (rdbInactivos.Checked)
            {
                btnAgregar.Enabled = false;
                btnModificar.Enabled = false;
                btnBaja.Name = "btnReactivar";
                btnBaja.Text = Strings.btnReactivar;

                _estado = false;
                if (dtgPersonas.DataSource != null)
                {
                    dtgRefresh(sender, e);
                    rdbActivos.Checked = _estado;
                    rdbInactivos.Checked = !_estado;
                }
            }
        }

        // Funcion que refresca el dtg simulando presionar el btnFiltrar
        public void dtgRefresh(object sender, EventArgs e)
        {
            _void = true;
            btnFiltrar_Click(sender, e);
            _void = false;
        }

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
