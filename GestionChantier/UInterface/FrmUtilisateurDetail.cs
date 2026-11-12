using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmUtilisateurDetail : Form
    {
        private readonly Utilisateur _item;
        private readonly bool _edition;
        public Utilisateur Resultat { get; private set; }

        public FrmUtilisateurDetail() : this(null) { }

        public FrmUtilisateurDetail(Utilisateur item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Utilisateurs";
            else lblTitre.Text = "Nouveau – Utilisateurs";
        }

        private void FrmUtilisateurDetail_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            txtUtilisateurLogin.Enabled = false;
            txtMotDePasse.Visible = false; lblMotDePasse.Visible = false;
            chkUtilisateurActif.Visible = true;
            }
            if (_item == null) chkUtilisateurActif.Checked = true;
        }

        private void Remplir(Utilisateur x)
        {
            txtUtilisateurLogin.Text = x.UtilisateurLogin;
            txtUtilisateurNomComplet.Text = x.UtilisateurNomComplet;
            { int i = cboUtilisateurRole.FindStringExact(x.UtilisateurRole); if (i < 0 && !string.IsNullOrEmpty(x.UtilisateurRole)) i = cboUtilisateurRole.Items.Add(x.UtilisateurRole); cboUtilisateurRole.SelectedIndex = i; }
            chkUtilisateurActif.Checked = x.UtilisateurActif;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtUtilisateurLogin.Text)) return Refuser("Le champ « Identifiant de connexion » est obligatoire.", txtUtilisateurLogin);
            if (string.IsNullOrWhiteSpace(txtUtilisateurNomComplet.Text)) return Refuser("Le champ « Nom complet » est obligatoire.", txtUtilisateurNomComplet);
            if (!_edition && txtMotDePasse.Text.Length < 6) return Refuser("Le mot de passe doit contenir au moins 6 caractères.", txtMotDePasse);
            if (cboUtilisateurRole.SelectedIndex < 0) return Refuser("Veuillez choisir : Rôle.", cboUtilisateurRole);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new Utilisateur();
            x.UtilisateurLogin = txtUtilisateurLogin.Text.Trim();
            x.UtilisateurNomComplet = txtUtilisateurNomComplet.Text.Trim();
            x.MotDePasse = txtMotDePasse.Text;
            x.UtilisateurRole = Convert.ToString(cboUtilisateurRole.SelectedItem);
            x.UtilisateurActif = chkUtilisateurActif.Checked;
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
