using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmIntervenantDetail : Form
    {
        private readonly Intervenant _item;
        private readonly bool _edition;
        public Intervenant Resultat { get; private set; }

        public FrmIntervenantDetail() : this(null) { }

        public FrmIntervenantDetail(Intervenant item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Intervenants";
            else lblTitre.Text = "Nouveau – Intervenants";
        }

        private void FrmIntervenantDetail_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(Intervenant x)
        {
            txtIntervenantNom.Text = x.IntervenantNom;
            txtIntervenantSpecialite.Text = x.IntervenantSpecialite;
            numIntervenantTauxHoraire.Value = Math.Min(numIntervenantTauxHoraire.Maximum, Math.Max(numIntervenantTauxHoraire.Minimum, Convert.ToDecimal(x.IntervenantTauxHoraire)));
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtIntervenantNom.Text)) return Refuser("Le champ « Nom » est obligatoire.", txtIntervenantNom);
            if (string.IsNullOrWhiteSpace(txtIntervenantSpecialite.Text)) return Refuser("Le champ « Spécialité » est obligatoire.", txtIntervenantSpecialite);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new Intervenant();
            x.IntervenantNom = txtIntervenantNom.Text.Trim();
            x.IntervenantSpecialite = txtIntervenantSpecialite.Text.Trim();
            x.IntervenantTauxHoraire = numIntervenantTauxHoraire.Value;
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
