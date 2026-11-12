using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmFournisseurDetail : Form
    {
        private readonly Fournisseur _item;
        private readonly bool _edition;
        public Fournisseur Resultat { get; private set; }

        public FrmFournisseurDetail() : this(null) { }

        public FrmFournisseurDetail(Fournisseur item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Fournisseurs";
            else lblTitre.Text = "Nouveau – Fournisseurs";
        }

        private void FrmFournisseurDetail_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(Fournisseur x)
        {
            txtFournisseurNom.Text = x.FournisseurNom;
            txtFournisseurAdresse.Text = x.FournisseurAdresse;
            txtFournisseurTelephone.Text = x.FournisseurTelephone;
            txtFournisseurMail.Text = x.FournisseurMail;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtFournisseurNom.Text)) return Refuser("Le champ « Nom » est obligatoire.", txtFournisseurNom);
            if (string.IsNullOrWhiteSpace(txtFournisseurAdresse.Text)) return Refuser("Le champ « Adresse » est obligatoire.", txtFournisseurAdresse);
            if (string.IsNullOrWhiteSpace(txtFournisseurTelephone.Text)) return Refuser("Le champ « Téléphone » est obligatoire.", txtFournisseurTelephone);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new Fournisseur();
            x.FournisseurNom = txtFournisseurNom.Text.Trim();
            x.FournisseurAdresse = txtFournisseurAdresse.Text.Trim();
            x.FournisseurTelephone = txtFournisseurTelephone.Text.Trim();
            x.FournisseurMail = txtFournisseurMail.Text.Trim();
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
