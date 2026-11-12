namespace GestionChantier.UInterface
{
    partial class FrmPhaseDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.txtPhaseLibelle = new System.Windows.Forms.TextBox();
            this.lblPhaseLibelle = new System.Windows.Forms.Label();
            this.numPhaseOrdre = new System.Windows.Forms.NumericUpDown();
            this.lblPhaseOrdre = new System.Windows.Forms.Label();
            this.cboChantierId = new System.Windows.Forms.ComboBox();
            this.lblChantierId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPhaseOrdre)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblTitre);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 72);
            // lblTitre
            this.lblTitre.AutoSize = true;
            this.lblTitre.BackColor = System.Drawing.Color.Transparent;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Location = new System.Drawing.Point(28, 18);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Text = "Fiche – Phases";
            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(243, 245, 249);
            this.pnlFooter.Controls.Add(this.btnEnregistrer);
            this.pnlFooter.Controls.Add(this.btnAnnuler);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(480, 68);
            // btnEnregistrer
            this.btnEnregistrer.Location = new System.Drawing.Point(178, 15);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(140, 38);
            this.btnEnregistrer.TabIndex = 100;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // btnAnnuler
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(330, 15);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(120, 38);
            this.btnAnnuler.TabIndex = 101;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            // lblPhaseLibelle
            this.lblPhaseLibelle.AutoSize = true;
            this.lblPhaseLibelle.Location = new System.Drawing.Point(30, 98);
            this.lblPhaseLibelle.Name = "lblPhaseLibelle";
            this.lblPhaseLibelle.Text = "Libellé de la phase *";
            // txtPhaseLibelle
            this.txtPhaseLibelle.Location = new System.Drawing.Point(30, 120);
            this.txtPhaseLibelle.Size = new System.Drawing.Size(420, 27);
            this.txtPhaseLibelle.Name = "txtPhaseLibelle";
            this.txtPhaseLibelle.TabIndex = 0;
            this.txtPhaseLibelle.MaxLength = 100;
            // lblPhaseOrdre
            this.lblPhaseOrdre.AutoSize = true;
            this.lblPhaseOrdre.Location = new System.Drawing.Point(30, 174);
            this.lblPhaseOrdre.Name = "lblPhaseOrdre";
            this.lblPhaseOrdre.Text = "Ordre *";
            // numPhaseOrdre
            this.numPhaseOrdre.Location = new System.Drawing.Point(30, 196);
            this.numPhaseOrdre.Size = new System.Drawing.Size(420, 27);
            this.numPhaseOrdre.Name = "numPhaseOrdre";
            this.numPhaseOrdre.TabIndex = 1;
            this.numPhaseOrdre.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numPhaseOrdre.ThousandsSeparator = true;
            this.numPhaseOrdre.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPhaseOrdre.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // lblChantierId
            this.lblChantierId.AutoSize = true;
            this.lblChantierId.Location = new System.Drawing.Point(30, 250);
            this.lblChantierId.Name = "lblChantierId";
            this.lblChantierId.Text = "Chantier *";
            // cboChantierId
            this.cboChantierId.Location = new System.Drawing.Point(30, 272);
            this.cboChantierId.Size = new System.Drawing.Size(420, 27);
            this.cboChantierId.Name = "cboChantierId";
            this.cboChantierId.TabIndex = 2;
            this.cboChantierId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // FrmPhaseDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 416);
            this.Controls.Add(this.txtPhaseLibelle);
            this.Controls.Add(this.lblPhaseLibelle);
            this.Controls.Add(this.numPhaseOrdre);
            this.Controls.Add(this.lblPhaseOrdre);
            this.Controls.Add(this.cboChantierId);
            this.Controls.Add(this.lblChantierId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPhaseDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phases";
            this.Load += new System.EventHandler(this.FrmPhaseDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPhaseOrdre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox txtPhaseLibelle;
        private System.Windows.Forms.Label lblPhaseLibelle;
        private System.Windows.Forms.NumericUpDown numPhaseOrdre;
        private System.Windows.Forms.Label lblPhaseOrdre;
        private System.Windows.Forms.ComboBox cboChantierId;
        private System.Windows.Forms.Label lblChantierId;
    }
}
