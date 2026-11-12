namespace GestionChantier.UInterface
{
    partial class FrmRapportControleDetail
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
            this.dtpRapportDate = new System.Windows.Forms.DateTimePicker();
            this.lblRapportDate = new System.Windows.Forms.Label();
            this.txtRapportRecommandation = new System.Windows.Forms.TextBox();
            this.lblRapportRecommandation = new System.Windows.Forms.Label();
            this.cboControleId = new System.Windows.Forms.ComboBox();
            this.lblControleId = new System.Windows.Forms.Label();
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
            this.lblTitre.Text = "Fiche – Rapports de contrôle";
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
            // lblRapportDate
            this.lblRapportDate.AutoSize = true;
            this.lblRapportDate.Location = new System.Drawing.Point(30, 98);
            this.lblRapportDate.Name = "lblRapportDate";
            this.lblRapportDate.Text = "Date du rapport *";
            // dtpRapportDate
            this.dtpRapportDate.Location = new System.Drawing.Point(30, 120);
            this.dtpRapportDate.Size = new System.Drawing.Size(420, 27);
            this.dtpRapportDate.Name = "dtpRapportDate";
            this.dtpRapportDate.TabIndex = 0;
            this.dtpRapportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // lblRapportRecommandation
            this.lblRapportRecommandation.AutoSize = true;
            this.lblRapportRecommandation.Location = new System.Drawing.Point(30, 174);
            this.lblRapportRecommandation.Name = "lblRapportRecommandation";
            this.lblRapportRecommandation.Text = "Recommandation *";
            // txtRapportRecommandation
            this.txtRapportRecommandation.Location = new System.Drawing.Point(30, 196);
            this.txtRapportRecommandation.Size = new System.Drawing.Size(420, 100);
            this.txtRapportRecommandation.Name = "txtRapportRecommandation";
            this.txtRapportRecommandation.TabIndex = 1;
            this.txtRapportRecommandation.MaxLength = 4000;
            this.txtRapportRecommandation.Multiline = true;
            this.txtRapportRecommandation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // lblControleId
            this.lblControleId.AutoSize = true;
            this.lblControleId.Location = new System.Drawing.Point(30, 324);
            this.lblControleId.Name = "lblControleId";
            this.lblControleId.Text = "Contrôle *";
            // cboControleId
            this.cboControleId.Location = new System.Drawing.Point(30, 346);
            this.cboControleId.Size = new System.Drawing.Size(420, 27);
            this.cboControleId.Name = "cboControleId";
            this.cboControleId.TabIndex = 2;
            this.cboControleId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // FrmRapportControleDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 490);
            this.Controls.Add(this.dtpRapportDate);
            this.Controls.Add(this.lblRapportDate);
            this.Controls.Add(this.txtRapportRecommandation);
            this.Controls.Add(this.lblRapportRecommandation);
            this.Controls.Add(this.cboControleId);
            this.Controls.Add(this.lblControleId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRapportControleDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rapports de contrôle";
            this.Load += new System.EventHandler(this.FrmRapportControleDetail_Load);
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
        private System.Windows.Forms.DateTimePicker dtpRapportDate;
        private System.Windows.Forms.Label lblRapportDate;
        private System.Windows.Forms.TextBox txtRapportRecommandation;
        private System.Windows.Forms.Label lblRapportRecommandation;
        private System.Windows.Forms.ComboBox cboControleId;
        private System.Windows.Forms.Label lblControleId;
    }
}
