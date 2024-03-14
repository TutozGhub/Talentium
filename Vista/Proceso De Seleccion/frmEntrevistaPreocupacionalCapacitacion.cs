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
using LogicaNegocio.Accesibilidad;
using LogicaNegocio.Lenguajes;
using Vista.Lenguajes;

namespace Vista.Gestion_de_Talento
{
    public partial class frmEntrevistaPreocupacionalCapacitacion : Form
    {
        CN_LogicaProcesoSeleccion proceso = new CN_LogicaProcesoSeleccion();
        CN_LogicaEntrevista logicaEntrevista = new CN_LogicaEntrevista();
        private int idCandidato;
        private bool seleccionarTab = true;
        public frmEntrevistaPreocupacionalCapacitacion()
        {
            InitializeComponent();
            DataTable DTEntrevistas = logicaEntrevista.ConsultarEntrevistas();
        }
        public int AgregarControlesEnTab(string nombreEtapa, string nombre, string apellido, string puesto,
            string estado, DateTime fecha, string entrevistador, TabPage nuevaPestana, int id_persona)
        {
            this.idCandidato= id_persona;
            nuevaPestana.Text = nombreEtapa;

            nuevaPestana.BackColor = Color.White;
            GroupBox groupBox = new GroupBox();
            groupBox.Text = "Datos del candidato";
            groupBox.Size = new Size(500, 60);
            groupBox.Location = new Point(20, 35);

            Label lblNombre = new Label();
            lblNombre.Location = new Point(40, 30);
            lblNombre.Text = "Nombre y Apellido: ";
            Label lblNombreApellido = new Label();
            lblNombreApellido.Location = new Point(150, 30);
            lblNombreApellido.Text = $"{nombre} {apellido}";
            Label lblPuestoT = new Label();
            lblPuestoT.Location = new Point(340, 30);
            lblPuestoT.Size = new Size(50, 20);
            lblPuestoT.Text = "Puesto: ";
            Label lblPuesto = new Label();
            lblPuesto.Location = new Point(400, 30);
            lblPuesto.Text = puesto;

            groupBox.Controls.Add(lblNombre);
            groupBox.Controls.Add(lblNombreApellido);
            groupBox.Controls.Add(lblPuestoT);
            groupBox.Controls.Add(lblPuesto);

            nuevaPestana.Controls.Add(groupBox);

            GroupBox groupBox2 = new GroupBox();
            groupBox2.Text = "Entrevista";
            groupBox2.Size = new Size(400, 200);
            groupBox2.Location = new Point(70, 95);

            ComboBox cmbEstado = new ComboBox();
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Items.AddRange(new string[] { "PROGRAMADA", "APTO", "NO APTO" });
            cmbEstado.Location = new Point(150, 150);
            cmbEstado.Size = new Size(200, 20);
            cmbEstado.SelectedIndex = 0;
            cmbEstado.Tag = "Estado";
            cmbEstado.Text = estado;
            

            Label lblFecha = new Label();
            lblFecha.Text = "Fecha:";
            lblFecha.Location = new Point(20, 30);

            DateTimePicker dtpFecha = new DateTimePicker();
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(150, 30);
            dtpFecha.Tag = "FechaEntrevista";
            dtpFecha.Value = fecha;
            if (fecha < DateTime.Today)
            {
                dtpFecha.MinDate = dtpFecha.Value;
            }
            else
            {
                dtpFecha.MinDate = DateTime.Today;
            }
            if (fecha > DateTime.Today)
            {
                cmbEstado.Enabled = false;
            }
            else
            {
                cmbEstado.Enabled = true;
            }

            if(dtpFecha.Value.Date > DateTime.Today)
                {
                cmbEstado.SelectedItem = "PROGRAMADA";
                cmbEstado.Enabled = false;
            }
                else
            {
                cmbEstado.Enabled = true;
            }

            Label lblArea = new Label();
            lblArea.Text = "Área:";
            lblArea.Size = new Size(50, 20);
            lblArea.Location = new Point(20, 70);

            ComboBox cmbArea = new ComboBox();
            DataTable datosArea = proceso.ObtenerAreas();
            cmbArea.DataSource = datosArea;
            cmbArea.DisplayMember = "area";
            cmbArea.ValueMember = "id_area";
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArea.Location = new Point(150, 70);
            cmbArea.Size = new Size(200, 20);

            Label lblEntrevistador = new Label();
            lblEntrevistador.Text = "Entrevistador:";
            lblEntrevistador.Location = new Point(20, 110);

            ComboBox cmbEntrevistador = new ComboBox();
            cmbEntrevistador.Location = new Point(150, 110);
            cmbEntrevistador.Size = new Size(200, 20);
            cmbEntrevistador.Tag = "Entrevistador";
            cmbEntrevistador.Text = entrevistador;

            Label lblEstado = new Label();
            lblEstado.Text = "Estado:";
            lblEstado.Location = new Point(20, 150);

            groupBox2.Controls.Add(lblFecha);
            groupBox2.Controls.Add(dtpFecha);
            groupBox2.Controls.Add(lblEntrevistador);
            groupBox2.Controls.Add(cmbEntrevistador);
            groupBox2.Controls.Add(lblEstado);
            groupBox2.Controls.Add(cmbEstado);
            groupBox2.Controls.Add(cmbArea);
            groupBox2.Controls.Add(lblArea);

            nuevaPestana.Controls.Add(groupBox2);

            Button btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(390, 300);
            btnGuardar.Size = new Size(80, 30);
            btnGuardar.Click += btnGuardar_Click;
            btnGuardar.BackColor = Color.FromArgb(72, 113, 141);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.ForeColor = Color.WhiteSmoke;

            nuevaPestana.Controls.Add(btnGuardar);
            cmbArea.SelectedIndexChanged += (sender, e) =>
            {
                DataRowView selectedArea = cmbArea.SelectedItem as DataRowView;
                int idAreaSeleccionada = Convert.ToInt32(selectedArea["id_area"]);
                DataTable DTEmpleados = proceso.ObtenerEmpleados(idAreaSeleccionada);
                DTEmpleados.Columns.Add("NombreCompleto", typeof(string), "APELLIDOS + ', ' + NOMBRES");
                cmbEntrevistador.DataSource = DTEmpleados;
                cmbEntrevistador.DisplayMember = "NombreCompleto";
            };
            dtpFecha.ValueChanged += (sender, e) =>
            {
                if (dtpFecha.Value.Date > DateTime.Today)
                {
                    cmbEstado.SelectedItem = "PROGRAMADA";
                    cmbEstado.Enabled = false;
                }
                else
                {
                    cmbEstado.Enabled = true;
                }
            };
            return id_persona;
        }

