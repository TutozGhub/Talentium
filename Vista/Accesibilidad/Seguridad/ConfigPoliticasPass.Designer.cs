namespace Vista
{
    partial class ConfigPoliticasPass
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
            this.chcChar = new System.Windows.Forms.CheckBox();
            this.chcMay = new System.Windows.Forms.CheckBox();
            this.chcNum = new System.Windows.Forms.CheckBox();
            this.chcEsp = new System.Windows.Forms.CheckBox();
            this.chcDatos = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCrearBackup = new System.Windows.Forms.Button();
            this.btnCargarBackup = new System.Windows.Forms.Button();
            this.opnBackup = new System.Windows.Forms.OpenFileDialog();
            this.tbcConfig = new System.Windows.Forms.TabControl();
            this.tbpPoliticasPass = new System.Windows.Forms.TabPage();
            this.grpCriterios = new System.Windows.Forms.GroupBox();
            this.tbpBackups = new System.Windows.Forms.TabPage();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            this.tbcConfig.SuspendLayout();
            this.tbpPoliticasPass.SuspendLayout();
            this.grpCriterios.SuspendLayout();
            this.tbpBackups.SuspendLayout();
            this.grpBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // chcChar
            // 
            this.chcChar.AutoSize = true;
            this.chcChar.Location = new System.Drawing.Point(30, 49);
            this.chcChar.Margin = new System.Windows.Forms.Padding(2);
            this.chcChar.Name = "chcChar";
            this.chcChar.Size = new System.Drawing.Size(157, 17);
            this.chcChar.TabIndex = 0;
            this.chcChar.Text = "Minimo de ocho caracteres.";
            this.chcChar.UseVisualStyleBackColor = true;
            this.chcChar.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chcMay
            // 
            this.chcMay.AutoSize = true;
            this.chcMay.Location = new System.Drawing.Point(30, 89);
            this.chcMay.Margin = new System.Windows.Forms.Padding(2);
            this.chcMay.Name = "chcMay";
            this.chcMay.Size = new System.Drawing.Size(136, 17);
            this.chcMay.TabIndex = 1;
            this.chcMay.Text = "Minimo una mayúscula.";
            this.chcMay.UseVisualStyleBackColor = true;
            // 
            // chcNum
            // 
            this.chcNum.AutoSize = true;
            this.chcNum.Location = new System.Drawing.Point(30, 129);
            this.chcNum.Margin = new System.Windows.Forms.Padding(2);
            this.chcNum.Name = "chcNum";
            this.chcNum.Size = new System.Drawing.Size(119, 17);
            this.chcNum.TabIndex = 2;
            this.chcNum.Text = "Minumo un número.";
            this.chcNum.UseVisualStyleBackColor = true;
            // 
            // chcEsp
            // 
            this.chcEsp.AutoSize = true;
            this.chcEsp.Location = new System.Drawing.Point(30, 169);
            this.chcEsp.Margin = new System.Windows.Forms.Padding(2);
            this.chcEsp.Name = "chcEsp";
            this.chcEsp.Size = new System.Drawing.Size(161, 17);
            this.chcEsp.TabIndex = 3;
            this.chcEsp.Text = "Minimo un caractér especial.";
            this.chcEsp.UseVisualStyleBackColor = true;
            // 
            // chcDatos
            // 
            this.chcDatos.AutoSize = true;
            this.chcDatos.Location = new System.Drawing.Point(30, 209);
            this.chcDatos.Margin = new System.Windows.Forms.Padding(2);
            this.chcDatos.Name = "chcDatos";
            this.chcDatos.Size = new System.Drawing.Size(171, 17);
            this.chcDatos.TabIndex = 5;
            this.chcDatos.Text = "No contener datos personales.";
            this.chcDatos.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(212, 317);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(76, 31);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCrearBackup
            // 
            this.btnCrearBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnCrearBackup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrearBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearBackup.ForeColor = System.Drawing.Color.White;
            this.btnCrearBackup.Location = new System.Drawing.Point(16, 38);
            this.btnCrearBackup.Name = "btnCrearBackup";
            this.btnCrearBackup.Size = new System.Drawing.Size(192, 31);
            this.btnCrearBackup.TabIndex = 7;
            this.btnCrearBackup.Text = "Crear Backup";
            this.btnCrearBackup.UseVisualStyleBackColor = false;
            this.btnCrearBackup.Click += new System.EventHandler(this.btnCrearBakup_Click);
            // 
            // btnCargarBackup
            // 
            this.btnCargarBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.btnCargarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargarBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarBackup.ForeColor = System.Drawing.Color.White;
            this.btnCargarBackup.Location = new System.Drawing.Point(16, 90);
            this.btnCargarBackup.Name = "btnCargarBackup";
            this.btnCargarBackup.Size = new System.Drawing.Size(192, 31);
            this.btnCargarBackup.TabIndex = 8;
            this.btnCargarBackup.Text = "Cargar Backup";
            this.btnCargarBackup.UseVisualStyleBackColor = false;
            this.btnCargarBackup.Click += new System.EventHandler(this.btnCargarBakup_Click);
            // 
            // opnBackup
            // 
            this.opnBackup.Filter = "*.bak|";
            // 
            // tbcConfig
            // 
            this.tbcConfig.Controls.Add(this.tbpPoliticasPass);
            this.tbcConfig.Controls.Add(this.tbpBackups);
            this.tbcConfig.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbcConfig.Location = new System.Drawing.Point(65, 0);
            this.tbcConfig.Multiline = true;
            this.tbcConfig.Name = "tbcConfig";
            this.tbcConfig.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbcConfig.SelectedIndex = 0;
            this.tbcConfig.Size = new System.Drawing.Size(316, 392);
            this.tbcConfig.TabIndex = 25;
            // 
            // tbpPoliticasPass
            // 
            this.tbpPoliticasPass.BackColor = System.Drawing.Color.White;
            this.tbpPoliticasPass.Controls.Add(this.grpCriterios);
            this.tbpPoliticasPass.Controls.Add(this.btnGuardar);
            this.tbpPoliticasPass.Location = new System.Drawing.Point(4, 22);
            this.tbpPoliticasPass.Name = "tbpPoliticasPass";
            this.tbpPoliticasPass.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPoliticasPass.Size = new System.Drawing.Size(308, 366);
            this.tbpPoliticasPass.TabIndex = 0;
            this.tbpPoliticasPass.Text = "Politicas de contraseña";
            // 
            // grpCriterios
            // 
            this.grpCriterios.Controls.Add(this.chcChar);
            this.grpCriterios.Controls.Add(this.chcDatos);
            this.grpCriterios.Controls.Add(this.chcEsp);
            this.grpCriterios.Controls.Add(this.chcMay);
            this.grpCriterios.Controls.Add(this.chcNum);
            this.grpCriterios.Location = new System.Drawing.Point(33, 30);
            this.grpCriterios.Name = "grpCriterios";
            this.grpCriterios.Size = new System.Drawing.Size(245, 270);
            this.grpCriterios.TabIndex = 7;
            this.grpCriterios.TabStop = false;
            this.grpCriterios.Text = "Criterios";
            // 
            // tbpBackups
            // 
            this.tbpBackups.BackColor = System.Drawing.Color.White;
            this.tbpBackups.Controls.Add(this.grpBackup);
            this.tbpBackups.Location = new System.Drawing.Point(4, 22);
            this.tbpBackups.Name = "tbpBackups";
            this.tbpBackups.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBackups.Size = new System.Drawing.Size(308, 366);
            this.tbpBackups.TabIndex = 1;
            this.tbpBackups.Text = "Backups";
            // 
            // grpBackup
            // 
            this.grpBackup.Controls.Add(this.btnCrearBackup);
            this.grpBackup.Controls.Add(this.btnCargarBackup);
            this.grpBackup.Location = new System.Drawing.Point(43, 109);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(225, 149);
            this.grpBackup.TabIndex = 9;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Backup";
            // 
            // lnkAtras
            // 
            this.lnkAtras.AutoSize = true;
            this.lnkAtras.Location = new System.Drawing.Point(12, 370);
            this.lnkAtras.Name = "lnkAtras";
            this.lnkAtras.Size = new System.Drawing.Size(31, 13);
            this.lnkAtras.TabIndex = 31;
            this.lnkAtras.TabStop = true;
            this.lnkAtras.Text = "Atrás";
            this.lnkAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtras_LinkClicked);
            // 
            // ConfigPoliticasPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(381, 392);
            this.Controls.Add(this.lnkAtras);
            this.Controls.Add(this.tbcConfig);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfigPoliticasPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Politicas de contraseñas";
            this.Load += new System.EventHandler(this.ConfigPoliticasPass_Load);
            this.tbcConfig.ResumeLayout(false);
            this.tbpPoliticasPass.ResumeLayout(false);
            this.grpCriterios.ResumeLayout(false);
            this.grpCriterios.PerformLayout();
            this.tbpBackups.ResumeLayout(false);
            this.grpBackup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chcChar;
        private System.Windows.Forms.CheckBox chcMay;
        private System.Windows.Forms.CheckBox chcNum;
        private System.Windows.Forms.CheckBox chcEsp;
        private System.Windows.Forms.CheckBox chcDatos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCrearBackup;
        private System.Windows.Forms.Button btnCargarBackup;
        private System.Windows.Forms.OpenFileDialog opnBackup;
        private System.Windows.Forms.TabControl tbcConfig;
        private System.Windows.Forms.TabPage tbpPoliticasPass;
        private System.Windows.Forms.TabPage tbpBackups;
        private System.Windows.Forms.GroupBox grpCriterios;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.LinkLabel lnkAtras;
    }
}