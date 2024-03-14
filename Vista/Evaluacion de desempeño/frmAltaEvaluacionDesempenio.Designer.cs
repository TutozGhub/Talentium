namespace Vista.Evaluacion_de_desempeño
{
    partial class frmAltaEvaluacionDesempenio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaEvaluacionDesempenio));
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.grpFiltrosBusqueda = new System.Windows.Forms.GroupBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.lblArea = new System.Windows.Forms.Label();
            this.cmbAreas = new System.Windows.Forms.ComboBox();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtgEvaluacion = new System.Windows.Forms.DataGridView();
            this.grpPeriodo = new System.Windows.Forms.GroupBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            this.NombreApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Efectividad = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Puntualidad = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RelSuperiores = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Disciplina = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DesempEquipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grpFiltrosBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaluacion)).BeginInit();
            this.grpPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(73, 70);
            this.cmbMes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(92, 21);
            this.cmbMes.TabIndex = 3;
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(73, 34);
            this.cmbAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(92, 21);
            this.cmbAnio.TabIndex = 2;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(33, 74);
            this.lblMes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(27, 13);
            this.lblMes.TabIndex = 1;
            this.lblMes.Text = "Mes";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(35, 36);
            this.lblAnio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(26, 13);
            this.lblAnio.TabIndex = 0;
            this.lblAnio.Text = "Año";
            // 
            // grpFiltrosBusqueda
            // 
            this.grpFiltrosBusqueda.BackColor = System.Drawing.Color.White;
            this.grpFiltrosBusqueda.Controls.Add(this.btnSeleccionar);
            this.grpFiltrosBusqueda.Controls.Add(this.lblArea);
            this.grpFiltrosBusqueda.Controls.Add(this.cmbAreas);
            this.grpFiltrosBusqueda.Controls.Add(this.cmbPersonal);
            this.grpFiltrosBusqueda.Controls.Add(this.lblEmpleado);
            this.grpFiltrosBusqueda.Location = new System.Drawing.Point(74, 9);
            this.grpFiltrosBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.grpFiltrosBusqueda.Name = "grpFiltrosBusqueda";
            this.grpFiltrosBusqueda.Padding = new System.Windows.Forms.Padding(2);
            this.grpFiltrosBusqueda.Size = new System.Drawing.Size(307, 139);
            this.grpFiltrosBusqueda.TabIndex = 25;
            this.grpFiltrosBusqueda.TabStop = false;
            this.grpFiltrosBusqueda.Text = "Filtros de búsqueda *";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeleccionar.Location = new System.Drawing.Point(175, 101);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 25);
            this.btnSeleccionar.TabIndex = 16;
            this.btnSeleccionar.Text = "Filtrar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(20, 30);
            this.lblArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(29, 13);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "Área";
            // 
            // cmbAreas
            // 
            this.cmbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreas.FormattingEnabled = true;
            this.cmbAreas.Location = new System.Drawing.Point(91, 28);
            this.cmbAreas.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAreas.Name = "cmbAreas";
            this.cmbAreas.Size = new System.Drawing.Size(168, 21);
            this.cmbAreas.TabIndex = 2;
            this.cmbAreas.SelectedIndexChanged += new System.EventHandler(this.cmbAreas_SelectedIndexChanged);
            // 
            // cmbPersonal
            // 
            this.cmbPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonal.FormattingEnabled = true;
            this.cmbPersonal.Location = new System.Drawing.Point(91, 62);
            this.cmbPersonal.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPersonal.Name = "cmbPersonal";
            this.cmbPersonal.Size = new System.Drawing.Size(168, 21);
            this.cmbPersonal.TabIndex = 15;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(20, 66);
            this.lblEmpleado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(54, 13);
            this.lblEmpleado.TabIndex = 1;
            this.lblEmpleado.Text = "Empleado";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardar.Location = new System.Drawing.Point(595, 322);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(86, 28);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtgEvaluacion
            // 
            this.dtgEvaluacion.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEvaluacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEvaluacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvaluacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreApellido,
            this.Efectividad,
            this.Puntualidad,
            this.RelSuperiores,
            this.Disciplina,
            this.DesempEquipo});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgEvaluacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgEvaluacion.Location = new System.Drawing.Point(25, 166);
            this.dtgEvaluacion.Margin = new System.Windows.Forms.Padding(2);
            this.dtgEvaluacion.Name = "dtgEvaluacion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEvaluacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgEvaluacion.RowHeadersWidth = 51;
            this.dtgEvaluacion.RowTemplate.Height = 24;
            this.dtgEvaluacion.Size = new System.Drawing.Size(656, 149);
            this.dtgEvaluacion.TabIndex = 18;
            // 
            // grpPeriodo
            // 
            this.grpPeriodo.BackColor = System.Drawing.Color.White;
            this.grpPeriodo.Controls.Add(this.lblAnio);
            this.grpPeriodo.Controls.Add(this.cmbMes);
            this.grpPeriodo.Controls.Add(this.lblMes);
            this.grpPeriodo.Controls.Add(this.cmbAnio);
            this.grpPeriodo.Location = new System.Drawing.Point(410, 10);
            this.grpPeriodo.Name = "grpPeriodo";
            this.grpPeriodo.Size = new System.Drawing.Size(216, 139);
            this.grpPeriodo.TabIndex = 26;
            this.grpPeriodo.TabStop = false;
            this.grpPeriodo.Text = "Periodo de evaluación";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblReferencia.Location = new System.Drawing.Point(22, 322);
            this.lblReferencia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(398, 13);
            this.lblReferencia.TabIndex = 27;
            this.lblReferencia.Text = "ⓘ Elegir un valor dentro de la escala 1-6, siendo 1 el valor más bajo y 6 el más " +
    "alto.";
            // 
            // lnkAtras
            // 
            this.lnkAtras.AutoSize = true;
            this.lnkAtras.Location = new System.Drawing.Point(9, 345);
            this.lnkAtras.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkAtras.Name = "lnkAtras";
            this.lnkAtras.Size = new System.Drawing.Size(31, 13);
            this.lnkAtras.TabIndex = 28;
            this.lnkAtras.TabStop = true;
            this.lnkAtras.Text = "Atras";
            this.lnkAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtras_LinkClicked);
            // 
            // NombreApellido
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.NombreApellido.DefaultCellStyle = dataGridViewCellStyle2;
            this.NombreApellido.HeaderText = "Nombre y Apellido";
            this.NombreApellido.MinimumWidth = 6;
            this.NombreApellido.Name = "NombreApellido";
            this.NombreApellido.Width = 125;
            // 
            // Efectividad
            // 
            this.Efectividad.DataPropertyName = "Efectividad";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            this.Efectividad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Efectividad.HeaderText = "Efectividad en las tareas *";
            this.Efectividad.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.Efectividad.MinimumWidth = 6;
            this.Efectividad.Name = "Efectividad";
            this.Efectividad.Width = 125;
            // 
            // Puntualidad
            // 
            this.Puntualidad.DataPropertyName = "Puntualidad";
            this.Puntualidad.HeaderText = "Puntualidad *";
            this.Puntualidad.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.Puntualidad.MinimumWidth = 6;
            this.Puntualidad.Name = "Puntualidad";
            this.Puntualidad.Width = 125;
            // 
            // RelSuperiores
            // 
            this.RelSuperiores.DataPropertyName = "RelSuperiores";
            this.RelSuperiores.HeaderText = "Relación con superiores *";
            this.RelSuperiores.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.RelSuperiores.MinimumWidth = 6;
            this.RelSuperiores.Name = "RelSuperiores";
            this.RelSuperiores.Width = 125;
            // 
            // Disciplina
            // 
            this.Disciplina.DataPropertyName = "Disciplina";
            this.Disciplina.HeaderText = "Disciplina *";
            this.Disciplina.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.Disciplina.MinimumWidth = 6;
            this.Disciplina.Name = "Disciplina";
            this.Disciplina.Width = 125;
            // 
            // DesempEquipo
            // 
            this.DesempEquipo.DataPropertyName = "DesempEquipo";
            this.DesempEquipo.HeaderText = "Desempeño en equipo *";
            this.DesempEquipo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.DesempEquipo.MinimumWidth = 6;
            this.DesempEquipo.Name = "DesempEquipo";
            this.DesempEquipo.Width = 125;
            // 
            // frmAltaEvaluacionDesempenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 366);
            this.Controls.Add(this.lnkAtras);
            this.Controls.Add(this.lblReferencia);
            this.Controls.Add(this.grpPeriodo);
            this.Controls.Add(this.grpFiltrosBusqueda);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtgEvaluacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAltaEvaluacionDesempenio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Evaluacion de Desempeño";
            this.Load += new System.EventHandler(this.frmAltaEvaluacionDesempeño_Load);
            this.grpFiltrosBusqueda.ResumeLayout(false);
            this.grpFiltrosBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaluacion)).EndInit();
            this.grpPeriodo.ResumeLayout(false);
            this.grpPeriodo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.GroupBox grpFiltrosBusqueda;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cmbAreas;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dtgEvaluacion;
        private System.Windows.Forms.GroupBox grpPeriodo;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.LinkLabel lnkAtras;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreApellido;
        private System.Windows.Forms.DataGridViewComboBoxColumn Efectividad;
        private System.Windows.Forms.DataGridViewComboBoxColumn Puntualidad;
        private System.Windows.Forms.DataGridViewComboBoxColumn RelSuperiores;
        private System.Windows.Forms.DataGridViewComboBoxColumn Disciplina;
        private System.Windows.Forms.DataGridViewComboBoxColumn DesempEquipo;
    }
}