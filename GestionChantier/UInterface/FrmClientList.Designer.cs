namespace GestionChantier.UInterface
{
    partial class FrmClientList
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
            this.lblSousTitre = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.btnExporter = new System.Windows.Forms.Button();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblCompte = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblSousTitre);
            this.pnlHeader.Controls.Add(this.lblTitre);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 84);
            this.pnlHeader.TabIndex = 3;
            // lblTitre
            this.lblTitre.AutoSize = true;
            this.lblTitre.BackColor = System.Drawing.Color.Transparent;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Location = new System.Drawing.Point(24, 10);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Text = "Clients";
            // lblSousTitre
            this.lblSousTitre.AutoSize = true;
            this.lblSousTitre.BackColor = System.Drawing.Color.Transparent;
            this.lblSousTitre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSousTitre.ForeColor = System.Drawing.Color.FromArgb(190, 205, 225);
            this.lblSousTitre.Location = new System.Drawing.Point(26, 49);
            this.lblSousTitre.Name = "lblSousTitre";
            this.lblSousTitre.Text = "Maîtres d'ouvrage et clients de l'entreprise";
            // pnlToolbar
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.txtRecherche);
            this.pnlToolbar.Controls.Add(this.btnNouveau);
            this.pnlToolbar.Controls.Add(this.btnModifier);
            this.pnlToolbar.Controls.Add(this.btnSupprimer);
            this.pnlToolbar.Controls.Add(this.btnImprimer);
            this.pnlToolbar.Controls.Add(this.btnExporter);
            this.pnlToolbar.Controls.Add(this.btnActualiser);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1100, 64);
            this.pnlToolbar.TabIndex = 2;
            // txtRecherche
            this.txtRecherche.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtRecherche.Location = new System.Drawing.Point(24, 17);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.PlaceholderText = "Rechercher...";
            this.txtRecherche.Size = new System.Drawing.Size(250, 26);
            this.txtRecherche.TabIndex = 0;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            // btnNouveau
            this.btnNouveau.Location = new System.Drawing.Point(296, 13);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(112, 36);
            this.btnNouveau.TabIndex = 1;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = false;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // btnModifier
            this.btnModifier.Location = new System.Drawing.Point(416, 13);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(112, 36);
            this.btnModifier.TabIndex = 2;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // btnSupprimer
            this.btnSupprimer.Location = new System.Drawing.Point(536, 13);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(118, 36);
            this.btnSupprimer.TabIndex = 3;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // btnImprimer
            this.btnImprimer.Location = new System.Drawing.Point(662, 13);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(112, 36);
            this.btnImprimer.TabIndex = 4;
            this.btnImprimer.Text = "Imprimer";
            this.btnImprimer.UseVisualStyleBackColor = false;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // btnExporter
            this.btnExporter.Location = new System.Drawing.Point(782, 13);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(128, 36);
            this.btnExporter.TabIndex = 5;
            this.btnExporter.Text = "Exporter CSV";
            this.btnExporter.UseVisualStyleBackColor = false;
            this.btnExporter.Click += new System.EventHandler(this.btnExporter_Click);
            // btnActualiser
            this.btnActualiser.Location = new System.Drawing.Point(918, 13);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(112, 36);
            this.btnActualiser.TabIndex = 6;
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.UseVisualStyleBackColor = false;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // dgv
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colClientId,
                this.colClientNom,
                this.colClientTelephone,
                this.colClientEmail});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            // colClientId
            this.colClientId.DataPropertyName = "ClientId";
            this.colClientId.HeaderText = "N°";
            this.colClientId.Name = "colClientId";
            this.colClientId.ReadOnly = true;
            this.colClientId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClientId.FillWeight = 40F;
            // colClientNom
            this.colClientNom.DataPropertyName = "ClientNom";
            this.colClientNom.HeaderText = "Nom / Raison sociale";
            this.colClientNom.Name = "colClientNom";
            this.colClientNom.ReadOnly = true;
            this.colClientNom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClientNom.FillWeight = 100F;
            // colClientTelephone
            this.colClientTelephone.DataPropertyName = "ClientTelephone";
            this.colClientTelephone.HeaderText = "Téléphone";
            this.colClientTelephone.Name = "colClientTelephone";
            this.colClientTelephone.ReadOnly = true;
            this.colClientTelephone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClientTelephone.FillWeight = 100F;
            // colClientEmail
            this.colClientEmail.DataPropertyName = "ClientEmail";
            this.colClientEmail.HeaderText = "Email";
            this.colClientEmail.Name = "colClientEmail";
            this.colClientEmail.ReadOnly = true;
            this.colClientEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClientEmail.FillWeight = 100F;
            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblCompte);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1100, 34);
            this.pnlFooter.TabIndex = 1;
            // lblCompte
            this.lblCompte.AutoSize = true;
            this.lblCompte.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCompte.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCompte.Location = new System.Drawing.Point(24, 8);
            this.lblCompte.Name = "lblCompte";
            this.lblCompte.Text = "0 enregistrement";
            // FrmClientList
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmClientList";
            this.Text = "Clients";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblSousTitre;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnImprimer;
        private System.Windows.Forms.Button btnExporter;
        private System.Windows.Forms.Button btnActualiser;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientEmail;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblCompte;
    }
}
