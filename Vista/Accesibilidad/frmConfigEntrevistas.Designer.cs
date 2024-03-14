namespace Vista.Accesibilidad
{
    partial class frmConfigEntrevistas
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
            this.txtNombreEntrevista = new System.Windows.Forms.TextBox();
            this.lblNombreEntrevista = new System.Windows.Forms.Label();
            this.dtgEntrevistas = new System.Windows.Forms.DataGridView();
            this.etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entrevista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.grpAltaEntrevista = new System.Windows.Forms.GroupBox();
            this.lblInstancia = new System.Windows.Forms.Label();
            this.txtInstancia = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpModEntrevista = new System.Windows.Forms.GroupBox();
            this.lblInstanciaMod = new System.Windows.Forms.Label();
            this.txtInstanciaMod = new System.Windows.Forms.TextBox();
            this.btnModCancelar = new System.Windows.Forms.Button();
            this.btnModGuardar = new System.Windows.Forms.Button();
            this.lblModEntrevista = new System.Windows.Forms.Label();
            this.txtModNombre = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEntrevistas)).BeginInit();
            this.grpAltaEntrevista.SuspendLayout();
            this.grpModEntrevista.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombreEntrevista
            // 
            this.txtNombreEntrevista.Location = new System.Drawing.Point(194, 37);
            this.txtNombreEntrevista.Name = "txtNombreEntrevista";
            this.txtNombreEntrevista.Size = new System.Drawing.Size(192, 20);
            this.txtNombreEntrevista.TabIndex = 0;
            // 
            // lblNombreEntrevista
            // 
            this.lblNombreEntrevista.AutoSize = true;
            this.lblNombreEntrevista.Location = new System.Drawing.Point(144, 40);
            this.lblNombreEntrevista.Name = "lblNombreEntrevista";
            this.lblNombreEntrevista.Size = new System.Drawing.Size(44, 13);
            this.lblNombreEntrevista.TabIndex = 1;
            this.lblNombreEntrevista.Text = "Nombre";
            // 
            // dtgEntrevistas
            // 
            this.dtgEntrevistas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgEntrevistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEntrevistas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.etapa,
            this.entrevista});
            this.dtgEntrevistas.Location = new System.Drawing.Point(33, 50);
            this.dtgEntrevistas.Name = "dtgEntrevistas";
            this.dtgEntrevistas.RowHeadersWidth = 51;
            this.dtgEntrevistas.Size = new System.Drawing.Size(240, 287);
            this.dtgEntrevistas.TabIndex = 2;
            this.dtgEntrevistas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEntrevistas_CellClick);
            this.dtgEntrevistas.SelectionChanged += new System.EventHandler(this.dtgEntrevistas_SelectionChanged);
            this.dtgEntrevistas.DoubleClick += new System.EventHandler(this.dtgEntrevistas_DoubleClick);
            // 
            // etapa
            // 
            this.etapa.DataPropertyName = "etapa";
            this.etapa.HeaderText = "ID";
            this.etapa.MinimumWidth = 6;
            this.etapa.Name = "etapa";
            this.etapa.Width = 80;
            // 
            // entrevista
            // 
            this.entrevista.DataPropertyName = "entrevista";
            this.entrevista.HeaderText = "Entrevista";
            this.entrevista.MinimumWidth = 6;
            this.entrevista.Name = "entrevista";
            this.entrevista.Width = 125;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardar.Location = new System.Drawing.Point(311, 89);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // grpAltaEntrevista
            // 
            this.grpAltaEntrevista.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpAltaEntrevista.Controls.Add(this.lblInstancia);
            this.grpAltaEntrevista.Controls.Add(this.txtInstancia);
            this.grpAltaEntrevista.Controls.Add(this.btnCancelar);
            this.grpAltaEntrevista.Controls.Add(this.btnGuardar);
            this.grpAltaEntrevista.Controls.Add(this.lblNombreEntrevista);
            this.grpAltaEntrevista.Controls.Add(this.txtNombreEntrevista);
            this.grpAltaEntrevista.Location = new System.Drawing.Point(304, 50);
            this.grpAltaEntrevista.Name = "grpAltaEntrevista";
            this.grpAltaEntrevista.Size = new System.Drawing.Size(398, 128);
            this.grpAltaEntrevista.TabIndex = 4;
            this.grpAltaEntrevista.TabStop = false;
            this.grpAltaEntrevista.Text = "Alta de Entrevista";
            // 
            // lblInstancia
            // 
            this.lblInstancia.AutoSize = true;
            this.lblInstancia.Location = new System.Drawing.Point(7, 40);
            this.lblInstancia.Name = "lblInstancia";
            this.lblInstancia.Size = new System.Drawing.Size(50, 13);
            this.lblInstancia.TabIndex = 6;
            this.lblInstancia.Text = "Instancia";
            // 
            // txtInstancia
            // 
            this.txtInstancia.Location = new System.Drawing.Point(62, 37);
            this.txtInstancia.Name = "txtInstancia";
            this.txtInstancia.Size = new System.Drawing.Size(51, 20);
            this.txtInstancia.TabIndex = 5;
            this.txtInstancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Location = new System.Drawing.Point(10, 89);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grpModEntrevista
            // 
            this.grpModEntrevista.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpModEntrevista.Controls.Add(this.lblInstanciaMod);
            this.grpModEntrevista.Controls.Add(this.txtInstanciaMod);
            this.grpModEntrevista.Controls.Add(this.btnModCancelar);
            this.grpModEntrevista.Controls.Add(this.btnModGuardar);
            this.grpModEntrevista.Controls.Add(this.lblModEntrevista);
            this.grpModEntrevista.Controls.Add(this.txtModNombre);
            this.grpModEntrevista.Location = new System.Drawing.Point(304, 209);
            this.grpModEntrevista.Name = "grpModEntrevista";
            this.grpModEntrevista.Size = new System.Drawing.Size(398, 128);
            this.grpModEntrevista.TabIndex = 5;
            this.grpModEntrevista.TabStop = false;
            this.grpModEntrevista.Text = "Modificar Entrevista";
            // 
            // lblInstanciaMod
            // 
            this.lblInstanciaMod.AutoSize = true;
            this.lblInstanciaMod.Location = new System.Drawing.Point(7, 40);
            this.lblInstanciaMod.Name = "lblInstanciaMod";
            this.lblInstanciaMod.Size = new System.Drawing.Size(50, 13);
            this.lblInstanciaMod.TabIndex = 8;
            this.lblInstanciaMod.Text = "Instancia";
            // 
            // txtInstanciaMod
            // 
            this.txtInstanciaMod.Location = new System.Drawing.Point(62, 37);
            this.txtInstanciaMod.Name = "txtInstanciaMod";
            this.txtInstanciaMod.Size = new System.Drawing.Size(51, 20);
            this.txtInstanciaMod.TabIndex = 7;
            this.txtInstanciaMod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // btnModCancelar
            // 
            this.btnModCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnModCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModCancelar.Location = new System.Drawing.Point(10, 89);
            this.btnModCancelar.Name = "btnModCancelar";
            this.btnModCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnModCancelar.TabIndex = 4;
            this.btnModCancelar.Text = "Cancelar";
            this.btnModCancelar.UseVisualStyleBackColor = false;
            this.btnModCancelar.Click += new System.EventHandler(this.btnModCancelar_Click);
            // 
            // btnModGuardar
            // 
            this.btnModGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnModGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModGuardar.Location = new System.Drawing.Point(311, 89);
            this.btnModGuardar.Name = "btnModGuardar";
            this.btnModGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnModGuardar.TabIndex = 3;
            this.btnModGuardar.Text = "Guardar";
            this.btnModGuardar.UseVisualStyleBackColor = false;
            this.btnModGuardar.Click += new System.EventHandler(this.btnModGuardar_Click);
            // 
            // lblModEntrevista
            // 
            this.lblModEntrevista.AutoSize = true;
            this.lblModEntrevista.Location = new System.Drawing.Point(144, 40);
            this.lblModEntrevista.Name = "lblModEntrevista";
            this.lblModEntrevista.Size = new System.Drawing.Size(44, 13);
            this.lblModEntrevista.TabIndex = 1;
            this.lblModEntrevista.Text = "Nombre";
            // 
            // txtModNombre
            // 
            this.txtModNombre.Location = new System.Drawing.Point(194, 37);
            this.txtModNombre.Name = "txtModNombre";
            this.txtModNombre.Size = new System.Drawing.Size(192, 20);
            this.txtModNombre.TabIndex = 0;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.Location = new System.Drawing.Point(33, 344);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.Location = new System.Drawing.Point(198, 344);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Dar de Baja";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lnkAtras
            // 
            this.lnkAtras.AutoSize = true;
            this.lnkAtras.Location = new System.Drawing.Point(11, 387);
            this.lnkAtras.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkAtras.Name = "lnkAtras";
            this.lnkAtras.Size = new System.Drawing.Size(31, 13);
            this.lnkAtras.TabIndex = 7;
            this.lnkAtras.TabStop = true;
            this.lnkAtras.Text = "Atras";
            this.lnkAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtras_LinkClicked);
            // 
            // frmConfigEntrevistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 409);
            this.Controls.Add(this.lnkAtras);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.grpModEntrevista);
            this.Controls.Add(this.dtgEntrevistas);
            this.Controls.Add(this.grpAltaEntrevista);
            this.Name = "frmConfigEntrevistas";
            this.Text = "Configurar Entrevistas del Proceso de Seleccion";
            ((System.ComponentModel.ISupportInitialize)(this.dtgEntrevistas)).EndInit();
            this.grpAltaEntrevista.ResumeLayout(false);
            this.grpAltaEntrevista.PerformLayout();
            this.grpModEntrevista.ResumeLayout(false);
            this.grpModEntrevista.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreEntrevista;
        private System.Windows.Forms.Label lblNombreEntrevista;
        private System.Windows.Forms.DataGridView dtgEntrevistas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox grpAltaEntrevista;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpModEntrevista;
        private System.Windows.Forms.Button btnModCancelar;
        private System.Windows.Forms.Button btnModGuardar;
        private System.Windows.Forms.Label lblModEntrevista;
        private System.Windows.Forms.TextBox txtModNombre;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblInstancia;
        private System.Windows.Forms.TextBox txtInstancia;
        private System.Windows.Forms.Label lblInstanciaMod;
        private System.Windows.Forms.TextBox txtInstanciaMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn entrevista;
        private System.Windows.Forms.LinkLabel lnkAtras;
    }
}