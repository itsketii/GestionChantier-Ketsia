using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using GestionChantier.DataAccess;

namespace GestionChantier.UInterface
{
    /// <summary>
    /// Petit moteur de rapport imprimable : titres, lignes clé/valeur, tableaux, totaux.
    /// L'aperçu avant impression permet aussi d'imprimer vers "Microsoft Print to PDF".
    /// </summary>
    public class Rapport
    {
        private class Element { public float H; public Action<Graphics, float, float, float> Dessiner; }

        private readonly List<Element> _elements = new List<Element>();
        private int _index;
        private int _page;
        private const float LH = 24f;

        public string Titre { get; set; }
        public string SousTitre { get; set; }
        public bool Paysage { get; set; }

        public void Section(string texte)
        {
            _elements.Add(new Element
            {
                H = 44,
                Dessiner = (g, x, y, w) =>
                {
                    using (var f = Theme.PoliceGras(12F))
                    using (var b = new SolidBrush(Theme.Navy))
                        g.DrawString(texte, f, b, x, y + 14);
                    using (var p = new Pen(Theme.Orange, 2F))
                        g.DrawLine(p, x, y + 40, x + w, y + 40);
                }
            });
        }

        public void Ligne(string cle, string valeur)
        {
            _elements.Add(new Element
            {
                H = LH,
                Dessiner = (g, x, y, w) =>
                {
                    using (var f = Theme.Police(10F))
                    using (var fb = Theme.Police(10F, FontStyle.Bold))
                    using (var b = new SolidBrush(Theme.Muted))
                    using (var b2 = new SolidBrush(Theme.Texte))
                    {
                        g.DrawString(cle, f, b, x, y + 3);
                        g.DrawString(valeur, fb, b2, x + 190, y + 3);
                    }
                }
            });
        }

        public void Texte(string texte)
        {
            _elements.Add(new Element
            {
                H = LH,
                Dessiner = (g, x, y, w) =>
                {
                    using (var f = Theme.Police(10F))
                    using (var b = new SolidBrush(Theme.Texte))
                        g.DrawString(texte, f, b, x, y + 3);
                }
            });
        }

        public void Espace(float h)
        {
            _elements.Add(new Element { H = h, Dessiner = (g, x, y, w) => { } });
        }

        public void Total(string libelle, string valeur)
        {
            _elements.Add(new Element
            {
                H = 30,
                Dessiner = (g, x, y, w) =>
                {
                    var r = new RectangleF(x + w - 360, y + 2, 360, 26);
                    using (var br = new SolidBrush(Theme.OrangeSoft)) g.FillRectangle(br, r);
                    using (var f = Theme.PoliceGras(10.5F))
                    using (var b = new SolidBrush(Theme.Navy))
                    {
                        g.DrawString(libelle, f, b, r.X + 10, r.Y + 4);
                        var sf = new StringFormat { Alignment = StringAlignment.Far };
                        g.DrawString(valeur, f, b, new RectangleF(r.X, r.Y + 4, r.Width - 10, 22), sf);
                    }
                }
            });
        }

        public void Tableau(string[] entetes, float[] poids, bool[] droite, List<string[]> lignes)
        {
            Action<Graphics, float, float, float, string[], bool, int> ligne = (g, x, y, w, vals, entete, n) =>
            {
                float total = 0; foreach (float p in poids) total += p;
                var fond = entete ? Theme.Navy : (n % 2 == 0 ? Color.White : Color.FromArgb(246, 248, 252));
                using (var br = new SolidBrush(fond)) g.FillRectangle(br, x, y, w, entete ? 28 : 24);
                float cx = x;
                using (var f = entete ? Theme.PoliceGras(9.5F) : Theme.Police(9.5F))
                using (var b = new SolidBrush(entete ? Color.White : Theme.Texte))
                {
                    for (int i = 0; i < vals.Length; i++)
                    {
                        float cw = w * poids[i] / total;
                        var sf = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap, LineAlignment = StringAlignment.Center };
                        if (droite != null && droite[i]) sf.Alignment = StringAlignment.Far;
                        g.DrawString(vals[i], f, b, new RectangleF(cx + 6, y, cw - 12, entete ? 28 : 24), sf);
                        cx += cw;
                    }
                }
                if (!entete) using (var p = new Pen(Theme.Bordure)) g.DrawLine(p, x, y + 24, x + w, y + 24);
            };
            _elements.Add(new Element { H = 28, Dessiner = (g, x, y, w) => ligne(g, x, y, w, entetes, true, 0) });
            for (int k = 0; k < lignes.Count; k++)
            {
                int n = k; string[] v = lignes[k];
                _elements.Add(new Element { H = 24, Dessiner = (g, x, y, w) => ligne(g, x, y, w, v, false, n) });
            }
        }

