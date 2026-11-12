namespace GestionChantier.UInterface
{
    partial class FrmUtilisateurDetail
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
            this.txtUtilisateurLogin = new System.Windows.Forms.TextBox();
            this.lblUtilisateurLogin = new System.Windows.Forms.Label();
            this.txtUtilisateurNomComplet = new System.Windows.Forms.TextBox();
            this.lblUtilisateurNomComplet = new System.Windows.Forms.Label();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.cboUtilisateurRole = new System.Windows.Forms.ComboBox();
            this.lblUtilisateurRole = new System.Windows.Forms.Label();
            this.chkUtilisateurActif = new System.Windows.Forms.CheckBox();
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
            this.lblTitre.Text = "Fiche – Utilisateurs";
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
            // lblUtilisateurLogin
            this.lblUtilisateurLogin.AutoSize = true;
            this.lblUtilisateurLogin.Location = new System.Drawing.Point(30, 98);
            this.lblUtilisateurLogin.Name = "lblUtilisateurLogin";
            this.lblUtilisateurLogin.Text = "Identifiant de connexion *";
            // txtUtilisateurLogin
            this.txtUtilisateurLogin.Location = new System.Drawing.Point(30, 120);
            this.txtUtilisateurLogin.Size = new System.Drawing.Size(420, 27);
            this.txtUtilisateurLogin.Name = "txtUtilisateurLogin";
            this.txtUtilisateurLogin.TabIndex = 0;
            this.txtUtilisateurLogin.MaxLength = 50;
            // lblUtilisateurNomComplet
            this.lblUtilisateurNomComplet.AutoSize = true;
            this.lblUtilisateurNomComplet.Location = new System.Drawing.Point(30, 174);
            this.lblUtilisateurNomComplet.Name = "lblUtilisateurNomComplet";
            this.lblUtilisateurNomComplet.Text = "Nom complet *";
            // txtUtilisateurNomComplet
            this.txtUtilisateurNomComplet.Location = new System.Drawing.Point(30, 196);
            this.txtUtilisateurNomComplet.Size = new System.Drawing.Size(420, 27);
            this.txtUtilisateurNomComplet.Name = "txtUtilisateurNomComplet";
            this.txtUtilisateurNomComplet.TabIndex = 1;
            this.txtUtilisateurNomComplet.MaxLength = 100;
            // lblMotDePasse
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Location = new System.Drawing.Point(30, 250);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Text = "Mot de passe *";
            // txtMotDePasse
            this.txtMotDePasse.Location = new System.Drawing.Point(30, 272);
            this.txtMotDePasse.Size = new System.Drawing.Size(420, 27);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.TabIndex = 2;
            this.txtMotDePasse.MaxLength = 100;
            this.txtMotDePasse.UseSystemPasswordChar = true;
            // lblUtilisateurRole
            this.lblUtilisateurRole.AutoSize = true;
            this.lblUtilisateurRole.Location = new System.Drawing.Point(30, 326);
            this.lblUtilisateurRole.Name = "lblUtilisateurRole";
            this.lblUtilisateurRole.Text = "Rôle *";
            // cboUtilisateurRole
            this.cboUtilisateurRole.Location = new System.Drawing.Point(30, 348);
            this.cboUtilisateurRole.Size = new System.Drawing.Size(420, 27);
            this.cboUtilisateurRole.Name = "cboUtilisateurRole";
            this.cboUtilisateurRole.TabIndex = 3;
            this.cboUtilisateurRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUtilisateurRole.Items.AddRange(new object[] { "Admin", "Gestionnaire", "Consultant" });
            // chkUtilisateurActif
            this.chkUtilisateurActif.AutoSize = true;
            this.chkUtilisateurActif.Location = new System.Drawing.Point(30, 402);
            this.chkUtilisateurActif.Text = "Compte actif";
            this.chkUtilisateurActif.Name = "chkUtilisateurActif";
            this.chkUtilisateurActif.TabIndex = 4;
            // FrmUtilisateurDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 536);
            this.Controls.Add(this.txtUtilisateurLogin);
            this.Controls.Add(this.lblUtilisateurLogin);
            this.Controls.Add(this.txtUtilisateurNomComplet);
            this.Controls.Add(this.lblUtilisateurNomComplet);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.lblMotDePasse);
            this.Controls.Add(this.cboUtilisateurRole);
            this.Controls.Add(this.lblUtilisateurRole);
            this.Controls.Add(this.chkUtilisateurActif);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUtilisateurDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Utilisateurs";
            this.Load += new System.EventHandler(this.FrmUtilisateurDetail_Load);
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
        private System.Windows.Forms.TextBox txtUtilisateurLogin;
        private System.Windows.Forms.Label lblUtilisateurLogin;
        private System.Windows.Forms.TextBox txtUtilisateurNomComplet;
        private System.Windows.Forms.Label lblUtilisateurNomComplet;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.ComboBox cboUtilisateurRole;
        private System.Windows.Forms.Label lblUtilisateurRole;
        private System.Windows.Forms.CheckBox chkUtilisateurActif;
    }
}
