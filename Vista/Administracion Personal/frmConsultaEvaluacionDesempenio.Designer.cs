namespace Vista.Evaluacion_de_desempeño
{
    partial class frmConsultaEvaluacionDesempenio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaEvaluacionDesempenio));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblCantidadEval = new System.Windows.Forms.Label();
            this.lblEvTotales = new System.Windows.Forms.Label();
            this.lblCuil = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.lblNombreYApellido = new System.Windows.Forms.Label();
            this.cmbAreas = new System.Windows.Forms.ComboBox();
            this.lblNombreApellido = new System.Windows.Forms.Label();
            this.lblFiltroPorArea = new System.Windows.Forms.Label();
            this.lblFiltroPorAño = new System.Windows.Forms.Label();
            this.dtgConsultaEvaluacion = new System.Windows.Forms.DataGridView();
            this.Anio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MesEvaluacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EfectTareas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntualidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelSup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesempEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFiltroPorEmpleado = new System.Windows.Forms.Label();
            this.grpDatosEmpleado = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultaEvaluacion)).BeginInit();
            this.grpDatosEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBuscar.Location = new System.Drawing.Point(321, 95);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(72, 19);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Filtrar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCantidadEval
            // 
            this.lblCantidadEval.AutoSize = true;
            this.lblCantidadEval.Location = new System.Drawing.Point(166, 305);
            this.lblCantidadEval.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidadEval.Name = "lblCantidadEval";
            this.lblCantidadEval.Size = new System.Drawing.Size(13, 13);
            this.lblCantidadEval.TabIndex = 33;
            this.lblCantidadEval.Text = "0";
            // 
            // lblEvTotales
            // 
            this.lblEvTotales.AutoSize = true;
            this.lblEvTotales.Location = new System.Drawing.Point(14, 305);
            this.lblEvTotales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEvTotales.Name = "lblEvTotales";
            this.lblEvTotales.Size = new System.Drawing.Size(148, 13);
            this.lblEvTotales.TabIndex = 32;
            this.lblEvTotales.Text = "TOTAL DE EVALUACIONES:";
            // 
            // lblCuil
            // 
            this.lblCuil.AutoSize = true;
            this.lblCuil.Location = new System.Drawing.Point(101, 42);
            this.lblCuil.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCuil.Name = "lblCuil";
            this.lblCuil.Size = new System.Drawing.Size(0, 13);
            this.lblCuil.TabIndex = 29;
            this.lblCuil.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "CUIL/CUIT";
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(210, 94);
            this.cmbAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(92, 21);
            this.cmbAnio.TabIndex = 27;
            // 
            // cmbPersonal
            // 
            this.cmbPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonal.FormattingEnabled = true;
            this.cmbPersonal.Items.AddRange(new object[] {
            "sdsad"});
            this.cmbPersonal.Location = new System.Drawing.Point(210, 63);
            this.cmbPersonal.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPersonal.Name = "cmbPersonal";
            this.cmbPersonal.Size = new System.Drawing.Size(92, 21);
            this.cmbPersonal.TabIndex = 26;
            // 
            // lblNombreYApellido
            // 
            this.lblNombreYApellido.AutoSize = true;
            this.lblNombreYApellido.Location = new System.Drawing.Point(101, 21);
            this.lblNombreYApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreYApellido.Name = "lblNombreYApellido";
            this.lblNombreYApellido.Size = new System.Drawing.Size(0, 13);
            this.lblNombreYApellido.TabIndex = 25;
            this.lblNombreYApellido.Visible = false;
            // 
            // cmbAreas
            // 
            this.cmbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreas.FormattingEnabled = true;
            this.cmbAreas.Location = new System.Drawing.Point(210, 25);
            this.cmbAreas.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAreas.Name = "cmbAreas";
            this.cmbAreas.Size = new System.Drawing.Size(92, 21);
            this.cmbAreas.TabIndex = 24;
            this.cmbAreas.SelectedIndexChanged += new System.EventHandler(this.cmbAreas_SelectedIndexChanged);
            // 
            // lblNombreApellido
            // 
            this.lblNombreApellido.AutoSize = true;
            this.lblNombreApellido.Location = new System.Drawing.Point(5, 21);
            this.lblNombreApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreApellido.Name = "lblNombreApellido";
            this.lblNombreApellido.Size = new System.Drawing.Size(92, 13);
            this.lblNombreApellido.TabIndex = 23;
            this.lblNombreApellido.Text = "Nombre y Apellido";
            // 
            // lblFiltroPorArea
            // 
            this.lblFiltroPorArea.AutoSize = true;
            this.lblFiltroPorArea.Location = new System.Drawing.Point(46, 32);
            this.lblFiltroPorArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroPorArea.Name = "lblFiltroPorArea";
            this.lblFiltroPorArea.Size = new System.Drawing.Size(78, 13);
            this.lblFiltroPorArea.TabIndex = 22;
            this.lblFiltroPorArea.Text = "Filtro por area *";
            // 
            // lblFiltroPorAño
            // 
            this.lblFiltroPorAño.AutoSize = true;
            this.lblFiltroPorAño.Location = new System.Drawing.Point(46, 94);
            this.lblFiltroPorAño.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroPorAño.Name = "lblFiltroPorAño";
            this.lblFiltroPorAño.Size = new System.Drawing.Size(68, 13);
            this.lblFiltroPorAño.TabIndex = 21;
            this.lblFiltroPorAño.Text = "Filtro por año";
            // 
            // dtgConsultaEvaluacion
            // 
            this.dtgConsultaEvaluacion.AllowUserToAddRows = false;
            this.dtgConsultaEvaluacion.AllowUserToDeleteRows = false;
            this.dtgConsultaEvaluacion.BackgroundColor = System.Drawing.Color.White;
            this.dtgConsultaEvaluacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsultaEvaluacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Anio,
            this.MesEvaluacion,
            this.EfectTareas,
            this.Puntualidad,
            this.Disciplina,
            this.RelSup,
            this.DesempEquipo});
            this.dtgConsultaEvaluacion.Location = new System.Drawing.Point(17, 132);
            this.dtgConsultaEvaluacion.Margin = new System.Windows.Forms.Padding(2);
            this.dtgConsultaEvaluacion.Name = "dtgConsultaEvaluacion";
            this.dtgConsultaEvaluacion.ReadOnly = true;
            this.dtgConsultaEvaluacion.RowHeadersWidth = 51;
            this.dtgConsultaEvaluacion.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgConsultaEvaluacion.RowTemplate.Height = 24;
            this.dtgConsultaEvaluacion.Size = new System.Drawing.Size(707, 162);
            this.dtgConsultaEvaluacion.TabIndex = 20;
            // 
            // Anio
            // 
            this.Anio.HeaderText = "Año";
            this.Anio.MinimumWidth = 6;
            this.Anio.Name = "Anio";
            this.Anio.ReadOnly = true;
            this.Anio.Width = 60;
            // 
            // MesEvaluacion
            // 
            this.MesEvaluacion.HeaderText = "Mes de Evaluacion";
            this.MesEvaluacion.MinimumWidth = 6;
            this.MesEvaluacion.Name = "MesEvaluacion";
            this.MesEvaluacion.ReadOnly = true;
            this.MesEvaluacion.Width = 90;
            // 
            // EfectTareas
            // 
            this.EfectTareas.HeaderText = "Efectividad en las tareas";
            this.EfectTareas.MinimumWidth = 6;
            this.EfectTareas.Name = "EfectTareas";
            this.EfectTareas.ReadOnly = true;
            this.EfectTareas.Width = 95;
            // 
            // Puntualidad
            // 
            this.Puntualidad.HeaderText = "Puntualidad";
            this.Puntualidad.MinimumWidth = 6;
            this.Puntualidad.Name = "Puntualidad";
            this.Puntualidad.ReadOnly = true;
            this.Puntualidad.Width = 95;
            // 
            // Disciplina
            // 
            this.Disciplina.HeaderText = "Disciplina";
            this.Disciplina.MinimumWidth = 6;
            this.Disciplina.Name = "Disciplina";
            this.Disciplina.ReadOnly = true;
            this.Disciplina.Width = 95;
            // 
            // RelSup
            // 
            this.RelSup.HeaderText = "Relacion con superiores";
            this.RelSup.MinimumWidth = 6;
            this.RelSup.Name = "RelSup";
            this.RelSup.ReadOnly = true;
            this.RelSup.Width = 95;
            // 
            // DesempEquipo
            // 
            this.DesempEquipo.HeaderText = "Desempeño en equipo";
            this.DesempEquipo.MinimumWidth = 6;
            this.DesempEquipo.Name = "DesempEquipo";
            this.DesempEquipo.ReadOnly = true;
            this.DesempEquipo.Width = 95;
            // 
            // lblFiltroPorEmpleado
            // 
            this.lblFiltroPorEmpleado.AutoSize = true;
            this.lblFiltroPorEmpleado.Location = new System.Drawing.Point(46, 63);
            this.lblFiltroPorEmpleado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroPorEmpleado.Name = "lblFiltroPorEmpleado";
            this.lblFiltroPorEmpleado.Size = new System.Drawing.Size(103, 13);
            this.lblFiltroPorEmpleado.TabIndex = 19;
            this.lblFiltroPorEmpleado.Text = "Filtro por empleado *";
            // 
            // grpDatosEmpleado
            // 
            this.grpDatosEmpleado.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpDatosEmpleado.Controls.Add(this.lblNombreApellido);
            this.grpDatosEmpleado.Controls.Add(this.label6);
            this.grpDatosEmpleado.Controls.Add(this.lblNombreYApellido);
            this.grpDatosEmpleado.Controls.Add(this.lblCuil);
            this.grpDatosEmpleado.Location = new System.Drawing.Point(505, 52);
            this.grpDatosEmpleado.Name = "grpDatosEmpleado";
            this.grpDatosEmpleado.Size = new System.Drawing.Size(195, 63);
            this.grpDatosEmpleado.TabIndex = 35;
            this.grpDatosEmpleado.TabStop = false;
            this.grpDatosEmpleado.Text = "Datos del empleado";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExcel.Location = new System.Drawing.Point(648, 305);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(69, 35);
            this.btnExcel.TabIndex = 36;
            this.btnExcel.Text = "Descargar Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.descargarExcel_Click);
            // 
            // lnkAtras
            // 
            this.lnkAtras.AutoSize = true;
            this.lnkAtras.Location = new System.Drawing.Point(14, 327);
            this.lnkAtras.Name = "lnkAtras";
            this.lnkAtras.Size = new System.Drawing.Size(31, 13);
            this.lnkAtras.TabIndex = 37;
            this.lnkAtras.TabStop = true;
            this.lnkAtras.Text = "Atrás";
            this.lnkAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtras_LinkClicked);
            // 
            // frmConsultaEvaluacionDesempenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 349);
            this.Controls.Add(this.lnkAtras);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.grpDatosEmpleado);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblCantidadEval);
            this.Controls.Add(this.lblEvTotales);
            this.Controls.Add(this.cmbAnio);
            this.Controls.Add(this.cmbPersonal);
            this.Controls.Add(this.cmbAreas);
            this.Controls.Add(this.lblFiltroPorArea);
            this.Controls.Add(this.lblFiltroPorAño);
            this.Controls.Add(this.dtgConsultaEvaluacion);
            this.Controls.Add(this.lblFiltroPorEmpleado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmConsultaEvaluacionDesempenio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Evaluacion de Desempeño";
            this.Load += new System.EventHandler(this.frmConsultaEvaluacionDesempenio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultaEvaluacion)).EndInit();
            this.grpDatosEmpleado.ResumeLayout(false);
            this.grpDatosEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCantidadEval;
        private System.Windows.Forms.Label lblEvTotales;
        private System.Windows.Forms.Label lblCuil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.Label lblNombreYApellido;
        private System.Windows.Forms.ComboBox cmbAreas;
        private System.Windows.Forms.Label lblNombreApellido;
        private System.Windows.Forms.Label lblFiltroPorArea;
        private System.Windows.Forms.Label lblFiltroPorAño;
        private System.Windows.Forms.DataGridView dtgConsultaEvaluacion;
        private System.Windows.Forms.Label lblFiltroPorEmpleado;
        private System.Windows.Forms.GroupBox grpDatosEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anio;
        private System.Windows.Forms.DataGridViewTextBoxColumn MesEvaluacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EfectTareas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntualidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disciplina;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelSup;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesempEquipo;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.LinkLabel lnkAtras;
    }
}