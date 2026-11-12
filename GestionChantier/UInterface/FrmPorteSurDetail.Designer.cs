namespace GestionChantier.UInterface
{
    partial class FrmPorteSurDetail
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
            this.cboAchatId = new System.Windows.Forms.ComboBox();
            this.lblAchatId = new System.Windows.Forms.Label();
            this.cboArticleId = new System.Windows.Forms.ComboBox();
            this.lblArticleId = new System.Windows.Forms.Label();
            this.numQuantite = new System.Windows.Forms.NumericUpDown();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.numPrixAchat = new System.Windows.Forms.NumericUpDown();
            this.lblPrixAchat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrixAchat)).BeginInit();
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
            this.lblTitre.Text = "Fiche – Lignes d'achat";
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
            // lblAchatId
            this.lblAchatId.AutoSize = true;
            this.lblAchatId.Location = new System.Drawing.Point(30, 98);
            this.lblAchatId.Name = "lblAchatId";
            this.lblAchatId.Text = "Achat *";
            // cboAchatId
            this.cboAchatId.Location = new System.Drawing.Point(30, 120);
            this.cboAchatId.Size = new System.Drawing.Size(420, 27);
            this.cboAchatId.Name = "cboAchatId";
            this.cboAchatId.TabIndex = 0;
            this.cboAchatId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // lblArticleId
            this.lblArticleId.AutoSize = true;
            this.lblArticleId.Location = new System.Drawing.Point(30, 174);
            this.lblArticleId.Name = "lblArticleId";
            this.lblArticleId.Text = "Article *";
            // cboArticleId
            this.cboArticleId.Location = new System.Drawing.Point(30, 196);
            this.cboArticleId.Size = new System.Drawing.Size(420, 27);
            this.cboArticleId.Name = "cboArticleId";
            this.cboArticleId.TabIndex = 1;
            this.cboArticleId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // lblQuantite
            this.lblQuantite.AutoSize = true;
            this.lblQuantite.Location = new System.Drawing.Point(30, 250);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Text = "Quantité *";
            // numQuantite
            this.numQuantite.Location = new System.Drawing.Point(30, 272);
            this.numQuantite.Size = new System.Drawing.Size(420, 27);
            this.numQuantite.Name = "numQuantite";
            this.numQuantite.TabIndex = 2;
            this.numQuantite.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numQuantite.ThousandsSeparator = true;
            this.numQuantite.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // lblPrixAchat
            this.lblPrixAchat.AutoSize = true;
            this.lblPrixAchat.Location = new System.Drawing.Point(30, 326);
            this.lblPrixAchat.Name = "lblPrixAchat";
            this.lblPrixAchat.Text = "Prix d'achat unitaire (FCFA) *";
            // numPrixAchat
            this.numPrixAchat.Location = new System.Drawing.Point(30, 348);
            this.numPrixAchat.Size = new System.Drawing.Size(420, 27);
            this.numPrixAchat.Name = "numPrixAchat";
            this.numPrixAchat.TabIndex = 3;
            this.numPrixAchat.Maximum = new decimal(new int[] { -1, 2, 0, 0 });
            this.numPrixAchat.ThousandsSeparator = true;
            // FrmPorteSurDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 492);
            this.Controls.Add(this.cboAchatId);
            this.Controls.Add(this.lblAchatId);
            this.Controls.Add(this.cboArticleId);
            this.Controls.Add(this.lblArticleId);
            this.Controls.Add(this.numQuantite);
            this.Controls.Add(this.lblQuantite);
            this.Controls.Add(this.numPrixAchat);
            this.Controls.Add(this.lblPrixAchat);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPorteSurDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lignes d'achat";
            this.Load += new System.EventHandler(this.FrmPorteSurDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrixAchat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.ComboBox cboAchatId;
        private System.Windows.Forms.Label lblAchatId;
        private System.Windows.Forms.ComboBox cboArticleId;
        private System.Windows.Forms.Label lblArticleId;
        private System.Windows.Forms.NumericUpDown numQuantite;
        private System.Windows.Forms.Label lblQuantite;
        private System.Windows.Forms.NumericUpDown numPrixAchat;
        private System.Windows.Forms.Label lblPrixAchat;
    }
}
