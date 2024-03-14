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
using SpreadsheetLight;
using System.IO;
using SpreadsheetLight.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Reflection;
using System.Globalization;
namespace Vista
{
    public partial class frmReporteNominaSalarial : Form
    {
        CN_Convenio convenios = new CN_Convenio();
        public frmReporteNominaSalarial()
        {
            InitializeComponent();
            DataTable convA = convenios.area();
            areas.DisplayMember = "area";
            areas.DataSource = convA;
            DataTable conv = convenios.ObtenerConvenio();

            // Crear un nuevo DataTable que sea una copia del original
            DataTable nuevoDataTable = conv.Copy();

            // Agregar una nueva fila vacía al principio del nuevo DataTable
            DataRow row = nuevoDataTable.NewRow();
            nuevoDataTable.Rows.InsertAt(row, 0);

            // Establecer el nombre de la columna "convenio" como valor vacío en la nueva fila
            nuevoDataTable.Rows[0]["convenio"] = "Todos";

            // Asignar el nuevo DataTable como origen de datos al ComboBox
            conven.DisplayMember = "convenio";
            conven.DataSource = nuevoDataTable;



        }

        private void dataGridAlta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void cargarDtg(DataTable data)
        {
            dataGridNomina.AllowUserToAddRows = false;
            dataGridNomina.DataSource = data;


            // Ocultar los id en las columnas
            
            dataGridNomina.Columns["id_convenio"].Visible = false;
            dataGridNomina.Columns["id_categoria"].Visible = false;

            dataGridNomina.Columns["nombres"].HeaderText = "Nombre";
            dataGridNomina.Columns["apellidos"].HeaderText = "Apellido";
            dataGridNomina.Columns["cuit_cuil"].HeaderText = "Cuil";
            dataGridNomina.Columns["fecha_alta"].HeaderText = "Fecha alta";
            dataGridNomina.Columns["convenio"].HeaderText = "Convenio";
            dataGridNomina.Columns["seguridad_salud"].HeaderText = "Seguridad y salud";
            dataGridNomina.Columns["obra_social"].HeaderText = "Obra social";
            dataGridNomina.Columns["nombre_categoria"].HeaderText = "Categoria";
            dataGridNomina.Columns["jornada"].HeaderText = "Jornada";
            dataGridNomina.Columns["sueldos"].HeaderText = "Sueldo";

        }

        private void buscarAlta_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)conven.SelectedItem;
            DataRowView selectedRowA = (DataRowView)areas.SelectedItem;
            DataRowView selectedRowP = (DataRowView)puestos.SelectedItem;
            int id = Convert.ToInt32(selectedRow["id_convenio"]);
            int idA = Convert.ToInt32(selectedRowA["id_area"]);
            int idP = Convert.ToInt32(selectedRowP["id_puesto"]);
            string _cuil = cuil.Text;

            if (selectedRow["convenio"].ToString() == "Todos")
            {
                if (string.IsNullOrEmpty(cuil.Text))
                {
                    //le paso cuil y convenio en null
                    DataTable cvenios = convenios.ConsultarConveniosPersonas(idA, idP, -1, null);
                    cargarDtg(cvenios);
                }
                else 
                {
                    //le paso solo convenio en null
                    DataTable cvenios = convenios.ConsultarConveniosPersonas(idA, idP, -1, _cuil);
                    cargarDtg(cvenios);
                }
            }
            else 
            {
                if (string.IsNullOrEmpty(cuil.Text))
                {
                    //le paso cuil en null
                    DataTable cvenios = convenios.ConsultarConveniosPersonas(idA, idP, id, null);
                    cargarDtg(cvenios);
                }
                else
                {
                    //le paso todo sin null
                    DataTable cvenios = convenios.ConsultarConveniosPersonas(idA, idP, id, _cuil);
                    cargarDtg(cvenios);
                }
            }
        }

        private void areasAltas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)areas.SelectedItem;
            int id = Convert.ToInt32(selectedRow["id_area"]);

            DataTable convenioP = convenios.puesto(id);
            puestos.DisplayMember = "puesto";
            puestos.DataSource = convenioP;

            if (areas.SelectedItem != null && puestos.Text != null)
            {
                buscar.Enabled = true;
            }
        }

        private void conven_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void grbFiltrosAlta_Enter(object sender, EventArgs e)
        {

        }

        private void frmReporteNominaSalarial_Load(object sender, EventArgs e)
        {


        }

        private void Descargar_Click(object sender, EventArgs e)
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
                            int numCol = 1;
                            int numFila = 10;

                            string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Resources", "ImgTalentium.jpeg");

                            SLPicture picture = new SLPicture(rutaImagen);
                            picture.SetPosition(0, 0); // Establece la posición de la imagen (fila 2, columna 1)
                            picture.ResizeInPixels(170, 110);  // Establece el tamaño de la imagen (ancho, alto)
                            sl.InsertPicture(picture);

                            try
                            {
                                foreach (DataGridViewColumn cl in dataGridNomina.Columns)
                                {
                                    //El if esta para que las columnas ids no se muestren en el excel
                                    if (cl.Index != 4 && cl.Index != 8)
                                    {
                                        string nombreColumna = cl.HeaderText;
                                        string nombreColumnaFormateado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreColumna.ToLower());

                                        sl.SetCellValue(9, numCol, nombreColumnaFormateado);
                                        sl.SetCellStyle(9, numCol, style);
                                        sl.SetCellStyle(9, 10, 9, numCol, style);

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
                                sl.SetCellStyle(6, 5, titulo);
                                sl.SetCellValue(6, 5, "Reporte de nomina salarial");
                                SLStyle fondo = new SLStyle();
                                fondo.Alignment.Horizontal = HorizontalAlignmentValues.Right;
                                fondo.Fill.SetPatternType(PatternValues.Solid);
                                fondo.Fill.SetPatternForegroundColor(System.Drawing.Color.White);
                                sl.SetCellStyle(1, 1, 8, 12, fondo);

                                var data = dataGridNomina.Columns;
                                var fila = dataGridNomina.Rows;
                                foreach (DataGridViewRow row in dataGridNomina.Rows)
                                {
                                    sl.SetCellValue(numFila, 1, row.Cells[0].Value.ToString());
                                    sl.SetCellValue(numFila, 2, row.Cells[1].Value.ToString());
                                    sl.SetCellValue(numFila, 3, row.Cells[2].Value.ToString());
                                    sl.SetCellValue(numFila, 4, row.Cells[3].Value.ToString());
                                    sl.SetCellValue(numFila, 5, row.Cells[5].Value.ToString());
                                    sl.SetCellValue(numFila, 6, row.Cells[6].Value.ToString());
                                    sl.SetCellValue(numFila, 7, row.Cells[7].Value.ToString());
                                    sl.SetCellValue(numFila, 8, row.Cells[9].Value.ToString());
                                    sl.SetCellValue(numFila, 9, row.Cells[10].Value.ToString());
                                    sl.SetCellValue(numFila, 10, row.Cells[11].Value.ToString());
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
