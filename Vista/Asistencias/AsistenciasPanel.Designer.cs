namespace Vista
{
    partial class AsistenciasPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.valorPuesto = new System.Windows.Forms.Label();
            this.valorArea = new System.Windows.Forms.Label();
            this.valorApellido = new System.Windows.Forms.Label();
            this.valorNombre = new System.Windows.Forms.Label();
            this.dttFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dttFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.checkJustificada = new System.Windows.Forms.CheckBox();
            this.fecha = new System.Windows.Forms.Label();
            this.fechaDesde = new System.Windows.Forms.Label();
            this.fechaHasta = new System.Windows.Forms.Label();
            this.dttFecha = new System.Windows.Forms.DateTimePicker();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblOtro = new System.Windows.Forms.Label();
            this.cmbMotivo = new System.Windows.Forms.ComboBox();
            this.txtOtro = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkPeriodo = new System.Windows.Forms.CheckBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-162, -118);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(21, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(21, 64);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(319, 28);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 3;
            this.lblArea.Text = "Àrea:";
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Location = new System.Drawing.Point(319, 64);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(43, 13);
            this.lblPuesto.TabIndex = 4;
            this.lblPuesto.Text = "Puesto:";
            // 
            // valorPuesto
            // 
            this.valorPuesto.AutoSize = true;
            this.valorPuesto.Location = new System.Drawing.Point(367, 64);
            this.valorPuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.valorPuesto.Name = "valorPuesto";
            this.valorPuesto.Size = new System.Drawing.Size(13, 13);
            this.valorPuesto.TabIndex = 5;
            this.valorPuesto.Text = "--";
            this.valorPuesto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.valorPuesto.Click += new System.EventHandler(this.valorPuesto_Click);
            // 
            // valorArea
            // 
            this.valorArea.AutoSize = true;
            this.valorArea.Location = new System.Drawing.Point(356, 28);
            this.valorArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.valorArea.Name = "valorArea";
            this.valorArea.Size = new System.Drawing.Size(13, 13);
            this.valorArea.TabIndex = 6;
            this.valorArea.Text = "--";
            // 
            // valorApellido
            // 
            this.valorApellido.AutoSize = true;
            this.valorApellido.Location = new System.Drawing.Point(73, 64);
            this.valorApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.valorApellido.Name = "valorApellido";
            this.valorApellido.Size = new System.Drawing.Size(13, 13);
            this.valorApellido.TabIndex = 7;
            this.valorApellido.Text = "--";
            // 
            // valorNombre
            // 
            this.valorNombre.AutoSize = true;
            this.valorNombre.Location = new System.Drawing.Point(73, 28);
            this.valorNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.valorNombre.Name = "valorNombre";
            this.valorNombre.Size = new System.Drawing.Size(13, 13);
            this.valorNombre.TabIndex = 8;
            this.valorNombre.Text = "--";
            // 
            // dttFechaDesde
            // 
            this.dttFechaDesde.Location = new System.Drawing.Point(98, 189);
            this.dttFechaDesde.Name = "dttFechaDesde";
            this.dttFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dttFechaDesde.TabIndex = 10;
            // 
            // dttFechaHasta
            // 
            this.dttFechaHasta.Location = new System.Drawing.Point(396, 190);
            this.dttFechaHasta.Name = "dttFechaHasta";
            this.dttFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dttFechaHasta.TabIndex = 11;
            this.dttFechaHasta.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // checkJustificada
            // 
            this.checkJustificada.AutoSize = true;
            this.checkJustificada.Location = new System.Drawing.Point(24, 304);
            this.checkJustificada.Margin = new System.Windows.Forms.Padding(2);
            this.checkJustificada.Name = "checkJustificada";
            this.checkJustificada.Size = new System.Drawing.Size(76, 17);
            this.checkJustificada.TabIndex = 12;
            this.checkJustificada.Text = "Justificada";
            this.checkJustificada.UseVisualStyleBackColor = true;
            this.checkJustificada.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Location = new System.Drawing.Point(21, 155);
            this.fecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(40, 13);
            this.fecha.TabIndex = 13;
            this.fecha.Text = "Fecha:";
            this.fecha.Click += new System.EventHandler(this.fecha_Click);
            // 
            // fechaDesde
            // 
            this.fechaDesde.AutoSize = true;
            this.fechaDesde.Location = new System.Drawing.Point(21, 195);
            this.fechaDesde.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(72, 13);
            this.fechaDesde.TabIndex = 14;
            this.fechaDesde.Text = "Fecha desde:";
            // 
            // fechaHasta
            // 
            this.fechaHasta.AutoSize = true;
            this.fechaHasta.Location = new System.Drawing.Point(319, 196);
            this.fechaHasta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(69, 13);
            this.fechaHasta.TabIndex = 15;
            this.fechaHasta.Text = "Fecha hasta:";
            this.fechaHasta.Click += new System.EventHandler(this.fechaHasta_Click);
            // 
            // dttFecha
            // 
            this.dttFecha.Location = new System.Drawing.Point(66, 149);
            this.dttFecha.Name = "dttFecha";
            this.dttFecha.Size = new System.Drawing.Size(200, 20);
            this.dttFecha.TabIndex = 16;
            this.dttFecha.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(21, 251);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(42, 13);
            this.lblMotivo.TabIndex = 17;
            this.lblMotivo.Text = "Motivo:";
            // 
            // lblOtro
            // 
            this.lblOtro.AutoSize = true;
            this.lblOtro.Location = new System.Drawing.Point(180, 270);
            this.lblOtro.Name = "lblOtro";
            this.lblOtro.Size = new System.Drawing.Size(30, 13);
            this.lblOtro.TabIndex = 18;
            this.lblOtro.Text = "Otro:";
            // 
            // cmbMotivo
            // 
            this.cmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMotivo.FormattingEnabled = true;
            this.cmbMotivo.Location = new System.Drawing.Point(24, 266);
            this.cmbMotivo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMotivo.Name = "cmbMotivo";
            this.cmbMotivo.Size = new System.Drawing.Size(148, 21);
            this.cmbMotivo.TabIndex = 19;
            this.cmbMotivo.SelectedIndexChanged += new System.EventHandler(this.cmbMotivo_SelectedIndexChanged);
            // 
            // txtOtro
            // 
            this.txtOtro.Location = new System.Drawing.Point(219, 267);
            this.txtOtro.MaxLength = 50;
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.Size = new System.Drawing.Size(143, 20);
            this.txtOtro.TabIndex = 20;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(308, 313);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(81, 13);
            this.lblObservaciones.TabIndex = 22;
            this.lblObservaciones.Text = "Observaciones:";
            this.lblObservaciones.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(514, 499);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(93, 29);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(311, 499);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 29);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkPeriodo
            // 
            this.checkPeriodo.AutoSize = true;
            this.checkPeriodo.Location = new System.Drawing.Point(24, 109);
            this.checkPeriodo.Margin = new System.Windows.Forms.Padding(2);
            this.checkPeriodo.Name = "checkPeriodo";
            this.checkPeriodo.Size = new System.Drawing.Size(62, 17);
            this.checkPeriodo.TabIndex = 25;
            this.checkPeriodo.Text = "Periodo";
            this.checkPeriodo.UseVisualStyleBackColor = true;
            this.checkPeriodo.CheckedChanged += new System.EventHandler(this.checkPeriodo_CheckedChanged);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(310, 329);
            this.txtObservaciones.MaxLength = 50;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(301, 128);
            this.txtObservaciones.TabIndex = 26;
            // 
            // AsistenciasPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 565);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.checkPeriodo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.txtOtro);
            this.Controls.Add(this.cmbMotivo);
            this.Controls.Add(this.lblOtro);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.dttFecha);
            this.Controls.Add(this.fechaHasta);
            this.Controls.Add(this.fechaDesde);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.checkJustificada);
            this.Controls.Add(this.dttFechaHasta);
            this.Controls.Add(this.dttFechaDesde);
            this.Controls.Add(this.valorNombre);
            this.Controls.Add(this.valorApellido);
            this.Controls.Add(this.valorArea);
            this.Controls.Add(this.valorPuesto);
            this.Controls.Add(this.lblPuesto);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AsistenciasPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AsistenciasPanel";
            this.Load += new System.EventHandler(this.AsistenciasPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.Label valorPuesto;
        private System.Windows.Forms.Label valorArea;
        private System.Windows.Forms.Label valorApellido;
        private System.Windows.Forms.Label valorNombre;
        private System.Windows.Forms.DateTimePicker dttFechaDesde;
        private System.Windows.Forms.DateTimePicker dttFechaHasta;
        private System.Windows.Forms.CheckBox checkJustificada;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Label fechaDesde;
        private System.Windows.Forms.Label fechaHasta;
        private System.Windows.Forms.DateTimePicker dttFecha;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Label lblOtro;
        private System.Windows.Forms.ComboBox cmbMotivo;
        private System.Windows.Forms.TextBox txtOtro;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkPeriodo;
        private System.Windows.Forms.TextBox txtObservaciones;
    }
}