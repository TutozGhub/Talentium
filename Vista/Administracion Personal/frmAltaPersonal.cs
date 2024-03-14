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
using LogicaNegocio.Administracion_Del_Personal;
using LogicaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Text.RegularExpressions;


namespace Vista
{
    public partial class frmAltaPersonal : Form
    {

        
        //instancias a clases
        CN_AdministracionPersonalComboBox logica= new CN_AdministracionPersonalComboBox();
        CN_AdministracionDatosPersonal logicaPersona = new CN_AdministracionDatosPersonal();

        private bool esCandidato;
        private bool esReactivicacion;
        private bool esEmpleado;

        private DateTime? fechaNull = new DateTime(1900, 1, 1);

        private byte[] foto;
        //variables
        private bool inicial = true;
        private int infoLaborales = 0;
        private int infoAcademicos = 1;

        private int nivelEspaniol = -1;
        private int nivelIngles = -1;

        private DateTime fn;
        private DateTime fa;
        private bool _mod = false;

        private int _id_persona;
           
        List<InfoAcademicoDto> infoAcademic = new List<InfoAcademicoDto>();
        List<IdiomaDto> infoIdiom = new List<IdiomaDto>();
        List<infoLaboralDto> infoLabora = new List<infoLaboralDto>();


        List<IdiomaMostrar> mostrarIdioma = new List<IdiomaMostrar>();
        List<NivelProgresoMostrar> mostrarProgresoNivel = new List<NivelProgresoMostrar>();
        
        public frmAltaPersonal(bool esCandidato)
        {
            InitializeComponent();
            DeshabilitarCampos();
            this.esCandidato = esCandidato;
         
            this.esReactivicacion = false;

            dtpFechaDeNacimiento.MaxDate = DateTime.Today.AddYears(-18);

          
            inicial = false;


            tabControl.TabPages[1].Enabled = false;
            tabControl.TabPages[2].Enabled = false;


            DataTable idioma = logica.ObtenerIdioma();
            cmbIdioma.DataSource = idioma;
            cmbIdioma.DisplayMember = "idioma";
            cmbIdioma.ValueMember = "id_idiomas";
            cmbIdioma.SelectedIndex = -1;



            DataTable provincia = logica.ObtenerProvincia();
            cmbProvincia.DataSource = provincia;
            cmbProvincia.DisplayMember = "provincia";
            cmbProvincia.ValueMember = "id_provincia";
            cmbProvincia.SelectedIndex = -1;

            DataTable genero = logica.ObtenerGenero();
            cmbGenero.DataSource = genero;
            cmbGenero.DisplayMember = "genero";
            cmbGenero.ValueMember = "id_genero";
            cmbGenero.SelectedIndex = -1;

            DataTable tipotel = logica.ObtenerTipoTel();
            cmbTipoTelAlternativo.DataSource = tipotel;
            cmbTipoTelAlternativo.DisplayMember = "tipo";
            cmbTipoTelAlternativo.ValueMember = "id_tipo";
            cmbTipoTelAlternativo.SelectedIndex = -1;
            cmbTipoTel.DataSource = tipotel.Copy();
            cmbTipoTel.DisplayMember = "tipo";
            cmbTipoTel.ValueMember = "id_tipo";
            cmbTipoTel.SelectedIndex = -1;

            DataTable estadocivil = logica.ObtenerEstadoCivil();
            cmbEstadoCivil.DataSource = estadocivil;
            cmbEstadoCivil.DisplayMember = "estado_civil";
            cmbEstadoCivil.ValueMember = "id_estado_civil";
            cmbEstadoCivil.SelectedIndex = -1;


            DataTable nacionalidad = logica.ObtenerNacionalidad();
            cmbNacionalidad.DataSource = nacionalidad;
            cmbNacionalidad.DisplayMember = "nacionalidad";
            cmbNacionalidad.ValueMember = "id_nacionalidad";
            cmbNacionalidad.SelectedIndex = -1;

            DataTable tipodoc = logica.ObtenerTipoDoc();
            cmbTipoDoc.DataSource = tipodoc;
            cmbTipoDoc.DisplayMember = "tipo_doc";
            cmbTipoDoc.ValueMember = "id_tipo_doc";
            cmbTipoDoc.SelectedIndex = -1;

            cmbPartido.SelectedIndex = -1;

            DataTable progreso = logica.ObtenerProgreso();
            cmbProgreso.DataSource = progreso;
            cmbProgreso.DisplayMember = "estado_progreso";
            cmbProgreso.ValueMember = "id_progreso";
            cmbProgreso.SelectedIndex = -1;

            DataTable convenio = logica.ObtenerConvenio();
            cmbConvenio.DataSource = convenio;
            cmbConvenio.DisplayMember = "convenio";
            cmbConvenio.ValueMember = "id_convenio";
            cmbConvenio.SelectedIndex = -1;


            DataTable puesto = logica.ObtenerPuesto();
            cmbPuesto.DataSource = puesto;
            cmbPuesto.DisplayMember = "puesto";
            cmbPuesto.ValueMember = "id_puesto";
            cmbPuesto.SelectedIndex = -1;

            DataTable area = logica.ObtenerArea();

            cmbArea.DataSource = area;
            cmbArea.DisplayMember = "area";
            cmbArea.ValueMember = "id_area";
            cmbArea.SelectedIndex = -1;

            //ComboBox Solapa Academico*************

            // Agrega los años desde 1900 hasta el año actual a la lista
            int anioActual = DateTime.Now.Year;
            List<string> listaDeAnios = new List<string>();

            for (int i = anioActual; i >= 1900; i--)
            {
                listaDeAnios.Add(i.ToString());
            }
            // Selecciona el ComboBox en el cual se cargan los años
            cmbIngreso.Items.AddRange(listaDeAnios.ToArray());
            cmbIngreso.SelectedIndex = -1;
            cmbEgreso.SelectedIndex = -1;
            DataTable nivelacademico = logica.ObtenerNivelAcademico();
            cmbNivelAcademico.DataSource = nivelacademico;
            cmbNivelAcademico.DisplayMember = "nivel";
            cmbNivelAcademico.ValueMember = "id_nivel";
            cmbNivelAcademico.SelectedIndex = -1;
            //ComboBox Solapa Laboral
            cmbLaboralIngreso.Items.AddRange(listaDeAnios.ToArray());
            cmbLaboralEgreso.Items.AddRange(listaDeAnios.ToArray());
            cmbLaboralIngreso.SelectedIndex = -1;
            cmbLaboralEgreso.SelectedIndex = -1;

 

        }
        public bool EsReactivacion
        {
            get { return esReactivicacion; }
            set
            {
                esReactivicacion = value;
                if (value)
                {
                    // Si es reactivación, habilitar el campo dttFechaAlta
                    dttFechaAlta.Enabled = true;
                }
            }
        }
        private void frmAltaPersonal_Load(object sender, EventArgs e)
        {
            if (_mod)
            {
                dtpFechaDeNacimiento.Value = fn;
                dttFechaAlta.Value = fa;
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
      

        }

        private void button6_Click(object sender, EventArgs e)
        {
   
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
    
        }

        private void button13_Click(object sender, EventArgs e)
        {
         
        }

        private void button14_Click(object sender, EventArgs e)
        {
   
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
          
        }

        //validar cuit
        private void btbValidarCuil(object sender, EventArgs e)
        {
            string dniIngresado = txtDni.Text;
            string cuilIngresado = txtCuitCuil.Text;
            if (string.IsNullOrWhiteSpace(txtCuitCuil.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
            }
            else
            {
                // Verificar si la entrada contiene solo números y tiene exactamente 11 dígitos
                if (EsNumero(txtCuitCuil.Text))
                {
                    if (txtCuitCuil.Text.Length == 11)
                    {
                        bool valor = logicaPersona.ValidarCuit(txtCuitCuil.Text.Trim());
                        if (valor)
                        {
                            DeshabilitarCampos();
                            MessageBox.Show("El Cuit/Cuil ya esta asociado a un empleado");

                        }
                        else
                        {
               
                            HabilitarCampos();
                            txtCuitCuil.Enabled = false;
                            pctFoto.Enabled = true;
                            string numerosCuil = cuilIngresado.Substring(2, 8);
                            txtDni.Text = numerosCuil;
                        }
                    }
                    else
                    {
                        DeshabilitarCampos();
                        MessageBox.Show("El campo debe contener 11 digitos.");
                    }
                }
                else
                {
                    DeshabilitarCampos();
                    MessageBox.Show("La entrada debe contener solamente numeros.");
                }
            }
            if (esCandidato)
            {
                cmbConvenio.Enabled = false;
                dttFechaAlta.Enabled = false;
            }
        }
   
        private bool EsNumero(string input )
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false; // La cadena contiene caracteres que no son números
                }
            }
            return true; // La cadena contiene solo números
        }

