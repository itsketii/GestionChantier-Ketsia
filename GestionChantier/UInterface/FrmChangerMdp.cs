using System;
using System.Drawing;
using System.Windows.Forms;
using GestionChantier.DataAccess;

namespace GestionChantier.UInterface
{
    /// <summary>Changement du mot de passe de l'utilisateur connecté.</summary>
    public class FrmChangerMdp : Form
    {
        private TextBox txtAncien, txtNouveau, txtConfirm;

        public FrmChangerMdp()
        {
            Text = "Changer mon mot de passe";
            ClientSize = new Size(420, 360);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9.75F);

            var header = new Panel { Dock = DockStyle.Top, Height = 64 };
            UiHelper.Degrade(header);
            header.Controls.Add(new Label { Text = "Changer mon mot de passe", AutoSize = true, Left = 24, Top = 16, BackColor = Color.Transparent, ForeColor = Color.White, Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold) });
            Controls.Add(header);

            txtAncien = Champ("Mot de passe actuel", 84);
            txtNouveau = Champ("Nouveau mot de passe (6 caractères min.)", 154);
            txtConfirm = Champ("Confirmer le nouveau mot de passe", 224);

            var ok = new Button { Text = "Enregistrer", Left = 150, Top = 300, Width = 130, Height = 38 };
            var annuler = new Button { Text = "Annuler", Left = 290, Top = 300, Width = 100, Height = 38, DialogResult = DialogResult.Cancel };
            UiHelper.StyleBouton(ok, true);
            UiHelper.StyleBouton(annuler, false);
            annuler.BackColor = Color.FromArgb(107, 114, 128);
            ok.Click += Valider;
            Controls.Add(ok); Controls.Add(annuler);
            AcceptButton = ok; CancelButton = annuler;
        }

        private TextBox Champ(string titre, int y)
        {
            Controls.Add(new Label { Text = titre, Left = 30, Top = y, AutoSize = true });
            var t = new TextBox { Left = 30, Top = y + 24, Width = 360, UseSystemPasswordChar = true };
            Controls.Add(t);
            return t;
        }

        private void Valider(object sender, EventArgs e)
        {
            if (txtNouveau.Text.Length < 6) { UiHelper.Avertir("Le nouveau mot de passe doit contenir au moins 6 caractères."); return; }
            if (txtNouveau.Text != txtConfirm.Text) { UiHelper.Avertir("La confirmation ne correspond pas au nouveau mot de passe."); return; }
            try
            {
                bool ok = new UtilisateurDAO().ChangerMotDePasse(Session.Courant.UtilisateurId, txtAncien.Text, txtNouveau.Text);
                if (!ok) { UiHelper.Avertir("Le mot de passe actuel est incorrect."); return; }
                UiHelper.Info("Votre mot de passe a été modifié.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { UiHelper.Erreur(ex); }
        }
    }
}
