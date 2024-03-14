namespace Vista
{
    partial class Asistencias
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
            this.ControlAsist = new System.Windows.Forms.TabControl();
            this.tbpAlta = new System.Windows.Forms.TabPage();
            this.grbPersonalAlta = new System.Windows.Forms.GroupBox();
            this.dataGridAlta = new System.Windows.Forms.DataGridView();
            this.Abrir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grbFiltrosAlta = new System.Windows.Forms.GroupBox();
            this.lblErrorPuesto = new System.Windows.Forms.Label();
            this.lblErrorArea = new System.Windows.Forms.Label();
            this.lblPuestoAlta = new System.Windows.Forms.Label();
            this.puestosAltas = new System.Windows.Forms.ComboBox();
            this.buscarAlta = new System.Windows.Forms.Button();
            this.cuilAltas = new System.Windows.Forms.TextBox();
            this.lblCuilAlta = new System.Windows.Forms.Label();
            this.lblAreaAlta = new System.Windows.Forms.Label();
            this.areasAltas = new System.Windows.Forms.ComboBox();
            this.tbpModificar = new System.Windows.Forms.TabPage();
            this.grbInasistenciasMod = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dataGridModificar = new System.Windows.Forms.DataGridView();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grbFiltroMod = new System.Windows.Forms.GroupBox();
            this.periodo = new System.Windows.Forms.CheckBox();
            this.lblErrorPuestoMod = new System.Windows.Forms.Label();
            this.lblErrorAreaMod = new System.Windows.Forms.Label();
            this.lblPuestoMod = new System.Windows.Forms.Label();
            this.PuestoMod = new System.Windows.Forms.ComboBox();
            this.AreaMod = new System.Windows.Forms.ComboBox();
            this.lblAreaMod = new System.Windows.Forms.Label();
            this.lblFechaMod = new System.Windows.Forms.Label();
            this.lblFechaDesdeMod = new System.Windows.Forms.Label();
            this.lblFechaHastaMod = new System.Windows.Forms.Label();
            this.FechaHastaMod = new System.Windows.Forms.DateTimePicker();
            this.fechaDesdeMod = new System.Windows.Forms.DateTimePicker();
            this.FechaMod = new System.Windows.Forms.DateTimePicker();
            this.buscarMod = new System.Windows.Forms.Button();
            this.CuilMod = new System.Windows.Forms.TextBox();
            this.lblCuilMod = new System.Windows.Forms.Label();
            this.ControlAsist.SuspendLayout();
            this.tbpAlta.SuspendLayout();
            this.grbPersonalAlta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlta)).BeginInit();
            this.grbFiltrosAlta.SuspendLayout();
            this.tbpModificar.SuspendLayout();
            this.grbInasistenciasMod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridModificar)).BeginInit();
            this.grbFiltroMod.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlAsist
            // 
            this.ControlAsist.AccessibleName = "";
            this.ControlAsist.Controls.Add(this.tbpAlta);
            this.ControlAsist.Controls.Add(this.tbpModificar);
            this.ControlAsist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlAsist.Location = new System.Drawing.Point(0, 0);
            this.ControlAsist.Margin = new System.Windows.Forms.Padding(4);
            this.ControlAsist.Name = "ControlAsist";
            this.ControlAsist.SelectedIndex = 0;
            this.ControlAsist.Size = new System.Drawing.Size(1469, 665);
            this.ControlAsist.TabIndex = 7;
            // 
            // tbpAlta
            // 
            this.tbpAlta.Controls.Add(this.grbPersonalAlta);
            this.tbpAlta.Controls.Add(this.grbFiltrosAlta);
            this.tbpAlta.Location = new System.Drawing.Point(4, 25);
            this.tbpAlta.Margin = new System.Windows.Forms.Padding(4);
            this.tbpAlta.Name = "tbpAlta";
            this.tbpAlta.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpAlta.Size = new System.Drawing.Size(1461, 636);
            this.tbpAlta.TabIndex = 0;
            this.tbpAlta.Text = "Alta";
            this.tbpAlta.UseVisualStyleBackColor = true;
            this.tbpAlta.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // grbPersonalAlta
            // 
            this.grbPersonalAlta.Controls.Add(this.dataGridAlta);
            this.grbPersonalAlta.Location = new System.Drawing.Point(404, 31);
            this.grbPersonalAlta.Margin = new System.Windows.Forms.Padding(4);
            this.grbPersonalAlta.Name = "grbPersonalAlta";
            this.grbPersonalAlta.Padding = new System.Windows.Forms.Padding(4);
            this.grbPersonalAlta.Size = new System.Drawing.Size(811, 468);
            this.grbPersonalAlta.TabIndex = 11;
            this.grbPersonalAlta.TabStop = false;
            this.grbPersonalAlta.Text = "Personal";
            // 
            // dataGridAlta
            // 
            this.dataGridAlta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridAlta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAlta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Abrir});
            this.dataGridAlta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridAlta.Location = new System.Drawing.Point(5, 21);
            this.dataGridAlta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridAlta.Name = "dataGridAlta";
            this.dataGridAlta.RowHeadersWidth = 51;
            this.dataGridAlta.RowTemplate.Height = 24;
            this.dataGridAlta.Size = new System.Drawing.Size(771, 353);
            this.dataGridAlta.TabIndex = 12;
            this.dataGridAlta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridAlta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Abrir
            // 
            this.Abrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Abrir.HeaderText = "Abrir";
            this.Abrir.MinimumWidth = 6;
            this.Abrir.Name = "Abrir";
            this.Abrir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Abrir.Text = "Abrir";
            this.Abrir.ToolTipText = "Click";
            this.Abrir.UseColumnTextForButtonValue = true;
            this.Abrir.Width = 80;
            // 
            // grbFiltrosAlta
            // 
            this.grbFiltrosAlta.Controls.Add(this.lblErrorPuesto);
            this.grbFiltrosAlta.Controls.Add(this.lblErrorArea);
            this.grbFiltrosAlta.Controls.Add(this.lblPuestoAlta);
            this.grbFiltrosAlta.Controls.Add(this.puestosAltas);
            this.grbFiltrosAlta.Controls.Add(this.buscarAlta);
            this.grbFiltrosAlta.Controls.Add(this.cuilAltas);
            this.grbFiltrosAlta.Controls.Add(this.lblCuilAlta);
            this.grbFiltrosAlta.Controls.Add(this.lblAreaAlta);
            this.grbFiltrosAlta.Controls.Add(this.areasAltas);
            this.grbFiltrosAlta.Location = new System.Drawing.Point(9, 31);
            this.grbFiltrosAlta.Margin = new System.Windows.Forms.Padding(4);
            this.grbFiltrosAlta.Name = "grbFiltrosAlta";
            this.grbFiltrosAlta.Padding = new System.Windows.Forms.Padding(4);
            this.grbFiltrosAlta.Size = new System.Drawing.Size(387, 468);
            this.grbFiltrosAlta.TabIndex = 10;
            this.grbFiltrosAlta.TabStop = false;
            this.grbFiltrosAlta.Text = "Filtros";
            this.grbFiltrosAlta.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblErrorPuesto
            // 
            this.lblErrorPuesto.AutoSize = true;
            this.lblErrorPuesto.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPuesto.Location = new System.Drawing.Point(59, 80);
            this.lblErrorPuesto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorPuesto.Name = "lblErrorPuesto";
            this.lblErrorPuesto.Size = new System.Drawing.Size(12, 16);
            this.lblErrorPuesto.TabIndex = 19;
            this.lblErrorPuesto.Text = "*";
            // 
            // lblErrorArea
            // 
            this.lblErrorArea.AutoSize = true;
            this.lblErrorArea.ForeColor = System.Drawing.Color.Red;
            this.lblErrorArea.Location = new System.Drawing.Point(47, 39);
            this.lblErrorArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorArea.Name = "lblErrorArea";
            this.lblErrorArea.Size = new System.Drawing.Size(12, 16);
            this.lblErrorArea.TabIndex = 17;
            this.lblErrorArea.Text = "*";
            // 
            // lblPuestoAlta
            // 
            this.lblPuestoAlta.AutoSize = true;
            this.lblPuestoAlta.Location = new System.Drawing.Point(8, 86);
            this.lblPuestoAlta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPuestoAlta.Name = "lblPuestoAlta";
            this.lblPuestoAlta.Size = new System.Drawing.Size(52, 16);
            this.lblPuestoAlta.TabIndex = 16;
            this.lblPuestoAlta.Text = "Puesto:";
            // 
            // puestosAltas
            // 
            this.puestosAltas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.puestosAltas.FormattingEnabled = true;
            this.puestosAltas.Location = new System.Drawing.Point(101, 76);
            this.puestosAltas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.puestosAltas.Name = "puestosAltas";
            this.puestosAltas.Size = new System.Drawing.Size(208, 24);
            this.puestosAltas.TabIndex = 15;
            // 
            // buscarAlta
            // 
            this.buscarAlta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(142)))), ((int)(((byte)(171)))));
            this.buscarAlta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarAlta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buscarAlta.Location = new System.Drawing.Point(229, 192);
            this.buscarAlta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buscarAlta.Name = "buscarAlta";
            this.buscarAlta.Size = new System.Drawing.Size(81, 32);
            this.buscarAlta.TabIndex = 13;
            this.buscarAlta.Text = "Buscar";
            this.buscarAlta.UseVisualStyleBackColor = false;
            this.buscarAlta.Click += new System.EventHandler(this.button1_Click);
            // 
            // cuilAltas
            // 
            this.cuilAltas.Location = new System.Drawing.Point(101, 133);
            this.cuilAltas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cuilAltas.Name = "cuilAltas";
            this.cuilAltas.Size = new System.Drawing.Size(208, 22);
            this.cuilAltas.TabIndex = 14;
            // 
            // lblCuilAlta
            // 
            this.lblCuilAlta.AutoSize = true;
            this.lblCuilAlta.Location = new System.Drawing.Point(8, 142);
            this.lblCuilAlta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuilAlta.Name = "lblCuilAlta";
            this.lblCuilAlta.Size = new System.Drawing.Size(39, 16);
            this.lblCuilAlta.TabIndex = 13;
            this.lblCuilAlta.Text = "CUIL:";
            // 
            // lblAreaAlta
            // 
            this.lblAreaAlta.AutoSize = true;
            this.lblAreaAlta.Location = new System.Drawing.Point(8, 43);
            this.lblAreaAlta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAreaAlta.Name = "lblAreaAlta";
            this.lblAreaAlta.Size = new System.Drawing.Size(39, 16);
            this.lblAreaAlta.TabIndex = 7;
            this.lblAreaAlta.Text = "Àrea:";
            // 
            // areasAltas
            // 
            this.areasAltas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areasAltas.FormattingEnabled = true;
            this.areasAltas.Location = new System.Drawing.Point(101, 39);
            this.areasAltas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.areasAltas.Name = "areasAltas";
            this.areasAltas.Size = new System.Drawing.Size(208, 24);
            this.areasAltas.TabIndex = 9;
            this.areasAltas.SelectedIndexChanged += new System.EventHandler(this.areasAltas_SelectedIndexChanged);
            // 
            // tbpModificar
            // 
            this.tbpModificar.Controls.Add(this.grbInasistenciasMod);
            this.tbpModificar.Controls.Add(this.grbFiltroMod);
            this.tbpModificar.Location = new System.Drawing.Point(4, 25);
            this.tbpModificar.Margin = new System.Windows.Forms.Padding(4);
            this.tbpModificar.Name = "tbpModificar";
            this.tbpModificar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpModificar.Size = new System.Drawing.Size(1461, 636);
            this.tbpModificar.TabIndex = 1;
            this.tbpModificar.Text = "Modificaciòn y consulta";
            this.tbpModificar.UseVisualStyleBackColor = true;
            // 
            // grbInasistenciasMod
            // 
            this.grbInasistenciasMod.Controls.Add(this.btnExcel);
            this.grbInasistenciasMod.Controls.Add(this.dataGridModificar);
            this.grbInasistenciasMod.Location = new System.Drawing.Point(404, 18);
            this.grbInasistenciasMod.Margin = new System.Windows.Forms.Padding(4);
            this.grbInasistenciasMod.Name = "grbInasistenciasMod";
            this.grbInasistenciasMod.Padding = new System.Windows.Forms.Padding(4);
            this.grbInasistenciasMod.Size = new System.Drawing.Size(801, 466);
            this.grbInasistenciasMod.TabIndex = 13;
            this.grbInasistenciasMod.TabStop = false;
            this.grbInasistenciasMod.Text = "Inasistencias";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(142)))), ((int)(((byte)(171)))));
            this.btnExcel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExcel.Location = new System.Drawing.Point(645, 395);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(115, 49);
            this.btnExcel.TabIndex = 14;
            this.btnExcel.Text = "Descargar Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dataGridModificar
            // 
            this.dataGridModificar.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridModificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridModificar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Modificar,
            this.Eliminar});
            this.dataGridModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridModificar.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridModificar.Location = new System.Drawing.Point(3, 17);
            this.dataGridModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridModificar.Name = "dataGridModificar";
            this.dataGridModificar.RowHeadersWidth = 51;
            this.dataGridModificar.RowTemplate.Height = 24;
            this.dataGridModificar.Size = new System.Drawing.Size(771, 353);
            this.dataGridModificar.TabIndex = 12;
            this.dataGridModificar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridModificar_CellContentClick);
            // 
            // Modificar
            // 
            this.Modificar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.MinimumWidth = 6;
            this.Modificar.Name = "Modificar";
            this.Modificar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Modificar.Text = "Abrir";
            this.Modificar.ToolTipText = "Abrir";
            this.Modificar.UseColumnTextForButtonValue = true;
            this.Modificar.Width = 68;
            // 
            // Eliminar
            // 
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.ToolTipText = "Eliminar";
            this.Eliminar.UseColumnTextForButtonValue = true;
            this.Eliminar.Width = 80;
            // 
            // grbFiltroMod
            // 
            this.grbFiltroMod.Controls.Add(this.periodo);
            this.grbFiltroMod.Controls.Add(this.lblErrorPuestoMod);
            this.grbFiltroMod.Controls.Add(this.lblErrorAreaMod);
            this.grbFiltroMod.Controls.Add(this.lblPuestoMod);
            this.grbFiltroMod.Controls.Add(this.PuestoMod);
            this.grbFiltroMod.Controls.Add(this.AreaMod);
            this.grbFiltroMod.Controls.Add(this.lblAreaMod);
            this.grbFiltroMod.Controls.Add(this.lblFechaMod);
            this.grbFiltroMod.Controls.Add(this.lblFechaDesdeMod);
            this.grbFiltroMod.Controls.Add(this.lblFechaHastaMod);
            this.grbFiltroMod.Controls.Add(this.FechaHastaMod);
            this.grbFiltroMod.Controls.Add(this.fechaDesdeMod);
            this.grbFiltroMod.Controls.Add(this.FechaMod);
            this.grbFiltroMod.Controls.Add(this.buscarMod);
            this.grbFiltroMod.Controls.Add(this.CuilMod);
            this.grbFiltroMod.Controls.Add(this.lblCuilMod);
            this.grbFiltroMod.Location = new System.Drawing.Point(9, 18);
            this.grbFiltroMod.Margin = new System.Windows.Forms.Padding(4);
            this.grbFiltroMod.Name = "grbFiltroMod";
            this.grbFiltroMod.Padding = new System.Windows.Forms.Padding(4);
            this.grbFiltroMod.Size = new System.Drawing.Size(387, 466);
            this.grbFiltroMod.TabIndex = 12;
            this.grbFiltroMod.TabStop = false;
            this.grbFiltroMod.Text = "Filtros";
            this.grbFiltroMod.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // periodo
            // 
            this.periodo.AutoSize = true;
            this.periodo.Location = new System.Drawing.Point(12, 158);
            this.periodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.periodo.Name = "periodo";
            this.periodo.Size = new System.Drawing.Size(77, 20);
            this.periodo.TabIndex = 32;
            this.periodo.Text = "Periodo";
            this.periodo.UseVisualStyleBackColor = true;
            this.periodo.CheckedChanged += new System.EventHandler(this.periodo_CheckedChanged_1);
            // 
            // lblErrorPuestoMod
            // 
            this.lblErrorPuestoMod.AutoSize = true;
            this.lblErrorPuestoMod.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPuestoMod.Location = new System.Drawing.Point(60, 63);
            this.lblErrorPuestoMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorPuestoMod.Name = "lblErrorPuestoMod";
            this.lblErrorPuestoMod.Size = new System.Drawing.Size(12, 16);
            this.lblErrorPuestoMod.TabIndex = 31;
            this.lblErrorPuestoMod.Text = "*";
            // 
            // lblErrorAreaMod
            // 
            this.lblErrorAreaMod.AutoSize = true;
            this.lblErrorAreaMod.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAreaMod.Location = new System.Drawing.Point(43, 34);
            this.lblErrorAreaMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorAreaMod.Name = "lblErrorAreaMod";
            this.lblErrorAreaMod.Size = new System.Drawing.Size(12, 16);
            this.lblErrorAreaMod.TabIndex = 30;
            this.lblErrorAreaMod.Text = "*";
            // 
            // lblPuestoMod
            // 
            this.lblPuestoMod.AutoSize = true;
            this.lblPuestoMod.Location = new System.Drawing.Point(8, 71);
            this.lblPuestoMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPuestoMod.Name = "lblPuestoMod";
            this.lblPuestoMod.Size = new System.Drawing.Size(52, 16);
            this.lblPuestoMod.TabIndex = 28;
            this.lblPuestoMod.Text = "Puesto:";
            // 
            // PuestoMod
            // 
            this.PuestoMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PuestoMod.FormattingEnabled = true;
            this.PuestoMod.Location = new System.Drawing.Point(91, 73);
            this.PuestoMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PuestoMod.Name = "PuestoMod";
            this.PuestoMod.Size = new System.Drawing.Size(208, 24);
            this.PuestoMod.TabIndex = 27;
            // 
            // AreaMod
            // 
            this.AreaMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AreaMod.FormattingEnabled = true;
            this.AreaMod.Location = new System.Drawing.Point(91, 25);
            this.AreaMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AreaMod.Name = "AreaMod";
            this.AreaMod.Size = new System.Drawing.Size(208, 24);
            this.AreaMod.TabIndex = 26;
            this.AreaMod.SelectedIndexChanged += new System.EventHandler(this.AreaMod_SelectedIndexChanged);
            // 
            // lblAreaMod
            // 
            this.lblAreaMod.AutoSize = true;
            this.lblAreaMod.Location = new System.Drawing.Point(8, 42);
            this.lblAreaMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAreaMod.Name = "lblAreaMod";
            this.lblAreaMod.Size = new System.Drawing.Size(39, 16);
            this.lblAreaMod.TabIndex = 25;
            this.lblAreaMod.Text = "Àrea:";
            // 
            // lblFechaMod
            // 
            this.lblFechaMod.AutoSize = true;
            this.lblFechaMod.Location = new System.Drawing.Point(8, 192);
            this.lblFechaMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaMod.Name = "lblFechaMod";
            this.lblFechaMod.Size = new System.Drawing.Size(48, 16);
            this.lblFechaMod.TabIndex = 22;
            this.lblFechaMod.Text = "Fecha:";
            // 
            // lblFechaDesdeMod
            // 
            this.lblFechaDesdeMod.AutoSize = true;
            this.lblFechaDesdeMod.Location = new System.Drawing.Point(8, 238);
            this.lblFechaDesdeMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaDesdeMod.Name = "lblFechaDesdeMod";
            this.lblFechaDesdeMod.Size = new System.Drawing.Size(90, 16);
            this.lblFechaDesdeMod.TabIndex = 21;
            this.lblFechaDesdeMod.Text = "Fecha desde:";
            // 
            // lblFechaHastaMod
            // 
            this.lblFechaHastaMod.AutoSize = true;
            this.lblFechaHastaMod.Location = new System.Drawing.Point(8, 288);
            this.lblFechaHastaMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaHastaMod.Name = "lblFechaHastaMod";
            this.lblFechaHastaMod.Size = new System.Drawing.Size(84, 16);
            this.lblFechaHastaMod.TabIndex = 20;
            this.lblFechaHastaMod.Text = "Fecha hasta:";
            // 
            // FechaHastaMod
            // 
            this.FechaHastaMod.Location = new System.Drawing.Point(111, 279);
            this.FechaHastaMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FechaHastaMod.Name = "FechaHastaMod";
            this.FechaHastaMod.Size = new System.Drawing.Size(208, 22);
            this.FechaHastaMod.TabIndex = 19;
            // 
            // fechaDesdeMod
            // 
            this.fechaDesdeMod.Location = new System.Drawing.Point(111, 230);
            this.fechaDesdeMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fechaDesdeMod.Name = "fechaDesdeMod";
            this.fechaDesdeMod.Size = new System.Drawing.Size(208, 22);
            this.fechaDesdeMod.TabIndex = 18;
            // 
            // FechaMod
            // 
            this.FechaMod.Location = new System.Drawing.Point(111, 185);
            this.FechaMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FechaMod.Name = "FechaMod";
            this.FechaMod.Size = new System.Drawing.Size(208, 22);
            this.FechaMod.TabIndex = 17;
            // 
            // buscarMod
            // 
            this.buscarMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(142)))), ((int)(((byte)(171)))));
            this.buscarMod.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarMod.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buscarMod.Location = new System.Drawing.Point(239, 338);
            this.buscarMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buscarMod.Name = "buscarMod";
            this.buscarMod.Size = new System.Drawing.Size(81, 32);
            this.buscarMod.TabIndex = 13;
            this.buscarMod.Text = "Buscar";
            this.buscarMod.UseVisualStyleBackColor = false;
            this.buscarMod.Click += new System.EventHandler(this.button2_Click);
            // 
            // CuilMod
            // 
            this.CuilMod.Location = new System.Drawing.Point(91, 118);
            this.CuilMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CuilMod.Name = "CuilMod";
            this.CuilMod.Size = new System.Drawing.Size(208, 22);
            this.CuilMod.TabIndex = 14;
            // 
            // lblCuilMod
            // 
            this.lblCuilMod.AutoSize = true;
            this.lblCuilMod.Location = new System.Drawing.Point(8, 122);
            this.lblCuilMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuilMod.Name = "lblCuilMod";
            this.lblCuilMod.Size = new System.Drawing.Size(39, 16);
            this.lblCuilMod.TabIndex = 13;
            this.lblCuilMod.Text = "CUIL:";
            // 
            // Asistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 665);
            this.Controls.Add(this.ControlAsist);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Asistencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistencias";
            this.ControlAsist.ResumeLayout(false);
            this.tbpAlta.ResumeLayout(false);
            this.grbPersonalAlta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlta)).EndInit();
            this.grbFiltrosAlta.ResumeLayout(false);
            this.grbFiltrosAlta.PerformLayout();
            this.tbpModificar.ResumeLayout(false);
            this.grbInasistenciasMod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridModificar)).EndInit();
            this.grbFiltroMod.ResumeLayout(false);
            this.grbFiltroMod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ControlAsist;
        private System.Windows.Forms.TabPage tbpAlta;
        private System.Windows.Forms.GroupBox grbPersonalAlta;
        private System.Windows.Forms.DataGridView dataGridAlta;
        private System.Windows.Forms.GroupBox grbFiltrosAlta;
        private System.Windows.Forms.Button buscarAlta;
        private System.Windows.Forms.TextBox cuilAltas;
        private System.Windows.Forms.Label lblCuilAlta;
        private System.Windows.Forms.Label lblAreaAlta;
        private System.Windows.Forms.ComboBox areasAltas;
        private System.Windows.Forms.TabPage tbpModificar;
        private System.Windows.Forms.GroupBox grbInasistenciasMod;
        private System.Windows.Forms.DataGridView dataGridModificar;
        private System.Windows.Forms.GroupBox grbFiltroMod;
        private System.Windows.Forms.Label lblFechaMod;
        private System.Windows.Forms.Label lblFechaDesdeMod;
        private System.Windows.Forms.Label lblFechaHastaMod;
        private System.Windows.Forms.DateTimePicker FechaHastaMod;
        private System.Windows.Forms.DateTimePicker fechaDesdeMod;
        private System.Windows.Forms.DateTimePicker FechaMod;
        private System.Windows.Forms.Button buscarMod;
        private System.Windows.Forms.TextBox CuilMod;
        private System.Windows.Forms.Label lblCuilMod;
        private System.Windows.Forms.Label lblPuestoAlta;
        private System.Windows.Forms.ComboBox puestosAltas;
        private System.Windows.Forms.Label lblPuestoMod;
        private System.Windows.Forms.ComboBox PuestoMod;
        private System.Windows.Forms.ComboBox AreaMod;
        private System.Windows.Forms.Label lblAreaMod;
        private System.Windows.Forms.Label lblErrorPuesto;
        private System.Windows.Forms.Label lblErrorArea;
        private System.Windows.Forms.Label lblErrorPuestoMod;
        private System.Windows.Forms.Label lblErrorAreaMod;
        private System.Windows.Forms.CheckBox periodo;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewButtonColumn Abrir;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}