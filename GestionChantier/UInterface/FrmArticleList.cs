using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmArticleList : Form
    {
        private readonly ArticleDAO _dao = new ArticleDAO();
        private List<Article> _donnees = new List<Article>();
        private string _tri;
        private bool _asc = true;

        public FrmArticleList()
        {
            InitializeComponent();
            Initialiser();
        }

        private void Initialiser()
        {
            UiHelper.StyleListe(pnlHeader, dgv, pnlToolbar, pnlFooter);
            foreach (var b in new Button[] { btnNouveau, btnModifier, btnSupprimer, btnImprimer, btnExporter, btnActualiser })
                UiHelper.StyleBouton(b, b == btnNouveau);
            UiHelper.RoleGuard(btnNouveau, btnModifier, btnSupprimer);
            Load += (s, e) => Charger();
        }

        private void Charger()
        {
            try { _donnees = _dao.ReadAll(); Filtrer(); }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }

        private static string Texte(Article x)
        {
            return string.Join(" ", new object[] { x.ArticleId, x.ArticleNom, x.ArticleUnite, x.ArticlePrixUnitaire }).ToLowerInvariant();
        }

        private void Filtrer()
        {
            string q = txtRecherche.Text.Trim().ToLowerInvariant();
            var liste = string.IsNullOrEmpty(q) ? _donnees : _donnees.Where(x => Texte(x).Contains(q)).ToList();
            dgv.DataSource = new BindingList<Article>(liste);
            lblCompte.Text = liste.Count + (liste.Count > 1 ? " enregistrements" : " enregistrement")
                             + (liste.Count != _donnees.Count ? " (sur " + _donnees.Count + ")" : "");
        }

        private Article Selection()
        {
            var sel = dgv.CurrentRow == null ? null : dgv.CurrentRow.DataBoundItem as Article;
            if (sel == null) UiHelper.Avertir("Sélectionnez d'abord une ligne dans la liste.");
            return sel;
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e) { Filtrer(); }

        private void dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string p = dgv.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(p)) return;
            _asc = (_tri == p) ? !_asc : true;
            _tri = p;
            var prop = typeof(Article).GetProperty(p);
            _donnees = (_asc ? _donnees.OrderBy(x => prop.GetValue(x, null)) : _donnees.OrderByDescending(x => prop.GetValue(x, null))).ToList();
            Filtrer();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && btnModifier.Enabled) btnModifier_Click(sender, e);
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            using (var f = new FrmArticleDetail()) {
                if (f.ShowDialog(this) != DialogResult.OK) return;
                try { _dao.Create(f.Resultat); Charger(); }
                catch (Exception ex) { UiHelper.Erreur(ex); }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            var sel = Selection();
            if (sel == null) return;
            using (var f = new FrmArticleDetail(sel))
            {
                if (f.ShowDialog(this) != DialogResult.OK) return;
                try { _dao.Update(f.Resultat); Charger(); }
                catch (Exception ex) { UiHelper.Erreur(ex); }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            var sel = Selection();
            if (sel == null) return;
            if (!UiHelper.Confirmer("Voulez-vous vraiment supprimer cet enregistrement ?")) return;
            try { _dao.Delete(sel.ArticleId); Charger(); }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            PrintHelper.ImprimerGrille(dgv, "Articles");
        }

        private void btnExporter_Click(object sender, EventArgs e)
        {
            CsvExporter.Exporter(dgv, "article");
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            Charger();
        }
    }
}
