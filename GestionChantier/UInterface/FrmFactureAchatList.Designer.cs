namespace GestionChantier.UInterface
{
    partial class FrmFactureAchatList
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
            this.btnFacture = new System.Windows.Forms.Button();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.btnExporter = new System.Windows.Forms.Button();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colFactureId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactureTotalTtc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFournisseurNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblTitre.Text = "Factures d'achat";
            // lblSousTitre
            this.lblSousTitre.AutoSize = true;
            this.lblSousTitre.BackColor = System.Drawing.Color.Transparent;
            this.lblSousTitre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSousTitre.ForeColor = System.Drawing.Color.FromArgb(190, 205, 225);
            this.lblSousTitre.Location = new System.Drawing.Point(26, 49);
            this.lblSousTitre.Name = "lblSousTitre";
            this.lblSousTitre.Text = "Factures reçues des fournisseurs (TVA 18 %)";
            // pnlToolbar
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.txtRecherche);
            this.pnlToolbar.Controls.Add(this.btnNouveau);
            this.pnlToolbar.Controls.Add(this.btnModifier);
            this.pnlToolbar.Controls.Add(this.btnSupprimer);
            this.pnlToolbar.Controls.Add(this.btnFacture);
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
            // btnFacture
            this.btnFacture.Location = new System.Drawing.Point(662, 13);
            this.btnFacture.Name = "btnFacture";
            this.btnFacture.Size = new System.Drawing.Size(150, 36);
            this.btnFacture.TabIndex = 4;
            this.btnFacture.Text = "Imprimer la facture";
            this.btnFacture.UseVisualStyleBackColor = false;
            this.btnFacture.Click += new System.EventHandler(this.btnFacture_Click);
            // btnImprimer
            this.btnImprimer.Location = new System.Drawing.Point(820, 13);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(112, 36);
            this.btnImprimer.TabIndex = 5;
            this.btnImprimer.Text = "Imprimer";
            this.btnImprimer.UseVisualStyleBackColor = false;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // btnExporter
            this.btnExporter.Location = new System.Drawing.Point(940, 13);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(128, 36);
            this.btnExporter.TabIndex = 6;
            this.btnExporter.Text = "Exporter CSV";
            this.btnExporter.UseVisualStyleBackColor = false;
            this.btnExporter.Click += new System.EventHandler(this.btnExporter_Click);
            // btnActualiser
            this.btnActualiser.Location = new System.Drawing.Point(1076, 13);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(112, 36);
            this.btnActualiser.TabIndex = 7;
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.UseVisualStyleBackColor = false;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // dgv
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFactureId,
                this.colFactureTotalTtc,
                this.colFactureDate,
                this.colFournisseurNom});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            // colFactureId
            this.colFactureId.DataPropertyName = "FactureId";
            this.colFactureId.HeaderText = "N°";
            this.colFactureId.Name = "colFactureId";
            this.colFactureId.ReadOnly = true;
            this.colFactureId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFactureId.FillWeight = 40F;
            // colFactureTotalTtc
            this.colFactureTotalTtc.DataPropertyName = "FactureTotalTtc";
            this.colFactureTotalTtc.HeaderText = "Total TTC (FCFA)";
            this.colFactureTotalTtc.Name = "colFactureTotalTtc";
            this.colFactureTotalTtc.ReadOnly = true;
            this.colFactureTotalTtc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFactureTotalTtc.FillWeight = 80F;
            var st1 = new System.Windows.Forms.DataGridViewCellStyle();
            st1.Format = "N0";
            st1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colFactureTotalTtc.DefaultCellStyle = st1;
            // colFactureDate
            this.colFactureDate.DataPropertyName = "FactureDate";
            this.colFactureDate.HeaderText = "Date de la facture";
            this.colFactureDate.Name = "colFactureDate";
            this.colFactureDate.ReadOnly = true;
            this.colFactureDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFactureDate.FillWeight = 70F;
            var st2 = new System.Windows.Forms.DataGridViewCellStyle();
            st2.Format = "dd/MM/yyyy";
            this.colFactureDate.DefaultCellStyle = st2;
            // colFournisseurNom
            this.colFournisseurNom.DataPropertyName = "FournisseurNom";
            this.colFournisseurNom.HeaderText = "Fournisseur";
            this.colFournisseurNom.Name = "colFournisseurNom";
            this.colFournisseurNom.ReadOnly = true;
            this.colFournisseurNom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFournisseurNom.FillWeight = 110F;
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
            // FrmFactureAchatList
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmFactureAchatList";
            this.Text = "Factures d'achat";
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
        private System.Windows.Forms.Button btnFacture;
        private System.Windows.Forms.Button btnImprimer;
        private System.Windows.Forms.Button btnExporter;
        private System.Windows.Forms.Button btnActualiser;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactureId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactureTotalTtc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFournisseurNom;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblCompte;
    }
}
