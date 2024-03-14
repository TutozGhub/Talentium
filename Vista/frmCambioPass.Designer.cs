namespace Vista
{
    partial class frmCambioPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioPass));
            this.btnContinuar = new System.Windows.Forms.Button();
            this.lblReingresarConraseña = new System.Windows.Forms.Label();
            this.txtContra2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNuevaContraseña = new System.Windows.Forms.Label();
            this.txtContra1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCambioContraseña = new System.Windows.Forms.Label();
            this.cmbPreguntas = new System.Windows.Forms.ComboBox();
            this.lblPreguntaSeguridad = new System.Windows.Forms.Label();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnMostrar2 = new System.Windows.Forms.Button();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnContinuar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(67)))), ((int)(((byte)(128)))));
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnContinuar.Location = new System.Drawing.Point(618, 322);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(88, 32);
            this.btnContinuar.TabIndex = 5;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.continuar_Click);
            // 
            // lblReingresarConraseña
            // 
            this.lblReingresarConraseña.AutoSize = true;
            this.lblReingresarConraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReingresarConraseña.Location = new System.Drawing.Point(41, 180);
            this.lblReingresarConraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReingresarConraseña.Name = "lblReingresarConraseña";
            this.lblReingresarConraseña.Size = new System.Drawing.Size(157, 17);
            this.lblReingresarConraseña.TabIndex = 19;
            this.lblReingresarConraseña.Text = "Reingresar contraseña:";
            // 
            // txtContra2
            // 
            this.txtContra2.Location = new System.Drawing.Point(210, 177);
            this.txtContra2.Margin = new System.Windows.Forms.Padding(2);
            this.txtContra2.MaxLength = 30;
            this.txtContra2.Name = "txtContra2";
            this.txtContra2.PasswordChar = '*';
            this.txtContra2.Size = new System.Drawing.Size(279, 20);
            this.txtContra2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 16;
            // 
            // lblNuevaContraseña
            // 
            this.lblNuevaContraseña.AutoSize = true;
            this.lblNuevaContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevaContraseña.Location = new System.Drawing.Point(41, 140);
            this.lblNuevaContraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNuevaContraseña.Name = "lblNuevaContraseña";
            this.lblNuevaContraseña.Size = new System.Drawing.Size(128, 17);
            this.lblNuevaContraseña.TabIndex = 14;
            this.lblNuevaContraseña.Text = "Nueva contraseña:";
            // 
            // txtContra1
            // 
            this.txtContra1.Location = new System.Drawing.Point(210, 137);
            this.txtContra1.Margin = new System.Windows.Forms.Padding(2);
            this.txtContra1.MaxLength = 30;
            this.txtContra1.Name = "txtContra1";
            this.txtContra1.PasswordChar = '*';
            this.txtContra1.Size = new System.Drawing.Size(279, 20);
            this.txtContra1.TabIndex = 1;
            this.txtContra1.Leave += new System.EventHandler(this.tbContra1_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.panel1.Controls.Add(this.lblCambioContraseña);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 50);
            this.panel1.TabIndex = 21;
            // 
            // lblCambioContraseña
            // 
            this.lblCambioContraseña.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCambioContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioContraseña.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCambioContraseña.Location = new System.Drawing.Point(0, 0);
            this.lblCambioContraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCambioContraseña.Name = "lblCambioContraseña";
            this.lblCambioContraseña.Size = new System.Drawing.Size(718, 50);
            this.lblCambioContraseña.TabIndex = 0;
            this.lblCambioContraseña.Text = "Cambio de Contraseña";
            this.lblCambioContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPreguntas
            // 
            this.cmbPreguntas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreguntas.FormattingEnabled = true;
            this.cmbPreguntas.ItemHeight = 13;
            this.cmbPreguntas.Location = new System.Drawing.Point(210, 216);
            this.cmbPreguntas.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPreguntas.MaxLength = 10;
            this.cmbPreguntas.Name = "cmbPreguntas";
            this.cmbPreguntas.Size = new System.Drawing.Size(279, 21);
            this.cmbPreguntas.TabIndex = 3;
            // 
            // lblPreguntaSeguridad
            // 
            this.lblPreguntaSeguridad.AutoSize = true;
            this.lblPreguntaSeguridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreguntaSeguridad.Location = new System.Drawing.Point(41, 220);
            this.lblPreguntaSeguridad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPreguntaSeguridad.Name = "lblPreguntaSeguridad";
            this.lblPreguntaSeguridad.Size = new System.Drawing.Size(164, 17);
            this.lblPreguntaSeguridad.TabIndex = 23;
            this.lblPreguntaSeguridad.Text = "Preguntas de seguridad:";
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.BackColor = System.Drawing.Color.Transparent;
            this.lblRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuesta.Location = new System.Drawing.Point(41, 260);
            this.lblRespuesta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(80, 17);
            this.lblRespuesta.TabIndex = 24;
            this.lblRespuesta.Text = "Respuesta:";
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(210, 257);
            this.txtRespuesta.Margin = new System.Windows.Forms.Padding(2);
            this.txtRespuesta.MaxLength = 30;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(279, 20);
            this.txtRespuesta.TabIndex = 4;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblError.Location = new System.Drawing.Point(530, 137);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(29, 13);
            this.lblError.TabIndex = 26;
            this.lblError.Text = "Error";
            this.lblError.Visible = false;
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMostrar.BackgroundImage")));
            this.btnMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMostrar.FlatAppearance.BorderSize = 0;
            this.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrar.Location = new System.Drawing.Point(494, 134);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(30, 30);
            this.btnMostrar.TabIndex = 28;
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMostrar_MouseDown);
            this.btnMostrar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMostrar_MouseUp);
            // 
            // btnMostrar2
            // 
            this.btnMostrar2.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMostrar2.BackgroundImage")));
            this.btnMostrar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMostrar2.FlatAppearance.BorderSize = 0;
            this.btnMostrar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrar2.Location = new System.Drawing.Point(494, 171);
            this.btnMostrar2.Name = "btnMostrar2";
            this.btnMostrar2.Size = new System.Drawing.Size(30, 30);
            this.btnMostrar2.TabIndex = 29;
            this.btnMostrar2.UseVisualStyleBackColor = false;
            this.btnMostrar2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMostrar2_MouseDown);
            this.btnMostrar2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMostrar2_MouseUp);
            // 
            // lnkAtras
            // 
            this.lnkAtras.AutoSize = true;
            this.lnkAtras.Location = new System.Drawing.Point(12, 344);
            this.lnkAtras.Name = "lnkAtras";
            this.lnkAtras.Size = new System.Drawing.Size(31, 13);
            this.lnkAtras.TabIndex = 32;
            this.lnkAtras.TabStop = true;
            this.lnkAtras.Text = "Atrás";
            this.lnkAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtras_LinkClicked);
            // 
            // frmCambioPass
            // 
            this.AcceptButton = this.btnContinuar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(718, 366);
            this.Controls.Add(this.lnkAtras);
            this.Controls.Add(this.btnMostrar2);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.lblPreguntaSeguridad);
            this.Controls.Add(this.cmbPreguntas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.lblReingresarConraseña);
            this.Controls.Add(this.txtContra2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNuevaContraseña);
            this.Controls.Add(this.txtContra1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmCambioPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de contraseña";
            this.Load += new System.EventHandler(this.CambioDePass_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label lblReingresarConraseña;
        private System.Windows.Forms.TextBox txtContra2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNuevaContraseña;
        private System.Windows.Forms.TextBox txtContra1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCambioContraseña;
        private System.Windows.Forms.ComboBox cmbPreguntas;
        private System.Windows.Forms.Label lblPreguntaSeguridad;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnMostrar2;
        private System.Windows.Forms.LinkLabel lnkAtras;
    }
}