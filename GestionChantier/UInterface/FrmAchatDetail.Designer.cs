namespace GestionChantier.UInterface
{
    partial class FrmAchatDetail
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
            this.dtpAchatDate = new System.Windows.Forms.DateTimePicker();
            this.lblAchatDate = new System.Windows.Forms.Label();
            this.txtAchatDescription = new System.Windows.Forms.TextBox();
            this.lblAchatDescription = new System.Windows.Forms.Label();
            this.cboChantierId = new System.Windows.Forms.ComboBox();
            this.lblChantierId = new System.Windows.Forms.Label();
            this.cboFactureId = new System.Windows.Forms.ComboBox();
            this.lblFactureId = new System.Windows.Forms.Label();
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
            this.lblTitre.Text = "Fiche – Achats";
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
            // lblAchatDate
            this.lblAchatDate.AutoSize = true;
            this.lblAchatDate.Location = new System.Drawing.Point(30, 98);
            this.lblAchatDate.Name = "lblAchatDate";
            this.lblAchatDate.Text = "Date de l'achat *";
            // dtpAchatDate
            this.dtpAchatDate.Location = new System.Drawing.Point(30, 120);
            this.dtpAchatDate.Size = new System.Drawing.Size(420, 27);
            this.dtpAchatDate.Name = "dtpAchatDate";
            this.dtpAchatDate.TabIndex = 0;
            this.dtpAchatDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // lblAchatDescription
            this.lblAchatDescription.AutoSize = true;
            this.lblAchatDescription.Location = new System.Drawing.Point(30, 174);
            this.lblAchatDescription.Name = "lblAchatDescription";
            this.lblAchatDescription.Text = "Description *";
            // txtAchatDescription
            this.txtAchatDescription.Location = new System.Drawing.Point(30, 196);
            this.txtAchatDescription.Size = new System.Drawing.Size(420, 27);
            this.txtAchatDescription.Name = "txtAchatDescription";
            this.txtAchatDescription.TabIndex = 1;
            this.txtAchatDescription.MaxLength = 255;
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
            // lblFactureId
            this.lblFactureId.AutoSize = true;
            this.lblFactureId.Location = new System.Drawing.Point(30, 326);
            this.lblFactureId.Name = "lblFactureId";
            this.lblFactureId.Text = "Facture *";
            // cboFactureId
            this.cboFactureId.Location = new System.Drawing.Point(30, 348);
            this.cboFactureId.Size = new System.Drawing.Size(420, 27);
            this.cboFactureId.Name = "cboFactureId";
            this.cboFactureId.TabIndex = 3;
            this.cboFactureId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // FrmAchatDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 492);
            this.Controls.Add(this.dtpAchatDate);
            this.Controls.Add(this.lblAchatDate);
            this.Controls.Add(this.txtAchatDescription);
            this.Controls.Add(this.lblAchatDescription);
            this.Controls.Add(this.cboChantierId);
            this.Controls.Add(this.lblChantierId);
            this.Controls.Add(this.cboFactureId);
            this.Controls.Add(this.lblFactureId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAchatDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Achats";
            this.Load += new System.EventHandler(this.FrmAchatDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.DateTimePicker dtpAchatDate;
        private System.Windows.Forms.Label lblAchatDate;
        private System.Windows.Forms.TextBox txtAchatDescription;
        private System.Windows.Forms.Label lblAchatDescription;
        private System.Windows.Forms.ComboBox cboChantierId;
        private System.Windows.Forms.Label lblChantierId;
        private System.Windows.Forms.ComboBox cboFactureId;
        private System.Windows.Forms.Label lblFactureId;
    }
}
