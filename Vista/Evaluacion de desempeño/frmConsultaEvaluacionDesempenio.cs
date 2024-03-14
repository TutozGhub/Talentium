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
using SpreadsheetLight;
using System.IO;
using SpreadsheetLight.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Reflection;
using System.Globalization;
using LogicaNegocio.Lenguajes;

namespace Vista.Evaluacion_de_desempeño
{
    public partial class frmConsultaEvaluacionDesempenio : Form
    {
        CN_LogicaEvaluacionDesempenio evaluacionDesempenio = new CN_LogicaEvaluacionDesempenio();
        CargarCombobox combos = new CargarCombobox();
        public bool isReport = false;
        public string nombres;
        public string apellidos;
        public string cuil;
        public string area;
        public frmConsultaEvaluacionDesempenio()
        {
            InitializeComponent();
            btnExcel.Visible = false;
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
        }
        public void RecibirDatos(bool ocultar)
        {
            isReport = ocultar;
            btnExcel.Visible = ocultar;
            btnExcel.Enabled = false;
            
        }
        private void frmConsultaEvaluacionDesempenio_Load(object sender, EventArgs e)
        {
            // cargar combo de Area
            DataTable DT = evaluacionDesempenio.ObtenerAreas();
            cmbAreas.DataSource = DT;
            cmbAreas.DisplayMember = "area";
            cmbAreas.ValueMember = "id_area";

            // cargar el combo de los años
            List<string> DTAnio = combos.CargarAnioCombobox();
            DTAnio.Insert(0, "");
            cmbAnio.DataSource = DTAnio;

            dtgConsultaEvaluacion.AllowUserToAddRows = false;
            dtgConsultaEvaluacion.AutoGenerateColumns = false;
            dtgConsultaEvaluacion.MultiSelect = false;
            dtgConsultaEvaluacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgConsultaEvaluacion.RowHeadersVisible = false;
            UtilidadesForms.TraducirColumnasDtg(ref dtgConsultaEvaluacion);
        }

        private void cmbAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedArea = cmbAreas.SelectedItem as DataRowView;
            int idAreaSeleccionada = Convert.ToInt32(selectedArea["id_area"]);
            area = selectedArea["area"].ToString();
            DataTable DTEmpleados = evaluacionDesempenio.ObtenerPersonaConArea(idAreaSeleccionada);
            DTEmpleados.Columns.Add("NombreCompleto", typeof(string), "APELLIDOS + ', ' + NOMBRES");

            if (DTEmpleados != null && DTEmpleados.Rows.Count > 0)
            {
                cmbPersonal.DataSource = DTEmpleados;
                cmbPersonal.DisplayMember = "NombreCompleto";
                cmbPersonal.ValueMember = "id_persona";
            }
            else
            {
                // Si no hay empleados para mostrar, limpia el ComboBox de empleados
                cmbPersonal.DataSource = null;
                cmbPersonal.Items.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbPersonal.SelectedItem != null && cmbPersonal.SelectedValue != null)
            {
                DataRowView empleadoSeleccionado = cmbPersonal.SelectedItem as DataRowView;

                 nombres = empleadoSeleccionado["nombres"].ToString();
                 apellidos = empleadoSeleccionado["apellidos"].ToString();
                string nombreApellido = $"{apellidos}, {nombres}";

                lblNombreYApellido.Text = nombreApellido;

                 cuil = empleadoSeleccionado["cuit_cuil"].ToString();
                lblCuil.Text = cuil;

                lblNombreYApellido.Visible = true;
                lblCuil.Visible = true;
            }
            string anio = cmbAnio.SelectedValue.ToString();
            int id_persona = Convert.ToInt32(cmbPersonal.SelectedValue);
            dtgConsultaEvaluacion.AutoGenerateColumns = false;
            if (!string.IsNullOrEmpty(anio) && anio!="")
            {
                dtgConsultaEvaluacion.DataSource = evaluacionDesempenio.ObtenerEvaluacion(anio, id_persona);
                CargarColumnasDataGrid();
                dtgConsultaEvaluacion.Columns["Anio"].Visible = false;
                int cantidadEvaluacion = dtgConsultaEvaluacion.Rows.Count;
                lblCantidadEval.Text = cantidadEvaluacion.ToString();

            }
            else
            {
                dtgConsultaEvaluacion.Columns["Anio"].Visible = true;
                dtgConsultaEvaluacion.DataSource = evaluacionDesempenio.ObtenerEvaluacionPersona(id_persona);
                CargarColumnasDataGrid();
                int cantidadEvaluacion = dtgConsultaEvaluacion.Rows.Count;
                lblCantidadEval.Text = cantidadEvaluacion.ToString();
            }
            if (dtgConsultaEvaluacion.Rows.Count >= 1)
            {
                btnExcel.Enabled = true;
            }
            else
            {
                btnExcel.Enabled = false;
            }
            UtilidadesForms.TraducirColumnasDtg(ref dtgConsultaEvaluacion);
        }

        public void CargarColumnasDataGrid()
        {
            dtgConsultaEvaluacion.Columns["MesEvaluacion"].DataPropertyName = "mes";
            dtgConsultaEvaluacion.Columns["EfectTareas"].DataPropertyName = "efectividadTarea";
            dtgConsultaEvaluacion.Columns["Puntualidad"].DataPropertyName = "puntualidad";
            dtgConsultaEvaluacion.Columns["RelSup"].DataPropertyName = "relacionSuperiores";
            dtgConsultaEvaluacion.Columns["Disciplina"].DataPropertyName = "disciplina";
            dtgConsultaEvaluacion.Columns["DesempEquipo"].DataPropertyName = "desempenioEquipo";
            dtgConsultaEvaluacion.Columns["Anio"].DataPropertyName = "anio";
        }

