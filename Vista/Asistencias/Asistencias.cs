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
using SpreadsheetLight;
using System.IO;
using SpreadsheetLight.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Reflection;
using System.Globalization;

namespace Vista
{
    public partial class Asistencias : Form
    {
        CN_Asistencias asistencias = new CN_Asistencias();
        public bool isReport = false;
        public Asistencias()
        {
            InitializeComponent();
            btnExcel.Visible = false;
            buscarAlta.Enabled = false;
            DataTable asistencia = asistencias.area();
            areasAltas.DisplayMember = "area";
            areasAltas.DataSource = asistencia;
            AreaMod.DisplayMember = "area";
            AreaMod.DataSource = asistencia;
            dataGridAlta.Columns["Abrir"].Visible = false;
            dataGridModificar.Columns["Eliminar"].Visible = false;
            dataGridModificar.Columns["Modificar"].Visible = false;
            fechaDesdeMod.Visible = false;
            FechaHastaMod.Visible = false;
            lblFechaHastaMod.Visible = false;
            lblFechaDesdeMod.Visible = false;
            Refrescar(dataGridAlta);
            Refrescar(dataGridModificar);

        }
        public void RecibirDatos(bool ocultar)
        {
            isReport = ocultar;
            btnExcel.Visible = ocultar;
            btnExcel.Enabled = false; 
            ControlAsist.TabPages[0].Enabled = false;
            ControlAsist.TabPages[0].Hide();
            ControlAsist.TabPages[1].Enabled = true;
            ControlAsist.SelectedIndex = 1;
            tbpModificar.Text = "Reporte Inasistencias";
        }
        public void Refrescar(DataGridView dtg)
        {
            dtg.DataSource = null;
            dtg.AllowUserToAddRows = false;
            dtg.MultiSelect = false;
            dtg.RowHeadersVisible = false;
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtg.AllowUserToAddRows = false;
            dtg.AllowUserToResizeRows = false;
            dtg.ReadOnly = true;

            dataGridModificar.Columns["Modificar"].Visible = false;
            dataGridModificar.Columns["Eliminar"].Visible = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dataGridAlta.CurrentRow;
            C_Asistencias datos = new C_Asistencias();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == 0) // Índice de la primera columna de botón
                {
                    if (filaSeleccionada != null)
                    {
                        // Accede a los valores de las celdas en esa fila

                        datos.idPersona = Convert.ToInt32(filaSeleccionada.Cells["id_persona"].Value.ToString());
                        datos.Nombre = filaSeleccionada.Cells["Nombre"].Value.ToString();
                        datos.Apellido = filaSeleccionada.Cells["Apellido"].Value.ToString();
                        datos.Area = filaSeleccionada.Cells["Area"].Value.ToString();
                        datos.Puesto = filaSeleccionada.Cells["Puesto"].Value.ToString();
                        datos.Alta = true;
                    }
                    AsistenciasPanel panel = new AsistenciasPanel(datos);

                    this.Hide();
                    panel.ShowDialog();
                    this.Show();
                    dataGridAlta.DataSource = null;
                    cuilAltas.Clear();
                    areasAltas.SelectedIndex = 0;
                    puestosAltas.SelectedIndex = 0;
                    dataGridAlta.Columns["Abrir"].Visible = false;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void cargar(DataTable data)
        {
            dataGridAlta.AllowUserToAddRows = false;
            dataGridAlta.DataSource = data;
            dataGridAlta.Columns["Abrir"].Visible = true;

            // Ocultar las demás columnas

            dataGridAlta.Columns["id_persona"].Visible = false;
        }
        public void cargarDtg(DataTable data)
        {
            dataGridModificar.AllowUserToAddRows = false;
            dataGridModificar.DataSource = data;
            if (!isReport)
            {
                dataGridModificar.Columns["Modificar"].Visible = true;
                dataGridModificar.Columns["Eliminar"].Visible = true;
            }
            
            // Ocultar los id en las columnas

            dataGridModificar.Columns["id_persona"].Visible = false;
            dataGridModificar.Columns["id_asistencia"].Visible = false;
            dataGridModificar.Columns["id_motivo"].Visible = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //boton buscar del alta
            DataRowView selectedArea = (DataRowView)areasAltas.SelectedItem;
            DataRowView selectedPuesto = (DataRowView)puestosAltas.SelectedItem;
            int idA = Convert.ToInt32(selectedArea["id_area"]);
            int idP = Convert.ToInt32(selectedPuesto["id_puesto"]);
            if (string.IsNullOrEmpty(cuilAltas.Text))
            {
                DataTable asis = asistencias.filtroAlta(idA, idP, null);
                cargar(asis);
            }
            else
            {
                DataTable asis = asistencias.filtroAlta(idA, idP, cuilAltas.Text);
                cargar(asis);

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void areasAltas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)areasAltas.SelectedItem;
            int id = Convert.ToInt32(selectedRow["id_area"]);

            DataTable asistenciaP = asistencias.puesto(id);
            puestosAltas.DisplayMember = "puesto";
            puestosAltas.DataSource = asistenciaP;

            if (areasAltas.SelectedItem != null && puestosAltas.Text != null)
            {
                buscarAlta.Enabled = true;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void periodo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void periodo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (periodo.Checked)
            {
                FechaMod.Visible = false;
                fechaDesdeMod.Visible = true;
                FechaHastaMod.Visible = true;
                lblFechaHastaMod.Visible = true;
                lblFechaDesdeMod.Visible = true;
                lblFechaMod.Visible = false;
            }
            else
            {
                FechaMod.Visible = true;
                fechaDesdeMod.Visible = false;
                FechaHastaMod.Visible = false;
                lblFechaHastaMod.Visible = false;
                lblFechaDesdeMod.Visible = false;
                lblFechaMod.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //boton buscar del modificar
            DataRowView selectedArea = (DataRowView)AreaMod.SelectedItem;
            DataRowView selectedPuesto = (DataRowView)PuestoMod.SelectedItem;
            object idA = selectedArea["id_area"];
            object idP = selectedPuesto["id_puesto"];

            DataTable asis = asistencias.filtroModificacion(periodo.Checked, idA, idP, CuilMod.Text, FechaMod.Value, fechaDesdeMod.Value, FechaHastaMod.Value);
            //corroborar las cargas del dtg aplicar la busqueda del motivo para traerlo.
            //tengo que traer nombre y apellido de persona, dejando el id_persona y el id_motivo
            cargarDtg(asis);
            if (asis.Rows.Count >= 1)
            {
                btnExcel.Enabled = true;
            }
            else {
                btnExcel.Enabled = false;
            }


        }

        private void AreaMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)areasAltas.SelectedItem;
            int id = Convert.ToInt32(selectedRow["id_area"]);

            DataTable asistenciaP = asistencias.puesto(id);
            PuestoMod.DisplayMember = "puesto";
            PuestoMod.DataSource = asistenciaP;

            if (areasAltas.SelectedItem != null && puestosAltas.Text != null)
            {
                buscarAlta.Enabled = true;
            }
        }

        private void dataGridModificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dataGridModificar.CurrentRow;
            C_Asistencias datos = new C_Asistencias();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == 0) // Índice de la primera columna de botón
                {
                    if (filaSeleccionada != null)
                    {
                        // Accede a los valores de las celdas en esa fila

                        datos.idAsistencia = Convert.ToInt32(filaSeleccionada.Cells["id_asistencia"].Value.ToString());
                        datos.idPersona = Convert.ToInt32(filaSeleccionada.Cells["id_persona"].Value.ToString());
                        datos.Nombre = filaSeleccionada.Cells["Nombre"].Value.ToString();
                        datos.Apellido = filaSeleccionada.Cells["Apellido"].Value.ToString();
                        datos.Area = filaSeleccionada.Cells["Area"].Value.ToString();
                        datos.Puesto = filaSeleccionada.Cells["Puesto"].Value.ToString();

                        datos.Periodo = Convert.ToBoolean(filaSeleccionada.Cells["periodo"].Value.ToString());
                        /* if (datos.Periodo)
                         {
                             datos.Fecha = DateTime.Now;
                             datos.Fecha_desde = Convert.ToDateTime(filaSeleccionada.Cells["fecha_desde"].Value.ToString());
                             datos.Fecha_hasta = Convert.ToDateTime(filaSeleccionada.Cells["fecha_hasta"].Value.ToString());
                         }
                         else
                         {*/
                        datos.Fecha = Convert.ToDateTime(filaSeleccionada.Cells["fecha"].Value.ToString());
                        /*     datos.Fecha_desde = DateTime.Now;
                             datos.Fecha_hasta = DateTime.Now;

                         }*/
                        datos.Justificada = Convert.ToBoolean(filaSeleccionada.Cells["justificada"].Value.ToString());
                        datos.Id_motivo = Convert.ToInt32(filaSeleccionada.Cells["id_motivo"].Value.ToString());
                        datos.Otro_motivo = filaSeleccionada.Cells["otro_motivo"].Value.ToString();
                        datos.Observaciones = filaSeleccionada.Cells["observaciones"].Value.ToString();
                        datos.Alta = false;
                        // y así sucesivamente para las otras columnas

                        // Ahora puedes trabajar con los valores obtenidos
                    }
                    AsistenciasPanel panel = new AsistenciasPanel(datos);

                    this.Hide();
                    panel.ShowDialog();
                    this.Show();

                    dataGridModificar.DataSource = null;
                    CuilMod.Clear();
                    AreaMod.SelectedIndex = 0;
                    PuestoMod.SelectedIndex = 0;
                    periodo.Checked = false;
                    FechaMod.Value = DateTime.Now;
                    fechaDesdeMod.Value = DateTime.Now;
                    FechaHastaMod.Value = DateTime.Now;
                    dataGridModificar.Columns["Modificar"].Visible = false;
                    dataGridModificar.Columns["Eliminar"].Visible = false;
                }
                else if(e.ColumnIndex == 1) {
                    DialogResult result = MessageBox.Show("¿Estás seguro de realizar esta acción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Verificar la respuesta del usuario
                    if (result == DialogResult.Yes)
                    {
                        datos.idAsistencia = Convert.ToInt32(filaSeleccionada.Cells["id_asistencia"].Value.ToString());

                        asistencias.EliminarAsistencias(datos.idAsistencia);
                        Refrescar(dataGridModificar);
                    }
                    }
            }
        }

