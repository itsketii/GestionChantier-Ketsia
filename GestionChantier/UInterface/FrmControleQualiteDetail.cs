using System;
using System.Windows.Forms;
using GestionChantier.DataAccess;
using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    public partial class FrmControleQualiteDetail : Form
    {
        private readonly ControleQualite _item;
        private readonly bool _edition;
        public ControleQualite Resultat { get; private set; }

        public FrmControleQualiteDetail() : this(null) { }

        public FrmControleQualiteDetail(ControleQualite item)
        {
            InitializeComponent();
            _item = item;
            _edition = item != null;
            UiHelper.StyleDetail(this, pnlHeader, btnEnregistrer, btnAnnuler);
            if (_edition) lblTitre.Text = "Modifier – Contrôles qualité";
            else lblTitre.Text = "Nouveau – Contrôles qualité";
        }

        private void FrmControleQualiteDetail_Load(object sender, EventArgs e)
        {
            try
            {
            cboSerTravId.DisplayMember = "Libelle"; cboSerTravId.ValueMember = "SerTravId"; cboSerTravId.DataSource = new ServiceTravailDAO().ReadAll(); cboSerTravId.SelectedIndex = -1;
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
            if (_edition) { Remplir(_item);
            }
        }

        private void Remplir(ControleQualite x)
        {
            dtpControleDate.Value = x.ControleDate < dtpControleDate.MinDate ? dtpControleDate.MinDate : x.ControleDate;
            cboSerTravId.SelectedValue = x.SerTravId;
        }

        private bool Refuser(string message, Control c)
        {
            UiHelper.Avertir(message);
            c.Focus();
            return false;
        }

        private bool Valider()
        {
            if (cboSerTravId.SelectedIndex < 0) return Refuser("Veuillez choisir : Service contrôlé.", cboSerTravId);
            return true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            var x = _item ?? new ControleQualite();
            x.ControleDate = dtpControleDate.Value.Date;
            x.SerTravId = Convert.ToInt32(cboSerTravId.SelectedValue);
            Resultat = x;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
