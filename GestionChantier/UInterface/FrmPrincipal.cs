using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using GestionChantier.DataAccess;

namespace GestionChantier.UInterface
{
    /// <summary>Fenêtre principale : menu latéral + zone de contenu + barre d'état.</summary>
    public class FrmPrincipal : Form
    {
        public bool Deconnecte { get; private set; }

        private readonly Panel pnlMenu = new Panel { Dock = DockStyle.Left, Width = 250, BackColor = Theme.Navy };
        private readonly FlowLayoutPanel flux = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true, BackColor = Theme.Navy };
        private readonly Panel pnlHaut = new Panel { Dock = DockStyle.Top, Height = 62, BackColor = Color.White };
        private readonly Panel pnlContenu = new Panel { Dock = DockStyle.Fill, BackColor = Theme.Bg };
        private readonly Panel pnlEtat = new Panel { Dock = DockStyle.Bottom, Height = 26, BackColor = Color.FromArgb(7, 20, 38) };
        private readonly Label lblPage = new Label { AutoSize = true, Left = 26, Top = 15, Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold), ForeColor = Theme.Navy };
        private readonly Label lblEtat = new Label { AutoSize = true, Left = 14, Top = 5, Font = new Font("Segoe UI", 8.5F), ForeColor = Color.FromArgb(190, 205, 225) };
        private readonly Label lblHeure = new Label { AutoSize = true, Top = 5, Font = new Font("Segoe UI", 8.5F), ForeColor = Color.FromArgb(190, 205, 225), Anchor = AnchorStyles.Top | AnchorStyles.Right };
        private readonly Timer horloge = new Timer { Interval = 1000 };
        private readonly List<NavButton> boutons = new List<NavButton>();
        private Form _courant;
        private Action _accueil;

        public FrmPrincipal()
        {
            Text = "GestionChantier – Gestion de chantiers";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1100, 640);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9.5F);
            BackColor = Theme.Bg;
            ConstruireMenu();
            ConstruireBarreHaute();

            lblEtat.Text = "● Connecté à MySQL – " + Connexion.NomServeur + " / " + Connexion.NomBase;
            pnlEtat.Controls.Add(lblEtat);
            pnlEtat.Controls.Add(lblHeure);
            pnlEtat.Resize += (s, e) => lblHeure.Left = pnlEtat.Width - lblHeure.Width - 14;

            Controls.Add(pnlContenu);
            Controls.Add(pnlHaut);
            Controls.Add(pnlEtat);
            Controls.Add(pnlMenu);

            horloge.Tick += (s, e) => { lblHeure.Text = DateTime.Now.ToString("dddd d MMMM yyyy  HH:mm:ss", new CultureInfo("fr-FR")); lblHeure.Left = pnlEtat.Width - lblHeure.Width - 14; };
            horloge.Start();
            Load += (s, e) => _accueil();
            FormClosed += (s, e) => horloge.Stop();
        }

        private void ConstruireMenu()
        {
            var logo = new Panel { Dock = DockStyle.Top, Height = 74, BackColor = Theme.Navy };
            var img = Assets.Image("logo.png");
            if (img != null) logo.Controls.Add(new PictureBox { Image = img, SizeMode = PictureBoxSizeMode.Zoom, Left = 18, Top = 13, Width = 48, Height = 48 });
            logo.Controls.Add(new Label { Text = "GESTION", AutoSize = true, Left = 74, Top = 12, ForeColor = Color.White, Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold) });
            logo.Controls.Add(new Label { Text = "CHANTIER", AutoSize = true, Left = 74, Top = 34, ForeColor = Theme.Orange, Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold) });
            pnlMenu.Controls.Add(flux);
            pnlMenu.Controls.Add(logo);

            Section("GÉNÉRAL");
            Entree("Tableau de bord", () => new FrmDashboard());
            Section("PROJETS");
            Entree("Clients", () => new FrmClientList());
            Entree("Chantiers", () => new FrmChantierList());
            Entree("Phases", () => new FrmPhaseList());
            Entree("Services de travail", () => new FrmServiceTravailList());
            Entree("Intervenants", () => new FrmIntervenantList());
            Section("ACHATS & FINANCES");
            Entree("Fournisseurs", () => new FrmFournisseurList());
            Entree("Articles", () => new FrmArticleList());
            Entree("Factures d'achat", () => new FrmFactureAchatList());
            Entree("Achats", () => new FrmAchatList());
            Entree("Lignes d'achat", () => new FrmPorteSurList());
            Entree("Règlements", () => new FrmReglementList());
            Section("QUALITÉ");
            Entree("Contrôles qualité", () => new FrmControleQualiteList());
            Entree("Rapports de contrôle", () => new FrmRapportControleList());
            if (Session.EstAdmin)
            {
                Section("ADMINISTRATION");
                Entree("Utilisateurs", () => new FrmUtilisateurList());
            }
        }

        private void Section(string titre)
        {
            flux.Controls.Add(new Label
            {
                Text = titre, Width = 232, Height = 26, ForeColor = Color.FromArgb(120, 140, 170),
                Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold), Padding = new Padding(22, 8, 0, 0),
                Margin = new Padding(0), BackColor = Theme.Navy
            });
        }

        private void Entree(string texte, Func<Form> fabrique)
        {
            var b = new NavButton { Text = texte, Width = 232, Margin = new Padding(0, 0, 0, 1) };
            b.Click += (s, e) => Ouvrir(texte, b, fabrique);
            if (boutons.Count == 0) _accueil = () => Ouvrir(texte, b, fabrique);
            boutons.Add(b);
            flux.Controls.Add(b);
        }

        private void Ouvrir(string titre, NavButton b, Func<Form> fabrique)
        {
            try
            {
                foreach (var x in boutons) x.Actif = false;
                b.Actif = true;
                lblPage.Text = titre;
                var ancien = _courant;
                var f = fabrique();
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                pnlContenu.Controls.Add(f);
                f.Show();
                f.BringToFront();
                _courant = f;
                if (ancien != null) { pnlContenu.Controls.Remove(ancien); ancien.Dispose(); }
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }

        private void ConstruireBarreHaute()
        {
            pnlHaut.Controls.Add(lblPage);
            pnlHaut.Paint += (s, e) => { using (var p = new Pen(Theme.Bordure)) e.Graphics.DrawLine(p, 0, pnlHaut.Height - 1, pnlHaut.Width, pnlHaut.Height - 1); };

            var btnOut = new Button { Text = "Déconnexion", Width = 118, Height = 34, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            UiHelper.StyleBouton(btnOut, false);
            btnOut.BackColor = Theme.Danger;
            btnOut.Click += (s, e) => { if (UiHelper.Confirmer("Voulez-vous vous déconnecter ?")) { Deconnecte = true; Session.Courant = null; Close(); } };

            var btnMdp = new Button { Text = "Mon compte", Width = 118, Height = 34, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            UiHelper.StyleBouton(btnMdp, false);
            btnMdp.Click += (s, e) => { using (var f = new FrmChangerMdp()) f.ShowDialog(this); };

            var u = Session.Courant;
            string nom = u == null ? "" : u.UtilisateurNomComplet;
            string role = u == null ? "" : u.UtilisateurRole;
            string ini = nom.Length > 0 ? nom.Substring(0, 1).ToUpper() : "?";
            var avatar = new Label { Text = ini, Width = 40, Height = 40, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.White, BackColor = Theme.Orange, Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            avatar.Paint += (s, e) => { };
            var lblNom = new Label { Text = nom, AutoSize = true, Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold), ForeColor = Theme.Navy, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            var lblRole = new Label { Text = role, AutoSize = true, Font = new Font("Segoe UI", 8.5F), ForeColor = Theme.Muted, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            pnlHaut.Controls.AddRange(new Control[] { btnOut, btnMdp, avatar, lblNom, lblRole });
            Action place = () =>
            {
                int w = pnlHaut.Width;
                btnOut.Location = new Point(w - 118 - 24, 14);
                btnMdp.Location = new Point(w - 118 - 24 - 118 - 10, 14);
                int xTxt = btnMdp.Left - 24 - Math.Max(lblNom.Width, lblRole.Width);
                avatar.Location = new Point(xTxt - 50, 11);
                lblNom.Location = new Point(xTxt, 11);
                lblRole.Location = new Point(xTxt, 33);
            };
            pnlHaut.Resize += (s, e) => place();
            Load += (s, e) => place();
        }
    }
}
