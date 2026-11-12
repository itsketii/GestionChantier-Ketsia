using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmFactureAchatDetail : Form
    {
        private readonly FactureAchat _item;
        private readonly bool _edition;
        public FactureAchat Resultat { get; private set; }

        public FrmFactureAchatDetail() : this(null) { }

        public FrmFactureAchatDetail(FactureAchat item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Factures d'achat";
            else lblTitre.Text = "Nouveau – Factures d'achat";
        }

        private void FrmFactureAchatDetail_Load(object sender, EventArgs e)
        {
            try
            {
            cboFournisseurId.DisplayMember = "Libelle"; cboFournisseurId.ValueMember = "FournisseurId"; cboFournisseurId.DataSource = new FournisseurDAO().ReadAll(); cboFournisseurId.SelectedIndex = -1;
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(FactureAchat x)
        {
            numFactureTotalTtc.Value = Math.Min(numFactureTotalTtc.Maximum, Math.Max(numFactureTotalTtc.Minimum, Convert.ToDecimal(x.FactureTotalTtc)));
            dtpFactureDate.Value = x.FactureDate < dtpFactureDate.MinDate ? dtpFactureDate.MinDate : x.FactureDate;
            cboFournisseurId.SelectedValue = x.FournisseurId;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (cboFournisseurId.SelectedIndex < 0) return Refuser("Veuillez choisir : Fournisseur.", cboFournisseurId);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new FactureAchat();
            x.FactureTotalTtc = numFactureTotalTtc.Value;
            x.FactureDate = dtpFactureDate.Value.Date;
            x.FournisseurId = Convert.ToInt32(cboFournisseurId.SelectedValue);
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
