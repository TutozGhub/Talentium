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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;

namespace Vista
{
    public partial class frmAltaUsuario : Form
    {
        private bool _mod = false; // Si es modificacion de usuario (true) o alta de usuario (false)
        private int _idUsuario;

        CN_LogicaUsuarios usuario = new CN_LogicaUsuarios();
        int _rowIndex = -1; // Index de la fila actual
        int _idPersona = -1; // Index del id_persona de la fila actual
        bool configEnd = false; // Controla si la configuracion (el constructor) finalizó
        bool perfilCustom = false; // Si es un perfil personalizado es true
        DataTable dtListaBd; // Almacena los permisos existentes en la bd
        DataTable dtListaMem = new DataTable("Permisos"); // Almacena los permisos asignados al usuario que sera dado de alta
        private string emailPersona = "";

        //Constructor Alta de usuario
        public frmAltaUsuario()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            #region config

            this.Text = Strings.frmAltaUsuario;

            //dtg configura el dtg
            dtgPersonas.MultiSelect = false;
            dtgPersonas.RowHeadersVisible = false;
            dtgPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPersonas.AllowUserToAddRows = false;
            dtgPersonas.AllowUserToResizeRows = false;
            dtgPersonas.ReadOnly = true;
            dtgPersonas.DataSource = null;
            //cmb area
            cmbArea.DataSource = null;
            cmbArea.DataSource = usuario.ConsultarAreas();
            cmbArea.ValueMember = "id_area";
            cmbArea.DisplayMember = "area";
            cmbArea.SelectedValue = -1;
            //cmb perfiles
            cmbRol.DataSource = null;
            cmbRol.DataSource = usuario.ConsultarPerfiles();
            cmbRol.ValueMember = "id_grupo";
            cmbRol.DisplayMember = "Perfil";
            cmbRol.SelectedValue = -1;
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
            dtListaBd = usuario.ConsultarPermisosLst();
            lstPermisos.DataSource = dtListaBd;
            lstPermisos.ValueMember = "id_permiso";
            lstPermisos.DisplayMember = (Properties.Settings.Default.Idioma == "es-AR") ? "funcionalidad" : "funcionalidad_eng";

            lstPermisosAsignados.DataSource = null;
            lstPermisosAsignados.DataSource = dtListaMem;
            lstPermisosAsignados.ValueMember = "id_permiso";
            lstPermisosAsignados.DisplayMember = (Properties.Settings.Default.Idioma == "es-AR") ? "funcionalidad" : "funcionalidad_eng";

            #endregion

            configEnd = true;
        }

        //Constructor Modificacion de usuario
        public frmAltaUsuario(int id_usuario)
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            #region config
            _idUsuario = id_usuario;
            _mod = true;
            this.Text =
            this.Text = Strings.frmModUsuario;

            //dtg configura el dtg
            dtgPersonas.MultiSelect = false;
            dtgPersonas.RowHeadersVisible = false;
            dtgPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPersonas.AllowUserToAddRows = false;
            dtgPersonas.AllowUserToResizeRows = false;
            dtgPersonas.ReadOnly = true;

            usuario.IdUsuario = id_usuario;
            DataTable dt = usuario.ConsultarPersonaMod();

