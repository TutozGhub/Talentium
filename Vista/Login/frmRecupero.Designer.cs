namespace Vista
{
    partial class frmRecupero
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecupero));
            this.textBoxUsuarioRec = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblIngreseUsuario = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRecuperoContraseña = new System.Windows.Forms.Label();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.codigo = new System.Windows.Forms.TextBox();
            this.lblIngreseCodigo = new System.Windows.Forms.Label();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUsuarioRec
            // 
            this.textBoxUsuarioRec.Location = new System.Drawing.Point(160, 147);
            this.textBoxUsuarioRec.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUsuarioRec.MaxLength = 30;
            this.textBoxUsuarioRec.Name = "textBoxUsuarioRec";
            this.textBoxUsuarioRec.Size = new System.Drawing.Size(182, 20);
            this.textBoxUsuarioRec.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblIngreseUsuario
            // 
            this.lblIngreseUsuario.AutoSize = true;
            this.lblIngreseUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngreseUsuario.Location = new System.Drawing.Point(158, 128);
            this.lblIngreseUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIngreseUsuario.Name = "lblIngreseUsuario";
            this.lblIngreseUsuario.Size = new System.Drawing.Size(127, 17);
            this.lblIngreseUsuario.TabIndex = 2;
            this.lblIngreseUsuario.Text = "Ingrese su Usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.panel1.Controls.Add(this.lblRecuperoContraseña);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 50);
            this.panel1.TabIndex = 3;
            // 
            // lblRecuperoContraseña
            // 
            this.lblRecuperoContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecuperoContraseña.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRecuperoContraseña.Location = new System.Drawing.Point(0, 0);
            this.lblRecuperoContraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecuperoContraseña.Name = "lblRecuperoContraseña";
            this.lblRecuperoContraseña.Size = new System.Drawing.Size(600, 50);
            this.lblRecuperoContraseña.TabIndex = 0;
            this.lblRecuperoContraseña.Text = "Recupero de Contraseña";
            this.lblRecuperoContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnContinuar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(67)))), ((int)(((byte)(128)))));
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ForeColor = System.Drawing.Color.White;
            this.btnContinuar.Location = new System.Drawing.Point(364, 140);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(88, 27);
            this.btnContinuar.TabIndex = 1;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 241);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Texto";
            this.label3.Visible = false;
            // 
            // codigo
            // 
            this.codigo.Location = new System.Drawing.Point(161, 219);
            this.codigo.Margin = new System.Windows.Forms.Padding(2);
            this.codigo.MaxLength = 8;
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(182, 20);
            this.codigo.TabIndex = 2;
            this.codigo.Visible = false;
            // 
            // lblIngreseCodigo
            // 
            this.lblIngreseCodigo.AutoSize = true;
            this.lblIngreseCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngreseCodigo.Location = new System.Drawing.Point(158, 200);
            this.lblIngreseCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIngreseCodigo.Name = "lblIngreseCodigo";
            this.lblIngreseCodigo.Size = new System.Drawing.Size(118, 17);
            this.lblIngreseCodigo.TabIndex = 11;
            this.lblIngreseCodigo.Text = "Ingrese el Código";
            this.lblIngreseCodigo.Visible = false;
            this.lblIngreseCodigo.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnVerificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(67)))), ((int)(((byte)(128)))));
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.ForeColor = System.Drawing.Color.White;
            this.btnVerificar.Location = new System.Drawing.Point(364, 211);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(88, 28);
            this.btnVerificar.TabIndex = 3;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Visible = false;
            this.btnVerificar.Click += new System.EventHandler(this.button1_Click);
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
            // frmRecupero
            // 
            this.AcceptButton = this.btnContinuar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 366);
            this.Controls.Add(this.lnkAtras);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.lblIngreseCodigo);
            this.Controls.Add(this.codigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblIngreseUsuario);
            this.Controls.Add(this.textBoxUsuarioRec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmRecupero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recupero de Contraseña";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsuarioRec;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblIngreseUsuario;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRecuperoContraseña;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox codigo;
        private System.Windows.Forms.Label lblIngreseCodigo;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.LinkLabel lnkAtras;
    }
}