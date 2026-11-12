using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmServiceTravailDetail : Form
    {
        private readonly ServiceTravail _item;
        private readonly bool _edition;
        public ServiceTravail Resultat { get; private set; }

        public FrmServiceTravailDetail() : this(null) { }

        public FrmServiceTravailDetail(ServiceTravail item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Services de travail";
            else lblTitre.Text = "Nouveau – Services de travail";
        }

        private void FrmServiceTravailDetail_Load(object sender, EventArgs e)
        {
            try
            {
            cboPhaseId.DisplayMember = "Libelle"; cboPhaseId.ValueMember = "PhaseId"; cboPhaseId.DataSource = new PhaseDAO().ReadAll(); cboPhaseId.SelectedIndex = -1;
            cboIntervenantId.DisplayMember = "Libelle"; cboIntervenantId.ValueMember = "IntervenantId"; cboIntervenantId.DataSource = new IntervenantDAO().ReadAll(); cboIntervenantId.SelectedIndex = -1;
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(ServiceTravail x)
        {
            txtSerTravNom.Text = x.SerTravNom;
            { int i = cboType.FindStringExact(x.Type); if (i < 0 && !string.IsNullOrEmpty(x.Type)) i = cboType.Items.Add(x.Type); cboType.SelectedIndex = i; }
            cboPhaseId.SelectedValue = x.PhaseId;
            cboIntervenantId.SelectedValue = x.IntervenantId;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtSerTravNom.Text)) return Refuser("Le champ « Nom du service » est obligatoire.", txtSerTravNom);
            if (cboType.SelectedIndex < 0) return Refuser("Veuillez choisir : Type.", cboType);
            if (cboPhaseId.SelectedIndex < 0) return Refuser("Veuillez choisir : Phase.", cboPhaseId);
            if (cboIntervenantId.SelectedIndex < 0) return Refuser("Veuillez choisir : Intervenant.", cboIntervenantId);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new ServiceTravail();
            x.SerTravNom = txtSerTravNom.Text.Trim();
            x.Type = Convert.ToString(cboType.SelectedItem);
            x.PhaseId = Convert.ToInt32(cboPhaseId.SelectedValue);
            x.IntervenantId = Convert.ToInt32(cboIntervenantId.SelectedValue);
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
