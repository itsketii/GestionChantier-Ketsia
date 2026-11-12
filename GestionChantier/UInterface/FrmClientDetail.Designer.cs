namespace GestionChantier.UInterface
{
    partial class FrmClientDetail
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
            this.txtClientNom = new System.Windows.Forms.TextBox();
            this.lblClientNom = new System.Windows.Forms.Label();
            this.txtClientTelephone = new System.Windows.Forms.TextBox();
            this.lblClientTelephone = new System.Windows.Forms.Label();
            this.txtClientEmail = new System.Windows.Forms.TextBox();
            this.lblClientEmail = new System.Windows.Forms.Label();
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
            this.lblTitre.Text = "Fiche – Clients";
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
            // lblClientNom
            this.lblClientNom.AutoSize = true;
            this.lblClientNom.Location = new System.Drawing.Point(30, 98);
            this.lblClientNom.Name = "lblClientNom";
            this.lblClientNom.Text = "Nom / Raison sociale *";
            // txtClientNom
            this.txtClientNom.Location = new System.Drawing.Point(30, 120);
            this.txtClientNom.Size = new System.Drawing.Size(420, 27);
            this.txtClientNom.Name = "txtClientNom";
            this.txtClientNom.TabIndex = 0;
            this.txtClientNom.MaxLength = 100;
            // lblClientTelephone
            this.lblClientTelephone.AutoSize = true;
            this.lblClientTelephone.Location = new System.Drawing.Point(30, 174);
            this.lblClientTelephone.Name = "lblClientTelephone";
            this.lblClientTelephone.Text = "Téléphone *";
            // txtClientTelephone
            this.txtClientTelephone.Location = new System.Drawing.Point(30, 196);
            this.txtClientTelephone.Size = new System.Drawing.Size(420, 27);
            this.txtClientTelephone.Name = "txtClientTelephone";
            this.txtClientTelephone.TabIndex = 1;
            this.txtClientTelephone.MaxLength = 100;
            // lblClientEmail
            this.lblClientEmail.AutoSize = true;
            this.lblClientEmail.Location = new System.Drawing.Point(30, 250);
            this.lblClientEmail.Name = "lblClientEmail";
            this.lblClientEmail.Text = "Email";
            // txtClientEmail
            this.txtClientEmail.Location = new System.Drawing.Point(30, 272);
            this.txtClientEmail.Size = new System.Drawing.Size(420, 27);
            this.txtClientEmail.Name = "txtClientEmail";
            this.txtClientEmail.TabIndex = 2;
            this.txtClientEmail.MaxLength = 100;
            // FrmClientDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 416);
            this.Controls.Add(this.txtClientNom);
            this.Controls.Add(this.lblClientNom);
            this.Controls.Add(this.txtClientTelephone);
            this.Controls.Add(this.lblClientTelephone);
            this.Controls.Add(this.txtClientEmail);
            this.Controls.Add(this.lblClientEmail);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClientDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.FrmClientDetail_Load);
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
        private System.Windows.Forms.TextBox txtClientNom;
        private System.Windows.Forms.Label lblClientNom;
        private System.Windows.Forms.TextBox txtClientTelephone;
        private System.Windows.Forms.Label lblClientTelephone;
        private System.Windows.Forms.TextBox txtClientEmail;
        private System.Windows.Forms.Label lblClientEmail;
    }
}
