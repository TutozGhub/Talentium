using Comun;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Accesibilidad;
using Vista.Analisis_y_reportes;
using Vista.Evaluacion_de_desempeño;
using Vista.Gestion_de_Talento;
using Vista.Lenguajes;
using LogicaNegocio.Administracion_Del_Personal;
using Vista.Bitacora;

namespace Vista
{
    public partial class frmMenu : Form
    {
        private CN_AdministracionDatosPersonal datosPersonales;
        private Point lastMousePosition;
        private long minTotal = 60_000 * 1; // Cantidad de minutos que va a tardar en cerrar sesión automaticamente
        private int minActual = 0;
        public frmMenu()
        {
            InitializeComponent();
            datosPersonales = new CN_AdministracionDatosPersonal();
            Idioma.CargarIdioma(this.Controls, this); //Asigno los nombres a los controles del formulario

            string permisos = "";
            PermisosCache[] listaPermisos = PermisosCache.GetPermisos();
            for (int i = 0, len = listaPermisos.Length; i < len; i++)
            {
                permisos += $"{listaPermisos[i].Id}: {listaPermisos[i].Permiso}\n";
            }
            //MessageBox.Show(permisos);
            // AdminPersonal
            UtilidadesForms.checkPermiso(altasToolStripMenuItem, Permisos.Alta_personal);
            UtilidadesForms.checkPermiso(consultarToolStripMenuItem, Permisos.Gestion_personal);

            // GestTalento
            UtilidadesForms.checkPermiso(altaCandidatoToolStripMenuItem, Permisos.Alta_PrSeleccion);
            UtilidadesForms.checkPermiso(gestiónCandidatoToolStripMenuItem, Permisos.Gestion_PrSeleccion);
            UtilidadesForms.checkPermiso(altaEvaluaciónDeDesempeñoToolStripMenuItem, Permisos.Alta_Desempeño);
            UtilidadesForms.checkPermiso(gestionDeDesempeñoToolStripMenuItem, Permisos.Gestion_Desempeño);
            UtilidadesForms.checkPermiso(asignarToolStripMenuItem, Permisos.Gestion_Capacitaciones);
            UtilidadesForms.checkPermiso(gestionDeCapacitacionesToolStripMenuItem, Permisos.Gestion_Capacitaciones);

            // GestAsistencia
            UtilidadesForms.checkPermiso(gestiónDeAsistenciasToolStripMenuItem, Permisos.Gestion_Asistencias);

            // NominaSalarial
            UtilidadesForms.checkPermiso(conveniosToolStripMenuItem, Permisos.Gestion_Nomina);
            UtilidadesForms.checkPermiso(categoriasToolStripMenuItem, Permisos.Gestion_Nomina);

            // AnalisisYReportes
            UtilidadesForms.checkPermiso(asistenciasToolStripMenuItem1, Permisos.Gestion_Informes);
            UtilidadesForms.checkPermiso(desempeñoToolStripMenuItem, Permisos.Gestion_Informes);
            UtilidadesForms.checkPermiso(nóminaSalarialToolStripMenuItem1, Permisos.Gestion_Informes);
            UtilidadesForms.checkPermiso(candidatoToolStripMenuItem, Permisos.Gestion_Informes);
            UtilidadesForms.checkPermiso(certificacionDeServiciosToolStripMenuItem, Permisos.Gestion_Certificado);

            // Accesibilidad
            UtilidadesForms.checkPermiso(configuracionDeAltaDelPersonalToolStripMenuItem, Permisos.Gestion_Jerarquia);
            UtilidadesForms.checkPermiso(configuracionDeToolStripMenuItem, Permisos.Gestion_Jerarquia);
            UtilidadesForms.checkPermiso(usuariosToolStripMenuItem, Permisos.Gestion_Usuario);
            UtilidadesForms.checkPermiso(perfilesToolStripMenuItem, Permisos.Gestion_Perfiles);
            UtilidadesForms.checkPermiso(configuraciónToolStripMenuItem, Permisos.Seguridad);
            UtilidadesForms.checkPermiso(bitacoraToolStripMenuItem, Permisos.Seguridad);
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsultaPersonal frm = new frmConsultaPersonal();
            frm.ShowDialog();
            this.Show();
        }

        private void altasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAltaPersonal alta = new frmAltaPersonal(false);
            alta.ShowDialog();
            this.Show();
        }

