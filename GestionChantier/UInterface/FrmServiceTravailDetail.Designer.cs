namespace GestionChantier.UInterface
{
    partial class FrmServiceTravailDetail
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
            this.txtSerTravNom = new System.Windows.Forms.TextBox();
            this.lblSerTravNom = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboPhaseId = new System.Windows.Forms.ComboBox();
            this.lblPhaseId = new System.Windows.Forms.Label();
            this.cboIntervenantId = new System.Windows.Forms.ComboBox();
            this.lblIntervenantId = new System.Windows.Forms.Label();
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
            this.lblTitre.Text = "Fiche – Services de travail";
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
            // lblSerTravNom
            this.lblSerTravNom.AutoSize = true;
            this.lblSerTravNom.Location = new System.Drawing.Point(30, 98);
            this.lblSerTravNom.Name = "lblSerTravNom";
            this.lblSerTravNom.Text = "Nom du service *";
            // txtSerTravNom
            this.txtSerTravNom.Location = new System.Drawing.Point(30, 120);
            this.txtSerTravNom.Size = new System.Drawing.Size(420, 27);
            this.txtSerTravNom.Name = "txtSerTravNom";
            this.txtSerTravNom.TabIndex = 0;
            this.txtSerTravNom.MaxLength = 100;
            // lblType
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(30, 174);
            this.lblType.Name = "lblType";
            this.lblType.Text = "Type *";
            // cboType
            this.cboType.Location = new System.Drawing.Point(30, 196);
            this.cboType.Size = new System.Drawing.Size(420, 27);
            this.cboType.Name = "cboType";
            this.cboType.TabIndex = 1;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Items.AddRange(new object[] { "Interne", "Externe" });
            // lblPhaseId
            this.lblPhaseId.AutoSize = true;
            this.lblPhaseId.Location = new System.Drawing.Point(30, 250);
            this.lblPhaseId.Name = "lblPhaseId";
            this.lblPhaseId.Text = "Phase *";
            // cboPhaseId
            this.cboPhaseId.Location = new System.Drawing.Point(30, 272);
            this.cboPhaseId.Size = new System.Drawing.Size(420, 27);
            this.cboPhaseId.Name = "cboPhaseId";
            this.cboPhaseId.TabIndex = 2;
            this.cboPhaseId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // lblIntervenantId
            this.lblIntervenantId.AutoSize = true;
            this.lblIntervenantId.Location = new System.Drawing.Point(30, 326);
            this.lblIntervenantId.Name = "lblIntervenantId";
            this.lblIntervenantId.Text = "Intervenant *";
            // cboIntervenantId
            this.cboIntervenantId.Location = new System.Drawing.Point(30, 348);
            this.cboIntervenantId.Size = new System.Drawing.Size(420, 27);
            this.cboIntervenantId.Name = "cboIntervenantId";
            this.cboIntervenantId.TabIndex = 3;
            this.cboIntervenantId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // FrmServiceTravailDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 492);
            this.Controls.Add(this.txtSerTravNom);
            this.Controls.Add(this.lblSerTravNom);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cboPhaseId);
            this.Controls.Add(this.lblPhaseId);
            this.Controls.Add(this.cboIntervenantId);
            this.Controls.Add(this.lblIntervenantId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmServiceTravailDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Services de travail";
            this.Load += new System.EventHandler(this.FrmServiceTravailDetail_Load);
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
        private System.Windows.Forms.TextBox txtSerTravNom;
        private System.Windows.Forms.Label lblSerTravNom;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboPhaseId;
        private System.Windows.Forms.Label lblPhaseId;
        private System.Windows.Forms.ComboBox cboIntervenantId;
        private System.Windows.Forms.Label lblIntervenantId;
    }
}
