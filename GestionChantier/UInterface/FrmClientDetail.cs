using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmClientDetail : Form
    {
        private readonly Client _item;
        private readonly bool _edition;
        public Client Resultat { get; private set; }

        public FrmClientDetail() : this(null) { }

        public FrmClientDetail(Client item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Clients";
            else lblTitre.Text = "Nouveau – Clients";
        }

        private void FrmClientDetail_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(Client x)
        {
            txtClientNom.Text = x.ClientNom;
            txtClientTelephone.Text = x.ClientTelephone;
            txtClientEmail.Text = x.ClientEmail;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtClientNom.Text)) return Refuser("Le champ « Nom / Raison sociale » est obligatoire.", txtClientNom);
            if (string.IsNullOrWhiteSpace(txtClientTelephone.Text)) return Refuser("Le champ « Téléphone » est obligatoire.", txtClientTelephone);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new Client();
            x.ClientNom = txtClientNom.Text.Trim();
            x.ClientTelephone = txtClientTelephone.Text.Trim();
            x.ClientEmail = txtClientEmail.Text.Trim();
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
