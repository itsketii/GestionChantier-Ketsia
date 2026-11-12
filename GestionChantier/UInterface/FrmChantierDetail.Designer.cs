namespace GestionChantier.UInterface
{
    partial class FrmChantierDetail
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
            this.txtChantierNom = new System.Windows.Forms.TextBox();
            this.lblChantierNom = new System.Windows.Forms.Label();
            this.txtChantierAdresse = new System.Windows.Forms.TextBox();
            this.lblChantierAdresse = new System.Windows.Forms.Label();
            this.cboChantierStatut = new System.Windows.Forms.ComboBox();
            this.lblChantierStatut = new System.Windows.Forms.Label();
            this.dtpChantierDateDebut = new System.Windows.Forms.DateTimePicker();
            this.lblChantierDateDebut = new System.Windows.Forms.Label();
            this.dtpChantierDateFin = new System.Windows.Forms.DateTimePicker();
            this.lblChantierDateFin = new System.Windows.Forms.Label();
            this.numChantierBudget = new System.Windows.Forms.NumericUpDown();
            this.lblChantierBudget = new System.Windows.Forms.Label();
            this.cboClientId = new System.Windows.Forms.ComboBox();
            this.lblClientId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numChantierBudget)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblTitre);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(850, 72);
            // lblTitre
            this.lblTitre.AutoSize = true;
            this.lblTitre.BackColor = System.Drawing.Color.Transparent;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Location = new System.Drawing.Point(28, 18);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Text = "Fiche – Chantiers";
            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(243, 245, 249);
            this.pnlFooter.Controls.Add(this.btnEnregistrer);
            this.pnlFooter.Controls.Add(this.btnAnnuler);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(850, 68);
            // btnEnregistrer
            this.btnEnregistrer.Location = new System.Drawing.Point(548, 15);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(140, 38);
            this.btnEnregistrer.TabIndex = 100;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // btnAnnuler
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(700, 15);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(120, 38);
            this.btnAnnuler.TabIndex = 101;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            // lblChantierNom
            this.lblChantierNom.AutoSize = true;
            this.lblChantierNom.Location = new System.Drawing.Point(30, 98);
            this.lblChantierNom.Name = "lblChantierNom";
            this.lblChantierNom.Text = "Nom du chantier *";
            // txtChantierNom
            this.txtChantierNom.Location = new System.Drawing.Point(30, 120);
            this.txtChantierNom.Size = new System.Drawing.Size(380, 27);
            this.txtChantierNom.Name = "txtChantierNom";
            this.txtChantierNom.TabIndex = 0;
            this.txtChantierNom.MaxLength = 100;
            // lblChantierAdresse
            this.lblChantierAdresse.AutoSize = true;
            this.lblChantierAdresse.Location = new System.Drawing.Point(440, 98);
            this.lblChantierAdresse.Name = "lblChantierAdresse";
            this.lblChantierAdresse.Text = "Adresse *";
            // txtChantierAdresse
            this.txtChantierAdresse.Location = new System.Drawing.Point(440, 120);
            this.txtChantierAdresse.Size = new System.Drawing.Size(380, 27);
            this.txtChantierAdresse.Name = "txtChantierAdresse";
            this.txtChantierAdresse.TabIndex = 1;
            this.txtChantierAdresse.MaxLength = 100;
            // lblChantierStatut
            this.lblChantierStatut.AutoSize = true;
            this.lblChantierStatut.Location = new System.Drawing.Point(30, 174);
            this.lblChantierStatut.Name = "lblChantierStatut";
            this.lblChantierStatut.Text = "Statut *";
            // cboChantierStatut
            this.cboChantierStatut.Location = new System.Drawing.Point(30, 196);
            this.cboChantierStatut.Size = new System.Drawing.Size(380, 27);
            this.cboChantierStatut.Name = "cboChantierStatut";
            this.cboChantierStatut.TabIndex = 2;
            this.cboChantierStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChantierStatut.Items.AddRange(new object[] { "Planifié", "En cours", "Suspendu", "Terminé" });
            // lblChantierDateDebut
            this.lblChantierDateDebut.AutoSize = true;
            this.lblChantierDateDebut.Location = new System.Drawing.Point(440, 174);
            this.lblChantierDateDebut.Name = "lblChantierDateDebut";
            this.lblChantierDateDebut.Text = "Date de début *";
            // dtpChantierDateDebut
            this.dtpChantierDateDebut.Location = new System.Drawing.Point(440, 196);
            this.dtpChantierDateDebut.Size = new System.Drawing.Size(380, 27);
            this.dtpChantierDateDebut.Name = "dtpChantierDateDebut";
            this.dtpChantierDateDebut.TabIndex = 3;
            this.dtpChantierDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // lblChantierDateFin
            this.lblChantierDateFin.AutoSize = true;
            this.lblChantierDateFin.Location = new System.Drawing.Point(30, 250);
            this.lblChantierDateFin.Name = "lblChantierDateFin";
            this.lblChantierDateFin.Text = "Date de fin prévue *";
            // dtpChantierDateFin
            this.dtpChantierDateFin.Location = new System.Drawing.Point(30, 272);
            this.dtpChantierDateFin.Size = new System.Drawing.Size(380, 27);
            this.dtpChantierDateFin.Name = "dtpChantierDateFin";
            this.dtpChantierDateFin.TabIndex = 4;
            this.dtpChantierDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // lblChantierBudget
            this.lblChantierBudget.AutoSize = true;
            this.lblChantierBudget.Location = new System.Drawing.Point(440, 250);
            this.lblChantierBudget.Name = "lblChantierBudget";
            this.lblChantierBudget.Text = "Budget (FCFA) *";
            // numChantierBudget
            this.numChantierBudget.Location = new System.Drawing.Point(440, 272);
            this.numChantierBudget.Size = new System.Drawing.Size(380, 27);
            this.numChantierBudget.Name = "numChantierBudget";
            this.numChantierBudget.TabIndex = 5;
            this.numChantierBudget.Maximum = new decimal(new int[] { -1, 2, 0, 0 });
            this.numChantierBudget.ThousandsSeparator = true;
            // lblClientId
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(30, 326);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Text = "Client *";
            // cboClientId
            this.cboClientId.Location = new System.Drawing.Point(30, 348);
            this.cboClientId.Size = new System.Drawing.Size(380, 27);
            this.cboClientId.Name = "cboClientId";
            this.cboClientId.TabIndex = 6;
            this.cboClientId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // FrmChantierDetail
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(850, 492);
            this.Controls.Add(this.txtChantierNom);
            this.Controls.Add(this.lblChantierNom);
            this.Controls.Add(this.txtChantierAdresse);
            this.Controls.Add(this.lblChantierAdresse);
            this.Controls.Add(this.cboChantierStatut);
            this.Controls.Add(this.lblChantierStatut);
            this.Controls.Add(this.dtpChantierDateDebut);
            this.Controls.Add(this.lblChantierDateDebut);
            this.Controls.Add(this.dtpChantierDateFin);
            this.Controls.Add(this.lblChantierDateFin);
            this.Controls.Add(this.numChantierBudget);
            this.Controls.Add(this.lblChantierBudget);
            this.Controls.Add(this.cboClientId);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChantierDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chantiers";
            this.Load += new System.EventHandler(this.FrmChantierDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numChantierBudget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox txtChantierNom;
        private System.Windows.Forms.Label lblChantierNom;
        private System.Windows.Forms.TextBox txtChantierAdresse;
        private System.Windows.Forms.Label lblChantierAdresse;
        private System.Windows.Forms.ComboBox cboChantierStatut;
        private System.Windows.Forms.Label lblChantierStatut;
        private System.Windows.Forms.DateTimePicker dtpChantierDateDebut;
        private System.Windows.Forms.Label lblChantierDateDebut;
        private System.Windows.Forms.DateTimePicker dtpChantierDateFin;
        private System.Windows.Forms.Label lblChantierDateFin;
        private System.Windows.Forms.NumericUpDown numChantierBudget;
        private System.Windows.Forms.Label lblChantierBudget;
        private System.Windows.Forms.ComboBox cboClientId;
        private System.Windows.Forms.Label lblClientId;
    }
}
