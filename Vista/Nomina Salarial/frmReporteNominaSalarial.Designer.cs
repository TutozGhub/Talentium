namespace Vista
{
    partial class frmReporteNominaSalarial
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
            this.grbPersonalAlta = new System.Windows.Forms.GroupBox();
            this.dataGridNomina = new System.Windows.Forms.DataGridView();
            this.grbFiltrosAlta = new System.Windows.Forms.GroupBox();
            this.convenio = new System.Windows.Forms.Label();
            this.conven = new System.Windows.Forms.ComboBox();
            this.lblErrorPuesto = new System.Windows.Forms.Label();
            this.lblErrorArea = new System.Windows.Forms.Label();
            this.lblPuestoAlta = new System.Windows.Forms.Label();
            this.puestos = new System.Windows.Forms.ComboBox();
            this.buscar = new System.Windows.Forms.Button();
            this.cuil = new System.Windows.Forms.TextBox();
            this.lblCuilAlta = new System.Windows.Forms.Label();
            this.lblAreaAlta = new System.Windows.Forms.Label();
            this.areas = new System.Windows.Forms.ComboBox();
            this.Descargar = new System.Windows.Forms.Button();
            this.grbPersonalAlta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNomina)).BeginInit();
            this.grbFiltrosAlta.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPersonalAlta
            // 
            this.grbPersonalAlta.Controls.Add(this.Descargar);
            this.grbPersonalAlta.Controls.Add(this.dataGridNomina);
            this.grbPersonalAlta.Location = new System.Drawing.Point(348, 13);
            this.grbPersonalAlta.Margin = new System.Windows.Forms.Padding(4);
            this.grbPersonalAlta.Name = "grbPersonalAlta";
            this.grbPersonalAlta.Padding = new System.Windows.Forms.Padding(4);
            this.grbPersonalAlta.Size = new System.Drawing.Size(865, 520);
            this.grbPersonalAlta.TabIndex = 13;
            this.grbPersonalAlta.TabStop = false;
            this.grbPersonalAlta.Text = "Personal";
            // 
            // dataGridNomina
            // 
            this.dataGridNomina.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNomina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridNomina.Location = new System.Drawing.Point(9, 21);
            this.dataGridNomina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridNomina.Name = "dataGridNomina";
            this.dataGridNomina.RowHeadersWidth = 51;
            this.dataGridNomina.RowTemplate.Height = 24;
            this.dataGridNomina.Size = new System.Drawing.Size(834, 424);
            this.dataGridNomina.TabIndex = 12;
            this.dataGridNomina.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAlta_CellContentClick);
            // 
            // grbFiltrosAlta
            // 
            this.grbFiltrosAlta.Controls.Add(this.convenio);
            this.grbFiltrosAlta.Controls.Add(this.conven);
            this.grbFiltrosAlta.Controls.Add(this.lblErrorPuesto);
            this.grbFiltrosAlta.Controls.Add(this.lblErrorArea);
            this.grbFiltrosAlta.Controls.Add(this.lblPuestoAlta);
            this.grbFiltrosAlta.Controls.Add(this.puestos);
            this.grbFiltrosAlta.Controls.Add(this.buscar);
            this.grbFiltrosAlta.Controls.Add(this.cuil);
            this.grbFiltrosAlta.Controls.Add(this.lblCuilAlta);
            this.grbFiltrosAlta.Controls.Add(this.lblAreaAlta);
            this.grbFiltrosAlta.Controls.Add(this.areas);
            this.grbFiltrosAlta.Location = new System.Drawing.Point(3, 13);
            this.grbFiltrosAlta.Margin = new System.Windows.Forms.Padding(4);
            this.grbFiltrosAlta.Name = "grbFiltrosAlta";
            this.grbFiltrosAlta.Padding = new System.Windows.Forms.Padding(4);
            this.grbFiltrosAlta.Size = new System.Drawing.Size(337, 520);
            this.grbFiltrosAlta.TabIndex = 12;
            this.grbFiltrosAlta.TabStop = false;
            this.grbFiltrosAlta.Text = "Filtros";
            this.grbFiltrosAlta.Enter += new System.EventHandler(this.grbFiltrosAlta_Enter);
            // 
            // convenio
            // 
            this.convenio.AutoSize = true;
            this.convenio.Location = new System.Drawing.Point(8, 121);
            this.convenio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.convenio.Name = "convenio";
            this.convenio.Size = new System.Drawing.Size(67, 16);
            this.convenio.TabIndex = 21;
            this.convenio.Text = "Convenio:";
            // 
            // conven
            // 
            this.conven.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conven.FormattingEnabled = true;
            this.conven.Location = new System.Drawing.Point(101, 113);
            this.conven.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.conven.Name = "conven";
            this.conven.Size = new System.Drawing.Size(208, 24);
            this.conven.TabIndex = 20;
            this.conven.SelectedIndexChanged += new System.EventHandler(this.conven_SelectedIndexChanged);
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
            // puestos
            // 
            this.puestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.puestos.FormattingEnabled = true;
            this.puestos.Location = new System.Drawing.Point(101, 76);
            this.puestos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.puestos.Name = "puestos";
            this.puestos.Size = new System.Drawing.Size(208, 24);
            this.puestos.TabIndex = 15;
            // 
            // buscar
            // 
            this.buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(142)))), ((int)(((byte)(171)))));
            this.buscar.Location = new System.Drawing.Point(135, 253);
            this.buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(81, 32);
            this.buscar.TabIndex = 13;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = false;
            this.buscar.Click += new System.EventHandler(this.buscarAlta_Click);
            // 
            // cuil
            // 
            this.cuil.Location = new System.Drawing.Point(101, 151);
            this.cuil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cuil.Name = "cuil";
            this.cuil.Size = new System.Drawing.Size(208, 22);
            this.cuil.TabIndex = 14;
            // 
            // lblCuilAlta
            // 
            this.lblCuilAlta.AutoSize = true;
            this.lblCuilAlta.Location = new System.Drawing.Point(8, 157);
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
            // areas
            // 
            this.areas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areas.FormattingEnabled = true;
            this.areas.Location = new System.Drawing.Point(101, 39);
            this.areas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.areas.Name = "areas";
            this.areas.Size = new System.Drawing.Size(208, 24);
            this.areas.TabIndex = 9;
            this.areas.SelectedIndexChanged += new System.EventHandler(this.areasAltas_SelectedIndexChanged);
            // 
            // Descargar
            // 
            this.Descargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(142)))), ((int)(((byte)(171)))));
            this.Descargar.Location = new System.Drawing.Point(750, 467);
            this.Descargar.Name = "Descargar";
            this.Descargar.Size = new System.Drawing.Size(93, 46);
            this.Descargar.TabIndex = 14;
            this.Descargar.Text = "Descargar Excel";
            this.Descargar.UseVisualStyleBackColor = false;
            this.Descargar.Click += new System.EventHandler(this.Descargar_Click);
            // 
            // frmReporteNominaSalarial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1299, 563);
            this.Controls.Add(this.grbPersonalAlta);
            this.Controls.Add(this.grbFiltrosAlta);
            this.Name = "frmReporteNominaSalarial";
            this.Text = "frmReporteNominaSalarial";
            this.Load += new System.EventHandler(this.frmReporteNominaSalarial_Load);
            this.grbPersonalAlta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNomina)).EndInit();
            this.grbFiltrosAlta.ResumeLayout(false);
            this.grbFiltrosAlta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPersonalAlta;
        private System.Windows.Forms.DataGridView dataGridNomina;
        private System.Windows.Forms.GroupBox grbFiltrosAlta;
        private System.Windows.Forms.Label convenio;
        private System.Windows.Forms.ComboBox conven;
        private System.Windows.Forms.Label lblErrorPuesto;
        private System.Windows.Forms.Label lblErrorArea;
        private System.Windows.Forms.Label lblPuestoAlta;
        private System.Windows.Forms.ComboBox puestos;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.TextBox cuil;
        private System.Windows.Forms.Label lblCuilAlta;
        private System.Windows.Forms.Label lblAreaAlta;
        private System.Windows.Forms.ComboBox areas;
        private System.Windows.Forms.Button Descargar;
    }
}