namespace GestionChantier.UInterface
{
    partial class FrmIntervenantDetail
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
            this.txtIntervenantNom = new System.Windows.Forms.TextBox();
            this.lblIntervenantNom = new System.Windows.Forms.Label();
            this.txtIntervenantSpecialite = new System.Windows.Forms.TextBox();
            this.lblIntervenantSpecialite = new System.Windows.Forms.Label();
            this.numIntervenantTauxHoraire = new System.Windows.Forms.NumericUpDown();
            this.lblIntervenantTauxHoraire = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervenantTauxHoraire)).BeginInit();
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
            this.lblTitre.Text = "Fiche – Intervenants";
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
            // lblIntervenantNom
            this.lblIntervenantNom.AutoSize = true;
            this.lblIntervenantNom.Location = new System.Drawing.Point(30, 98);
            this.lblIntervenantNom.Name = "lblIntervenantNom";
            this.lblIntervenantNom.Text = "Nom *";
            // txtIntervenantNom
            this.txtIntervenantNom.Location = new System.Drawing.Point(30, 120);
            this.txtIntervenantNom.Size = new System.Drawing.Size(420, 27);
            this.txtIntervenantNom.Name = "txtIntervenantNom";
            this.txtIntervenantNom.TabIndex = 0;
            this.txtIntervenantNom.MaxLength = 255;
            // lblIntervenantSpecialite
            this.lblIntervenantSpecialite.AutoSize = true;
            this.lblIntervenantSpecialite.Location = new System.Drawing.Point(30, 174);
            this.lblIntervenantSpecialite.Name = "lblIntervenantSpecialite";
            this.lblIntervenantSpecialite.Text = "Spécialité *";
            // txtIntervenantSpecialite
            this.txtIntervenantSpecialite.Location = new System.Drawing.Point(30, 196);
            this.txtIntervenantSpecialite.Size = new System.Drawing.Size(420, 27);
            this.txtIntervenantSpecialite.Name = "txtIntervenantSpecialite";
            this.txtIntervenantSpecialite.TabIndex = 1;
            this.txtIntervenantSpecialite.MaxLength = 100;
            // lblIntervenantTauxHoraire
            this.lblIntervenantTauxHoraire.AutoSize = true;
            this.lblIntervenantTauxHoraire.Location = new System.Drawing.Point(30, 250);
            this.lblIntervenantTauxHoraire.Name = "lblIntervenantTauxHoraire";
            this.lblIntervenantTauxHoraire.Text = "Taux horaire (FCFA) *";
            // numIntervenantTauxHoraire
            this.numIntervenantTauxHoraire.Location = new System.Drawing.Point(30, 272);
            this.numIntervenantTauxHoraire.Size = new System.Drawing.Size(420, 27);
            this.numIntervenantTauxHoraire.Name = "numIntervenantTauxHoraire";
            this.numIntervenantTauxHoraire.TabIndex = 2;
            this.numIntervenantTauxHoraire.Maximum = new decimal(new int[] { -1, 2, 0, 0 });
            this.numIntervenantTauxHoraire.ThousandsSeparator = true;
            // FrmIntervenantDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 416);
            this.Controls.Add(this.txtIntervenantNom);
            this.Controls.Add(this.lblIntervenantNom);
            this.Controls.Add(this.txtIntervenantSpecialite);
            this.Controls.Add(this.lblIntervenantSpecialite);
            this.Controls.Add(this.numIntervenantTauxHoraire);
            this.Controls.Add(this.lblIntervenantTauxHoraire);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIntervenantDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Intervenants";
            this.Load += new System.EventHandler(this.FrmIntervenantDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numIntervenantTauxHoraire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox txtIntervenantNom;
        private System.Windows.Forms.Label lblIntervenantNom;
        private System.Windows.Forms.TextBox txtIntervenantSpecialite;
        private System.Windows.Forms.Label lblIntervenantSpecialite;
        private System.Windows.Forms.NumericUpDown numIntervenantTauxHoraire;
        private System.Windows.Forms.Label lblIntervenantTauxHoraire;
    }
}
