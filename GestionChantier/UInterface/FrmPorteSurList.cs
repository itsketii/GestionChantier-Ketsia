using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmPorteSurList : Form
    {
        private readonly PorteSurDAO _dao = new PorteSurDAO();
        private List<PorteSur> _donnees = new List<PorteSur>();
        private string _tri;
        private bool _asc = true;
        private readonly int? _achatId;

        public FrmPorteSurList() : this(null) { }

        public FrmPorteSurList(int? achatId)
        {
            _achatId = achatId;
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
            try { _donnees = _achatId.HasValue ? _dao.ReadByAchat(_achatId.Value) : _dao.ReadAll(); Filtrer(); }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }

        private static string Texte(PorteSur x)
        {
            return string.Join(" ", new object[] { x.AchatLibelle, x.ArticleNom, x.Quantite, x.PrixAchat, x.ArticleUnite, x.SousTotal }).ToLowerInvariant();
        }

        private void Filtrer()
        {
            string q = txtRecherche.Text.Trim().ToLowerInvariant();
            var liste = string.IsNullOrEmpty(q) ? _donnees : _donnees.Where(x => Texte(x).Contains(q)).ToList();
            dgv.DataSource = new BindingList<PorteSur>(liste);
            lblCompte.Text = liste.Count + (liste.Count > 1 ? " enregistrements" : " enregistrement")
                             + (liste.Count != _donnees.Count ? " (sur " + _donnees.Count + ")" : "");
        }

        private PorteSur Selection()
        {
            var sel = dgv.CurrentRow == null ? null : dgv.CurrentRow.DataBoundItem as PorteSur;
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
            var prop = typeof(PorteSur).GetProperty(p);
            _donnees = (_asc ? _donnees.OrderBy(x => prop.GetValue(x, null)) : _donnees.OrderByDescending(x => prop.GetValue(x, null))).ToList();
            Filtrer();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && btnModifier.Enabled) btnModifier_Click(sender, e);
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            using (var f = new FrmPorteSurDetail()) {
                f.AchatPreset = _achatId;
                if (f.ShowDialog(this) != DialogResult.OK) return;
                try { _dao.Create(f.Resultat); Charger(); }
                catch (Exception ex) { UiHelper.Erreur(ex); }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            var sel = Selection();
            if (sel == null) return;
            using (var f = new FrmPorteSurDetail(sel))
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
            try { _dao.Delete(sel.AchatId, sel.ArticleId); Charger(); }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            PrintHelper.ImprimerGrille(dgv, "Lignes d'achat");
        }

        private void btnExporter_Click(object sender, EventArgs e)
        {
            CsvExporter.Exporter(dgv, "porte_sur");
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            Charger();
        }
    }
}
