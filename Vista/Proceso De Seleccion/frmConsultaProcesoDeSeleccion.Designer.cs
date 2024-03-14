namespace Vista
{
    partial class frmConsultaProcesoDeSeleccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaProcesoDeSeleccion));
            this.btnIngresarEmpleado = new System.Windows.Forms.Button();
            this.btnEtapas = new System.Windows.Forms.Button();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtCuilCuit = new System.Windows.Forms.TextBox();
            this.lblCuilCuit = new System.Windows.Forms.Label();
            this.dtgCandidatos = new System.Windows.Forms.DataGridView();
            this.Etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Entrevista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrevistador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificarCandidato = new System.Windows.Forms.Button();
            this.lblCuil = new System.Windows.Forms.Label();
            this.lblCuilLlenar = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombreLlenar = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblApellidoLlenar = new System.Windows.Forms.Label();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCandidatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIngresarEmpleado
            // 
            this.btnIngresarEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnIngresarEmpleado.Enabled = false;
            this.btnIngresarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngresarEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnIngresarEmpleado.Location = new System.Drawing.Point(146, 306);
            this.btnIngresarEmpleado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIngresarEmpleado.Name = "btnIngresarEmpleado";
            this.btnIngresarEmpleado.Size = new System.Drawing.Size(112, 33);
            this.btnIngresarEmpleado.TabIndex = 13;
            this.btnIngresarEmpleado.Text = "Ingresar Empleado";
            this.btnIngresarEmpleado.UseVisualStyleBackColor = false;
            this.btnIngresarEmpleado.Click += new System.EventHandler(this.btnIngresarEmpleado_Click);
            // 
            // btnEtapas
            // 
            this.btnEtapas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnEtapas.Enabled = false;
            this.btnEtapas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEtapas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEtapas.Location = new System.Drawing.Point(536, 306);
            this.btnEtapas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEtapas.Name = "btnEtapas";
            this.btnEtapas.Size = new System.Drawing.Size(78, 33);
            this.btnEtapas.TabIndex = 12;
            this.btnEtapas.Text = "Ver proceso";
            this.btnEtapas.UseVisualStyleBackColor = false;
            this.btnEtapas.Click += new System.EventHandler(this.btnEtapas_Click);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.btnFiltrar);
            this.grpFiltros.Controls.Add(this.txtCuilCuit);
            this.grpFiltros.Controls.Add(this.lblCuilCuit);
            this.grpFiltros.Location = new System.Drawing.Point(104, 35);
            this.grpFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFiltros.Size = new System.Drawing.Size(416, 51);
            this.grpFiltros.TabIndex = 9;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFiltrar.Location = new System.Drawing.Point(336, 12);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(56, 26);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCuilCuit
            // 
            this.txtCuilCuit.Location = new System.Drawing.Point(131, 15);
            this.txtCuilCuit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCuilCuit.MaxLength = 11;
            this.txtCuilCuit.Name = "txtCuilCuit";
            this.txtCuilCuit.Size = new System.Drawing.Size(168, 20);
            this.txtCuilCuit.TabIndex = 5;
            this.txtCuilCuit.TextChanged += new System.EventHandler(this.txtCuilCuit_TextChanged);
            this.txtCuilCuit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuilCuit_KeyPress);
            this.txtCuilCuit.Leave += new System.EventHandler(this.txtCuilCuit_Leave);
            // 
            // lblCuilCuit
            // 
            this.lblCuilCuit.AutoSize = true;
            this.lblCuilCuit.Location = new System.Drawing.Point(13, 18);
            this.lblCuilCuit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCuilCuit.Name = "lblCuilCuit";
            this.lblCuilCuit.Size = new System.Drawing.Size(61, 13);
            this.lblCuilCuit.TabIndex = 0;
            this.lblCuilCuit.Text = "CUIL/CUIT";
            // 
            // dtgCandidatos
            // 
            this.dtgCandidatos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgCandidatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCandidatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Etapa,
            this.Estado,
            this.Puesto,
            this.Fecha_Entrevista,
            this.Entrevistador,
            this.ID});
            this.dtgCandidatos.Location = new System.Drawing.Point(30, 138);
            this.dtgCandidatos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtgCandidatos.Name = "dtgCandidatos";
            this.dtgCandidatos.RowHeadersWidth = 51;
            this.dtgCandidatos.RowTemplate.Height = 24;
            this.dtgCandidatos.Size = new System.Drawing.Size(584, 154);
            this.dtgCandidatos.TabIndex = 8;
            this.dtgCandidatos.SelectionChanged += new System.EventHandler(this.dtgCandidatos_SelectionChanged);
            // 
            // Etapa
            // 
            this.Etapa.HeaderText = "Etapa";
            this.Etapa.MinimumWidth = 6;
            this.Etapa.Name = "Etapa";
            this.Etapa.Width = 95;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.Width = 95;
            // 
            // Puesto
            // 
            this.Puesto.HeaderText = "Puesto a postularse";
            this.Puesto.MinimumWidth = 6;
            this.Puesto.Name = "Puesto";
            this.Puesto.Width = 125;
            // 
            // Fecha_Entrevista
            // 
            this.Fecha_Entrevista.DataPropertyName = "Fecha_Entrevista";
            this.Fecha_Entrevista.HeaderText = "Fecha";
            this.Fecha_Entrevista.MinimumWidth = 6;
            this.Fecha_Entrevista.Name = "Fecha_Entrevista";
            this.Fecha_Entrevista.Width = 125;
            // 
            // Entrevistador
            // 
            this.Entrevistador.DataPropertyName = "Entrevistador";
            this.Entrevistador.HeaderText = "Entrevistador";
            this.Entrevistador.MinimumWidth = 6;
            this.Entrevistador.Name = "Entrevistador";
            this.Entrevistador.Width = 125;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // btnModificarCandidato
            // 
            this.btnModificarCandidato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnModificarCandidato.Enabled = false;
            this.btnModificarCandidato.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificarCandidato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnModificarCandidato.Location = new System.Drawing.Point(30, 306);
            this.btnModificarCandidato.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificarCandidato.Name = "btnModificarCandidato";
            this.btnModificarCandidato.Size = new System.Drawing.Size(112, 33);
            this.btnModificarCandidato.TabIndex = 14;
            this.btnModificarCandidato.Text = "Modificar Candidato";
            this.btnModificarCandidato.UseVisualStyleBackColor = false;
            this.btnModificarCandidato.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblCuil
            // 
            this.lblCuil.AutoSize = true;
            this.lblCuil.Location = new System.Drawing.Point(27, 123);
            this.lblCuil.Name = "lblCuil";
            this.lblCuil.Size = new System.Drawing.Size(64, 13);
            this.lblCuil.TabIndex = 15;
            this.lblCuil.Text = "CUIL/CUIT:";
            // 
            // lblCuilLlenar
            // 
            this.lblCuilLlenar.AutoSize = true;
            this.lblCuilLlenar.Location = new System.Drawing.Point(96, 123);
            this.lblCuilLlenar.Name = "lblCuilLlenar";
            this.lblCuilLlenar.Size = new System.Drawing.Size(0, 13);
            this.lblCuilLlenar.TabIndex = 16;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(216, 123);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = "Nombre: ";
            this.lblNombre.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblNombreLlenar
            // 
            this.lblNombreLlenar.AutoSize = true;
            this.lblNombreLlenar.Location = new System.Drawing.Point(269, 123);
            this.lblNombreLlenar.Name = "lblNombreLlenar";
            this.lblNombreLlenar.Size = new System.Drawing.Size(0, 13);
            this.lblNombreLlenar.TabIndex = 18;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(433, 123);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(50, 13);
            this.lblApellido.TabIndex = 19;
            this.lblApellido.Text = "Apellido: ";
            // 
            // lblApellidoLlenar
            // 
            this.lblApellidoLlenar.AutoSize = true;
            this.lblApellidoLlenar.Location = new System.Drawing.Point(486, 122);
            this.lblApellidoLlenar.Name = "lblApellidoLlenar";
            this.lblApellidoLlenar.Size = new System.Drawing.Size(0, 13);
            this.lblApellidoLlenar.TabIndex = 20;
            // 
            // lnkAtras
            // 
            this.lnkAtras.AutoSize = true;
            this.lnkAtras.Location = new System.Drawing.Point(12, 441);
            this.lnkAtras.Name = "lnkAtras";
            this.lnkAtras.Size = new System.Drawing.Size(38, 16);
            this.lnkAtras.TabIndex = 21;
            this.lnkAtras.TabStop = true;
            this.lnkAtras.Text = "Atras";
            this.lnkAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmConsultaProcesoDeSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 466);
            this.Controls.Add(this.lnkAtras);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblApellidoLlenar);
            this.Controls.Add(this.lblNombreLlenar);
            this.Controls.Add(this.lblCuilLlenar);
            this.Controls.Add(this.lblCuil);
            this.Controls.Add(this.btnModificarCandidato);
            this.Controls.Add(this.btnIngresarEmpleado);
            this.Controls.Add(this.btnEtapas);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.dtgCandidatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmConsultaProcesoDeSeleccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Candidatos";
            this.Load += new System.EventHandler(this.frmConsultaProcesoDeSeleccion_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCandidatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresarEmpleado;
        private System.Windows.Forms.Button btnEtapas;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblCuilCuit;
        private System.Windows.Forms.Button btnModificarCandidato;
        private System.Windows.Forms.Label lblCuil;
        private System.Windows.Forms.Label lblCuilLlenar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNombreLlenar;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Entrevista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrevistador;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Label lblApellidoLlenar;
        public System.Windows.Forms.TextBox txtCuilCuit;
        public System.Windows.Forms.DataGridView dtgCandidatos;
        private System.Windows.Forms.LinkLabel lnkAtras;
    }
}