        private void NavegarTabs(int siguiente)
        {
            int indiceActual = tabEtapas.SelectedIndex;
            int nuevoIndice = indiceActual + siguiente;

            if (nuevoIndice >= 0 && nuevoIndice < tabEtapas.TabCount)
            {
                tabEtapas.SelectedIndex = nuevoIndice;
            }
        }
        private void cmbEmpleados_DropDown(object sender, EventArgs e)
        {
        }
        private void cmbEstadoEntrevista_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id_entrevista = proceso.ObtenerIDEntrevistas(tabEtapas.SelectedTab.ToString().Split('-')[1].TrimEnd('}'));
            int id_persona = this.idCandidato;
            TabPage pestañaActual = tabEtapas.SelectedTab;
            DateTime fechaEntrevista = DateTime.MinValue;
            string entrevistador = "";
            string estado = "";

            GroupBox groupBoxEntrevista = null;

            foreach (Control control in pestañaActual.Controls)
            {
                if (control is GroupBox groupBox && groupBox.Text == "Entrevista")
                {
                    groupBoxEntrevista = groupBox;
                    break;
                }
            }

            if (groupBoxEntrevista != null)
            {
                foreach (Control groupBoxControl in groupBoxEntrevista.Controls)
                {
                    if (groupBoxControl is DateTimePicker dateTimePickerFechaEntrevista)
                    {
                        fechaEntrevista = dateTimePickerFechaEntrevista.Value;
                    }
                    else if (groupBoxControl is ComboBox cmbEntrevistador && cmbEntrevistador.Tag != null && cmbEntrevistador.Tag.ToString() == "Entrevistador")
                    {
                        if (cmbEntrevistador.SelectedItem is DataRowView selectedRow)
                        {
                            entrevistador = selectedRow["NombreCompleto"].ToString();
                        }
                        else
                        {
                            entrevistador = cmbEntrevistador.Text;
                        }
                        
                    }
                    else if (groupBoxControl is ComboBox cmbEstado && cmbEstado.Tag != null && cmbEstado.Tag.ToString() == "Estado")
                    {
                        estado = cmbEstado.SelectedItem?.ToString() ?? "";
                    }
                }
            }
            bool camposIncompletos = false;
            if (string.IsNullOrEmpty(fechaEntrevista.ToString()) || string.IsNullOrEmpty(entrevistador) || string.IsNullOrEmpty(estado))
            {
                camposIncompletos = true;
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bool esInsercion = string.IsNullOrEmpty(fechaEntrevista.ToString()) && string.IsNullOrEmpty(entrevistador) && string.IsNullOrEmpty(estado);

            if (!logicaEntrevista.VerificarExistenciaEntrevista(id_persona, id_entrevista))
            {
                if(!proceso.InsertarEtapa(id_persona, id_entrevista, fechaEntrevista, entrevistador, estado, null))
                {
                    DialogResult result = MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(Errores.RegNoCargado, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if(!proceso.ModificarEtapa(id_persona, id_entrevista, fechaEntrevista, entrevistador, estado, null))
                {
                    DialogResult result = MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(Errores.RegNoCargado, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void tabEtapas_Selecting(object sender, TabControlCancelEventArgs e)
        {
        }
        private void frmEntrevistaPreocupacionalCapacitacion_Load(object sender, EventArgs e)
        {
        }
        // *************** Preocupacional **************** 

        private void dtpPreocupacional_ValueChanged(object sender, EventArgs e)
        {
        }
        private void cmbEstadoPreocupacional_DropDown(object sender, EventArgs e)
        {
        }
        private void btnGuardarP_Click(object sender, EventArgs e)
        {
        }
        private void tabEtapas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!seleccionarTab)
            {
                tabEtapas.SelectedTab = null;
            }
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            NavegarTabs(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavegarTabs(1);
        }

        private void frmEntrevistaPreocupacionalCapacitacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmConsultaProcesoDeSeleccion formDataGridView = Application.OpenForms["frmConsultaProcesoDeSeleccion"] as frmConsultaProcesoDeSeleccion;

            // Verificar si el formulario se encontró y llamar al método para cargar los datos en el DataGridView
            if (formDataGridView != null)
            {
                formDataGridView.CargarDatos();
            }
        }

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }
    }
}