        //BOTTON PARA MODIFICAR Y GUARDAR
        private void button9_Click(object sender, EventArgs e)
        {
            switch (btnGuardar.Name)
            {
                case "btnGuardar":

            Tuple<bool, string> validacion = validarTodos();
            if (validacion.Item1)
            {
                #region Mapeo
                Persona insert = new Persona();
             
                if (pctFoto.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pctFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    insert.foto_perfil = ms.GetBuffer();
                }
                else
                {
                    insert.foto_perfil = new byte[0];
                }

                insert.apellidos = txtApellidos.Text;
                insert.nombres = txtNombres.Text;
                insert.id_tipo_doc = int.Parse(cmbTipoDoc.SelectedValue.ToString());
                insert.nro_doc = txtDni.Text;
                insert.cuit_cuil = txtCuitCuil.Text;
                insert.calle = txtCalle.Text;
                insert.nro = txtNro.Text.Length;
                insert.dpto = txtDpto.Text;
                insert.piso = txtPiso.Text;
                insert.id_localidad = int.Parse(cmbLocalidad.SelectedValue.ToString());
                insert.id_puesto = int.Parse(cmbPuesto.SelectedValue.ToString());
                insert.id_area = int.Parse(cmbArea.SelectedValue.ToString());
                insert.email = txtEmail.Text;
                insert.id_nacionalidad = int.Parse(cmbNacionalidad.SelectedValue.ToString());
                insert.id_genero = int.Parse(cmbGenero.SelectedValue.ToString());
                insert.fecha_nacimiento = dtpFechaDeNacimiento.Value;
                insert.id_estado_civil = int.Parse(cmbEstadoCivil.SelectedValue.ToString());
                insert.hijos = (int)nupHijos.Value;
                insert.candidato = esCandidato;
                        if (esCandidato)
                        {
                            insert.id_convenio = 0;
                            insert.fecha_alta = (DateTime) fechaNull;
                        } else
                        {
                            insert.id_convenio = int.Parse(cmbConvenio.SelectedValue.ToString());
                            insert.fecha_alta = dttFechaAlta.Value;
                        }

                        //CONSULTAR
                //insert.id_convenio = int.Parse(cmbConvenio.SelectedValue.ToString());
                //insert.fecha_alta = dttFechaAlta.Value;
                
                insert.telefono = txtTelefono.Text;
                insert.id_tipo = (int)cmbTipoTel.SelectedValue;
                insert.telefono_alternativo = txtTelefonoAlternativo.Text;
                insert.id_tipo_alternativo = (int)cmbTipoTelAlternativo.SelectedValue;
                insert.contacto = txtContacto.Text;
                

                #endregion

                lblFaltanCampos2.Visible = false;
                int id_persona = logicaPersona.InsertarPersona(insert /*infoLaborales, infoAcademicos*/);
                logicaPersona.InsertarInfo(id_persona,/*infoacademico, infolaboral, listaIdiomas,*/ infoIdiom,infoLabora,infoAcademic);

                MessageBox.Show("Todos los datos se cargaron correctamente.");
                this.Dispose();

            }
            else
            {
                lblFaltanCampos2.Visible = true;
                MessageBox.Show($"Faltan campos obligatorios de:{validacion.Item2}");
            }
                    break;
                case "btnModificar":

                    Tuple<bool, string> validacion1 = validarTodos();
                    if (validacion1.Item1)
                    {
                        #region

                        Persona modify = new Persona();

                    modify.id_persona = _id_persona;
                    modify.nombres = txtNombres.Text;
                    modify.apellidos = txtApellidos.Text;
                    modify.id_tipo_doc = (int)cmbTipoDoc.SelectedValue;
                    modify.nro_doc = txtDni.Text;
                    modify.email = txtEmail.Text;
                    modify.id_nacionalidad = (int)cmbNacionalidad.SelectedValue;
                    modify.id_genero = (int)cmbGenero.SelectedValue;
                    modify.hijos = (int)nupHijos.Value;
                    modify.id_area = (int)cmbArea.SelectedValue;
                    modify.id_convenio = (int)cmbConvenio.SelectedValue;
                    modify.id_localidad = (int)cmbLocalidad.SelectedValue;
                    modify.calle = txtCalle.Text;
                    modify.nro = int.Parse(txtNro.Text);
                    modify.piso = txtPiso.Text;
                    modify.dpto = txtDpto.Text;
                    modify.fecha_nacimiento = dtpFechaDeNacimiento.Value;
                    modify.fecha_alta = dttFechaAlta.Value;
                    modify.id_estado_civil = (int)cmbEstadoCivil.SelectedValue;
                    modify.telefono = txtTelefono.Text;
                    modify.id_tipo = (int)cmbTipoTel.SelectedValue;
                    modify.telefono_alternativo = txtTelefonoAlternativo.Text;
                    modify.id_tipo_alternativo = (int)cmbTipoTelAlternativo.SelectedValue;
                    modify.contacto = txtContacto.Text;

                    //ACADEMICOS

                        if (pctFoto.Image != null)
                        {
                            try
                            {
                                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                                pctFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                modify.foto_perfil = ms.GetBuffer();
                            }
                            catch
                            {
                                modify.foto_perfil = foto;
                            }
                        }
                        else
                        {

                            modify.foto_perfil = new byte[0];
                        }

                    lblFaltanCampos.Visible = false;
                    lblFaltanCampos1.Visible = false;
                    lblFaltanCampos2.Visible = false;
                    logicaPersona.InsertarInfo(modify.id_persona/*,infoacademico,infolaboral,listaIdiomas*/, infoIdiom,infoLabora, infoAcademic);
                    logicaPersona.ActualizarDatos(modify);
                        //logicaPersona.ActualizarDatosAcademicos(modify,cantidad);
                        //logicaPersona.ActualizarDatosLaborales(modify,cantidad);
                        //logicaPersona.ActualizarIdioma(modify, id_persona);
                        if(esReactivicacion == true)
                        {
                            logicaPersona.ReactivarPersona(modify.id_persona);
                        }
                        
                        MessageBox.Show("Los datos se han actualizado correctamente.");
                    this.Dispose();
                    }
                    else
                    {
                        lblFaltanCampos2.Visible = true;
                        MessageBox.Show($"Faltan campos obligatorios de:{validacion1.Item2}");
                    }
                    #endregion
                    break;
            }
        }

   

