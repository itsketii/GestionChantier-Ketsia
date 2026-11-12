namespace GestionChantier.UInterface
{
    partial class FrmFournisseurDetail
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
            this.txtFournisseurNom = new System.Windows.Forms.TextBox();
            this.lblFournisseurNom = new System.Windows.Forms.Label();
            this.txtFournisseurAdresse = new System.Windows.Forms.TextBox();
            this.lblFournisseurAdresse = new System.Windows.Forms.Label();
            this.txtFournisseurTelephone = new System.Windows.Forms.TextBox();
            this.lblFournisseurTelephone = new System.Windows.Forms.Label();
            this.txtFournisseurMail = new System.Windows.Forms.TextBox();
            this.lblFournisseurMail = new System.Windows.Forms.Label();
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
            this.lblTitre.Text = "Fiche – Fournisseurs";
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
            // lblFournisseurNom
            this.lblFournisseurNom.AutoSize = true;
            this.lblFournisseurNom.Location = new System.Drawing.Point(30, 98);
            this.lblFournisseurNom.Name = "lblFournisseurNom";
            this.lblFournisseurNom.Text = "Nom *";
            // txtFournisseurNom
            this.txtFournisseurNom.Location = new System.Drawing.Point(30, 120);
            this.txtFournisseurNom.Size = new System.Drawing.Size(420, 27);
            this.txtFournisseurNom.Name = "txtFournisseurNom";
            this.txtFournisseurNom.TabIndex = 0;
            this.txtFournisseurNom.MaxLength = 100;
            // lblFournisseurAdresse
            this.lblFournisseurAdresse.AutoSize = true;
            this.lblFournisseurAdresse.Location = new System.Drawing.Point(30, 174);
            this.lblFournisseurAdresse.Name = "lblFournisseurAdresse";
            this.lblFournisseurAdresse.Text = "Adresse *";
            // txtFournisseurAdresse
            this.txtFournisseurAdresse.Location = new System.Drawing.Point(30, 196);
            this.txtFournisseurAdresse.Size = new System.Drawing.Size(420, 27);
            this.txtFournisseurAdresse.Name = "txtFournisseurAdresse";
            this.txtFournisseurAdresse.TabIndex = 1;
            this.txtFournisseurAdresse.MaxLength = 100;
            // lblFournisseurTelephone
            this.lblFournisseurTelephone.AutoSize = true;
            this.lblFournisseurTelephone.Location = new System.Drawing.Point(30, 250);
            this.lblFournisseurTelephone.Name = "lblFournisseurTelephone";
            this.lblFournisseurTelephone.Text = "Téléphone *";
            // txtFournisseurTelephone
            this.txtFournisseurTelephone.Location = new System.Drawing.Point(30, 272);
            this.txtFournisseurTelephone.Size = new System.Drawing.Size(420, 27);
            this.txtFournisseurTelephone.Name = "txtFournisseurTelephone";
            this.txtFournisseurTelephone.TabIndex = 2;
            this.txtFournisseurTelephone.MaxLength = 100;
            // lblFournisseurMail
            this.lblFournisseurMail.AutoSize = true;
            this.lblFournisseurMail.Location = new System.Drawing.Point(30, 326);
            this.lblFournisseurMail.Name = "lblFournisseurMail";
            this.lblFournisseurMail.Text = "Email";
            // txtFournisseurMail
            this.txtFournisseurMail.Location = new System.Drawing.Point(30, 348);
            this.txtFournisseurMail.Size = new System.Drawing.Size(420, 27);
            this.txtFournisseurMail.Name = "txtFournisseurMail";
            this.txtFournisseurMail.TabIndex = 3;
            this.txtFournisseurMail.MaxLength = 100;
            // FrmFournisseurDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 492);
            this.Controls.Add(this.txtFournisseurNom);
            this.Controls.Add(this.lblFournisseurNom);
            this.Controls.Add(this.txtFournisseurAdresse);
            this.Controls.Add(this.lblFournisseurAdresse);
            this.Controls.Add(this.txtFournisseurTelephone);
            this.Controls.Add(this.lblFournisseurTelephone);
            this.Controls.Add(this.txtFournisseurMail);
            this.Controls.Add(this.lblFournisseurMail);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFournisseurDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fournisseurs";
            this.Load += new System.EventHandler(this.FrmFournisseurDetail_Load);
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
        private System.Windows.Forms.TextBox txtFournisseurNom;
        private System.Windows.Forms.Label lblFournisseurNom;
        private System.Windows.Forms.TextBox txtFournisseurAdresse;
        private System.Windows.Forms.Label lblFournisseurAdresse;
        private System.Windows.Forms.TextBox txtFournisseurTelephone;
        private System.Windows.Forms.Label lblFournisseurTelephone;
        private System.Windows.Forms.TextBox txtFournisseurMail;
        private System.Windows.Forms.Label lblFournisseurMail;
    }
}