            dtgPersonas.DataSource = dt;
            dtgPersonas.Columns[0].Visible = false;
            dtgPersonas.Columns[6].Visible = false;
            dtgPersonas.Columns[7].Visible = false;
            dtgPersonas.Columns[8].Visible = false;
            dtgPersonas.Columns[9].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgPersonas);
            //Cargar datos
            txtUsuario.Text = Seguridad.DesEncriptar(dt.Rows[0][7].ToString());
            nmrCambiaCada.Value = (int)(dt.Rows[0][8]);

            //Bloqueos de controles
            grpFiltro.Enabled = false;
            dtgPersonas.Enabled = false;
            txtUsuario.Enabled = false;
            txtContrasenia.Enabled = false;
            btnCrearContrasenia.Visible = false;
            //cmb perfiles
            cmbRol.DataSource = null;
            cmbRol.DataSource = usuario.ConsultarPerfiles();
            cmbRol.ValueMember = "id_grupo";
            cmbRol.DisplayMember = "Perfil";
            try
            {
                cmbRol.SelectedValue = (int)(dt.Rows[0][9]);
            }
            catch
            {
                cmbRol.SelectedValue = -1;
            }
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
            dtListaBd = usuario.ConsultarPermisosLst();
            lstPermisos.DataSource = dtListaBd;
            lstPermisos.ValueMember = "id_permiso";
            lstPermisos.DisplayMember = (Properties.Settings.Default.Idioma == "es-AR") ? "funcionalidad" : "funcionalidad_eng";

            lstPermisosAsignados.DataSource = null;
            lstPermisosAsignados.DataSource = dtListaMem;
            lstPermisosAsignados.ValueMember = "id_permiso";
            lstPermisosAsignados.DisplayMember = (Properties.Settings.Default.Idioma == "es-AR") ? "funcionalidad" : "funcionalidad_eng";

            usuario.IdUsuario = id_usuario;
            usuario.IdPerfil = (int)(dt.Rows[0][9]);
            DataTable dtPermisosUsuario = usuario.ConsultarPermisosUsuario();
            if (dtPermisosUsuario.Rows.Count > 0)
            {
                UtilidadesForms.ConfigListbox(usuario.ConsultarPermisosLst(), ref dtListaBd, ref dtListaMem, ref lstPermisos, ref lstPermisosAsignados, true, dtPermisosUsuario);
            }


            #endregion

            configEnd = true;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int len;
            string msg;
            List<int> permisos = new List<int>(); // Lista permisos
            switch (_mod)
            {
                default:  // Si esta en modo alta 

                    usuario.UsrName = txtUsuario.Text;
                    usuario.Contrasenia = txtContrasenia.Text;
                    usuario.CambiaCada = nmrCambiaCada.Value;
                    usuario.Mail = txtEmail.Text;
                    usuario.IdPerfil = cmbRol.SelectedValue;
                    usuario.IdPersona = _idPersona;
                    usuario.RowIndex = _rowIndex;

                    if (usuario.AltaUsuario(dtListaMem, dtgPersonas))
                    {

                        this.Dispose();
                    }
                    break;

                case true: // Si esta en modo modificacion 

                    usuario.IdUsuario = _idUsuario;
                    usuario.UsrName = txtUsuario.Text;
                    usuario.Contrasenia = txtContrasenia.Text;
                    usuario.CambiaCada = nmrCambiaCada.Value;
                    usuario.Mail = txtEmail.Text;
                    usuario.IdPerfil = cmbRol.SelectedValue;
                    usuario.IdPersona = _idPersona;
                    usuario.RowIndex = _rowIndex;

                    usuario.ModificarUsuario(dtListaMem);
                    CN_Bitacora.AltaBitacora($"Usuario modificado ID: {_idUsuario}", "UPDATE", this.Name);
                    this.Dispose();
                    break;
            }
        }

        private void btnCrearContrasenia_Click(object sender, EventArgs e)
        {
            // Crea una contraseña aleatoria para el usuario
            txtContrasenia.Text = Seguridad.GenerarStringAleatorio();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCuit.Text) && string.IsNullOrEmpty(txtNombre.Text)
                && string.IsNullOrEmpty(txtApellido.Text) && (int)cmbArea.SelectedValue == -1)
            // Entra si los campos de filtrado estan todos en su estado por defecto
            {
                MessageBox.Show(Errores.FiltroIncompleto, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            //Entra si se usa al menos uno de los filtros
            {
                DataTable dt = usuario.ConsultarPersonalAltaUsuario(txtCuit.Text, txtNombre.Text, txtApellido.Text, (int)cmbArea.SelectedValue);

                if (dt.Rows.Count == 0)
                {
                    // Si el dtg es ejecutado y el filtrado no devuelve registros aparece un messagebox
                    MessageBox.Show(Errores.RegNoCoincide, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    UtilidadesForms.TraducirColumnasDtg(ref dtgPersonas);
                }
            }
            dtgPersonas.AutoResizeColumns();
        }

        private void dtgPersonas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            switch (_mod)
            {
                default: // Si esta en modo alta 

                    // Carga variables y carga el lblDatosDtg
                    _rowIndex = e.RowIndex;
                    _idPersona = Convert.ToInt32(dtgPersonas.Rows[e.RowIndex].Cells[0].Value);
                    emailPersona = dtgPersonas.Rows[e.RowIndex].Cells[6].Value.ToString();
                    if (chcEmail.Checked == false)
                    {
                        txtEmail.Text = emailPersona;
                    }
                    break;
                case true: // Si esta en modo modificacion 

                    // Carga variables y carga el lblDatosDtg
                    _rowIndex = e.RowIndex;
                    _idPersona = Convert.ToInt32(dtgPersonas.Rows[e.RowIndex].Cells[0].Value);
                    emailPersona = dtgPersonas.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtEmail.Text = emailPersona;
                    dtgPersonas.AutoResizeColumns();
                    break;
            }

        }

        private void btnAsignarPermisos_Click(object sender, EventArgs e)
        {
            // Mueve el permiso seleccionado a la derecha
            UtilidadesForms.moverListboxRow(lstPermisos, lstPermisosAsignados, dtListaBd, dtListaMem, lstPermisos.SelectedIndex);
            PerfilCustom();
        }
        private void lstPermisos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Mueve el permiso seleccionado a la derecha
            UtilidadesForms.moverListboxRow(lstPermisos, lstPermisosAsignados, dtListaBd, dtListaMem, lstPermisos.SelectedIndex);
            PerfilCustom();
        }

        private void btnDesasignarPermisos_Click(object sender, EventArgs e)
        {
            // Mueve el permiso seleccionado a la izquierda
            UtilidadesForms.moverListboxRow(lstPermisosAsignados, lstPermisos, dtListaMem, dtListaBd, lstPermisosAsignados.SelectedIndex);
            PerfilCustom();
        }

        private void lstPermisosAsignados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Mueve el permiso seleccionado a la izquierda
            UtilidadesForms.moverListboxRow(lstPermisosAsignados, lstPermisos, dtListaMem, dtListaBd, lstPermisosAsignados.SelectedIndex);
            PerfilCustom();
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se encarga de cargar el perfil seleccionado en los permisos asignados
            if (configEnd && !perfilCustom)
            {
                int id_perfil = -1;
                try
                {
                    id_perfil = (int)cmbRol.SelectedValue;
                }
                catch { }

                usuario.IdPerfil = id_perfil;
                DataTable dtPermisosPerfil = usuario.ConsultarPermisosPerfil();
                DataTable dtPermisosDef = usuario.ConsultarPermisosLst();

                if (id_perfil != -1)
                {
                    // Si se selecciona un perfil especifico se cargan los permisos
                    UtilidadesForms.ConfigListbox(dtPermisosDef, ref dtListaBd, ref dtListaMem, ref lstPermisos, ref lstPermisosAsignados, true, dtPermisosPerfil);
                }
                else
                {
                    // Si se selecciona un perfil personalizado se establecen por defecto (todos los permisos a la izquierda)
                    UtilidadesForms.ConfigListbox(dtPermisosDef, ref dtListaBd, ref dtListaMem, ref lstPermisos, ref lstPermisosAsignados);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chcEmail_CheckedChanged(object sender, EventArgs e)
        {
            switch (chcEmail.Checked)
            {
                default:
                    txtEmail.ReadOnly = true;
                    txtEmail.Text = emailPersona;
                    break;
                case true:
                    txtEmail.ReadOnly = false;
                    txtEmail.Text = "";
                    break;
            }
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
                PerfilCustom();
            }
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
                PerfilCustom();
            }
        }
        // Funciones
        // Configura el los listbox en base a una lista de permisos

        // Pone el Perfil personalizado sin alterar el estado de los listbox ni los datatables de permisos
        public void PerfilCustom()
        {
            if ((int)cmbRol.SelectedValue != -1)
            {
                perfilCustom = true;
                cmbRol.SelectedValue = -1;
                perfilCustom = false;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }
        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancela la entrada de caracteres no numéricos

            }
        }
        private void SoloLetras(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada de caracteres no alfabéticos

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
    }
}
