using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Comun;
using LogicaNegocio;
using LogicaNegocio.Lenguajes;
using Vista.Lenguajes;

namespace Vista
{
    public partial class AsistenciasPanel : Form
    {
        CN_Asistencias asistencias = new CN_Asistencias();
        C_Asistencias datos;
        int idPer = 0;
        int idAsis = 0;
        public AsistenciasPanel(C_Asistencias dato)
        {
            InitializeComponent();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario
            datos = dato;
            
            DataTable asistencia = asistencias.motivo();
            cmbMotivo.ValueMember = "id_motivo";//id_motivo es el id
            cmbMotivo.DisplayMember = "motivo";
            cmbMotivo.DataSource = asistencia;

            List<C_Asistencias> listaObjetos = new List<C_Asistencias>();
            listaObjetos.Add(dato);
            valorNombre.Text = listaObjetos[0].Nombre;
            valorApellido.Text = listaObjetos [0].Apellido; 
            valorArea.Text = listaObjetos [0].Area; 
            valorPuesto.Text = listaObjetos [0].Puesto;
            idPer = listaObjetos[0].idPersona;
            idAsis = listaObjetos[0].idAsistencia;
            checkPeriodo.Checked = listaObjetos[0].Periodo;
            if (!dato.Alta) {
                dttFecha.Value = listaObjetos[0].Fecha;
                checkPeriodo.Enabled = false;
                cmbMotivo.SelectedValue = listaObjetos[0].Id_motivo;
            }
            txtOtro.Text = listaObjetos[0].Otro_motivo;
            checkJustificada.Checked = listaObjetos[0].Justificada;
            txtObservaciones.Text = listaObjetos[0].Observaciones;

            fechaDesde.Visible = false;
            fechaHasta.Visible = false;
            dttFechaDesde.Visible = false;
            dttFechaHasta.Visible = false;
            txtOtro.Visible = false;
            lblOtro.Visible = false;
        }

        private void AsistenciasPanel_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void fecha_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fechaHasta_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (datos.Alta)
                {
                    List<Asistencia> asistencia = new List<Asistencia>();
                    DataRowView selectedMotivo = (DataRowView)cmbMotivo.SelectedItem;

                    if (checkPeriodo.Checked)
                    {
                        for (DateTime fecha = dttFechaDesde.Value; fecha <= dttFechaHasta.Value;)
                        {
                            Asistencia nuevaAsistencia = new Asistencia
                            {
                                idPersona = idPer,
                                Fecha = fecha,
                                idMotivo = (int)selectedMotivo["id_motivo"],
                                OtroMotivo = txtOtro.Text,
                                Justificada = checkJustificada.Checked,
                                Observaciones = txtObservaciones.Text,
                                Periodo = checkPeriodo.Checked
                            };

                            asistencia.Add(nuevaAsistencia);
                            fecha = fecha.AddDays(1);
                        }
                    }
                    else
                    {
                        Asistencia nuevaAsistencia = new Asistencia
                        {
                            idPersona = idPer,
                            Fecha = dttFecha.Value,
                            idMotivo = (int)selectedMotivo["id_motivo"],
                            OtroMotivo = txtOtro.Text,
                            Justificada = checkJustificada.Checked,
                            Observaciones = txtObservaciones.Text,
                            Periodo = checkPeriodo.Checked
                        };

                        asistencia.Add(nuevaAsistencia);
                    }
                    try
                    {
                        asistencias.insertarAsistencias(asistencia);
                        MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    this.Hide();
                }
                else 
                {
                    DataRowView selectedMotivo = (DataRowView)cmbMotivo.SelectedItem;
                    asistencias.IdPersona = idPer;
                    asistencias.IdAsistencia = idAsis;
                    asistencias.Fecha = dttFecha.Value;
                    asistencias.FechaDesde = dttFechaDesde.Value;
                    asistencias.FechaHasta = dttFechaHasta.Value;
                    asistencias.IdMotivo = selectedMotivo["id_motivo"];
                    asistencias.OtroMotivo = txtOtro.Text;
                    asistencias.Justificada = checkJustificada.Checked;
                    asistencias.Observaciones = txtObservaciones.Text;
                    asistencias.Periodo = checkPeriodo.Checked;
                    asistencias.ModificarAsistencias();
                    this.Hide();
                    MessageBox.Show(Errores.OperacionExitosa, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPeriodo.Checked && datos.Alta == true)
            {
                fechaDesde.Visible = true;
                fechaHasta.Visible = true;
                dttFechaDesde.Visible = true;
                dttFechaHasta.Visible = true;
                fecha.Visible = false;
                dttFecha.Visible = false;
            }
            else if (checkPeriodo.Checked == false && datos.Alta == true)
            {
                fechaDesde.Visible = false;
                fechaHasta.Visible = false;
                dttFechaDesde.Visible = false;
                dttFechaHasta.Visible = false;
                fecha.Visible = true;
                dttFecha.Visible = true;
            }
        }

        private void valorPuesto_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedMotivo = (DataRowView)cmbMotivo.SelectedItem;
            var valor = asistencias.revisarMotivo(selectedMotivo["id_motivo"]);
            if (valor == 9)
            {
                txtOtro.Visible = true;
                lblOtro.Visible = true;
            }
            else 
            {
                txtOtro.Visible = false;
                lblOtro.Visible = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void dttFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaDesde = dttFechaDesde.Value;
            dttFechaHasta.MinDate = fechaDesde;
        }
    }
}
