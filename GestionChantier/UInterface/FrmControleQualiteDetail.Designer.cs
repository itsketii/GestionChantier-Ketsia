namespace GestionChantier.UInterface
{
    partial class FrmControleQualiteDetail
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
            this.dtpControleDate = new System.Windows.Forms.DateTimePicker();
            this.lblControleDate = new System.Windows.Forms.Label();
            this.cboSerTravId = new System.Windows.Forms.ComboBox();
            this.lblSerTravId = new System.Windows.Forms.Label();
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
            this.lblTitre.Text = "Fiche – Contrôles qualité";
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
            // lblControleDate
            this.lblControleDate.AutoSize = true;
            this.lblControleDate.Location = new System.Drawing.Point(30, 98);
            this.lblControleDate.Name = "lblControleDate";
            this.lblControleDate.Text = "Date du contrôle *";
            // dtpControleDate
            this.dtpControleDate.Location = new System.Drawing.Point(30, 120);
            this.dtpControleDate.Size = new System.Drawing.Size(420, 27);
            this.dtpControleDate.Name = "dtpControleDate";
            this.dtpControleDate.TabIndex = 0;
            this.dtpControleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // lblSerTravId
            this.lblSerTravId.AutoSize = true;
            this.lblSerTravId.Location = new System.Drawing.Point(30, 174);
            this.lblSerTravId.Name = "lblSerTravId";
            this.lblSerTravId.Text = "Service contrôlé *";
            // cboSerTravId
            this.cboSerTravId.Location = new System.Drawing.Point(30, 196);
            this.cboSerTravId.Size = new System.Drawing.Size(420, 27);
            this.cboSerTravId.Name = "cboSerTravId";
            this.cboSerTravId.TabIndex = 1;
            this.cboSerTravId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // FrmControleQualiteDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(480, 340);
            this.Controls.Add(this.dtpControleDate);
            this.Controls.Add(this.lblControleDate);
            this.Controls.Add(this.cboSerTravId);
            this.Controls.Add(this.lblSerTravId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmControleQualiteDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contrôles qualité";
            this.Load += new System.EventHandler(this.FrmControleQualiteDetail_Load);
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
        private System.Windows.Forms.DateTimePicker dtpControleDate;
        private System.Windows.Forms.Label lblControleDate;
        private System.Windows.Forms.ComboBox cboSerTravId;
        private System.Windows.Forms.Label lblSerTravId;
    }
}
