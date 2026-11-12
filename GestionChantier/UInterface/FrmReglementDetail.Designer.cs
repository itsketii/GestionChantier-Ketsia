namespace GestionChantier.UInterface
{
    partial class FrmReglementDetail
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
            this.dtpReglementDate = new System.Windows.Forms.DateTimePicker();
            this.lblReglementDate = new System.Windows.Forms.Label();
            this.numReglementMontant = new System.Windows.Forms.NumericUpDown();
            this.lblReglementMontant = new System.Windows.Forms.Label();
            this.cboAchatId = new System.Windows.Forms.ComboBox();
            this.lblAchatId = new System.Windows.Forms.Label();
            this.cboSerTravId = new System.Windows.Forms.ComboBox();
            this.lblSerTravId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numReglementMontant)).BeginInit();
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
            this.lblTitre.Text = "Fiche – Règlements";
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
            // lblReglementDate
            this.lblReglementDate.AutoSize = true;
            this.lblReglementDate.Location = new System.Drawing.Point(30, 98);
            this.lblReglementDate.Name = "lblReglementDate";
            this.lblReglementDate.Text = "Date du règlement *";
            // dtpReglementDate
            this.dtpReglementDate.Location = new System.Drawing.Point(30, 120);
            this.dtpReglementDate.Size = new System.Drawing.Size(420, 27);
            this.dtpReglementDate.Name = "dtpReglementDate";
            this.dtpReglementDate.TabIndex = 0;
            this.dtpReglementDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // lblReglementMontant
            this.lblReglementMontant.AutoSize = true;
            this.lblReglementMontant.Location = new System.Drawing.Point(30, 174);
            this.lblReglementMontant.Name = "lblReglementMontant";
            this.lblReglementMontant.Text = "Montant (FCFA) *";
            // numReglementMontant
            this.numReglementMontant.Location = new System.Drawing.Point(30, 196);
            this.numReglementMontant.Size = new System.Drawing.Size(420, 27);
            this.numReglementMontant.Name = "numReglementMontant";
            this.numReglementMontant.TabIndex = 1;
            this.numReglementMontant.Maximum = new decimal(new int[] { -1, 2, 0, 0 });
            this.numReglementMontant.ThousandsSeparator = true;
            // lblAchatId
            this.lblAchatId.AutoSize = true;
            this.lblAchatId.Location = new System.Drawing.Point(30, 250);
            this.lblAchatId.Name = "lblAchatId";
            this.lblAchatId.Text = "Achat réglé";
            // cboAchatId
            this.cboAchatId.Location = new System.Drawing.Point(30, 272);
            this.cboAchatId.Size = new System.Drawing.Size(420, 27);
            this.cboAchatId.Name = "cboAchatId";
            this.cboAchatId.TabIndex = 2;
            this.cboAchatId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // lblSerTravId
            this.lblSerTravId.AutoSize = true;
            this.lblSerTravId.Location = new System.Drawing.Point(30, 326);
            this.lblSerTravId.Name = "lblSerTravId";
            this.lblSerTravId.Text = "Service de travail réglé";
            // cboSerTravId
            this.cboSerTravId.Location = new System.Drawing.Point(30, 348);
            this.cboSerTravId.Size = new System.Drawing.Size(420, 27);
            this.cboSerTravId.Name = "cboSerTravId";
            this.cboSerTravId.TabIndex = 3;
            this.cboSerTravId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // FrmReglementDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 492);
            this.Controls.Add(this.dtpReglementDate);
            this.Controls.Add(this.lblReglementDate);
            this.Controls.Add(this.numReglementMontant);
            this.Controls.Add(this.lblReglementMontant);
            this.Controls.Add(this.cboAchatId);
            this.Controls.Add(this.lblAchatId);
            this.Controls.Add(this.cboSerTravId);
            this.Controls.Add(this.lblSerTravId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReglementDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Règlements";
            this.Load += new System.EventHandler(this.FrmReglementDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numReglementMontant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.DateTimePicker dtpReglementDate;
        private System.Windows.Forms.Label lblReglementDate;
        private System.Windows.Forms.NumericUpDown numReglementMontant;
        private System.Windows.Forms.Label lblReglementMontant;
        private System.Windows.Forms.ComboBox cboAchatId;
        private System.Windows.Forms.Label lblAchatId;
        private System.Windows.Forms.ComboBox cboSerTravId;
        private System.Windows.Forms.Label lblSerTravId;
    }
}
