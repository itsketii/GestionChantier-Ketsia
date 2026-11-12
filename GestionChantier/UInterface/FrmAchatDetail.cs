using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmAchatDetail : Form
    {
        private readonly Achat _item;
        private readonly bool _edition;
        public Achat Resultat { get; private set; }

        public FrmAchatDetail() : this(null) { }

        public FrmAchatDetail(Achat item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Achats";
            else lblTitre.Text = "Nouveau – Achats";
        }

        private void FrmAchatDetail_Load(object sender, EventArgs e)
        {
            try
            {
            cboChantierId.DisplayMember = "Libelle"; cboChantierId.ValueMember = "ChantierId"; cboChantierId.DataSource = new ChantierDAO().ReadAll(); cboChantierId.SelectedIndex = -1;
            cboFactureId.DisplayMember = "Libelle"; cboFactureId.ValueMember = "FactureId"; cboFactureId.DataSource = new FactureAchatDAO().ReadAll(); cboFactureId.SelectedIndex = -1;
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(Achat x)
        {
            dtpAchatDate.Value = x.AchatDate < dtpAchatDate.MinDate ? dtpAchatDate.MinDate : x.AchatDate;
            txtAchatDescription.Text = x.AchatDescription;
            cboChantierId.SelectedValue = x.ChantierId;
            cboFactureId.SelectedValue = x.FactureId;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtAchatDescription.Text)) return Refuser("Le champ « Description » est obligatoire.", txtAchatDescription);
            if (cboChantierId.SelectedIndex < 0) return Refuser("Veuillez choisir : Chantier.", cboChantierId);
            if (cboFactureId.SelectedIndex < 0) return Refuser("Veuillez choisir : Facture.", cboFactureId);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new Achat();
            x.AchatDate = dtpAchatDate.Value.Date;
            x.AchatDescription = txtAchatDescription.Text.Trim();
            x.ChantierId = Convert.ToInt32(cboChantierId.SelectedValue);
            x.FactureId = Convert.ToInt32(cboFactureId.SelectedValue);
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