        private void btnBuscarReporte_Click(object sender, EventArgs e)
        {

        }
        private string ConvertirBoolASiONo(object valor)
        {
            if (valor is bool)
            {
                return (bool)valor ? "Si" : "No";//devuelve si/no si es bool
            }
            return valor.ToString(); // Si no es bool, devuelve el valor original
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona la carpeta de destino";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.InitialDirectory = folderDialog.SelectedPath;
                        saveDialog.Filter = "Archivos Excel (.xlsx)|.xlsx";
                        saveDialog.Title = "Elije el nombre del archivo Excel";

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            string rutaCompleta = saveDialog.FileName;

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
                            int numCol = 0;
                            int numFila = 10;

                            string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Resources", "ImgTalentium.jpeg");

                            SLPicture picture = new SLPicture(rutaImagen);
                            picture.SetPosition(0, 0); // Establece la posición de la imagen (fila 2, columna 1)
                            picture.ResizeInPixels(170, 110);  // Establece el tamaño de la imagen (ancho, alto)
                            sl.InsertPicture(picture);

                            try
                            {
                                foreach (DataGridViewColumn cl in dataGridModificar.Columns)
                                {
                                    //El if esta para que las columnas ids no se muestren en el excel
                                    if (cl.Index != 0 && cl.Index != 1 && cl.Index != 5 && cl.Index != 11)
                                    {
                                        string nombreColumna = cl.HeaderText;
                                        string nombreColumnaFormateado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreColumna.ToLower());

                                        sl.SetCellValue(9, numCol, nombreColumnaFormateado);
                                        sl.SetCellStyle(9, numCol, style);
                                        sl.SetCellStyle(9, 9, 9, numCol, style);

                                        numCol++;
                                    }
                                }

                                DateTime fechaEmision = DateTime.Now; // Puedes ajustar la fecha según tus necesidades
                                SLStyle fechaEmisionStyle = new SLStyle();
                                fechaEmisionStyle.Alignment.Horizontal = HorizontalAlignmentValues.Right;
                                fechaEmisionStyle.SetFontBold(true);
                                fechaEmisionStyle.SetFontItalic(true);
                                fechaEmisionStyle.Font.FontSize = 12;
                                sl.SetCellStyle(2, 10, fechaEmisionStyle); // Fila 1, Columna 1
                                sl.SetCellValue(2, 10, "Fecha de Emisión: " + fechaEmision.ToString("dd/MM/yyyy"));
                                SLStyle titulo = new SLStyle();
                                titulo.Alignment.Horizontal = HorizontalAlignmentValues.Right;
                                titulo.SetFontBold(true);
                                titulo.SetFontUnderline(UnderlineValues.Single); // Aplicar subrayado al texto
                                titulo.Font.FontSize = 16;
                                sl.SetCellStyle(6, 6, titulo);
                                sl.SetCellValue(6, 6, "Reporte de Inasistencia");
                                SLStyle fondo = new SLStyle();
                                fondo.Alignment.Horizontal = HorizontalAlignmentValues.Right;
                                fondo.Fill.SetPatternType(PatternValues.Solid);
                                fondo.Fill.SetPatternForegroundColor(System.Drawing.Color.White);
                                sl.SetCellStyle(1, 1, 8, 12, fondo);

                                var data = dataGridModificar.Columns;
                                var fila = dataGridModificar.Rows;
                                foreach (DataGridViewRow row in dataGridModificar.Rows)
                                {

                                    sl.SetCellValue(numFila, 1, row.Cells[3].Value.ToString());
                                    sl.SetCellValue(numFila, 2, row.Cells[4].Value.ToString());
                                    sl.SetCellValue(numFila, 3, row.Cells[6].Value.ToString());
                                    sl.SetCellValue(numFila, 4, row.Cells[7].Value.ToString());
                                    sl.SetCellValue(numFila, 5, ConvertirBoolASiONo(row.Cells[8].Value));
                                    sl.SetCellValue(numFila, 6, row.Cells[9].Value.ToString());
                                    sl.SetCellValue(numFila, 7, ConvertirBoolASiONo(row.Cells[10].Value));
                                    sl.SetCellValue(numFila, 8, row.Cells[12].Value.ToString());
                                    sl.SetCellValue(numFila, 9, row.Cells[13].Value.ToString());
                                    sl.SetCellValue(numFila, 10, row.Cells[14].Value.ToString());
                                    numFila++;
                                }
                                sl.SaveAs(rutaCompleta);
                                MessageBox.Show("Operación exitosa. Archivo guardado en: " + rutaCompleta);
                            }
                            catch (Exception msj)
                            {
                                MessageBox.Show(msj.Message);

                            }
                        }
                    }
                }
            }
        }
    }
}
