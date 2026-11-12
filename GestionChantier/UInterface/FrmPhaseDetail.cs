using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmPhaseDetail : Form
    {
        private readonly Phase _item;
        private readonly bool _edition;
        public Phase Resultat { get; private set; }

        public FrmPhaseDetail() : this(null) { }

        public FrmPhaseDetail(Phase item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Phases";
            else lblTitre.Text = "Nouveau – Phases";
        }

        private void FrmPhaseDetail_Load(object sender, EventArgs e)
        {
            try
            {
            cboChantierId.DisplayMember = "Libelle"; cboChantierId.ValueMember = "ChantierId"; cboChantierId.DataSource = new ChantierDAO().ReadAll(); cboChantierId.SelectedIndex = -1;
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(Phase x)
        {
            txtPhaseLibelle.Text = x.PhaseLibelle;
            numPhaseOrdre.Value = Math.Min(numPhaseOrdre.Maximum, Math.Max(numPhaseOrdre.Minimum, Convert.ToDecimal(x.PhaseOrdre)));
            cboChantierId.SelectedValue = x.ChantierId;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtPhaseLibelle.Text)) return Refuser("Le champ « Libellé de la phase » est obligatoire.", txtPhaseLibelle);
            if (cboChantierId.SelectedIndex < 0) return Refuser("Veuillez choisir : Chantier.", cboChantierId);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new Phase();
            x.PhaseLibelle = txtPhaseLibelle.Text.Trim();
            x.PhaseOrdre = (int)numPhaseOrdre.Value;
            x.ChantierId = Convert.ToInt32(cboChantierId.SelectedValue);
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
