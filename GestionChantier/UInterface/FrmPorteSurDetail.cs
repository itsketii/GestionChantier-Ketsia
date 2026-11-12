using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmPorteSurDetail : Form
    {
        private readonly PorteSur _item;
        private readonly bool _edition;
        public PorteSur Resultat { get; private set; }
        public int? AchatPreset { get; set; }

        public FrmPorteSurDetail() : this(null) { }

        public FrmPorteSurDetail(PorteSur item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Lignes d'achat";
            else lblTitre.Text = "Nouveau – Lignes d'achat";
        }

        private void FrmPorteSurDetail_Load(object sender, EventArgs e)
        {
            try
            {
            cboAchatId.DisplayMember = "Libelle"; cboAchatId.ValueMember = "AchatId"; cboAchatId.DataSource = new AchatDAO().ReadAll(); cboAchatId.SelectedIndex = -1;
            cboArticleId.DisplayMember = "Libelle"; cboArticleId.ValueMember = "ArticleId"; cboArticleId.DataSource = new ArticleDAO().ReadAll(); cboArticleId.SelectedIndex = -1;
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            cboAchatId.Enabled = false;
            cboArticleId.Enabled = false;
            }
            if (AchatPreset.HasValue && _item == null) { cboAchatId.SelectedValue = AchatPreset.Value; cboAchatId.Enabled = false; }
        }

        private void Remplir(PorteSur x)
        {
            cboAchatId.SelectedValue = x.AchatId;
            cboArticleId.SelectedValue = x.ArticleId;
            numQuantite.Value = Math.Min(numQuantite.Maximum, Math.Max(numQuantite.Minimum, Convert.ToDecimal(x.Quantite)));
            numPrixAchat.Value = Math.Min(numPrixAchat.Maximum, Math.Max(numPrixAchat.Minimum, Convert.ToDecimal(x.PrixAchat)));
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (cboAchatId.SelectedIndex < 0) return Refuser("Veuillez choisir : Achat.", cboAchatId);
            if (cboArticleId.SelectedIndex < 0) return Refuser("Veuillez choisir : Article.", cboArticleId);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new PorteSur();
            x.AchatId = Convert.ToInt32(cboAchatId.SelectedValue);
            x.ArticleId = Convert.ToInt32(cboArticleId.SelectedValue);
            x.Quantite = (int)numQuantite.Value;
            x.PrixAchat = numPrixAchat.Value;
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
