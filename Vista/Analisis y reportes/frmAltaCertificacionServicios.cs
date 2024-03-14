using Comun;
using LogicaNegocio.Analisis_y_reportes;
using LogicaNegocio.Lenguajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Lenguajes;
using Vista.Properties;

namespace Vista.Analisis_y_reportes
{
    public partial class frmAltaCertificacionServicios : Form
    {
        private bool _mod = false; // Si es modificacion de usuario (true) o alta de usuario (false)
        private int _idEmpleado;
        private int _idCertificacion;
        private int _etapa = 0;

        int _rowIndex = -1; // Index de la fila actual
        int _idPersona = -1; // Index del id_persona de la fila actual

        // Filtros
        string _cuit;
        string _nombre;
        string _apellido;
        bool _estado = true;

        DataTable dtEtapas = new DataTable();
        public frmAltaCertificacionServicios()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario

            //dtg configura el dtg
            dtgCertificados.MultiSelect = false;
            dtgCertificados.RowHeadersVisible = false;
            dtgCertificados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCertificados.AllowUserToAddRows = false;
            dtgCertificados.AllowUserToResizeRows = false;
            dtgCertificados.ReadOnly = true;
            dtgCertificados.DataSource = null;
            dtgCertificados.Columns.Clear();

            //cmbEtapas
            Etapas.Culture = Thread.CurrentThread.CurrentUICulture;
            cmbEtapa.Items.Insert(0, Etapas.cmbEtapa_0);
            cmbEtapa.SelectedIndex = 0;
            cmbEtapa.Enabled = false;
        }
        public frmAltaCertificacionServicios(int idCertificacion, int idEmpleado, int etapa)
        {
            InitializeComponent();
            this.Name = "frmModCertificacionServicios";
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            _mod = true;

            _idCertificacion = idCertificacion;
            _idEmpleado = idEmpleado;
            _etapa = etapa;

            //dtg configura el dtg
            dtgCertificados.MultiSelect = false;
            dtgCertificados.RowHeadersVisible = false;
            dtgCertificados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCertificados.AllowUserToAddRows = false;
            dtgCertificados.AllowUserToResizeRows = false;
            dtgCertificados.ReadOnly = true;
            dtgCertificados.DataSource = null;
            dtgCertificados.Columns.Clear();
            refreshDtg(idCertificacion);

            //cmbEtapas
            Etapas.Culture = Thread.CurrentThread.CurrentUICulture;
            cmbEtapa.Items.Insert(0, Etapas.cmbEtapa_0);

            switch (etapa)
            {
                case 1:
                    cmbEtapa.Items.Insert(1, Etapas.cmbEtapa_1);
                    cmbEtapa.SelectedIndex = 1;
                    break;
                case 2:
                    cmbEtapa.Items.Insert(1, Etapas.cmbEtapa_1);
                    cmbEtapa.Items.Insert(2, Etapas.cmbEtapa_2);
                    cmbEtapa.SelectedIndex = 2;
                    break;
                case 3:
                    cmbEtapa.Items.Insert(1, Etapas.cmbEtapa_1);
                    cmbEtapa.Items.Insert(2, Etapas.cmbEtapa_2);
                    cmbEtapa.SelectedIndex = 2;
                    cmbEtapa.Enabled = false;
                    break;
            }

            //Configurar controles
            grpFiltro.Enabled = false;
            rdbActivos.Visible = false;
            rdbInactivos.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CN_CertificacionMetodos cm = new CN_CertificacionMetodos();
            CN_CertificacionServicios cs = new CN_CertificacionServicios();
            Tuple<bool, string> verif;
            switch (_mod)
            {
                default:
                    verif = cm.verif(dttFecha, dtgCertificados, _idPersona).ToTuple();

                    if (verif.Item1)
                    {
                        cs.IdEmpleado = _idPersona;
                        cs.Fecha = dttFecha.Value;
                        cs.AltaCertificacion();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(verif.Item2, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case true:
                    cs.IdCertificacion = _idCertificacion;
                    cs.Fecha = dttFecha.Value;
                    cs.FechaIndex = cmbEtapa.SelectedIndex;
                    cs.UpFechaCertificacion();
                    this.Dispose();
                    break;
            }
        }

        private void cmbEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime MaxDate;
            DateTime MinDate;
            switch (_mod)
            {
                default:

                    MaxDate = DateTime.Today;
                    dttFecha.MaxDate = MaxDate;
                    lblFechaSolicitud.Text = Etapas.lblFechaSolicitud_0;
                    break;

                case true:

                    MaxDate = DateTime.Today;
                    MinDate = Convert.ToDateTime("01/01/1753");
                    dttFecha.MaxDate = MaxDate;
                    dttFecha.MinDate = MinDate;
                    CN_CertificacionMetodos cm = new CN_CertificacionMetodos();
                    switch (cmbEtapa.SelectedIndex)
                    {
                        case 0:
                            lblFechaSolicitud.Text = Etapas.lblFechaSolicitud_0;
                            dttFecha.Value = cm.fechaNula(dtgCertificados.Rows[0].Cells[4]);
                            MaxDate = cm.fechaNula(dtgCertificados.Rows[0].Cells[5], MaxDate);
                            break;
                        case 1:
                            lblFechaSolicitud.Text = Etapas.lblFechaSolicitud_1;
                            dttFecha.Value = cm.fechaNula(dtgCertificados.Rows[0].Cells[5]);
                            MinDate = cm.fechaNula(dtgCertificados.Rows[0].Cells[4], MinDate);
                            MaxDate = cm.fechaNula(dtgCertificados.Rows[0].Cells[6], MaxDate);
                            break;
                        case 2:
                            lblFechaSolicitud.Text = Etapas.lblFechaSolicitud_2;
                            dttFecha.Value = cm.fechaNula(dtgCertificados.Rows[0].Cells[6]);
                            MinDate = cm.fechaNula(dtgCertificados.Rows[0].Cells[5], MinDate);
                            break;
                    }
                    dttFecha.MaxDate = MaxDate;
                    dttFecha.MinDate = MinDate;
                    break;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCuit.Text) && string.IsNullOrEmpty(txtNombre.Text)
                && string.IsNullOrEmpty(txtApellido.Text))
            // Entra si los campos de filtrado estan todos en su estado por defecto
            {
                MessageBox.Show(Errores.FiltroIncompleto, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            //Entra si se usa al menos uno de los filtros
            {
                _cuit = txtCuit.Text;
                _nombre = txtNombre.Text;
                _apellido = txtApellido.Text;

                CN_CertificacionServicios cs = new CN_CertificacionServicios();
                DataTable dt = cs.ConsultaPersonalCertificacion(_cuit, _nombre, _apellido, _estado);

                if (dt.Rows.Count == 0)
                {
                    // Si el dtg es ejecutado y el filtrado no devuelve registros aparece un messagebox
                    MessageBox.Show(Errores.RegNoCoincide, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    refreshDtg(dt);
                    UtilidadesForms.LimpiarControles(grpFiltro);
                }
            }
        }

        private void rdbActivos_CheckedChanged(object sender, EventArgs e)
        {

            // Configura los controles cuando se checkea el rdb activos
            if (rdbActivos.Checked)
            {
                _estado = true;
                if (dtgCertificados.DataSource != null)
                {
                    refreshDtg();
                }
            }
        }

        private void rdbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            // Configura los controles cuando se checkea el rdb inactivos
            if (rdbInactivos.Checked)
            {
                _estado = false;
                if (dtgCertificados.DataSource != null)
                {
                    refreshDtg();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void dtgCertificados_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void dtgCertificados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndex = e.RowIndex;
            _idPersona = Convert.ToInt32(dtgCertificados.Rows[_rowIndex].Cells[0].Value);
        }
        #region metodos
        public void refreshDtg(DataTable dt = null)
        {
            if (dt == null)
            {
                CN_CertificacionServicios ccs = new CN_CertificacionServicios();
                dt = ccs.ConsultaPersonalCertificacion(_cuit, _nombre, _apellido, _estado);
            }

            dtgCertificados.DataSource = dt;
            dtgCertificados.Columns[0].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgCertificados);
            dtgCertificados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void refreshDtg(int idCertificacion)
        {
            CN_CertificacionServicios cs = new CN_CertificacionServicios();
            DataTable dt = cs.ConsultaPersonaCertificacion(idCertificacion);

            dtgCertificados.DataSource = dt;
            dtgCertificados.Columns[0].Visible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgCertificados);
            dtgCertificados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

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

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }
    }
}
