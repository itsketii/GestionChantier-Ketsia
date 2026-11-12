using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using GestionChantier.DataAccess;

namespace GestionChantier.UInterface
{
    /// <summary>Tableau de bord : indicateurs clés et graphiques.</summary>
    public class FrmDashboard : Form
    {
        private readonly Panel pnlBanniere = new Panel { Dock = DockStyle.Top, Height = 124 };
        private readonly Panel pnlCorps = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
        private readonly Label lblTitre = new Label { AutoSize = true, Left = 28, Top = 24, BackColor = Color.Transparent, ForeColor = Color.White, Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold) };
        private readonly Label lblSous = new Label { AutoSize = true, Left = 30, Top = 70, BackColor = Color.Transparent, ForeColor = Color.FromArgb(215, 225, 240), Font = new Font("Segoe UI", 10.5F) };
        private readonly Button btnActualiser = new Button { Text = "Actualiser", Width = 110, Height = 34, Anchor = AnchorStyles.Top | AnchorStyles.Right };
        private readonly KpiCard[] kpis = new KpiCard[6];
        private readonly BarChart chBudget = new BarChart { Titre = "Budget par chantier (FCFA)" };
        private readonly DonutChart chStatut = new DonutChart { Titre = "Chantiers par statut" };
        private readonly BarChart chAchats = new BarChart { Titre = "Achats facturés par mois (TTC, FCFA)" };

        public FrmDashboard()
        {
            Text = "Tableau de bord";
            ClientSize = new Size(1100, 650);
            BackColor = Theme.Bg;
            Font = new Font("Segoe UI", 9.5F);

            var img = Assets.Image("banner.png");
            if (img != null) { pnlBanniere.BackgroundImage = img; pnlBanniere.BackgroundImageLayout = ImageLayout.Stretch; }
            else UiHelper.Degrade(pnlBanniere);
            pnlBanniere.Controls.Add(lblTitre);
            pnlBanniere.Controls.Add(lblSous);
            lblTitre.Text = "Tableau de bord";
            string nom = Session.Courant == null ? "" : Session.Courant.UtilisateurNomComplet;
            lblSous.Text = "Bonjour " + nom + "  •  " + DateTime.Now.ToString("dddd d MMMM yyyy", new CultureInfo("fr-FR"));
            UiHelper.StyleBouton(btnActualiser, true);
            btnActualiser.Click += (s, e) => Charger();
            pnlBanniere.Controls.Add(btnActualiser);
            pnlBanniere.Resize += (s, e) => btnActualiser.Location = new Point(pnlBanniere.Width - btnActualiser.Width - 28, 44);

            Color[] couleurs = { Theme.Orange, Theme.Navy, Theme.Bleu, Theme.Succes, Color.FromArgb(139, 92, 246), Theme.OrangeDark };
            string[] titres = { "Chantiers en cours", "Budget total", "Achats facturés (TTC)", "Règlements effectués", "Intervenants", "Contrôles qualité" };
            for (int i = 0; i < kpis.Length; i++)
            {
                kpis[i] = new KpiCard { Titre = titres[i], Accent = couleurs[i], Height = 96 };
                pnlCorps.Controls.Add(kpis[i]);
            }
            pnlCorps.Controls.Add(chBudget);
            pnlCorps.Controls.Add(chStatut);
            pnlCorps.Controls.Add(chAchats);
            Controls.Add(pnlCorps);
            Controls.Add(pnlBanniere);
            pnlCorps.Resize += (s, e) => Disposer();
            Load += (s, e) => { Disposer(); Charger(); };
        }

        private void Disposer()
        {
            int w = pnlCorps.ClientSize.Width - 56;
            if (w < 600) w = 600;
            int gap = 14, x0 = 28, y = 22;
            int cw = (w - gap * (kpis.Length - 1)) / kpis.Length;
            for (int i = 0; i < kpis.Length; i++) kpis[i].SetBounds(x0 + i * (cw + gap), y, cw, 96);
            y += 96 + 18;
            int w1 = (int)(w * 0.58) - gap / 2;
            chBudget.SetBounds(x0, y, w1, 300);
            chStatut.SetBounds(x0 + w1 + gap, y, w - w1 - gap, 300);
            y += 300 + 18;
            chAchats.SetBounds(x0, y, w, 270);
            pnlCorps.AutoScrollMinSize = new Size(0, y + 270 + 24);
        }

        private void Charger()
        {
            try
            {
                var s = new StatsDAO();
                decimal nb = s.NbChantiers(), achats = s.DepensesTtc(), regl = s.TotalReglements();
                kpis[0].Valeur = s.NbChantiersEnCours().ToString("0"); kpis[0].Detail = "sur " + nb.ToString("0") + " chantiers";
                kpis[1].Valeur = Theme.Compact(s.BudgetTotal()) + " FCFA"; kpis[1].Detail = "tous chantiers confondus";
                kpis[2].Valeur = Theme.Compact(achats) + " FCFA"; kpis[2].Detail = "factures fournisseurs";
                kpis[3].Valeur = Theme.Compact(regl) + " FCFA"; kpis[3].Detail = (achats > 0 ? Math.Round(regl * 100m / achats, 0) : 0m).ToString("0") + " % du montant des achats";
                kpis[4].Valeur = s.NbIntervenants().ToString("0"); kpis[4].Detail = "corps de métier";
                kpis[5].Valeur = s.NbControles().ToString("0"); kpis[5].Detail = "contrôles réalisés";
                chBudget.Donnees = s.BudgetParChantier();
                chStatut.Donnees = s.ChantiersParStatut();
                chAchats.Donnees = s.AchatsMensuels();
                foreach (var k in kpis) k.Invalidate();
                chBudget.Invalidate(); chStatut.Invalidate(); chAchats.Invalidate();
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }
    }
}
