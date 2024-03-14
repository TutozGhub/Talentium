namespace Vista.Bitacora
{
    partial class frmBitacora
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
            this.splContainer = new System.Windows.Forms.SplitContainer();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblBitacora = new System.Windows.Forms.Label();
            this.lnkAtras = new System.Windows.Forms.LinkLabel();
            this.dtgBitacora = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splContainer)).BeginInit();
            this.splContainer.Panel1.SuspendLayout();
            this.splContainer.Panel2.SuspendLayout();
            this.splContainer.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // splContainer
            // 
            this.splContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splContainer.IsSplitterFixed = true;
            this.splContainer.Location = new System.Drawing.Point(0, 0);
            this.splContainer.Name = "splContainer";
            this.splContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splContainer.Panel1
            // 
            this.splContainer.Panel1.Controls.Add(this.pnlTitulo);
            // 
            // splContainer.Panel2
            // 
            this.splContainer.Panel2.Controls.Add(this.lnkAtras);
            this.splContainer.Panel2.Controls.Add(this.dtgBitacora);
            this.splContainer.Size = new System.Drawing.Size(865, 626);
            this.splContainer.SplitterDistance = 48;
            this.splContainer.TabIndex = 0;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(113)))), ((int)(((byte)(141)))));
            this.pnlTitulo.Controls.Add(this.lblBitacora);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(865, 48);
            this.pnlTitulo.TabIndex = 22;
            // 
            // lblBitacora
            // 
            this.lblBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBitacora.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBitacora.Location = new System.Drawing.Point(0, 0);
            this.lblBitacora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBitacora.Name = "lblBitacora";
            this.lblBitacora.Size = new System.Drawing.Size(865, 48);
            this.lblBitacora.TabIndex = 0;
            this.lblBitacora.Text = "Bitácora";
            this.lblBitacora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkAtras
            // 
            this.lnkAtras.AutoSize = true;
            this.lnkAtras.BackColor = System.Drawing.Color.Transparent;
            this.lnkAtras.DisabledLinkColor = System.Drawing.Color.White;
            this.lnkAtras.Location = new System.Drawing.Point(12, 554);
            this.lnkAtras.Name = "lnkAtras";
            this.lnkAtras.Size = new System.Drawing.Size(31, 13);
            this.lnkAtras.TabIndex = 33;
            this.lnkAtras.TabStop = true;
            this.lnkAtras.Text = "Atrás";
            this.lnkAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtras_LinkClicked_1);
            // 
            // dtgBitacora
            // 
            this.dtgBitacora.BackgroundColor = System.Drawing.Color.White;
            this.dtgBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBitacora.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgBitacora.Location = new System.Drawing.Point(0, 0);
            this.dtgBitacora.Name = "dtgBitacora";
            this.dtgBitacora.Size = new System.Drawing.Size(865, 549);
            this.dtgBitacora.TabIndex = 0;
            // 
            // frmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(865, 626);
            this.Controls.Add(this.splContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBitacora";
            this.splContainer.Panel1.ResumeLayout(false);
            this.splContainer.Panel2.ResumeLayout(false);
            this.splContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splContainer)).EndInit();
            this.splContainer.ResumeLayout(false);
            this.pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splContainer;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblBitacora;
        private System.Windows.Forms.DataGridView dtgBitacora;
        private System.Windows.Forms.LinkLabel lnkAtras;
    }
}