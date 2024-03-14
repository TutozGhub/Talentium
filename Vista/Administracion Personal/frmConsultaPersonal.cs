using Comun;
using LogicaNegocio.Administracion_Del_Personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio.Lenguajes;
using Vista.Lenguajes;
using LogicaNegocio.Bitacora;

namespace Vista
{
    public partial class frmConsultaPersonal : Form
    {

        CN_AdministracionDatosPersonal logicaPersona = new CN_AdministracionDatosPersonal();
        CN_AdministracionPersonalComboBox logica = new CN_AdministracionPersonalComboBox();
        bool isReport = false;
        bool inactivo = false;
        public frmConsultaPersonal()
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            dtgEmpleados.MultiSelect = false;
            dtgEmpleados.RowHeadersVisible = false;
            dtgEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgEmpleados.AllowUserToResizeRows = false;

            DataTable area = logica.ObtenerArea(true);
            cmbArea.DataSource = area;
            cmbArea.DisplayMember = "area";
            cmbArea.ValueMember = "id_area";
            cmbArea.SelectedValue = -1;
        }
        public void RecibirDatos(bool report)
        {
            this.Text = Strings.frmCandidatosConsulta;
            isReport = report;
            rdbActivos.Visible = false;
            rdbInactivos.Visible = false;
            btnModificar.Visible = false;
            btnBaja.Visible = false;
            txtNombre.Visible = false;
            txtApellido.Visible = false;
            cmbArea.Visible = false;
            lblApellido.Visible = false;
            lblNombre.Visible = false;
            lblArea.Visible = false;
        }
        private void frmConsultaPersonal_Load(object sender, EventArgs e)
        {


        }
        private void Filtros(bool inactivo, bool isRep)
        {
            DataTable persona;
            if (isRep == true)
            {
                 persona = logicaPersona.ObtenerTodosCand(txtCuit.Text);
            }
            else 
            {
                 persona = logicaPersona.ObtenerPersona();
            }
            List<Persona> personList = persona.AsEnumerable()
                .Select(row => new Persona
                {
                    id_persona = row.Field<int>("id_persona"),
                    nombres = row.Field<string>("nombres"),
                    apellidos = row.Field<string>("apellidos"),
                    cuit_cuil = row.Field<string>("cuit_cuil"),
                    nro_doc = row.Field<string>("nro_doc"),
                    id_area = row.Field<int>("id_area"),
                    id_baja = row.Field<bool>("id_baja")
                })
                .ToList();


            string filtroNombres = txtNombre.Text.Trim();
            string filtroApellidos = txtApellido.Text.Trim();
            string filtroCuil = txtCuit.Text;
            int? filtroIdArea = (int?)cmbArea.SelectedValue; 


            var resultadosFiltrados = personList.Where(persona1 =>
                (string.IsNullOrEmpty(filtroNombres) || persona1.nombres.ToLower().Contains(filtroNombres.ToLower())) &&
                (string.IsNullOrEmpty(filtroApellidos) || persona1.apellidos.ToLower().Contains(filtroApellidos.ToLower())) &&
                (string.IsNullOrEmpty(filtroCuil) || persona1.cuit_cuil.Contains(filtroCuil)) &&
            (filtroIdArea == -1 || persona1.id_area == filtroIdArea) && (persona1.id_baja == inactivo)
            ).ToList();

            if (resultadosFiltrados.Count == 0)
            {
                dtgEmpleados.DataSource = null;
                MessageBox.Show(Errores.RegNoCoincide, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dtgEmpleados.DataSource = resultadosFiltrados;
                dtgEmpleados.Columns["nombres"].HeaderText = "Nombres";
                dtgEmpleados.Columns["apellidos"].HeaderText = "Apellidos";
                dtgEmpleados.Columns["cuit_cuil"].HeaderText = "Cuit/Cuil";
                dtgEmpleados.Columns["nro_doc"].HeaderText = "DNI";

                UtilidadesForms.TraducirColumnasDtg(ref dtgEmpleados);
            }

            

            foreach (DataGridViewColumn columna in dtgEmpleados.Columns)
            {
                if (columna.Name != "nombres" && columna.Name != "apellidos" && columna.Name != "cuit_cuil" && columna.Name != "nro_doc")
                {
                    columna.Visible = false;
                }
            }

        

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Filtros(inactivo, isReport);
        }


        private void frmConsultaPersonal_Load_1(object sender, EventArgs e)
        {

        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dtgEmpleados.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dtgEmpleados.SelectedRows[0].Cells["id_persona"].Value);
                
                //Abre FormAltaPersonal y pasa el id_persona
                frmAltaPersonal frmAltaPersonal = new frmAltaPersonal(isReport);
                if (isReport)
                {
                    frmAltaPersonal.pdf = true;
                }
                frmAltaPersonal.CargarDatosPersona(id);
                frmAltaPersonal.ShowDialog();
            }
            else
            {
                MessageBox.Show(Errores.RegNoSelec, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txtCuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgEmpleados.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dtgEmpleados.SelectedRows[0].Cells["id_persona"].Value);

                // Abre FormAltaPersonal y pasa el id_persona
                frmAltaPersonal frmAltaPersonal = new frmAltaPersonal(false);
                frmAltaPersonal.CargarDatosModificacion(id, false);
                frmAltaPersonal.ShowDialog();
            }
            else
            {
                MessageBox.Show(Errores.RegNoSelec, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Filtro_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbActivos.Checked)
            {
                btnBaja.Name = "btnBaja";
                btnBaja.Text = "Dar de Baja";
                inactivo = false;
                btnModificar.Enabled = true;
            }
            if (rdbInactivos.Checked)
            {
                btnBaja.Name = "btnReactivar";
                btnBaja.Text = "Reactivar";
                inactivo = true;
                btnModificar.Enabled = false;

            }
            Filtros(inactivo, isReport);

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {


            switch (dtgEmpleados.Rows.Count)
            {
                default:
                    int id = Convert.ToInt32(dtgEmpleados.SelectedRows[0].Cells["id_persona"].Value);
                    DialogResult result;
                    switch (btnBaja.Name)
                    {
                        case "btnBaja":
                            result = MessageBox.Show(Errores.QuiereContinuar,Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                logicaPersona.BajaPersona(id);
                                CN_Bitacora.AltaBitacora($"Empleado dado de baja ID: {id}", "UPDATE", this.Name);
                                Filtros(inactivo, isReport);
                            }
                            break;
                        case "btnReactivar":
                            result = MessageBox.Show(Errores.QuiereContinuar, Errores.Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dtgEmpleados.SelectedRows.Count > 0)
                            {
                                int idper = Convert.ToInt32(dtgEmpleados.SelectedRows[0].Cells["id_persona"].Value);


                                frmAltaPersonal frmAltaPersonal = new frmAltaPersonal(false);
                                frmAltaPersonal.EsReactivacion = true; // Es una reactivación
                                frmAltaPersonal.CargarDatosModificacion(idper, false, true);
                                frmAltaPersonal.dttFechaAlta.Enabled = true;
                                frmAltaPersonal.ShowDialog();

                            }
                            if (result == DialogResult.Yes)
                            {

                            
                      
                                
                                Filtros(inactivo, isReport);
                            }
                            break;
                    }
                    break;
                case 0:
                    MessageBox.Show(Errores.RegNoSelec, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

            }
        }
        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }

           

}