        private void áreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void crearEvaluacionDeDesempenioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAltaEvaluacionDesempenio evaluacionDesempenio = new frmAltaEvaluacionDesempenio();
            evaluacionDesempenio.ShowDialog();
            this.Show();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsultaEvaluacionDesempenio consultarEvaluacionDesempenio = new frmConsultaEvaluacionDesempenio();
            consultarEvaluacionDesempenio.ShowDialog();
            this.Show();
        }

        private void certificacionDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCertificacionServicios frm = new frmCertificacionServicios();
            frm.ShowDialog();
            this.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsultaUsuario frm = new frmConsultaUsuario();
            frm.ShowDialog();
            this.Show();
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPerfiles frm = new frmPerfiles();
            frm.ShowDialog();
            this.Show();
        }

        private void asistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Asistencias frm = new Asistencias();
            frm.ShowDialog();
            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void altaCandidatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAltaPersonal frm = new frmAltaPersonal(true);
            frm.ShowDialog();
            this.Show();
        }

        private void gestiónCandidatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsultaProcesoDeSeleccion frm = new frmConsultaProcesoDeSeleccion();
            frm.ShowDialog();
            this.Show();
        }

        private void altaEvaluaciónDeDesempeñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAltaEvaluacionDesempenio frm = new frmAltaEvaluacionDesempenio();
            frm.ShowDialog();
            this.Show();
        }

        private void gestionDeDesempeñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsultaEvaluacionDesempenio frm = new frmConsultaEvaluacionDesempenio();
            frm.ShowDialog();
            this.Show();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAsignarCapacitaciones frm = new frmAsignarCapacitaciones();
            frm.ShowDialog();
            this.Show();
        }

        private void gestionDeCapacitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmABMCapacitaciones frm = new frmABMCapacitaciones();
            frm.ShowDialog();
            this.Show();
        }

        private void consultaDeAsistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Asistencias frm = new Asistencias();
            frm.ShowDialog();
            this.Show();
        }

        private void cambioDeContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCambioPass frm = new frmCambioPass();
            frm.ShowDialog();
            this.Show();
        }

        private void conveniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConvenios frm = new frmConvenios();
            frm.ShowDialog();
            this.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCategorias frm = new frmCategorias();
            frm.ShowDialog();
            this.Show();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConfigPoliticasPass frm = new ConfigPoliticasPass();
            frm.ShowDialog();
            this.Show();
        }

        private void tmrMouse_Tick(object sender, EventArgs e)
        {
            Point currentMousePosition = Cursor.Position;

            if (currentMousePosition != lastMousePosition)
            {
                lastMousePosition = currentMousePosition;

                tmrMouseQuieto.Stop();
                tmrMouse.Stop();
                tmrMouse.Start();
                lblTiempoRestante.Visible = false;
                minActual = 0;
            }
            else if (tmrMouseQuieto.Enabled == false)
            {
                tmrMouseQuieto.Start();
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            lastMousePosition = Cursor.Position;
        }

        private void tmrMouseQuieto_Tick(object sender, EventArgs e)
        {
            minActual += 1000;
            long _minRestante = minTotal - minActual;

            if (_minRestante == 30_000 && this.Visible == true)
            {
                SystemSounds.Exclamation.Play();
            }
            if (_minRestante <= 30_000 && this.Visible == true)
            {
                lblTiempoRestante.Visible = true;

                TimeSpan minRestanteFormato = TimeSpan.FromMilliseconds(_minRestante);
                string minRestantes = minRestanteFormato.ToString(@"mm\:ss");
                lblTiempoRestante.Text = Strings.lblTiempoRestante + minRestantes;
            }
            if (minActual >= minTotal && this.Visible == true)
            {
                CN_LogicaLogout logout = new CN_LogicaLogout();
                this.DialogResult = DialogResult.Abort;
                this.Dispose();
            }
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            CN_LogicaLogout logout = new CN_LogicaLogout();
            if (this.DialogResult == DialogResult.Abort)
            {
                logout.Logout(this, true);
            }
            else
            {
                logout.Logout(this);
            }
        }
        private void configuraciónDeEntrevistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void configuraciónDeAltaPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void asistenciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Asistencias frm = new Asistencias();
            frm.RecibirDatos(true);
            frm.ShowDialog();
            this.Show();
        }

        private void desempeñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsultaEvaluacionDesempenio frm = new frmConsultaEvaluacionDesempenio();
            frm.RecibirDatos(true);
            frm.ShowDialog();
            this.Show();
        }

        private void nóminaSalarialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmReporteNominaSalarial frm = new frmReporteNominaSalarial();
            frm.ShowDialog();
            this.Show();
        }

        private void configuracionDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConfigEntrevistas frm = new frmConfigEntrevistas();
            frm.ShowDialog();
            this.Show();
        }

        private void configuracionDeAltaDelPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConfigAltaPersonal frm = new frmConfigAltaPersonal();
            frm.ShowDialog();
            this.Show();
        }

        private void gestiónDeAsistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Asistencias frm = new Asistencias();
            frm.ShowDialog();
            this.Show();
        }

        private void candidatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsultaPersonal frm = new frmConsultaPersonal();
            frm.RecibirDatos(true);
            frm.ShowDialog();
            this.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBitacora frm = new frmBitacora();
            frm.ShowDialog();
            this.Show();
        }

        private void frmMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                tmrMouse.Enabled = true;
                tmrMouseQuieto.Enabled = true;
            }
            else
            {
                tmrMouse.Enabled = false;
                tmrMouseQuieto.Enabled = false;
            }
        }
    }
}