        private void descargarExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Archivos Excel (.xlsx)|.xlsx";
                saveDialog.Title = "Elije el nombre del archivo Excel";
                string defaultFileName = string.Format("Reporte Desempeño " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx"); // Nombre predeterminado del archivo
                saveDialog.FileName = defaultFileName;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaCompleta = saveDialog.FileName;
                            //Estilo del encabezado
                            SLDocument sl = new SLDocument();
                            SLStyle style = new SLStyle();
                            style.Font.FontSize = 12;
                            style.Fill.SetPatternType(PatternValues.Solid);
                            style.Fill.SetPatternForegroundColor(System.Drawing.Color.LightBlue);
                            style.Border.TopBorder.BorderStyle = BorderStyleValues.Medium;
                            style.Border.BottomBorder.BorderStyle = BorderStyleValues.Medium;
                            style.Border.LeftBorder.BorderStyle = BorderStyleValues.Medium;
                            style.Border.RightBorder.BorderStyle = BorderStyleValues.Medium;
                            style.Font.Bold = true;
                            sl.SetWorksheetDefaultColumnWidth(25);
                            int numCol = 1;
                            int numFila = 10;

                            string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Resources", "ImgTalentium.jpeg");

                            SLPicture picture = new SLPicture(rutaImagen);
                            picture.SetPosition(0, 0); // Establece la posición de la imagen (fila 2, columna 1)
                            picture.ResizeInPixels(170, 110);  // Establece el tamaño de la imagen (ancho, alto)
                            sl.InsertPicture(picture);

                            try
                            {
                                foreach (DataGridViewColumn cl in dtgConsultaEvaluacion.Columns)
                                {
                                    
                                        string nombreColumna = cl.HeaderText;
                                        string nombreColumnaFormateado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreColumna.ToLower());

                                        sl.SetCellValue(9, numCol, nombreColumnaFormateado);
                                        sl.SetCellStyle(9, numCol, style);
                                        sl.SetCellStyle(9, 1, 9, numCol, style);

                                        numCol++;
                                }
                                

                                DateTime fechaEmision = DateTime.Now; // Puedes ajustar la fecha según tus necesidades
                                SLStyle fechaEmisionStyle = new SLStyle();
                                fechaEmisionStyle.Alignment.Horizontal = HorizontalAlignmentValues.Right;
                                fechaEmisionStyle.SetFontBold(true);
                                fechaEmisionStyle.SetFontItalic(true);
                                fechaEmisionStyle.Font.FontSize = 12;
                                sl.SetCellStyle(4, 8, fechaEmisionStyle); 
                                sl.SetCellValue(4, 8, "Area: " + area);
                                sl.SetCellStyle(2, 8, fechaEmisionStyle); // Fila 2, Columna 8
                                sl.SetCellValue(2, 8, "Fecha de Emisión: " + fechaEmision.ToString("dd/MM/yyyy"));
                                sl.SetCellStyle(1, 2, fechaEmisionStyle); 
                                sl.SetCellValue(1, 2, "Nombre: " + nombres);
                                sl.SetCellStyle(2, 2, fechaEmisionStyle); 
                                sl.SetCellValue(2, 2, "Apellido: " + apellidos);
                                sl.SetCellStyle(3, 2, fechaEmisionStyle);
                                sl.SetCellValue(3, 2, "Cuil: " + cuil);
                                sl.SetCellValue(9, 8, "Referencia: " );
                                sl.SetCellStyle(9, 8, fechaEmisionStyle);

                                sl.SetCellValue(10, 8, "ⓘ Escala de 1-6, siendo 1 el ");
                                sl.SetCellValue(11, 8, "valor más bajo y 6 el más alto.");


                                SLStyle titulo = new SLStyle();
                                titulo.Alignment.Horizontal = HorizontalAlignmentValues.Right;
                                titulo.SetFontBold(true);
                                titulo.SetFontUnderline(UnderlineValues.Single); // Aplicar subrayado al texto
                                titulo.Font.FontSize = 16;
                                sl.SetCellStyle(6, 5, titulo);
                                sl.SetCellValue(6, 5, "Reporte de Evaluación de desempeño");
                                SLStyle fondo = new SLStyle();
                                fondo.Alignment.Horizontal = HorizontalAlignmentValues.Right;
                                fondo.Fill.SetPatternType(PatternValues.Solid);
                                fondo.Fill.SetPatternForegroundColor(System.Drawing.Color.White);
                                sl.SetCellStyle(1, 1, 8, 12, fondo);

                                var data = dtgConsultaEvaluacion.Columns;
                                var fila = dtgConsultaEvaluacion.Rows;
                                foreach (DataGridViewRow row in dtgConsultaEvaluacion.Rows)
                                {
                                    sl.SetCellValue(numFila, 1, row.Cells[0].Value.ToString());
                                    sl.SetCellValue(numFila, 2, row.Cells[1].Value.ToString());
                                    sl.SetCellValue(numFila, 3, row.Cells[2].Value.ToString());
                                    sl.SetCellValue(numFila, 4, row.Cells[3].Value.ToString());
                                    sl.SetCellValue(numFila, 5, row.Cells[4].Value.ToString());
                                    sl.SetCellValue(numFila, 6, row.Cells[5].Value.ToString());
                                    sl.SetCellValue(numFila, 7, row.Cells[6].Value.ToString());

                                    numFila++;
                                }
                                sl.SaveAs(rutaCompleta);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                            catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                        }
                    }
                }

        private void lnkAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }
    }
        }

   