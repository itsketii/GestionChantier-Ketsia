using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmChantierDetail : Form
    {
        private readonly Chantier _item;
        private readonly bool _edition;
        public Chantier Resultat { get; private set; }

        public FrmChantierDetail() : this(null) { }

        public FrmChantierDetail(Chantier item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Chantiers";
            else lblTitre.Text = "Nouveau – Chantiers";
        }

        private void FrmChantierDetail_Load(object sender, EventArgs e)
        {
            try
            {
            cboClientId.DisplayMember = "Libelle"; cboClientId.ValueMember = "ClientId"; cboClientId.DataSource = new ClientDAO().ReadAll(); cboClientId.SelectedIndex = -1;
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(Chantier x)
        {
            txtChantierNom.Text = x.ChantierNom;
            txtChantierAdresse.Text = x.ChantierAdresse;
            { int i = cboChantierStatut.FindStringExact(x.ChantierStatut); if (i < 0 && !string.IsNullOrEmpty(x.ChantierStatut)) i = cboChantierStatut.Items.Add(x.ChantierStatut); cboChantierStatut.SelectedIndex = i; }
            dtpChantierDateDebut.Value = x.ChantierDateDebut < dtpChantierDateDebut.MinDate ? dtpChantierDateDebut.MinDate : x.ChantierDateDebut;
            dtpChantierDateFin.Value = x.ChantierDateFin < dtpChantierDateFin.MinDate ? dtpChantierDateFin.MinDate : x.ChantierDateFin;
            numChantierBudget.Value = Math.Min(numChantierBudget.Maximum, Math.Max(numChantierBudget.Minimum, Convert.ToDecimal(x.ChantierBudget)));
            cboClientId.SelectedValue = x.ClientId;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtChantierNom.Text)) return Refuser("Le champ « Nom du chantier » est obligatoire.", txtChantierNom);
            if (string.IsNullOrWhiteSpace(txtChantierAdresse.Text)) return Refuser("Le champ « Adresse » est obligatoire.", txtChantierAdresse);
            if (cboChantierStatut.SelectedIndex < 0) return Refuser("Veuillez choisir : Statut.", cboChantierStatut);
            if (cboClientId.SelectedIndex < 0) return Refuser("Veuillez choisir : Client.", cboClientId);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new Chantier();
            x.ChantierNom = txtChantierNom.Text.Trim();
            x.ChantierAdresse = txtChantierAdresse.Text.Trim();
            x.ChantierStatut = Convert.ToString(cboChantierStatut.SelectedItem);
            x.ChantierDateDebut = dtpChantierDateDebut.Value.Date;
            x.ChantierDateFin = dtpChantierDateFin.Value.Date;
            x.ChantierBudget = numChantierBudget.Value;
            x.ClientId = Convert.ToInt32(cboClientId.SelectedValue);
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
