using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmReglementDetail : Form
    {
        private readonly Reglement _item;
        private readonly bool _edition;
        public Reglement Resultat { get; private set; }

        public FrmReglementDetail() : this(null) { }

        public FrmReglementDetail(Reglement item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Règlements";
            else lblTitre.Text = "Nouveau – Règlements";
        }

        private void FrmReglementDetail_Load(object sender, EventArgs e)
        {
            try
            {
            cboAchatId.DisplayMember = "Libelle"; cboAchatId.ValueMember = "AchatId"; cboAchatId.DataSource = new AchatDAO().ReadAll(); cboAchatId.SelectedIndex = -1;
            cboSerTravId.DisplayMember = "Libelle"; cboSerTravId.ValueMember = "SerTravId"; cboSerTravId.DataSource = new ServiceTravailDAO().ReadAll(); cboSerTravId.SelectedIndex = -1;
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            cboAchatId.SelectionChangeCommitted += (s, ev) => cboSerTravId.SelectedIndex = -1;
            cboSerTravId.SelectionChangeCommitted += (s, ev) => cboAchatId.SelectedIndex = -1;
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(Reglement x)
        {
            dtpReglementDate.Value = x.ReglementDate < dtpReglementDate.MinDate ? dtpReglementDate.MinDate : x.ReglementDate;
            numReglementMontant.Value = Math.Min(numReglementMontant.Maximum, Math.Max(numReglementMontant.Minimum, Convert.ToDecimal(x.ReglementMontant)));
            if (x.AchatId.HasValue) cboAchatId.SelectedValue = x.AchatId.Value; else cboAchatId.SelectedIndex = -1;
            if (x.SerTravId.HasValue) cboSerTravId.SelectedValue = x.SerTravId.Value; else cboSerTravId.SelectedIndex = -1;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if ((cboAchatId.SelectedIndex < 0) == (cboSerTravId.SelectedIndex < 0)) return Refuser("Un règlement porte soit sur un achat, soit sur un service de travail (un seul des deux).", cboAchatId);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new Reglement();
            x.ReglementDate = dtpReglementDate.Value.Date;
            x.ReglementMontant = numReglementMontant.Value;
            x.AchatId = cboAchatId.SelectedIndex < 0 ? (int?)null : Convert.ToInt32(cboAchatId.SelectedValue);
            x.SerTravId = cboSerTravId.SelectedIndex < 0 ? (int?)null : Convert.ToInt32(cboSerTravId.SelectedValue);
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
