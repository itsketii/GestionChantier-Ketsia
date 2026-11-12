namespace GestionChantier.UInterface
{
    partial class FrmArticleDetail
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
            this.txtArticleNom = new System.Windows.Forms.TextBox();
            this.lblArticleNom = new System.Windows.Forms.Label();
            this.txtArticleUnite = new System.Windows.Forms.TextBox();
            this.lblArticleUnite = new System.Windows.Forms.Label();
            this.numArticlePrixUnitaire = new System.Windows.Forms.NumericUpDown();
            this.lblArticlePrixUnitaire = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numArticlePrixUnitaire)).BeginInit();
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
            this.lblTitre.Text = "Fiche – Articles";
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
            // lblArticleNom
            this.lblArticleNom.AutoSize = true;
            this.lblArticleNom.Location = new System.Drawing.Point(30, 98);
            this.lblArticleNom.Name = "lblArticleNom";
            this.lblArticleNom.Text = "Désignation *";
            // txtArticleNom
            this.txtArticleNom.Location = new System.Drawing.Point(30, 120);
            this.txtArticleNom.Size = new System.Drawing.Size(420, 27);
            this.txtArticleNom.Name = "txtArticleNom";
            this.txtArticleNom.TabIndex = 0;
            this.txtArticleNom.MaxLength = 100;
            // lblArticleUnite
            this.lblArticleUnite.AutoSize = true;
            this.lblArticleUnite.Location = new System.Drawing.Point(30, 174);
            this.lblArticleUnite.Name = "lblArticleUnite";
            this.lblArticleUnite.Text = "Unité *";
            // txtArticleUnite
            this.txtArticleUnite.Location = new System.Drawing.Point(30, 196);
            this.txtArticleUnite.Size = new System.Drawing.Size(420, 27);
            this.txtArticleUnite.Name = "txtArticleUnite";
            this.txtArticleUnite.TabIndex = 1;
            this.txtArticleUnite.MaxLength = 50;
            // lblArticlePrixUnitaire
            this.lblArticlePrixUnitaire.AutoSize = true;
            this.lblArticlePrixUnitaire.Location = new System.Drawing.Point(30, 250);
            this.lblArticlePrixUnitaire.Name = "lblArticlePrixUnitaire";
            this.lblArticlePrixUnitaire.Text = "Prix unitaire (FCFA) *";
            // numArticlePrixUnitaire
            this.numArticlePrixUnitaire.Location = new System.Drawing.Point(30, 272);
            this.numArticlePrixUnitaire.Size = new System.Drawing.Size(420, 27);
            this.numArticlePrixUnitaire.Name = "numArticlePrixUnitaire";
            this.numArticlePrixUnitaire.TabIndex = 2;
            this.numArticlePrixUnitaire.Maximum = new decimal(new int[] { -1, 2, 0, 0 });
            this.numArticlePrixUnitaire.ThousandsSeparator = true;
            // FrmArticleDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 416);
            this.Controls.Add(this.txtArticleNom);
            this.Controls.Add(this.lblArticleNom);
            this.Controls.Add(this.txtArticleUnite);
            this.Controls.Add(this.lblArticleUnite);
            this.Controls.Add(this.numArticlePrixUnitaire);
            this.Controls.Add(this.lblArticlePrixUnitaire);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArticleDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Articles";
            this.Load += new System.EventHandler(this.FrmArticleDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numArticlePrixUnitaire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox txtArticleNom;
        private System.Windows.Forms.Label lblArticleNom;
        private System.Windows.Forms.TextBox txtArticleUnite;
        private System.Windows.Forms.Label lblArticleUnite;
        private System.Windows.Forms.NumericUpDown numArticlePrixUnitaire;
        private System.Windows.Forms.Label lblArticlePrixUnitaire;
    }
}