        //BOTON PARA VALIDAR TAB "INFORMACION ACADEMICA"
        private void button8_Click(object sender, EventArgs e)
        {
            ValidarDataGrid();
            //if (validarVacios(tabAcademicos, infoAcademicos))
            // {
            //     lblFaltanCampos1.Visible = false;
            //     tabControl.TabPages[2].Enabled = true;
            //     RestaurarColorPredeterminado(tabAcademicos);
            //     tabControl.SelectedTab = tabLaborales;
            // }
            // else
            // {
            //     lblFaltanCampos1.Visible = true;
            //     MessageBox.Show("Faltan campos obligatorios");
            // }
        }

        //BOTON PARA VALIDAR TAB "INFORMACION PERSONAL"
        private void button4_Click(object sender, EventArgs e)
        {

            if (validarVacios(tabPersonales))
            {
                lblFaltanCampos.Visible = false;
                tabControl.TabPages[1].Enabled = true;
                RestaurarColorPredeterminado(tabPersonales);
                tabControl.SelectedTab = tabAcademicos;
            }
            else
            {
                lblFaltanCampos.Visible = true;
                MessageBox.Show("Faltan campos obligatorios");
            }
        }
        //BOTON PARA AGREGAR Y ELIMINAR FOTO
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Configura el cuadro de diálogo para seleccionar archivos de imagen
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.png;*.bmp;*.gif|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lee la imagen seleccionada
                    string rutaImagen = openFileDialog.FileName;
                    System.Drawing.Image imagen = System.Drawing.Image.FromFile(rutaImagen);

                    // Muestra la imagen en el PictureBox
                    pctFoto.SizeMode = PictureBoxSizeMode.Zoom;
                    pctFoto.Image = imagen;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btbEliminarImagen_Click(object sender, EventArgs e)
        {
            pctFoto.Image = null;
        }

