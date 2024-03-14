namespace Vista
{
    partial class frmCategorias
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
            this.dtgCategoria = new System.Windows.Forms.DataGridView();
            this.btnBaja = new System.Windows.Forms.Button();
            this.grpCrearCategoria = new System.Windows.Forms.GroupBox();
            this.btnGuardarCrear = new System.Windows.Forms.Button();
            this.btnCancelarCrear = new System.Windows.Forms.Button();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.lblSueldo = new System.Windows.Forms.Label();
            this.txtJornada = new System.Windows.Forms.TextBox();
            this.lblJornada = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.grpModificarCategoria = new System.Windows.Forms.GroupBox();
            this.btnGuardarModif = new System.Windows.Forms.Button();
            this.btnCancelarModif = new System.Windows.Forms.Button();
            this.txtSueldoModif = new System.Windows.Forms.TextBox();
            this.lblSueldoModif = new System.Windows.Forms.Label();
            this.txtJornadaModif = new System.Windows.Forms.TextBox();
            this.lblJornadaModif = new System.Windows.Forms.Label();
            this.txtCategoriaModif = new System.Windows.Forms.TextBox();
            this.lblCategoriaModif = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCategoria)).BeginInit();
            this.grpCrearCategoria.SuspendLayout();
            this.grpModificarCategoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgCategoria
            // 
            this.dtgCategoria.AllowUserToAddRows = false;
            this.dtgCategoria.AllowUserToDeleteRows = false;
            this.dtgCategoria.BackgroundColor = System.Drawing.Color.White;
            this.dtgCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCategoria.Location = new System.Drawing.Point(37, 37);
            this.dtgCategoria.Name = "dtgCategoria";
            this.dtgCategoria.ReadOnly = true;
            this.dtgCategoria.RowHeadersWidth = 51;
            this.dtgCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCategoria.Size = new System.Drawing.Size(357, 352);
            this.dtgCategoria.TabIndex = 0;
            this.dtgCategoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCategoria_CellContentClick);
            this.dtgCategoria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCategoria_CellDoubleClick);
            this.dtgCategoria.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCategoria_CellContentClick);
            this.dtgCategoria.Leave += new System.EventHandler(this.dtgCategoria_Leave);
            // 
            // btnBaja
            // 
            this.btnBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBaja.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBaja.Location = new System.Drawing.Point(320, 396);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 1;
            this.btnBaja.Text = "Dar de Baja";
            this.btnBaja.UseVisualStyleBackColor = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // grpCrearCategoria
            // 
            this.grpCrearCategoria.Controls.Add(this.btnGuardarCrear);
            this.grpCrearCategoria.Controls.Add(this.btnCancelarCrear);
            this.grpCrearCategoria.Controls.Add(this.txtSueldo);
            this.grpCrearCategoria.Controls.Add(this.lblSueldo);
            this.grpCrearCategoria.Controls.Add(this.txtJornada);
            this.grpCrearCategoria.Controls.Add(this.lblJornada);
            this.grpCrearCategoria.Controls.Add(this.txtCategoria);
            this.grpCrearCategoria.Controls.Add(this.lblCategoria);
            this.grpCrearCategoria.Location = new System.Drawing.Point(413, 37);
            this.grpCrearCategoria.Name = "grpCrearCategoria";
            this.grpCrearCategoria.Size = new System.Drawing.Size(250, 172);
            this.grpCrearCategoria.TabIndex = 2;
            this.grpCrearCategoria.TabStop = false;
            this.grpCrearCategoria.Text = "Crear Categoria";
            // 
            // btnGuardarCrear
            // 
            this.btnGuardarCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnGuardarCrear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarCrear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardarCrear.Location = new System.Drawing.Point(146, 143);
            this.btnGuardarCrear.Name = "btnGuardarCrear";
            this.btnGuardarCrear.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCrear.TabIndex = 7;
            this.btnGuardarCrear.Text = "Guardar";
            this.btnGuardarCrear.UseVisualStyleBackColor = false;
            this.btnGuardarCrear.Click += new System.EventHandler(this.btnGuardarCrear_Click);
            // 
            // btnCancelarCrear
            // 
            this.btnCancelarCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnCancelarCrear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarCrear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelarCrear.Location = new System.Drawing.Point(19, 143);
            this.btnCancelarCrear.Name = "btnCancelarCrear";
            this.btnCancelarCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCrear.TabIndex = 6;
            this.btnCancelarCrear.Text = "Cancelar";
            this.btnCancelarCrear.UseVisualStyleBackColor = false;
            this.btnCancelarCrear.Click += new System.EventHandler(this.btnCancelarCrear_Click);
            // 
            // txtSueldo
            // 
            this.txtSueldo.Location = new System.Drawing.Point(103, 102);
            this.txtSueldo.MaxLength = 7;
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.Size = new System.Drawing.Size(135, 20);
            this.txtSueldo.TabIndex = 5;
            this.txtSueldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSueldo_KeyPress);
            // 
            // lblSueldo
            // 
            this.lblSueldo.AutoSize = true;
            this.lblSueldo.Location = new System.Drawing.Point(16, 105);
            this.lblSueldo.Name = "lblSueldo";
            this.lblSueldo.Size = new System.Drawing.Size(40, 13);
            this.lblSueldo.TabIndex = 4;
            this.lblSueldo.Text = "Sueldo";
            // 
            // txtJornada
            // 
            this.txtJornada.Location = new System.Drawing.Point(103, 66);
            this.txtJornada.MaxLength = 5;
            this.txtJornada.Name = "txtJornada";
            this.txtJornada.Size = new System.Drawing.Size(135, 20);
            this.txtJornada.TabIndex = 3;
            this.txtJornada.TextChanged += new System.EventHandler(this.txtJornada_TextChanged);
            this.txtJornada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJornada_KeyPress);
            // 
            // lblJornada
            // 
            this.lblJornada.AutoSize = true;
            this.lblJornada.Location = new System.Drawing.Point(16, 68);
            this.lblJornada.Name = "lblJornada";
            this.lblJornada.Size = new System.Drawing.Size(84, 13);
            this.lblJornada.TabIndex = 2;
            this.lblJornada.Text = "Horas Laborales";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(103, 31);
            this.txtCategoria.MaxLength = 30;
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(135, 20);
            this.txtCategoria.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(16, 33);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 0;
            this.lblCategoria.Text = "Categoria";
            // 
            // grpModificarCategoria
            // 
            this.grpModificarCategoria.Controls.Add(this.btnGuardarModif);
            this.grpModificarCategoria.Controls.Add(this.btnCancelarModif);
            this.grpModificarCategoria.Controls.Add(this.txtSueldoModif);
            this.grpModificarCategoria.Controls.Add(this.lblSueldoModif);
            this.grpModificarCategoria.Controls.Add(this.txtJornadaModif);
            this.grpModificarCategoria.Controls.Add(this.lblJornadaModif);
            this.grpModificarCategoria.Controls.Add(this.txtCategoriaModif);
            this.grpModificarCategoria.Controls.Add(this.lblCategoriaModif);
            this.grpModificarCategoria.Location = new System.Drawing.Point(413, 217);
            this.grpModificarCategoria.Name = "grpModificarCategoria";
            this.grpModificarCategoria.Size = new System.Drawing.Size(250, 172);
            this.grpModificarCategoria.TabIndex = 8;
            this.grpModificarCategoria.TabStop = false;
            this.grpModificarCategoria.Text = "Modificar Categoria";
            this.grpModificarCategoria.Enter += new System.EventHandler(this.grpModificarCategoria_Enter);
            // 
            // btnGuardarModif
            // 
            this.btnGuardarModif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnGuardarModif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarModif.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardarModif.Location = new System.Drawing.Point(146, 143);
            this.btnGuardarModif.Name = "btnGuardarModif";
            this.btnGuardarModif.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarModif.TabIndex = 7;
            this.btnGuardarModif.Text = "Guardar";
            this.btnGuardarModif.UseVisualStyleBackColor = false;
            this.btnGuardarModif.Click += new System.EventHandler(this.btnGuardarModif_Click);
            // 
            // btnCancelarModif
            // 
            this.btnCancelarModif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnCancelarModif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarModif.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelarModif.Location = new System.Drawing.Point(19, 143);
            this.btnCancelarModif.Name = "btnCancelarModif";
            this.btnCancelarModif.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarModif.TabIndex = 6;
            this.btnCancelarModif.Text = "Cancelar";
            this.btnCancelarModif.UseVisualStyleBackColor = false;
            this.btnCancelarModif.Click += new System.EventHandler(this.btnCancelarModif_Click);
            // 
            // txtSueldoModif
            // 
            this.txtSueldoModif.Location = new System.Drawing.Point(103, 102);
            this.txtSueldoModif.MaxLength = 7;
            this.txtSueldoModif.Name = "txtSueldoModif";
            this.txtSueldoModif.Size = new System.Drawing.Size(135, 20);
            this.txtSueldoModif.TabIndex = 5;
            this.txtSueldoModif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSueldoModif_KeyPress);
            // 
            // lblSueldoModif
            // 
            this.lblSueldoModif.AutoSize = true;
            this.lblSueldoModif.Location = new System.Drawing.Point(16, 105);
            this.lblSueldoModif.Name = "lblSueldoModif";
            this.lblSueldoModif.Size = new System.Drawing.Size(40, 13);
            this.lblSueldoModif.TabIndex = 4;
            this.lblSueldoModif.Text = "Sueldo";
            // 
            // txtJornadaModif
            // 
            this.txtJornadaModif.Location = new System.Drawing.Point(103, 66);
            this.txtJornadaModif.MaxLength = 5;
            this.txtJornadaModif.Name = "txtJornadaModif";
            this.txtJornadaModif.Size = new System.Drawing.Size(135, 20);
            this.txtJornadaModif.TabIndex = 3;
            this.txtJornadaModif.TextChanged += new System.EventHandler(this.txtJornadaModif_TextChanged);
            this.txtJornadaModif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJornadaModif_KeyPress);
            // 
            // lblJornadaModif
            // 
            this.lblJornadaModif.AutoSize = true;
            this.lblJornadaModif.Location = new System.Drawing.Point(16, 68);
            this.lblJornadaModif.Name = "lblJornadaModif";
            this.lblJornadaModif.Size = new System.Drawing.Size(84, 13);
            this.lblJornadaModif.TabIndex = 2;
            this.lblJornadaModif.Text = "Horas Laborales";
            // 
            // txtCategoriaModif
            // 
            this.txtCategoriaModif.Location = new System.Drawing.Point(103, 31);
            this.txtCategoriaModif.MaxLength = 30;
            this.txtCategoriaModif.Name = "txtCategoriaModif";
            this.txtCategoriaModif.Size = new System.Drawing.Size(135, 20);
            this.txtCategoriaModif.TabIndex = 1;
            // 
            // lblCategoriaModif
            // 
            this.lblCategoriaModif.AutoSize = true;
            this.lblCategoriaModif.Location = new System.Drawing.Point(16, 33);
            this.lblCategoriaModif.Name = "lblCategoriaModif";
            this.lblCategoriaModif.Size = new System.Drawing.Size(52, 13);
            this.lblCategoriaModif.TabIndex = 0;
            this.lblCategoriaModif.Text = "Categoria";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.Location = new System.Drawing.Point(37, 398);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(56, 20);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lnkAtras
            // 
            this.lnkAtras.AutoSize = true;
            this.lnkAtras.Location = new System.Drawing.Point(12, 446);
            this.lnkAtras.Name = "lnkAtras";
            this.lnkAtras.Size = new System.Drawing.Size(31, 13);
            this.lnkAtras.TabIndex = 34;
            this.lnkAtras.TabStop = true;
            this.lnkAtras.Text = "Atrás";
            this.lnkAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtras_LinkClicked);
            // 
            // frmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 468);
            this.Controls.Add(this.lnkAtras);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.grpModificarCategoria);
            this.Controls.Add(this.grpCrearCategoria);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.dtgCategoria);
            this.Name = "frmCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.frmCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCategoria)).EndInit();
            this.grpCrearCategoria.ResumeLayout(false);
            this.grpCrearCategoria.PerformLayout();
            this.grpModificarCategoria.ResumeLayout(false);
            this.grpModificarCategoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCategoria;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.GroupBox grpCrearCategoria;
        private System.Windows.Forms.Button btnGuardarCrear;
        private System.Windows.Forms.Button btnCancelarCrear;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.Label lblSueldo;
        private System.Windows.Forms.TextBox txtJornada;
        private System.Windows.Forms.Label lblJornada;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.GroupBox grpModificarCategoria;
        private System.Windows.Forms.Button btnGuardarModif;
        private System.Windows.Forms.Button btnCancelarModif;
        private System.Windows.Forms.TextBox txtSueldoModif;
        private System.Windows.Forms.Label lblSueldoModif;
        private System.Windows.Forms.TextBox txtJornadaModif;
        private System.Windows.Forms.Label lblJornadaModif;
        private System.Windows.Forms.TextBox txtCategoriaModif;
        private System.Windows.Forms.Label lblCategoriaModif;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.LinkLabel lnkAtras;
    }
}