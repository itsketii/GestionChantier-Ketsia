namespace GestionChantier.UInterface
{
    partial class FrmFactureAchatDetail
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
            this.numFactureTotalTtc = new System.Windows.Forms.NumericUpDown();
            this.lblFactureTotalTtc = new System.Windows.Forms.Label();
            this.dtpFactureDate = new System.Windows.Forms.DateTimePicker();
            this.lblFactureDate = new System.Windows.Forms.Label();
            this.cboFournisseurId = new System.Windows.Forms.ComboBox();
            this.lblFournisseurId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numFactureTotalTtc)).BeginInit();
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
            this.lblTitre.Text = "Fiche – Factures d'achat";
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
            // lblFactureTotalTtc
            this.lblFactureTotalTtc.AutoSize = true;
            this.lblFactureTotalTtc.Location = new System.Drawing.Point(30, 98);
            this.lblFactureTotalTtc.Name = "lblFactureTotalTtc";
            this.lblFactureTotalTtc.Text = "Total TTC (FCFA) *";
            // numFactureTotalTtc
            this.numFactureTotalTtc.Location = new System.Drawing.Point(30, 120);
            this.numFactureTotalTtc.Size = new System.Drawing.Size(420, 27);
            this.numFactureTotalTtc.Name = "numFactureTotalTtc";
            this.numFactureTotalTtc.TabIndex = 0;
            this.numFactureTotalTtc.Maximum = new decimal(new int[] { -1, 2, 0, 0 });
            this.numFactureTotalTtc.ThousandsSeparator = true;
            // lblFactureDate
            this.lblFactureDate.AutoSize = true;
            this.lblFactureDate.Location = new System.Drawing.Point(30, 174);
            this.lblFactureDate.Name = "lblFactureDate";
            this.lblFactureDate.Text = "Date de la facture *";
            // dtpFactureDate
            this.dtpFactureDate.Location = new System.Drawing.Point(30, 196);
            this.dtpFactureDate.Size = new System.Drawing.Size(420, 27);
            this.dtpFactureDate.Name = "dtpFactureDate";
            this.dtpFactureDate.TabIndex = 1;
            this.dtpFactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // lblFournisseurId
            this.lblFournisseurId.AutoSize = true;
            this.lblFournisseurId.Location = new System.Drawing.Point(30, 250);
            this.lblFournisseurId.Name = "lblFournisseurId";
            this.lblFournisseurId.Text = "Fournisseur *";
            // cboFournisseurId
            this.cboFournisseurId.Location = new System.Drawing.Point(30, 272);
            this.cboFournisseurId.Size = new System.Drawing.Size(420, 27);
            this.cboFournisseurId.Name = "cboFournisseurId";
            this.cboFournisseurId.TabIndex = 2;
            this.cboFournisseurId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // FrmFactureAchatDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 416);
            this.Controls.Add(this.numFactureTotalTtc);
            this.Controls.Add(this.lblFactureTotalTtc);
            this.Controls.Add(this.dtpFactureDate);
            this.Controls.Add(this.lblFactureDate);
            this.Controls.Add(this.cboFournisseurId);
            this.Controls.Add(this.lblFournisseurId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFactureAchatDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Factures d'achat";
            this.Load += new System.EventHandler(this.FrmFactureAchatDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFactureTotalTtc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.NumericUpDown numFactureTotalTtc;
        private System.Windows.Forms.Label lblFactureTotalTtc;
        private System.Windows.Forms.DateTimePicker dtpFactureDate;
        private System.Windows.Forms.Label lblFactureDate;
        private System.Windows.Forms.ComboBox cboFournisseurId;
        private System.Windows.Forms.Label lblFournisseurId;
    }
}