        //METODOS
        #region Metodos
        private void RestaurarColorPredeterminado(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is GroupBox)
                {
                    RestaurarColorPredeterminado((GroupBox)c);
                }
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty(c.Text))
                    {
                        errorProvider1.SetError(c,""); // Limpia el mensaje de error
                    }
                }
            }
        }
       /* private bool validarVacios(Control control, int count = -1)
        {
            bool todosCompletos = true;
            foreach (Control c in control.Controls)
            {
                if (c is GroupBox grp)
                {
                    if (!validarVacios(grp, count))
                    {
                        todosCompletos = false;
                    }
                }
                if (c is TextBox txt &&
                    !string.IsNullOrEmpty(c.AccessibleDescription) &&
                    (count == -1 | c.AccessibleDescription.Length - 1 < count))
                {
                    if (string.IsNullOrWhiteSpace(c.Text))
                    {
                        //errorProvider1.SetError(txt, "Oblicatiorio");
                        cambiarColorLabel(txt, Color.Red);
                        todosCompletos = false;
                    }
                    else
                    {
                        cambiarColorLabel(txt, Color.Black);
                        //errorProvider1.SetError(txt, "");
                    }
                }

                if (c is ComboBox cmb &&
                    !string.IsNullOrEmpty(c.AccessibleDescription) &&
                    (count == -1 | c.AccessibleDescription.Length - 1 < count) && cmb.Enabled == true)
                {
                    if (cmb.SelectedIndex == -1)
                    {
                        //errorProvider1.SetError(c, "Oblicatiorio");
                        cambiarColorLabel(cmb, Color.Red);
                        todosCompletos = false;
                    }
                    else
                    {
                        cambiarColorLabel(cmb, Color.Black);
                        //errorProvider1.SetError(c, "");
                    }
                }
            }
            return todosCompletos;
        }*/


        private bool validarCorreoElectronico(string email)
        {
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, patronCorreo);
        }

        private Tuple<bool,string> validarTodos()
        {
            string msg = "";
            bool persona = validarVacios(tabPersonales);
            if (!persona) msg += "\n" + tabPersonales.Text;
            return (persona /*&& academico && laboral*/, msg).ToTuple();
        }

        private void cambiarColorLabel(Control control, Color color)
        {
            foreach (Control c in control.Parent.Controls)
            {
                if (c is Label lbl && lbl.Tag != null &&
                    lbl.Tag.ToString() == control.Name)
                {
                    lbl.ForeColor = color;
                }
            }            
        }
        public void HabilitarCampos()
        {


            foreach (TabPage tabPage in tabControl.TabPages)
            {
                foreach (GroupBox groupBox in tabPage.Controls.OfType<GroupBox>())
                {
                    foreach (Control control in groupBox.Controls)
                    {
                      
                        grpNivelIdiomas.Enabled = true;
                        btnContinuar1.Enabled = true;
                        btnContinuar2.Enabled = true;
                        btnEditarImagen.Enabled = true;
                        btnEliminarImagen.Enabled = true;

                        control.Enabled = true; // Habilitar todos los controles dentro del GroupBox
                    }
                }
            }
        }
        public void DeshabilitarCampos()
        {

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                foreach (GroupBox groupBox in tabPage.Controls.OfType<GroupBox>())
                {
                    foreach (Control control in groupBox.Controls)
                    {
                        if ((control is TextBox || control is ComboBox || control is NumericUpDown || control is DateTimePicker) && control != txtCuitCuil)
                        {
                            //grpEspaniol.Enabled = false;
                            grpNivelIdiomas.Enabled = false;
                            
                            btnContinuar1.Enabled = false;
                            btnEditarImagen.Enabled = false;
                            btnEliminarImagen.Enabled = false;
                            control.Enabled = false; // Deshabilitar todos los TextBox y ComboBox excepto el TextBox específico

                        }
                    }
                }
            }
        }
        private void BotonesInvisibles()
        {
            Button[] botones = { btnValidar,btnContinuar1,btnContinuar2,btnGuardar,btnEditarImagen,btnEliminarImagen,btnPdf,btnAtrasAcademico,btnAtrasLaboral
            ,btnAgregarIdioma,btnEliminarIdioma,btnAgregar,btnEliminarAcademico,AgregarLaboral,btnEliminarLaboral};

            // Ocultar todos los botones en el arreglo
            foreach (Button boton in botones)
            {
                boton.Visible = false;
            }
        }
        private void BotonesInvisiblesModificacion()
        {

            Button[] botonesOcultar = {btnValidar};
            foreach (Button botonOcultar in botonesOcultar)
            {
                botonOcultar.Visible = false;
            }
        }
        private void BotonesVisibles()
        {
            Button[] botones = { btnValidar,btnContinuar1,btnContinuar2,btnGuardar,btnEditarImagen,btnEliminarImagen};

            foreach (Button boton in botones)
            {
                boton.Visible = true;
            }
        }
        public void Visibilizar(string nombreControl, int len)
        {
            for (int i = 1; i <= len; i++)
            {
                string groupName = nombreControl + i;
                Control control = Controls.Find(groupName, true).FirstOrDefault();

                if (control != null && control is GroupBox)
                {
                    GroupBox groupBox = (GroupBox)control;
                    groupBox.Visible = true;
                }
            }
        }
        #endregion

        private void cmbConvenio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //LLENAR LOS COMBOBOX Localidad,Partido y Provincia + CodigoPostal.
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView provinciaSeleccionada = cmbProvincia.SelectedItem as DataRowView;
            if (provinciaSeleccionada != null)
            {
                int idProvinciaSeleccionada = Convert.ToInt32(provinciaSeleccionada["id_provincia"]);
                DataTable DTPartidos = logica.ObtenerPartido(idProvinciaSeleccionada);

                if (DTPartidos != null && DTPartidos.Rows.Count > 0)
                {
                    cmbPartido.DataSource = DTPartidos;
                    cmbPartido.DisplayMember = "partido";
                    cmbPartido.ValueMember = "id_partido";
                }
                else
                {
                    cmbPartido.DataSource = null;
                    cmbPartido.Items.Clear();
                }
            }

        }
        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView partidoSeleccionada = cmbPartido.SelectedItem as DataRowView;
            if (partidoSeleccionada != null)
            {
                int idPartidoSeleccionada = Convert.ToInt32(partidoSeleccionada["id_partido"]);
                DataTable DTLocalidades = logica.ObtenerLocalidades(idPartidoSeleccionada);

                if (DTLocalidades != null && DTLocalidades.Rows.Count > 0)
                {
                    cmbLocalidad.DataSource = DTLocalidades;
                    cmbLocalidad.DisplayMember = "localidad";
                    cmbLocalidad.ValueMember = "id_localidad";
                }
                else
                {
                    cmbLocalidad.DataSource = null;
                    cmbLocalidad.Items.Clear();
                }
            }
        }
        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView partidoSeleccionada = cmbLocalidad.SelectedItem as DataRowView;
            string variable = partidoSeleccionada["cod_postal"].ToString();
            txtCodigoPostal.Text = variable;
        }


        //CONTROLES MODIFICADOS
        private void button16_Click(object sender, EventArgs e)
        {
       
            infoAcademicos++;

        }
        private void button17_Click(object sender, EventArgs e)
        {
            grpExp1.Visible = true;
            btnMasLaborales1.Visible = false;
            lblAgregarExperienciaLaboral.Visible = false;

            infoLaborales++;
        }
        private void button18_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        
        }


        //CONTROLES CON EVENTOS
        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        private void txtTelefonoAlternativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        private void txtNro_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }
        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }
        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);

        }
        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }
        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }
        private void txtTitulo1_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        private void txtTitulo2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }


        private void SoloLetras(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada de caracteres no alfabéticos

            }
        }
        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancela la entrada de caracteres no numéricos

            }
        }

        private void Espaniol_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Ingles_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBasicoEn.Checked)
            {
                nivelIngles = 0;
            }
            if (rdbIntermedioEn.Checked)
            {
                nivelIngles = 1;
            }
            if (rdbAvanzadoEn.Checked)
            {
                nivelIngles = 2;
            }
            if (rdbNativoEn.Checked)
            {
                nivelIngles = 3;
            }
            if (btnContinuar2.Enabled == false && nivelEspaniol != -1 && nivelIngles != -1)
            {
                btnAtrasAcademico.Enabled = true;
                btnContinuar2.Enabled = true;
            }
        }



        //Consulta
       /* public void CargarDatosPersona(int id_persona, Persona modify = null)
        {

            _mod = true;
            
            tabControl.TabPages[1].Enabled = true;
            tabControl.TabPages[2].Enabled = true;
            DeshabilitarCampos();
            BotonesInvisibles();
            txtCuitCuil.Enabled = false;
    
            Persona insert = new Persona();
  
            logicaPersona.ObtenerPersona(insert, id_persona, ref infoAcademicos, ref infoLaborales);

            //PERSONAL
            //TextBox
            txtCuitCuil.Text = insert.cuit_cuil;
            txtApellidos.Text = insert.apellidos;
            txtNombres.Text = insert.nombres;
            txtDni.Text = insert.nro_doc;
            txtEmail.Text = insert.email;
            txtTelefono.Text = insert.telefono;
            txtTelefonoAlternativo.Text = insert.telefono_alternativo;
            txtContacto.Text = insert.contacto;
            txtCalle.Text = insert.calle;
            txtNro.Text = insert.nro.ToString();
            txtDpto.Text = insert.dpto;
            txtPiso.Text = insert.piso;
            //ComboBox
            cmbTipoDoc.SelectedValue = insert.id_tipo_doc;
            cmbTipoTel.SelectedValue = insert.id_tipo;
            cmbTipoTelAlternativo.SelectedValue = insert.id_tipo_alternativo;
            cmbNacionalidad.SelectedValue = insert.id_nacionalidad;
            cmbGenero.SelectedValue = insert.id_genero;
            cmbEstadoCivil.SelectedValue = insert.id_estado_civil;
            cmbArea.SelectedValue = insert.id_area;
            cmbPuesto.SelectedValue = insert.id_puesto;
            cmbConvenio.SelectedValue = insert.id_convenio;
            cmbProvincia.SelectedValue = insert.id_provincia;
            cmbPartido.SelectedValue = insert.id_partido;
            cmbLocalidad.SelectedValue = insert.id_localidad;
            //DateTime y Numeric
            nupHijos.Value = insert.hijos;
         
            fn = insert.fecha_nacimiento;
            fa = insert.fecha_alta;

            if (insert.foto_perfil != null && insert.foto_perfil.Length > 0)

            {
                byte[] imagenBytes = (byte[])insert.foto_perfil;
                foto = imagenBytes;
                using (MemoryStream stream = new MemoryStream(imagenBytes))
                {
                    System.Drawing.Image imagen = System.Drawing.Image.FromStream(stream);
                    pctFoto.Image = imagen;
                    pctFoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            //ACADEMICOS
            DataTable infoAcademico = logicaPersona.ObtenerInfoAcademico(id_persona);

            infoAcademic = infoAcademico.AsEnumerable().Select(row => new InfoAcademicoDto {
            Institucion = row.Field<string>("institucion"),
            Ingreso = row.Field<int>("año_ingreso"),
            Egreso = row.Field<int>("año_egreso"),
            Titulo = row.Field<string>("titulo"),
                Nivel = row.Field<int>("id_nivel"),
                Progreso = row.Field<int>("id_progreso")

            }).ToList();
            foreach (var item in infoAcademic)
            {
                NivelProgresoMostrar progresonivelMostrar = new NivelProgresoMostrar();
                progresonivelMostrar = logicaPersona.ObtenerDescripcionProgresoNivel(item.Nivel, item.Progreso);
                progresonivelMostrar.Insitutcion = item.Institucion.ToString();
                progresonivelMostrar.Titulo = item.Titulo.ToString();
                progresonivelMostrar.Ingreso = item.Ingreso.ToString();
                progresonivelMostrar.Egreso = item.Egreso.ToString();

                mostrarProgresoNivel.Add(progresonivelMostrar);
            }
            dgvAcademico.DataSource = null;
            dgvAcademico.DataSource = mostrarProgresoNivel;


            //LABORAL
            DataTable infoLaboral = logicaPersona.ObtenerInfoLaboral(id_persona);

            infoLabora = infoLaboral.AsEnumerable().Select(row => new infoLaboralDto {

                Puesto = row.Field<string>("puesto"),
                Empresa = row.Field<string>("empresa"),
                Fecha_Ingreso = row.Field<int>("fecha_ingreso"),
                Fecha_Egreso = row.Field<int>("fecha_egreso"),
                Personal_A_Cargo = row.Field<int>("personal_a_cargo")
            }).ToList();

            dgvLaboral.DataSource = infoLabora;

            //IDIOMA

            DataTable infoIdioma = logicaPersona.ObtenerIdioma(id_persona);

            //lo trae de la base de datos y no de la lista

            infoIdiom = infoIdioma.AsEnumerable().Select(row => new IdiomaDto {
               Nivel = row.Field<int> ("nivel_idioma"),
                Idioma = row.Field<int> ("id_idiomas")
            }).ToList();

            foreach (var item in infoIdiom)
            {
                IdiomaMostrar idiomaMostrar = new IdiomaMostrar();
                idiomaMostrar.IdiomaNombre = logicaPersona.ObtenerDescripcionIdioma(item.Idioma);
                idiomaMostrar.Nivel = ObtenerValorNivelById(item.Nivel);
                mostrarIdioma.Add(idiomaMostrar);

            }
            dgvIdioma.DataSource = null;
            dgvIdioma.DataSource = mostrarIdioma;
        }*/

        //Modificacion
       /* public void CargarDatosModificacion(int id_persona, bool esReactivar = false)
        {
            Persona modify = new Persona();
            
            btnGuardar.Name = "btnModificar";
            btnGuardar.Text = "Modificar";
            
            _id_persona = id_persona;
            CargarDatosPersona(id_persona, modify);

            BotonesInvisiblesModificacion();
            HabilitarCampos();
            btnContinuar1.Visible = true;
            btnContinuar2.Visible = true;
            btnAtrasAcademico.Visible = true;
            btnAtrasLaboral.Visible = true;
            btnEditarImagen.Visible = true;
            btnEliminarImagen.Visible = true;
            btnValidar.Visible = false;
            btnGuardar.Visible = true;
            txtCuitCuil.Enabled = false;
            btnAgregarIdioma.Visible = true;
            btnEliminarIdioma.Visible=true;
            btnAgregar.Visible = true;
            btnEliminarAcademico.Visible = true;
            AgregarLaboral.Visible = true;
            btnEliminarLaboral.Visible = true;
            if(esReactivar == false)
            {
                dttFechaAlta.Enabled = false;
                esReactivicacion = false;
            }
            else
            {
                EsReactivacion = true;
            }
           
        }*/

        //Controles vacios
        #region

      
        private void txtContacto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCalle_TextChanged(object sender, EventArgs e)
        {

        }
        private void tabLaborales_Click(object sender, EventArgs e)
        {

        }

        private void grbSuperior_Enter(object sender, EventArgs e)
        {

        }
        private void cmbNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }
        private void grbExp3_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void tabAcademicos_Click(object sender, EventArgs e)
        {

        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
        }

        private void btnAtrasLaboral_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabAcademicos;

        }
        private void btnAtrasAcademico_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPersonales;
        }
        private void dtpFechaDeNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int añoIngreso = Convert.ToInt32(cmbIngreso.SelectedItem);

            // Limpiar las opciones existentes en el ComboBox de egreso
            cmbEgreso.Items.Clear();

            // Agregar las opciones de años posteriores al ComboBox de egreso
            for (int i = añoIngreso; i <= DateTime.Now.Year; i++)
            {
                cmbEgreso.Items.Add(i);
            }

            // Si la fecha de egreso actualmente seleccionada es posterior a la fecha de ingreso, deselecciónala
            if (cmbEgreso.SelectedIndex != -1 && Convert.ToInt32(cmbEgreso.SelectedItem) < añoIngreso)
            {
                cmbEgreso.SelectedIndex = -1;
            }
        }

        private void cmbLaboralIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int añoIngreso = Convert.ToInt32(cmbLaboralIngreso.SelectedItem);
            cmbLaboralEgreso.Items.Clear();

            for (int i = añoIngreso; i <= DateTime.Now.Year; i++)
            {
                cmbLaboralEgreso.Items.Add(i);
            }

            if (cmbLaboralEgreso.SelectedIndex != -1 && Convert.ToInt32(cmbLaboralEgreso.SelectedItem) < añoIngreso)
            {
                cmbLaboralEgreso.SelectedIndex = -1;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string correo = txtEmail.Text;
            if (!string.IsNullOrEmpty(correo))
            {
                if (validarCorreoElectronico(correo))
                {
                    // El correo electrónico es válido
                    cambiarColorLabel(txtEmail, Color.Black);
                }
                else
                {
                    // El correo electrónico no es válido
                    cambiarColorLabel(txtEmail, Color.Red);
                    MessageBox.Show("El correo electrónico no es válido.", "Correo electrónico inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus(); // Devolver el foco al TextBox para que el usuario pueda corregirlo
                }
            }
        }
        private void txtDni_Leave(object sender, EventArgs e)
        {
            string dniIngresado = txtDni.Text;
            string cuilIngresado = txtCuitCuil.Text;

            // Extraer los números del medio del CUIL ingresado
            string numerosCuil = cuilIngresado.Substring(2, 8);
       
            // Comparar los números del medio del CUIL con el DNI ingresado
            if (dniIngresado == numerosCuil)
            {
                // Los números coinciden, permitir salir del campo txtDni
                
            }
            else
            {
                // Los números no coinciden
                MessageBox.Show("El DNI ingresado no coincide con el CUIL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus(); // Devolver el foco
            }
        }
       private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInsitutcionSuperior.Text) &&
             !string.IsNullOrEmpty(txtTitulo.Text) &&
             cmbNivelAcademico.SelectedItem != null &&
             cmbIngreso.SelectedItem != null &&
             cmbEgreso.SelectedItem != null &&
             cmbProgreso.SelectedItem != null)
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("Nivel", typeof(string));
                dt.Columns.Add("Insititucion", typeof(string));
                dt.Columns.Add("Titulo", typeof(string));  
                dt.Columns.Add("Año de ingreso", typeof(int));
                dt.Columns.Add("Año de Egreso", typeof(int));
                dt.Columns.Add("Progreso", typeof(int));

                InfoAcademicoDto academico = new InfoAcademicoDto();

                academico.Nivel = int.Parse(cmbNivelAcademico.SelectedValue.ToString());
                academico.Institucion = txtInsitutcionSuperior.Text;
                academico.Titulo = txtTitulo.Text;
                academico.Ingreso = Convert.ToInt32(cmbIngreso.SelectedItem?.ToString());
                academico.Egreso = Convert.ToInt32 (cmbEgreso.SelectedItem?.ToString ());
                academico.Progreso = int.Parse(cmbProgreso.SelectedValue.ToString ());
                infoAcademic.Add(academico);

              
                mostrarIdioma.Clear();

                foreach (var item in infoIdiom)
                {
                    IdiomaMostrar idiomaMostrar = new IdiomaMostrar();
                    idiomaMostrar.IdiomaNombre = logicaPersona.ObtenerDescripcionIdioma(item.Idioma);
                    idiomaMostrar.Nivel = ObtenerValorNivelById(item.Nivel);
                    mostrarIdioma.Add(idiomaMostrar);
                }

           

                foreach (var item in infoAcademic)
                {
                    NivelProgresoMostrar nivelProgresoMostrar = new NivelProgresoMostrar();
                    nivelProgresoMostrar = logicaPersona.ObtenerDescripcionProgresoNivel(item.Nivel, item.Progreso);
                    nivelProgresoMostrar.Insitutcion = item.Institucion.ToString();
                    nivelProgresoMostrar.Titulo = item.Titulo.ToString();
                    nivelProgresoMostrar.Ingreso = item.Ingreso.ToString();
                    nivelProgresoMostrar.Egreso = item.Egreso.ToString();

                    mostrarProgresoNivel.Add(nivelProgresoMostrar);
                    dt.Rows.Add(item);
                }

                dgvAcademico.DataSource = null;

                dgvAcademico.DataSource = mostrarProgresoNivel;

                LimpiarControles(grpSuperior1);

            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnEliminarAcademico_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvAcademico.SelectedRows.Count > 0 )
            {
                // Obtener el índice de la fila seleccionada
                int indiceFilaSeleccionada = dgvAcademico.SelectedRows[0].Index;

                // Eliminar la fila seleccionada del DataGridView
                infoAcademic.RemoveAt(indiceFilaSeleccionada);
                dgvAcademico.DataSource = null;
                dgvAcademico.DataSource = infoAcademic;

                //// Eliminar el elemento correspondiente de la lista
           
            }
            else
            {
                // Si no hay una fila seleccionada o es la última fila, mostrar un mensaje indicando al usuario que seleccione una fila válida
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


 
        private void AgregarLaboral_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbLaboralIngreso.Text) && !string.IsNullOrEmpty(cmbLaboralEgreso.Text))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Puesto", typeof(string));
                dt.Columns.Add("Empresa", typeof(string));
                dt.Columns.Add("Desde el año", typeof(int));
                dt.Columns.Add("Hasta el año", typeof (int));
                dt.Columns.Add("Persona a cargo", typeof(int));

                infoLaboralDto laboral = new infoLaboralDto();

                laboral.Puesto = txtPuesto.Text;
                laboral.Empresa = txtEmpresa.Text;
                laboral.Fecha_Ingreso = Convert.ToInt32(cmbLaboralIngreso.SelectedItem?.ToString());
                laboral.Fecha_Egreso = Convert.ToInt32(cmbLaboralIngreso.SelectedItem?.ToString());
                laboral.Personal_A_Cargo = Convert.ToInt32(nupPersonalACargo.Value);
                infoLabora.Add(laboral);

                foreach (var item in infoLabora)
                {
                    dt.Rows.Add(item);
                }

                dgvLaboral.DataSource = null;
          
                dgvLaboral.DataSource = infoLabora;

                LimpiarControles(grpExp1);
         
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btnEliminarLaboral_Click(object sender, EventArgs e)
        {
            if (dgvLaboral.SelectedRows.Count > 0 )
            {
                int indiceFilaSeleccionada = dgvLaboral.SelectedRows[0].Index;
                infoLabora.RemoveAt(indiceFilaSeleccionada);
                dgvLaboral.DataSource = null;
                dgvLaboral.DataSource = infoLabora;

            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregarIdioma_Click(object sender, EventArgs e)
        {
            string nivelSeleccionado = "";

            if (rdbBasicoEn.Checked)
            {
                nivelSeleccionado = "Básico";
            }
            else if (rdbIntermedioEn.Checked)
            {
                nivelSeleccionado = "Intermedio";
            }
            else if (rdbNativoEn.Checked)
            {
                nivelSeleccionado = "Nativo";
            }
            else if (rdbAvanzadoEn.Checked)
            {
                nivelSeleccionado = "Avanzado";
            }

            if (!string.IsNullOrEmpty(cmbIdioma.Text) && !string.IsNullOrEmpty(nivelSeleccionado))
            {
                IdiomaDto idioma = new IdiomaDto();

              idioma.Idioma = int.Parse(cmbIdioma.SelectedValue.ToString());
              idioma.Nivel = ObtenerValorNivel(nivelSeleccionado);
              
              bool permitido = ValidarIdioma(idioma);
                if (permitido)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("idioma", typeof(string));
                    dt.Columns.Add("nivel", typeof(string));
                    

                    
                    infoIdiom.Add(idioma);
                    mostrarIdioma.Clear();

                    foreach (var item in infoIdiom)
                    {
                        IdiomaMostrar idiomaMostrar = new IdiomaMostrar();
                        idiomaMostrar.IdiomaNombre = logicaPersona.ObtenerDescripcionIdioma(item.Idioma);
                        idiomaMostrar.Nivel = ObtenerValorNivelById(item.Nivel);
                        mostrarIdioma.Add(idiomaMostrar);
                    }

                    dgvIdioma.DataSource = null;
                    dgvIdioma.DataSource = mostrarIdioma;

                    LimpiarControles(grpIdiomas);
                    LimpiarControles(grpNivelIdiomas);
                }
                else
                {
                    MessageBox.Show("No se puede repetir el idioma.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
             
            }
            else
            {

                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public bool ValidarIdioma(IdiomaDto idiomaDto)
        {
            foreach (var item in infoIdiom)
            {
                if (item.Idioma == idiomaDto.Idioma)
                    return false;
            }
            return true;
        }
        private void btnEliminarIdioma_Click(object sender, EventArgs e)
        {
         
            if (dgvIdioma.SelectedRows.Count > 0 )
            {
                // Obtener el índice de la fila seleccionada
                int indiceFilaSeleccionada = dgvIdioma.SelectedRows[0].Index;
                mostrarIdioma.RemoveAt(indiceFilaSeleccionada);
                infoIdiom.RemoveAt(indiceFilaSeleccionada);
               
                dgvIdioma.DataSource = null;
                dgvAcademico.DataSource = infoIdiom;
                //dgvIdioma.DataSource = mostrarIdioma;

            }
            else
            {
                // Si no hay una fila seleccionada, mostrar un mensaje indicando al usuario que seleccione una fila primero
                MessageBox.Show("Seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int ObtenerValorNivel(string nivelSeleccionado)
        {
            switch (nivelSeleccionado)
            {
                case "Básico":
                    return 1;
                case "Intermedio":
                    return 2;
                case "Nativo":
                    return 3;
                case "Avanzado":
                    return 4;
                default:
                    return 0; // Valor predeterminado o error
            }
        }

        private string ObtenerValorNivelById(int nivelSeleccionado)
        {
            switch (nivelSeleccionado)
            {
                case 1:
                    return "Basico";
                case 2:
                    return "Intermedio";
                case 3:
                    return "Nativo";
                case 4:
                    return "Avanzado";
                default:
                    return null; // Valor predeterminado o error
            }
        }

        private void LimpiarControles(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox)
                {
                    // Limpiar TextBox
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    // Limpiar ComboBox
                    ((ComboBox)control).SelectedIndex = -1; // Opcional: Restablecer a la opción predeterminada
                }

                else if (control is NumericUpDown)
                {
                    // Limpiar NumericUpDown
                    ((NumericUpDown)control).Value = ((NumericUpDown)control).Minimum; // Opcional: Restablecer a un valor predeterminado
                }
                else if (control is RadioButton)
                {
                    // Desmarcar RadioButton
                    ((RadioButton)control).Checked = false;
                }
            }

        }
        private void ValidarDataGrid()
        {
            if (dgvAcademico.Columns.Count > 0 && dgvAcademico.Rows.Count > 0 && dgvIdioma.Columns.Count > 0 && dgvIdioma.Rows.Count > 0)
            {
                tabControl.TabPages[2].Enabled = true;
                tabControl.SelectedTab = tabLaborales;

            }
            else
            {
                MessageBox.Show("La informacion academica es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NoPegar(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox)
                {
                    
                    control.KeyDown += TextBoxNoPegar;
                }
            }
        }

        private void TextBoxNoPegar(object sender, KeyEventArgs e)
        {
            
            if (e.Control && e.KeyCode == Keys.V)
            {

                e.Handled = true;
                Console.WriteLine("Ctrl + V bloqueado");
            }
        }
        private void btnPdf_Click_1(object sender, EventArgs e)
        {


            try
            {
                /* string iniciofecha = dtpFecDesde.Value.ToString("dd-MM-yyyy");
                 string finfecha = dtpFecHasta.Value.ToString("dd-MM-yyyy");*/

                SaveFileDialog Guardar = new SaveFileDialog();
                Guardar.FileName = string.Format("Reporte " + DateTime.Now.ToString("ddMMyyyy") + ".pdf");

                string paginaHtmlTexto = Properties.Resources.PantillaEmpleadoPdf.ToString();

                paginaHtmlTexto = paginaHtmlTexto.Replace("@NOMYAPE", txtNombres.Text.ToString() + " " + txtApellidos.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@CUIL", txtCuitCuil.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@DOC", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@TIPODOC", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@GENERO", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@FECHANAC", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@ECIVIL", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@HIJOS", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@NAC", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@EMAIL", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@TEL", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@ALTERTEL", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@NOMALTERTEL", txtNombres.Text.ToString());

                paginaHtmlTexto = paginaHtmlTexto.Replace("@PROV", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@PART", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@LOC", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@CODPOSTAL", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@CALLE", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@ALTURA", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@PISO", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@DEPTO", txtNombres.Text.ToString());

                paginaHtmlTexto = paginaHtmlTexto.Replace("@AREA", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@PUESTO", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@CONVENIO", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@FECHAING", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@PUESTO2", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@EMPRESA", txtCuitCuil.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@DURACION", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@ESP", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@ING", txtNombres.Text.ToString());
                paginaHtmlTexto = paginaHtmlTexto.Replace("@FECHAEMIT", txtNombres.Text.ToString());



                /*  string filas = string.Empty;
                  for (int i = 0; i < dgvListaEventos.RowCount - 1; i++)
                  {
                      filas += "<tr>";
                      filas += "<td>" + dgvListaEventos.Rows[i].Cells[0].Value.ToString() + "</td>";
                      filas += "<td>" + dgvListaEventos.Rows[i].Cells[1].Value.ToString() + "</td>";
                      filas += "<td>" + dgvListaEventos.Rows[i].Cells[2].Value.ToString() + "</td>";
                      filas += "<td>" + dgvListaEventos.Rows[i].Cells[3].Value.ToString() + "</td>";
                      filas += "<td>" + dgvListaEventos.Rows[i].Cells[4].Value.ToString() + "</td>";
                      filas += "<td>" + dgvListaEventos.Rows[i].Cells[5].Value.ToString() + "</td>";
                      filas += "</tr>";

                  }

                  paginaHtmlTexto = paginaHtmlTexto.Replace("@FILAS", filas);*/

                if (Guardar.ShowDialog() == DialogResult.OK)
                {

                    using (FileStream stream = new FileStream(Guardar.FileName, FileMode.Create))
                    {
                        Document PDF = new Document(PageSize.A4, 25, 25, 25, 25);

                        PdfWriter writer = PdfWriter.GetInstance(PDF, stream);
                        PDF.Open();

                        PDF.Add(new Phrase(""));
                        //se agrega la imagen al pdf
                        using (MemoryStream streamm = new MemoryStream(foto))
                        {
                            System.Drawing.Image imagen = System.Drawing.Image.FromStream(streamm);
                            // Convertir la imagen de System.Drawing.Image a iTextSharp.text.Image
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagen, System.Drawing.Imaging.ImageFormat.Jpeg);

                            img.ScaleToFit(80, 80);
                            float x = PDF.PageSize.Width - PDF.RightMargin - img.ScaledWidth;
                            float y = PDF.PageSize.Height - PDF.TopMargin - img.ScaledHeight;

                            // Establecer la posición absoluta de la imagen
                            img.SetAbsolutePosition(x, y);
                            //img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            //img.SetAbsolutePosition(PDF.RightMargin, PDF.Top -70);
                            PDF.Add(img);

                        }


                        using (StringReader sr = new StringReader(paginaHtmlTexto))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, PDF, sr);
                        }

                        PDF.Close();
                        stream.Close();

                    }
                }
                MessageBox.Show("La descarga fue realizada con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar descargar el Pdf" + ex);
            }
        }
    }
    
}
 
