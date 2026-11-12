using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmChantierList : Form
    {
        private readonly ChantierDAO _dao = new ChantierDAO();
        private List<Chantier> _donnees = new List<Chantier>();
        private string _tri;
        private bool _asc = true;

        public FrmChantierList()
        {
            InitializeComponent();
            Initialiser();
        }

        private void Initialiser()
        {
            UiHelper.StyleListe(pnlHeader, dgv, pnlToolbar, pnlFooter);
            foreach (var b in new Button[] { btnNouveau, btnModifier, btnSupprimer, btnFiche, btnImprimer, btnExporter, btnActualiser })
                UiHelper.StyleBouton(b, b == btnNouveau);
            UiHelper.RoleGuard(btnNouveau, btnModifier, btnSupprimer);
            Load += (s, e) => Charger();
        }

        private void Charger()
        {
            try { _donnees = _dao.ReadAll(); Filtrer(); }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }

        private static string Texte(Chantier x)
        {
            return string.Join(" ", new object[] { x.ChantierId, x.ChantierNom, x.ChantierAdresse, x.ChantierStatut, x.ChantierDateDebut, x.ChantierDateFin, x.ChantierBudget, x.ClientNom, x.DepenseHt }).ToLowerInvariant();
        }

        private void Filtrer()
        {
            string q = txtRecherche.Text.Trim().ToLowerInvariant();
            var liste = string.IsNullOrEmpty(q) ? _donnees : _donnees.Where(x => Texte(x).Contains(q)).ToList();
            dgv.DataSource = new BindingList<Chantier>(liste);
            lblCompte.Text = liste.Count + (liste.Count > 1 ? " enregistrements" : " enregistrement")
                             + (liste.Count != _donnees.Count ? " (sur " + _donnees.Count + ")" : "");
        }

        private Chantier Selection()
        {
            var sel = dgv.CurrentRow == null ? null : dgv.CurrentRow.DataBoundItem as Chantier;
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
            var prop = typeof(Chantier).GetProperty(p);
            _donnees = (_asc ? _donnees.OrderBy(x => prop.GetValue(x, null)) : _donnees.OrderByDescending(x => prop.GetValue(x, null))).ToList();
            Filtrer();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && btnModifier.Enabled) btnModifier_Click(sender, e);
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            using (var f = new FrmChantierDetail()) {
                if (f.ShowDialog(this) != DialogResult.OK) return;
                try { _dao.Create(f.Resultat); Charger(); }
                catch (Exception ex) { UiHelper.Erreur(ex); }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            var sel = Selection();
            if (sel == null) return;
            using (var f = new FrmChantierDetail(sel))
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
            if (!UiHelper.Confirmer("Voulez-vous vraiment supprimer le chantier ?")) return;
            try { _dao.Delete(sel.ChantierId); Charger(); }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }

        private void btnFiche_Click(object sender, EventArgs e)
        {
            var sel = Selection();
            if (sel == null) return;
            try { PrintHelper.ImprimerFicheChantier(sel.ChantierId); }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            PrintHelper.ImprimerGrille(dgv, "Chantiers");
        }

        private void btnExporter_Click(object sender, EventArgs e)
        {
            CsvExporter.Exporter(dgv, "chantier");
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            Charger();
        }
    }
}
