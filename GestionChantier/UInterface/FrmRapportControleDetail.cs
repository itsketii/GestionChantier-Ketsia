using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmRapportControleDetail : Form
    {
        private readonly RapportControle _item;
        private readonly bool _edition;
        public RapportControle Resultat { get; private set; }

        public FrmRapportControleDetail() : this(null) { }

        public FrmRapportControleDetail(RapportControle item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Rapports de contrôle";
            else lblTitre.Text = "Nouveau – Rapports de contrôle";
        }

        private void FrmRapportControleDetail_Load(object sender, EventArgs e)
        {
            try
            {
            cboControleId.DisplayMember = "Libelle"; cboControleId.ValueMember = "ControleId"; cboControleId.DataSource = new ControleQualiteDAO().ReadAll(); cboControleId.SelectedIndex = -1;
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(RapportControle x)
        {
            dtpRapportDate.Value = x.RapportDate < dtpRapportDate.MinDate ? dtpRapportDate.MinDate : x.RapportDate;
            txtRapportRecommandation.Text = x.RapportRecommandation;
            cboControleId.SelectedValue = x.ControleId;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtRapportRecommandation.Text)) return Refuser("Le champ « Recommandation » est obligatoire.", txtRapportRecommandation);
            if (cboControleId.SelectedIndex < 0) return Refuser("Veuillez choisir : Contrôle.", cboControleId);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new RapportControle();
            x.RapportDate = dtpRapportDate.Value.Date;
            x.RapportRecommandation = txtRapportRecommandation.Text.Trim();
            x.ControleId = Convert.ToInt32(cboControleId.SelectedValue);
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
