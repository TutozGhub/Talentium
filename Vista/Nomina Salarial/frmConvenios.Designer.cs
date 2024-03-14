namespace Vista
{
    partial class frmConvenios
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
            this.dtgConvenio = new System.Windows.Forms.DataGridView();
            this.btnBaja = new System.Windows.Forms.Button();
            this.grpCrear = new System.Windows.Forms.GroupBox();
            this.btnGuardarCrear = new System.Windows.Forms.Button();
            this.btnCancelarCrear = new System.Windows.Forms.Button();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.lblSueldo = new System.Windows.Forms.Label();
            this.txtJornada = new System.Windows.Forms.TextBox();
            this.lblJornada = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtObraSocial = new System.Windows.Forms.TextBox();
            this.lblObraSocial = new System.Windows.Forms.Label();
            this.txtSeguridadSalud = new System.Windows.Forms.TextBox();
            this.lblSeguridadSalud = new System.Windows.Forms.Label();
            this.txtConvenio = new System.Windows.Forms.TextBox();
            this.lblConvenio = new System.Windows.Forms.Label();
            this.grpModificarConvenio = new System.Windows.Forms.GroupBox();
            this.cmbCateModif = new System.Windows.Forms.ComboBox();
            this.btnGuardarModif = new System.Windows.Forms.Button();
            this.txtSueldoModif = new System.Windows.Forms.TextBox();
            this.btnCancelarModif = new System.Windows.Forms.Button();
            this.lblSueldoModif = new System.Windows.Forms.Label();
            this.txtJornadaModif = new System.Windows.Forms.TextBox();
            this.lblJornadaModif = new System.Windows.Forms.Label();
            this.lblCategoriaModif = new System.Windows.Forms.Label();
            this.txtObraSocialModif = new System.Windows.Forms.TextBox();
            this.lblObraSocialModif = new System.Windows.Forms.Label();
            this.txtSeguridadSaludModif = new System.Windows.Forms.TextBox();
            this.lblSeguridadSaludModif = new System.Windows.Forms.Label();
            this.txtConvenioModif = new System.Windows.Forms.TextBox();
            this.lblConvenioModif = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConvenio)).BeginInit();
            this.grpCrear.SuspendLayout();
            this.grpModificarConvenio.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgConvenio
            // 
            this.dtgConvenio.AllowUserToAddRows = false;
            this.dtgConvenio.AllowUserToDeleteRows = false;
            this.dtgConvenio.BackgroundColor = System.Drawing.Color.White;
            this.dtgConvenio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConvenio.Location = new System.Drawing.Point(40, 31);
            this.dtgConvenio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgConvenio.Name = "dtgConvenio";
            this.dtgConvenio.ReadOnly = true;
            this.dtgConvenio.RowHeadersWidth = 51;
            this.dtgConvenio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConvenio.Size = new System.Drawing.Size(884, 185);
            this.dtgConvenio.TabIndex = 0;
            this.dtgConvenio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConvenio_CellContentClick);
            this.dtgConvenio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConvenio_CellContentClick);
            this.dtgConvenio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConvenio_CellDoubleClick);
            // 
            // btnBaja
            // 
            this.btnBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBaja.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBaja.Location = new System.Drawing.Point(933, 186);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(100, 28);
            this.btnBaja.TabIndex = 1;
            this.btnBaja.Text = "Dar de Baja";
            this.btnBaja.UseVisualStyleBackColor = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // grpCrear
            // 
            this.grpCrear.Controls.Add(this.btnGuardarCrear);
            this.grpCrear.Controls.Add(this.btnCancelarCrear);
            this.grpCrear.Controls.Add(this.txtSueldo);
            this.grpCrear.Controls.Add(this.lblSueldo);
            this.grpCrear.Controls.Add(this.txtJornada);
            this.grpCrear.Controls.Add(this.lblJornada);
            this.grpCrear.Controls.Add(this.cmbCategoria);
            this.grpCrear.Controls.Add(this.lblCategoria);
            this.grpCrear.Controls.Add(this.txtObraSocial);
            this.grpCrear.Controls.Add(this.lblObraSocial);
            this.grpCrear.Controls.Add(this.txtSeguridadSalud);
            this.grpCrear.Controls.Add(this.lblSeguridadSalud);
            this.grpCrear.Controls.Add(this.txtConvenio);
            this.grpCrear.Controls.Add(this.lblConvenio);
            this.grpCrear.Location = new System.Drawing.Point(40, 223);
            this.grpCrear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCrear.Name = "grpCrear";
            this.grpCrear.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCrear.Size = new System.Drawing.Size(400, 293);
            this.grpCrear.TabIndex = 2;
            this.grpCrear.TabStop = false;
            this.grpCrear.Text = "Crear Convenio";
            // 
            // btnGuardarCrear
            // 
            this.btnGuardarCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnGuardarCrear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarCrear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardarCrear.Location = new System.Drawing.Point(281, 257);
            this.btnGuardarCrear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardarCrear.Name = "btnGuardarCrear";
            this.btnGuardarCrear.Size = new System.Drawing.Size(100, 28);
            this.btnGuardarCrear.TabIndex = 13;
            this.btnGuardarCrear.Text = "Guardar";
            this.btnGuardarCrear.UseVisualStyleBackColor = false;
            this.btnGuardarCrear.Click += new System.EventHandler(this.btnGuardarCrear_Click);
            // 
            // btnCancelarCrear
            // 
            this.btnCancelarCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnCancelarCrear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarCrear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelarCrear.Location = new System.Drawing.Point(28, 257);
            this.btnCancelarCrear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelarCrear.Name = "btnCancelarCrear";
            this.btnCancelarCrear.Size = new System.Drawing.Size(100, 28);
            this.btnCancelarCrear.TabIndex = 12;
            this.btnCancelarCrear.Text = "Cancelar";
            this.btnCancelarCrear.UseVisualStyleBackColor = false;
            this.btnCancelarCrear.Click += new System.EventHandler(this.btnCancelarCrear_Click);
            // 
            // txtSueldo
            // 
            this.txtSueldo.Location = new System.Drawing.Point(293, 126);
            this.txtSueldo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.ReadOnly = true;
            this.txtSueldo.Size = new System.Drawing.Size(88, 22);
            this.txtSueldo.TabIndex = 11;
            // 
            // lblSueldo
            // 
            this.lblSueldo.AutoSize = true;
            this.lblSueldo.Location = new System.Drawing.Point(235, 129);
            this.lblSueldo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSueldo.Name = "lblSueldo";
            this.lblSueldo.Size = new System.Drawing.Size(50, 16);
            this.lblSueldo.TabIndex = 10;
            this.lblSueldo.Text = "Sueldo";
            // 
            // txtJornada
            // 
            this.txtJornada.Location = new System.Drawing.Point(132, 126);
            this.txtJornada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtJornada.Name = "txtJornada";
            this.txtJornada.ReadOnly = true;
            this.txtJornada.Size = new System.Drawing.Size(91, 22);
            this.txtJornada.TabIndex = 9;
            // 
            // lblJornada
            // 
            this.lblJornada.AutoSize = true;
            this.lblJornada.Location = new System.Drawing.Point(8, 129);
            this.lblJornada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJornada.Name = "lblJornada";
            this.lblJornada.Size = new System.Drawing.Size(108, 16);
            this.lblJornada.TabIndex = 8;
            this.lblJornada.Text = "Horas Laborales";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(132, 76);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(249, 24);
            this.cmbCategoria.TabIndex = 7;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            this.cmbCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCategoria_KeyPress);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(8, 87);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(66, 16);
            this.lblCategoria.TabIndex = 6;
            this.lblCategoria.Text = "Categoria";
            // 
            // txtObraSocial
            // 
            this.txtObraSocial.Location = new System.Drawing.Point(185, 218);
            this.txtObraSocial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtObraSocial.MaxLength = 30;
            this.txtObraSocial.Name = "txtObraSocial";
            this.txtObraSocial.Size = new System.Drawing.Size(196, 22);
            this.txtObraSocial.TabIndex = 5;
            this.txtObraSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObraSocial_KeyPress);
            // 
            // lblObraSocial
            // 
            this.lblObraSocial.AutoSize = true;
            this.lblObraSocial.Location = new System.Drawing.Point(8, 218);
            this.lblObraSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObraSocial.Name = "lblObraSocial";
            this.lblObraSocial.Size = new System.Drawing.Size(78, 16);
            this.lblObraSocial.TabIndex = 4;
            this.lblObraSocial.Text = "Obra Social";
            // 
            // txtSeguridadSalud
            // 
            this.txtSeguridadSalud.Location = new System.Drawing.Point(185, 176);
            this.txtSeguridadSalud.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSeguridadSalud.MaxLength = 30;
            this.txtSeguridadSalud.Name = "txtSeguridadSalud";
            this.txtSeguridadSalud.Size = new System.Drawing.Size(196, 22);
            this.txtSeguridadSalud.TabIndex = 3;
            this.txtSeguridadSalud.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeguridadSalud_KeyPress);
            // 
            // lblSeguridadSalud
            // 
            this.lblSeguridadSalud.AutoSize = true;
            this.lblSeguridadSalud.Location = new System.Drawing.Point(8, 176);
            this.lblSeguridadSalud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeguridadSalud.Name = "lblSeguridadSalud";
            this.lblSeguridadSalud.Size = new System.Drawing.Size(118, 16);
            this.lblSeguridadSalud.TabIndex = 2;
            this.lblSeguridadSalud.Text = "Seguridad y Salud";
            // 
            // txtConvenio
            // 
            this.txtConvenio.Location = new System.Drawing.Point(132, 39);
            this.txtConvenio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConvenio.MaxLength = 30;
            this.txtConvenio.Name = "txtConvenio";
            this.txtConvenio.Size = new System.Drawing.Size(249, 22);
            this.txtConvenio.TabIndex = 1;
            this.txtConvenio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenio_KeyPress);
            // 
            // lblConvenio
            // 
            this.lblConvenio.AutoSize = true;
            this.lblConvenio.Location = new System.Drawing.Point(8, 39);
            this.lblConvenio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConvenio.Name = "lblConvenio";
            this.lblConvenio.Size = new System.Drawing.Size(64, 16);
            this.lblConvenio.TabIndex = 0;
            this.lblConvenio.Text = "Convenio";
            // 
            // grpModificarConvenio
            // 
            this.grpModificarConvenio.Controls.Add(this.cmbCateModif);
            this.grpModificarConvenio.Controls.Add(this.btnGuardarModif);
            this.grpModificarConvenio.Controls.Add(this.txtSueldoModif);
            this.grpModificarConvenio.Controls.Add(this.btnCancelarModif);
            this.grpModificarConvenio.Controls.Add(this.lblSueldoModif);
            this.grpModificarConvenio.Controls.Add(this.txtJornadaModif);
            this.grpModificarConvenio.Controls.Add(this.lblJornadaModif);
            this.grpModificarConvenio.Controls.Add(this.lblCategoriaModif);
            this.grpModificarConvenio.Controls.Add(this.txtObraSocialModif);
            this.grpModificarConvenio.Controls.Add(this.lblObraSocialModif);
            this.grpModificarConvenio.Controls.Add(this.txtSeguridadSaludModif);
            this.grpModificarConvenio.Controls.Add(this.lblSeguridadSaludModif);
            this.grpModificarConvenio.Controls.Add(this.txtConvenioModif);
            this.grpModificarConvenio.Controls.Add(this.lblConvenioModif);
            this.grpModificarConvenio.Location = new System.Drawing.Point(524, 223);
            this.grpModificarConvenio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpModificarConvenio.Name = "grpModificarConvenio";
            this.grpModificarConvenio.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpModificarConvenio.Size = new System.Drawing.Size(400, 293);
            this.grpModificarConvenio.TabIndex = 12;
            this.grpModificarConvenio.TabStop = false;
            this.grpModificarConvenio.Text = "Modificar Convenio";
            // 
            // cmbCateModif
            // 
            this.cmbCateModif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCateModif.FormattingEnabled = true;
            this.cmbCateModif.Location = new System.Drawing.Point(123, 79);
            this.cmbCateModif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCateModif.Name = "cmbCateModif";
            this.cmbCateModif.Size = new System.Drawing.Size(249, 24);
            this.cmbCateModif.TabIndex = 17;
            this.cmbCateModif.SelectedIndexChanged += new System.EventHandler(this.cmbCateModif_SelectedIndexChanged);
            this.cmbCateModif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCateModif_KeyPress);
            // 
            // btnGuardarModif
            // 
            this.btnGuardarModif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnGuardarModif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarModif.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardarModif.Location = new System.Drawing.Point(272, 257);
            this.btnGuardarModif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardarModif.Name = "btnGuardarModif";
            this.btnGuardarModif.Size = new System.Drawing.Size(100, 28);
            this.btnGuardarModif.TabIndex = 15;
            this.btnGuardarModif.Text = "Guardar";
            this.btnGuardarModif.UseVisualStyleBackColor = false;
            this.btnGuardarModif.Click += new System.EventHandler(this.btnGuardarModif_Click);
            // 
            // txtSueldoModif
            // 
            this.txtSueldoModif.Location = new System.Drawing.Point(284, 126);
            this.txtSueldoModif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSueldoModif.Name = "txtSueldoModif";
            this.txtSueldoModif.ReadOnly = true;
            this.txtSueldoModif.Size = new System.Drawing.Size(88, 22);
            this.txtSueldoModif.TabIndex = 11;
            // 
            // btnCancelarModif
            // 
            this.btnCancelarModif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnCancelarModif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarModif.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelarModif.Location = new System.Drawing.Point(28, 257);
            this.btnCancelarModif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelarModif.Name = "btnCancelarModif";
            this.btnCancelarModif.Size = new System.Drawing.Size(100, 28);
            this.btnCancelarModif.TabIndex = 14;
            this.btnCancelarModif.Text = "Cancelar";
            this.btnCancelarModif.UseVisualStyleBackColor = false;
            this.btnCancelarModif.Click += new System.EventHandler(this.btnCancelarModif_Click);
            // 
            // lblSueldoModif
            // 
            this.lblSueldoModif.AutoSize = true;
            this.lblSueldoModif.Location = new System.Drawing.Point(227, 129);
            this.lblSueldoModif.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSueldoModif.Name = "lblSueldoModif";
            this.lblSueldoModif.Size = new System.Drawing.Size(50, 16);
            this.lblSueldoModif.TabIndex = 10;
            this.lblSueldoModif.Text = "Sueldo";
            // 
            // txtJornadaModif
            // 
            this.txtJornadaModif.Location = new System.Drawing.Point(127, 126);
            this.txtJornadaModif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtJornadaModif.Name = "txtJornadaModif";
            this.txtJornadaModif.ReadOnly = true;
            this.txtJornadaModif.Size = new System.Drawing.Size(91, 22);
            this.txtJornadaModif.TabIndex = 9;
            // 
            // lblJornadaModif
            // 
            this.lblJornadaModif.AutoSize = true;
            this.lblJornadaModif.Location = new System.Drawing.Point(8, 129);
            this.lblJornadaModif.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJornadaModif.Name = "lblJornadaModif";
            this.lblJornadaModif.Size = new System.Drawing.Size(108, 16);
            this.lblJornadaModif.TabIndex = 8;
            this.lblJornadaModif.Text = "Horas Laborales";
            // 
            // lblCategoriaModif
            // 
            this.lblCategoriaModif.AutoSize = true;
            this.lblCategoriaModif.Location = new System.Drawing.Point(8, 84);
            this.lblCategoriaModif.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoriaModif.Name = "lblCategoriaModif";
            this.lblCategoriaModif.Size = new System.Drawing.Size(66, 16);
            this.lblCategoriaModif.TabIndex = 6;
            this.lblCategoriaModif.Text = "Categoria";
            // 
            // txtObraSocialModif
            // 
            this.txtObraSocialModif.Location = new System.Drawing.Point(176, 218);
            this.txtObraSocialModif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtObraSocialModif.MaxLength = 30;
            this.txtObraSocialModif.Name = "txtObraSocialModif";
            this.txtObraSocialModif.Size = new System.Drawing.Size(196, 22);
            this.txtObraSocialModif.TabIndex = 5;
            this.txtObraSocialModif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObraSocialModif_KeyPress);
            // 
            // lblObraSocialModif
            // 
            this.lblObraSocialModif.AutoSize = true;
            this.lblObraSocialModif.Location = new System.Drawing.Point(8, 218);
            this.lblObraSocialModif.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObraSocialModif.Name = "lblObraSocialModif";
            this.lblObraSocialModif.Size = new System.Drawing.Size(78, 16);
            this.lblObraSocialModif.TabIndex = 4;
            this.lblObraSocialModif.Text = "Obra Social";
            // 
            // txtSeguridadSaludModif
            // 
            this.txtSeguridadSaludModif.Location = new System.Drawing.Point(176, 176);
            this.txtSeguridadSaludModif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSeguridadSaludModif.MaxLength = 30;
            this.txtSeguridadSaludModif.Name = "txtSeguridadSaludModif";
            this.txtSeguridadSaludModif.Size = new System.Drawing.Size(196, 22);
            this.txtSeguridadSaludModif.TabIndex = 3;
            this.txtSeguridadSaludModif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeguridadSaludModif_KeyPress);
            // 
            // lblSeguridadSaludModif
            // 
            this.lblSeguridadSaludModif.AutoSize = true;
            this.lblSeguridadSaludModif.Location = new System.Drawing.Point(8, 176);
            this.lblSeguridadSaludModif.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeguridadSaludModif.Name = "lblSeguridadSaludModif";
            this.lblSeguridadSaludModif.Size = new System.Drawing.Size(118, 16);
            this.lblSeguridadSaludModif.TabIndex = 2;
            this.lblSeguridadSaludModif.Text = "Seguridad y Salud";
            // 
            // txtConvenioModif
            // 
            this.txtConvenioModif.Location = new System.Drawing.Point(123, 39);
            this.txtConvenioModif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConvenioModif.MaxLength = 30;
            this.txtConvenioModif.Name = "txtConvenioModif";
            this.txtConvenioModif.Size = new System.Drawing.Size(249, 22);
            this.txtConvenioModif.TabIndex = 1;
            this.txtConvenioModif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenioModif_KeyPress);
            // 
            // lblConvenioModif
            // 
            this.lblConvenioModif.AutoSize = true;
            this.lblConvenioModif.Location = new System.Drawing.Point(8, 39);
            this.lblConvenioModif.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConvenioModif.Name = "lblConvenioModif";
            this.lblConvenioModif.Size = new System.Drawing.Size(64, 16);
            this.lblConvenioModif.TabIndex = 0;
            this.lblConvenioModif.Text = "Convenio";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.Location = new System.Drawing.Point(933, 140);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 28);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // frmConvenios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.grpModificarConvenio);
            this.Controls.Add(this.grpCrear);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.dtgConvenio);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmConvenios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convenios";
            this.Load += new System.EventHandler(this.frmConvenios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConvenio)).EndInit();
            this.grpCrear.ResumeLayout(false);
            this.grpCrear.PerformLayout();
            this.grpModificarConvenio.ResumeLayout(false);
            this.grpModificarConvenio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgConvenio;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.GroupBox grpCrear;
        private System.Windows.Forms.Button btnGuardarCrear;
        private System.Windows.Forms.Button btnCancelarCrear;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.Label lblSueldo;
        private System.Windows.Forms.TextBox txtJornada;
        private System.Windows.Forms.Label lblJornada;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtObraSocial;
        private System.Windows.Forms.Label lblObraSocial;
        private System.Windows.Forms.TextBox txtSeguridadSalud;
        private System.Windows.Forms.Label lblSeguridadSalud;
        private System.Windows.Forms.TextBox txtConvenio;
        private System.Windows.Forms.Label lblConvenio;
        private System.Windows.Forms.GroupBox grpModificarConvenio;
        private System.Windows.Forms.Button btnGuardarModif;
        private System.Windows.Forms.TextBox txtSueldoModif;
        private System.Windows.Forms.Button btnCancelarModif;
        private System.Windows.Forms.Label lblSueldoModif;
        private System.Windows.Forms.TextBox txtJornadaModif;
        private System.Windows.Forms.Label lblJornadaModif;
        private System.Windows.Forms.Label lblCategoriaModif;
        private System.Windows.Forms.TextBox txtObraSocialModif;
        private System.Windows.Forms.Label lblObraSocialModif;
        private System.Windows.Forms.TextBox txtSeguridadSaludModif;
        private System.Windows.Forms.Label lblSeguridadSaludModif;
        private System.Windows.Forms.TextBox txtConvenioModif;
        private System.Windows.Forms.Label lblConvenioModif;
        private System.Windows.Forms.ComboBox cmbCateModif;
        private System.Windows.Forms.Button btnModificar;
    }
}