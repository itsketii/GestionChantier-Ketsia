using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmArticleDetail : Form
    {
        private readonly Article _item;
        private readonly bool _edition;
        public Article Resultat { get; private set; }

        public FrmArticleDetail() : this(null) { }

        public FrmArticleDetail(Article item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Articles";
            else lblTitre.Text = "Nouveau – Articles";
        }

        private void FrmArticleDetail_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(Article x)
        {
            txtArticleNom.Text = x.ArticleNom;
            txtArticleUnite.Text = x.ArticleUnite;
            numArticlePrixUnitaire.Value = Math.Min(numArticlePrixUnitaire.Maximum, Math.Max(numArticlePrixUnitaire.Minimum, Convert.ToDecimal(x.ArticlePrixUnitaire)));
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtArticleNom.Text)) return Refuser("Le champ « Désignation » est obligatoire.", txtArticleNom);
            if (string.IsNullOrWhiteSpace(txtArticleUnite.Text)) return Refuser("Le champ « Unité » est obligatoire.", txtArticleUnite);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new Article();
            x.ArticleNom = txtArticleNom.Text.Trim();
            x.ArticleUnite = txtArticleUnite.Text.Trim();
            x.ArticlePrixUnitaire = numArticlePrixUnitaire.Value;
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
