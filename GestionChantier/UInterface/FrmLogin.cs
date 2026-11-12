using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using GestionChantier.DataAccess;

namespace GestionChantier.UInterface
{
    /// <summary>Fenêtre de connexion (interface construite en code).</summary>
    public class FrmLogin : Form
    {
        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr h, int msg, int w, int l);

        private TextBox txtLogin, txtMdp;
        private Button btnConnexion;
        private Label lblErreur, lblEtat;
        private CheckBox chkAfficher;

        public FrmLogin()
        {
            Text = "GestionChantier – Connexion";
            ClientSize = new Size(880, 540);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);
            Construire();
            Shown += (s, e) => VerifierBase();
            AcceptButton = btnConnexion;
        }

        private void Deplacer(object s, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }

        private Label Etiquette(string texte, int x, int y, float taille, FontStyle style, Color couleur)
        {
            var l = new Label { Text = texte, AutoSize = true, Left = x, Top = y, Font = new Font("Segoe UI", taille, style), ForeColor = couleur, BackColor = Color.Transparent };
            return l;
        }

        private void Construire()
        {
            // ----- Panneau gauche : illustration -----
            var gauche = new Panel { Left = 0, Top = 0, Width = 400, Height = 540, BackColor = Theme.Navy };
            var img = Assets.Image("login_bg.png");
            if (img != null) { gauche.BackgroundImage = img; gauche.BackgroundImageLayout = ImageLayout.Stretch; }
            gauche.MouseDown += Deplacer;
            gauche.Controls.Add(Etiquette("GESTION CHANTIER", 36, 40, 20F, FontStyle.Bold, Color.White));
            gauche.Controls.Add(Etiquette("Pilotez vos chantiers,\nvos achats et vos règlements.", 38, 82, 11F, FontStyle.Regular, Color.FromArgb(215, 225, 240)));
            gauche.Controls.Add(Etiquette("Clients  •  Chantiers  •  Achats  •  Qualité", 38, 490, 9F, FontStyle.Regular, Color.FromArgb(200, 212, 232)));
            Controls.Add(gauche);

            // ----- Panneau droit : formulaire -----
            var fermer = new Label { Text = "✕", Left = 835, Top = 10, AutoSize = true, Font = new Font("Segoe UI", 12F), ForeColor = Theme.Muted, Cursor = Cursors.Hand };
            fermer.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            fermer.MouseEnter += (s, e) => fermer.ForeColor = Theme.Danger;
            fermer.MouseLeave += (s, e) => fermer.ForeColor = Theme.Muted;
            Controls.Add(fermer);
            MouseDown += Deplacer;

            var logo = Assets.Image("logo.png");
            if (logo != null) Controls.Add(new PictureBox { Image = logo, SizeMode = PictureBoxSizeMode.Zoom, Left = 450, Top = 50, Width = 64, Height = 64 });
            Controls.Add(Etiquette("Bienvenue", 450, 126, 22F, FontStyle.Bold, Theme.Navy));
            Controls.Add(Etiquette("Connectez-vous pour accéder à votre espace de gestion.", 452, 172, 9.5F, FontStyle.Regular, Theme.Muted));

            Controls.Add(Etiquette("Identifiant", 452, 218, 9.5F, FontStyle.Bold, Theme.Texte));
            txtLogin = new TextBox { Left = 452, Top = 242, Width = 370, Font = new Font("Segoe UI", 12F), BorderStyle = BorderStyle.FixedSingle };
            Controls.Add(txtLogin);

            Controls.Add(Etiquette("Mot de passe", 452, 290, 9.5F, FontStyle.Bold, Theme.Texte));
            txtMdp = new TextBox { Left = 452, Top = 314, Width = 370, Font = new Font("Segoe UI", 12F), BorderStyle = BorderStyle.FixedSingle, UseSystemPasswordChar = true };
            Controls.Add(txtMdp);

            chkAfficher = new CheckBox { Text = "Afficher le mot de passe", Left = 452, Top = 354, AutoSize = true, ForeColor = Theme.Muted, Font = new Font("Segoe UI", 9F) };
            chkAfficher.CheckedChanged += (s, e) => txtMdp.UseSystemPasswordChar = !chkAfficher.Checked;
            Controls.Add(chkAfficher);

            lblErreur = new Label { Left = 452, Top = 384, Width = 370, Height = 36, ForeColor = Theme.Danger, Font = new Font("Segoe UI", 9.5F) };
            Controls.Add(lblErreur);

            btnConnexion = new Button { Text = "Se connecter", Left = 452, Top = 426, Width = 370, Height = 46 };
            UiHelper.StyleBouton(btnConnexion, true);
            btnConnexion.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnConnexion.Click += Connexion_Click;
            Controls.Add(btnConnexion);

            lblEtat = Etiquette("● Vérification de la base de données...", 452, 496, 9F, FontStyle.Regular, Theme.Muted);
            Controls.Add(lblEtat);
        }

        private void VerifierBase()
        {
            string err;
            if (GestionChantier.DataAccess.Connexion.Tester(out err))
            {
                lblEtat.Text = "● Base « " + GestionChantier.DataAccess.Connexion.NomBase + " » connectée";
                lblEtat.ForeColor = Theme.Succes;
            }
            else
            {
                lblEtat.Text = "● Serveur MySQL injoignable";
                lblEtat.ForeColor = Theme.Danger;
                lblErreur.Text = "Démarrez MySQL (XAMPP/WAMP) et vérifiez Connexion.cs.";
            }
        }

        private void Connexion_Click(object sender, EventArgs e)
        {
            lblErreur.Text = "";
            if (txtLogin.Text.Trim().Length == 0 || txtMdp.Text.Length == 0)
            {
                lblErreur.Text = "Saisissez votre identifiant et votre mot de passe.";
                return;
            }
            try
            {
                UseWaitCursor = true;
                var u = new UtilisateurDAO().Authentifier(txtLogin.Text.Trim(), txtMdp.Text);
                if (u == null)
                {
                    lblErreur.Text = "Identifiant ou mot de passe incorrect (ou compte désactivé).";
                    txtMdp.Clear();
                    txtMdp.Focus();
                    return;
                }
                Session.Courant = u;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblErreur.Text = ex is MySqlException ? DbHelper.Message((MySqlException)ex) : ex.Message;
            }
            finally { UseWaitCursor = false; }
        }
    }
}
