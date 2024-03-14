namespace Vista.Accesibilidad
{
    partial class frmPerfiles
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.dtgPerfiles = new System.Windows.Forms.DataGridView();
            this.txtNombrePermiso = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblNombrePerfil = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnDesasignarPermisosTodos = new System.Windows.Forms.Button();
            this.btnAsignarPermisosTodos = new System.Windows.Forms.Button();
            this.lstPermisosAsignados = new System.Windows.Forms.ListBox();
            this.lstPermisos = new System.Windows.Forms.ListBox();
            this.btnDesasignarPermisos = new System.Windows.Forms.Button();
            this.btnAsignarPermisos = new System.Windows.Forms.Button();
            this.chcModificar = new System.Windows.Forms.CheckBox();
            this.lblPermisos = new System.Windows.Forms.Label();
            this.lblPermisosAsignados = new System.Windows.Forms.Label();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(83, 208);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(114, 36);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaja.ForeColor = System.Drawing.Color.White;
            this.btnBaja.Location = new System.Drawing.Point(83, 266);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(114, 25);
            this.btnBaja.TabIndex = 4;
            this.btnBaja.Text = "Dar de baja";
            this.btnBaja.UseVisualStyleBackColor = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // dtgPerfiles
            // 
            this.dtgPerfiles.BackgroundColor = System.Drawing.Color.White;
            this.dtgPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPerfiles.Location = new System.Drawing.Point(279, 45);
            this.dtgPerfiles.Name = "dtgPerfiles";
            this.dtgPerfiles.Size = new System.Drawing.Size(378, 278);
            this.dtgPerfiles.TabIndex = 4;
            this.dtgPerfiles.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPerfiles_RowEnter);
            // 
            // txtNombrePermiso
            // 
            this.txtNombrePermiso.Location = new System.Drawing.Point(39, 77);
            this.txtNombrePermiso.MaxLength = 30;
            this.txtNombrePermiso.Name = "txtNombrePermiso";
            this.txtNombrePermiso.Size = new System.Drawing.Size(199, 20);
            this.txtNombrePermiso.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BulletIndent = 1;
            this.txtDescripcion.Location = new System.Drawing.Point(39, 116);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(199, 86);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.Text = "";
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // lblNombrePerfil
            // 
            this.lblNombrePerfil.AutoSize = true;
            this.lblNombrePerfil.BackColor = System.Drawing.Color.Transparent;
            this.lblNombrePerfil.Location = new System.Drawing.Point(36, 61);
            this.lblNombrePerfil.Name = "lblNombrePerfil";
            this.lblNombrePerfil.Size = new System.Drawing.Size(86, 13);
            this.lblNombrePerfil.TabIndex = 7;
            this.lblNombrePerfil.Text = "Nombre del perfil";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Location = new System.Drawing.Point(36, 100);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripción";
            // 
            // btnDesasignarPermisosTodos
            // 
            this.btnDesasignarPermisosTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnDesasignarPermisosTodos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDesasignarPermisosTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesasignarPermisosTodos.ForeColor = System.Drawing.Color.White;
            this.btnDesasignarPermisosTodos.Location = new System.Drawing.Point(317, 522);
            this.btnDesasignarPermisosTodos.Name = "btnDesasignarPermisosTodos";
            this.btnDesasignarPermisosTodos.Size = new System.Drawing.Size(40, 40);
            this.btnDesasignarPermisosTodos.TabIndex = 35;
            this.btnDesasignarPermisosTodos.Text = "<<";
            this.btnDesasignarPermisosTodos.UseVisualStyleBackColor = false;
            this.btnDesasignarPermisosTodos.Click += new System.EventHandler(this.btnDesasignarPermisosTodos_Click);
            // 
            // btnAsignarPermisosTodos
            // 
            this.btnAsignarPermisosTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnAsignarPermisosTodos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAsignarPermisosTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarPermisosTodos.ForeColor = System.Drawing.Color.White;
            this.btnAsignarPermisosTodos.Location = new System.Drawing.Point(318, 389);
            this.btnAsignarPermisosTodos.Name = "btnAsignarPermisosTodos";
            this.btnAsignarPermisosTodos.Size = new System.Drawing.Size(40, 40);
            this.btnAsignarPermisosTodos.TabIndex = 34;
            this.btnAsignarPermisosTodos.Text = ">>";
            this.btnAsignarPermisosTodos.UseVisualStyleBackColor = false;
            this.btnAsignarPermisosTodos.Click += new System.EventHandler(this.btnAsignarPermisosTodos_Click);
            // 
            // lstPermisosAsignados
            // 
            this.lstPermisosAsignados.FormattingEnabled = true;
            this.lstPermisosAsignados.Location = new System.Drawing.Point(364, 389);
            this.lstPermisosAsignados.Name = "lstPermisosAsignados";
            this.lstPermisosAsignados.Size = new System.Drawing.Size(216, 173);
            this.lstPermisosAsignados.TabIndex = 33;
            this.lstPermisosAsignados.DoubleClick += new System.EventHandler(this.lstPermisosAsignados_DoubleClick);
            // 
            // lstPermisos
            // 
            this.lstPermisos.FormattingEnabled = true;
            this.lstPermisos.Location = new System.Drawing.Point(96, 389);
            this.lstPermisos.Name = "lstPermisos";
            this.lstPermisos.Size = new System.Drawing.Size(216, 173);
            this.lstPermisos.TabIndex = 32;
            this.lstPermisos.DoubleClick += new System.EventHandler(this.lstPermisos_DoubleClick);
            // 
            // btnDesasignarPermisos
            // 
            this.btnDesasignarPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnDesasignarPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDesasignarPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesasignarPermisos.ForeColor = System.Drawing.Color.White;
            this.btnDesasignarPermisos.Location = new System.Drawing.Point(318, 476);
            this.btnDesasignarPermisos.Name = "btnDesasignarPermisos";
            this.btnDesasignarPermisos.Size = new System.Drawing.Size(40, 40);
            this.btnDesasignarPermisos.TabIndex = 31;
            this.btnDesasignarPermisos.Text = "<";
            this.btnDesasignarPermisos.UseVisualStyleBackColor = false;
            this.btnDesasignarPermisos.Click += new System.EventHandler(this.btnDesasignarPermisos_Click);
            // 
            // btnAsignarPermisos
            // 
            this.btnAsignarPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnAsignarPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAsignarPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarPermisos.ForeColor = System.Drawing.Color.White;
            this.btnAsignarPermisos.Location = new System.Drawing.Point(318, 435);
            this.btnAsignarPermisos.Name = "btnAsignarPermisos";
            this.btnAsignarPermisos.Size = new System.Drawing.Size(40, 40);
            this.btnAsignarPermisos.TabIndex = 30;
            this.btnAsignarPermisos.Text = ">";
            this.btnAsignarPermisos.UseVisualStyleBackColor = false;
            this.btnAsignarPermisos.Click += new System.EventHandler(this.btnAsignarPermisos_Click);
            // 
            // chcModificar
            // 
            this.chcModificar.AutoSize = true;
            this.chcModificar.BackColor = System.Drawing.Color.Transparent;
            this.chcModificar.Location = new System.Drawing.Point(279, 329);
            this.chcModificar.Name = "chcModificar";
            this.chcModificar.Size = new System.Drawing.Size(69, 17);
            this.chcModificar.TabIndex = 36;
            this.chcModificar.Text = "Modificar";
            this.chcModificar.UseVisualStyleBackColor = false;
            this.chcModificar.CheckedChanged += new System.EventHandler(this.chcModificar_CheckedChanged);
            // 
            // lblPermisos
            // 
            this.lblPermisos.AutoSize = true;
            this.lblPermisos.BackColor = System.Drawing.Color.Transparent;
            this.lblPermisos.Location = new System.Drawing.Point(93, 373);
            this.lblPermisos.Name = "lblPermisos";
            this.lblPermisos.Size = new System.Drawing.Size(49, 13);
            this.lblPermisos.TabIndex = 37;
            this.lblPermisos.Text = "Permisos";
            // 
            // lblPermisosAsignados
            // 
            this.lblPermisosAsignados.AutoSize = true;
            this.lblPermisosAsignados.BackColor = System.Drawing.Color.Transparent;
            this.lblPermisosAsignados.Location = new System.Drawing.Point(361, 373);
            this.lblPermisosAsignados.Name = "lblPermisosAsignados";
            this.lblPermisosAsignados.Size = new System.Drawing.Size(100, 13);
            this.lblPermisosAsignados.TabIndex = 38;
            this.lblPermisosAsignados.Text = "Permisos asignados";
            // 
            // lnkAtras
            // 
            this.lnkAtras.AutoSize = true;
            this.lnkAtras.Location = new System.Drawing.Point(12, 601);
            this.lnkAtras.Name = "lnkAtras";
            this.lnkAtras.Size = new System.Drawing.Size(31, 13);
            this.lnkAtras.TabIndex = 39;
            this.lnkAtras.TabStop = true;
            this.lnkAtras.Text = "Atrás";
            this.lnkAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtras_LinkClicked);
            // 
            // frmPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 623);
            this.Controls.Add(this.lnkAtras);
            this.Controls.Add(this.lblPermisosAsignados);
            this.Controls.Add(this.lblPermisos);
            this.Controls.Add(this.chcModificar);
            this.Controls.Add(this.btnDesasignarPermisosTodos);
            this.Controls.Add(this.btnAsignarPermisosTodos);
            this.Controls.Add(this.lstPermisosAsignados);
            this.Controls.Add(this.lstPermisos);
            this.Controls.Add(this.btnDesasignarPermisos);
            this.Controls.Add(this.btnAsignarPermisos);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombrePerfil);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombrePermiso);
            this.Controls.Add(this.dtgPerfiles);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPerfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perfiles";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.DataGridView dtgPerfiles;
        private System.Windows.Forms.TextBox txtNombrePermiso;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label lblNombrePerfil;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnDesasignarPermisosTodos;
        private System.Windows.Forms.Button btnAsignarPermisosTodos;
        private System.Windows.Forms.ListBox lstPermisosAsignados;
        private System.Windows.Forms.ListBox lstPermisos;
        private System.Windows.Forms.Button btnDesasignarPermisos;
        private System.Windows.Forms.Button btnAsignarPermisos;
        private System.Windows.Forms.CheckBox chcModificar;
        private System.Windows.Forms.Label lblPermisos;
        private System.Windows.Forms.Label lblPermisosAsignados;
        private System.Windows.Forms.LinkLabel lnkAtras;
    }
}