        public void Apercu()
        {
            var doc = new PrintDocument();
            doc.DocumentName = Titre;
            doc.DefaultPageSettings.Landscape = Paysage;
            doc.DefaultPageSettings.Margins = new Margins(50, 50, 40, 60);
            doc.BeginPrint += (s, e) => { _index = 0; _page = 0; };
            doc.PrintPage += ImprimerPage;
            using (var dlg = new PrintPreviewDialog())
            {
                dlg.Document = doc;
                dlg.Width = 1100;
                dlg.Height = 800;
                dlg.StartPosition = FormStartPosition.CenterScreen;
                dlg.Text = "Aperçu – " + Titre;
                dlg.ShowDialog();
            }
        }

        private void ImprimerPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            Rectangle m = e.MarginBounds;
            float x = m.Left, w = m.Width, y = m.Top;

            // En-tête : bandeau bleu nuit + logo + titre
            using (var br = new SolidBrush(Theme.Navy)) g.FillRectangle(br, x, y, w, 64);
            using (var br = new SolidBrush(Theme.Orange)) g.FillRectangle(br, x, y + 64, w, 4);
            var logo = Assets.Image("logo.png");
            if (logo != null) g.DrawImage(logo, x + 10, y + 8, 48, 48);
            using (var f = Theme.PoliceGras(15F)) g.DrawString("GESTION CHANTIER", f, Brushes.White, x + 68, y + 8);
            using (var f = Theme.Police(9F)) g.DrawString("Gestion de chantiers BTP", f, new SolidBrush(Color.FromArgb(190, 205, 225)), x + 70, y + 38);
            using (var f = Theme.Police(9F))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Far };
                g.DrawString("Édité le " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), f, Brushes.White, new RectangleF(x, y + 12, w - 12, 20), sf);
                g.DrawString(Session.Courant == null ? "" : "Par " + Session.Courant.UtilisateurNomComplet, f, Brushes.White, new RectangleF(x, y + 34, w - 12, 20), sf);
            }
            y += 84;
            if (_page == 0)
            {
                using (var f = Theme.PoliceGras(18F)) g.DrawString(Titre, f, new SolidBrush(Theme.Navy), x, y);
                y += 34;
                if (!string.IsNullOrEmpty(SousTitre))
                {
                    using (var f = Theme.Police(10F)) g.DrawString(SousTitre, f, new SolidBrush(Theme.Muted), x, y);
                    y += 26;
                }
                y += 6;
            }
            float bas = m.Bottom - 10;
            while (_index < _elements.Count && y + _elements[_index].H <= bas)
            {
                _elements[_index].Dessiner(g, x, y, w);
                y += _elements[_index].H;
                _index++;
            }
            _page++;
            using (var f = Theme.Police(8.5F))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("GestionChantier – Page " + _page, f, new SolidBrush(Theme.Muted), new RectangleF(x, m.Bottom + 8, w, 20), sf);
            }
            e.HasMorePages = _index < _elements.Count;
        }
    }

    /// <summary>Raccourcis d'impression : grilles, fiche chantier, facture.</summary>
    public static class PrintHelper
    {
        public static void ImprimerGrille(DataGridView dgv, string titre)
        {
            if (dgv.Rows.Count == 0) { UiHelper.Avertir("Il n'y a rien à imprimer."); return; }
            var cols = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn c in dgv.Columns) if (c.Visible) cols.Add(c);
            cols.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));
            var r = new Rapport { Titre = titre, Paysage = cols.Count > 5, SousTitre = dgv.Rows.Count + " enregistrement(s)" };
            var entetes = new string[cols.Count];
            var poids = new float[cols.Count];
            var droite = new bool[cols.Count];
            for (int i = 0; i < cols.Count; i++)
            {
                entetes[i] = cols[i].HeaderText;
                poids[i] = Math.Max(30f, cols[i].FillWeight);
                droite[i] = cols[i].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight;
            }
            var lignes = new List<string[]>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var v = new string[cols.Count];
                for (int i = 0; i < cols.Count; i++)
                {
                    object val = row.Cells[cols[i].Index].FormattedValue;
                    v[i] = val is bool ? ((bool)val ? "Oui" : "Non") : Convert.ToString(val);
                }
                lignes.Add(v);
            }
            r.Tableau(entetes, poids, droite, lignes);
            r.Apercu();
        }

        public static void ImprimerFicheChantier(int id)
        {
            var dao = new StatsDAO();
            DataTable info = dao.InfoChantier(id);
            if (info.Rows.Count == 0) { UiHelper.Avertir("Chantier introuvable."); return; }
            DataRow c = info.Rows[0];
            decimal budget = Convert.ToDecimal(c["chantier_budget"]);
            var achats = dao.AchatsChantier(id);
            decimal depense = 0m;
            foreach (DataRow a in achats.Rows) depense += Convert.ToDecimal(a["total_ht"]);
            decimal reglements = dao.ReglementsChantier(id);

            var r = new Rapport { Titre = "Fiche chantier", SousTitre = Convert.ToString(c["chantier_nom"]) };
            r.Section("Informations générales");
            r.Ligne("Chantier", Convert.ToString(c["chantier_nom"]));
            r.Ligne("Adresse", Convert.ToString(c["chantier_adresse"]));
            r.Ligne("Statut", Convert.ToString(c["chantier_statut"]));
            r.Ligne("Période", Convert.ToDateTime(c["chantier_date_debut"]).ToString("dd/MM/yyyy") + " au " + Convert.ToDateTime(c["chantier_date_fin"]).ToString("dd/MM/yyyy"));
            r.Ligne("Client", Convert.ToString(c["client_nom"]) + "  (" + Convert.ToString(c["client_telephone"]) + ")");
            r.Ligne("Budget prévu", Theme.Fcfa(budget));
            r.Espace(10);
            r.Section("Phases");
            var lp = new List<string[]>();
            foreach (DataRow p in dao.PhasesChantier(id).Rows)
                lp.Add(new[] { Convert.ToString(p["phase_ordre"]), Convert.ToString(p["phase_libelle"]) });
            if (lp.Count == 0) r.Texte("Aucune phase enregistrée."); else r.Tableau(new[] { "Ordre", "Phase" }, new float[] { 1, 6 }, null, lp);
            r.Espace(10);
            r.Section("Achats du chantier");
            var la = new List<string[]>();
            foreach (DataRow a in achats.Rows)
                la.Add(new[] { Convert.ToDateTime(a["achat_date"]).ToString("dd/MM/yyyy"), Convert.ToString(a["achat_description"]), Theme.Fcfa(Convert.ToDecimal(a["total_ht"])) });
            if (la.Count == 0) r.Texte("Aucun achat enregistré."); else r.Tableau(new[] { "Date", "Description", "Total HT" }, new float[] { 2, 6, 3 }, new[] { false, false, true }, la);
            r.Espace(8);
            r.Total("Total des achats HT", Theme.Fcfa(depense));
            r.Total("Règlements effectués", Theme.Fcfa(reglements));
            r.Total("Budget consommé", (budget > 0 ? Math.Round(depense * 100m / budget, 1) : 0m).ToString("0.0") + " %");
            r.Apercu();
        }

        public static void ImprimerFacture(int id)
        {
            var dao = new StatsDAO();
            DataTable info = dao.InfoFacture(id);
            if (info.Rows.Count == 0) { UiHelper.Avertir("Facture introuvable."); return; }
            DataRow f = info.Rows[0];
            var r = new Rapport { Titre = "Facture d'achat FA-" + id.ToString("D4"), Paysage = true, SousTitre = "Date : " + Convert.ToDateTime(f["facture_date"]).ToString("dd/MM/yyyy") };
            r.Section("Fournisseur");
            r.Ligne("Nom", Convert.ToString(f["fournisseur_nom"]));
            r.Ligne("Adresse", Convert.ToString(f["fournisseur_adresse"]));
            r.Ligne("Contact", Convert.ToString(f["fournisseur_telephone"]) + "  " + Convert.ToString(f["fournisseur_mail"]));
            r.Espace(10);
            r.Section("Détail des articles");
            var lignes = new List<string[]>();
            decimal ht = 0m;
            foreach (DataRow l in dao.LignesFacture(id).Rows)
            {
                decimal st = Convert.ToDecimal(l["sous_total"]);
                ht += st;
                lignes.Add(new[] { Convert.ToString(l["chantier_nom"]), Convert.ToString(l["article_nom"]), Convert.ToString(l["article_unite"]),
                    Convert.ToDecimal(l["quantite"]).ToString("N0"), Convert.ToDecimal(l["prix_achat"]).ToString("N0"), st.ToString("N0") });
            }
            if (lignes.Count == 0) r.Texte("Aucune ligne d'achat rattachée à cette facture.");
            else r.Tableau(new[] { "Chantier", "Article", "Unité", "Qté", "Prix unitaire", "Sous-total" }, new float[] { 4, 4, 2.5f, 1.2f, 2, 2.5f }, new[] { false, false, false, true, true, true }, lignes);
            r.Espace(8);
            r.Total("Total HT", Theme.Fcfa(ht));
            r.Total("TVA (18 %)", Theme.Fcfa(Math.Round(ht * 0.18m)));
            r.Total("Total TTC", Theme.Fcfa(Convert.ToDecimal(f["facture_total_ttc"])));
            r.Apercu();
        }
    }
}
