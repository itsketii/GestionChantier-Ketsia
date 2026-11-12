using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using GestionChantier.DataAccess;

namespace GestionChantier.UInterface
{
    /// <summary>Styles communs, messages et gardes de rôle.</summary>
    public static class UiHelper
    {
        // ---------- Messages ----------
        public static void Erreur(Exception ex)
        {
            string msg = ex is MySqlException ? DbHelper.Message((MySqlException)ex) : ex.Message;
            MessageBox.Show(msg, "GestionChantier", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Avertir(string msg)
        {
            MessageBox.Show(msg, "GestionChantier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Info(string msg)
        {
            MessageBox.Show(msg, "GestionChantier", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirmer(string msg)
        {
            return MessageBox.Show(msg, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // ---------- Gardes de rôle ----------
        public static void RoleGuard(Button nouveau, Button modifier, Button supprimer)
        {
            bool ok = Session.PeutModifier;
            nouveau.Enabled = ok; modifier.Enabled = ok; supprimer.Enabled = ok;
        }

        public static void AdminGuard(Button nouveau, Button modifier, Button supprimer)
        {
            bool ok = Session.EstAdmin;
            nouveau.Enabled = ok; modifier.Enabled = ok; supprimer.Enabled = ok;
        }

        // ---------- Styles ----------
        public static void Degrade(Panel p)
        {
            p.Paint += (s, e) =>
            {
                if (p.Width < 2 || p.Height < 2) return;
                using (var br = new LinearGradientBrush(p.ClientRectangle, Theme.Navy, Theme.NavyLight, 0f))
                    e.Graphics.FillRectangle(br, p.ClientRectangle);
                using (var pen = new Pen(Theme.Orange, 3f))
                    e.Graphics.DrawLine(pen, 0, p.Height - 2, p.Width, p.Height - 2);
            };
            p.Resize += (s, e) => p.Invalidate();
        }

        public static void StyleBouton(Button b, bool primaire)
        {
            Color couleur = primaire ? Theme.Orange : (b.Name == "btnSupprimer" ? Theme.Danger : Theme.NavyLight);
            Color survol = primaire ? Theme.OrangeDark : (b.Name == "btnSupprimer" ? Color.FromArgb(185, 28, 28) : Theme.NavyHover);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = couleur;
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.MouseEnter += (s, e) => { if (b.Enabled) b.BackColor = survol; };
            b.MouseLeave += (s, e) => { if (b.Enabled) b.BackColor = couleur; };
            b.EnabledChanged += (s, e) => { b.BackColor = b.Enabled ? couleur : Color.FromArgb(190, 196, 208); };
        }

        public static void StyleGrille(DataGridView g)
        {
            g.BackgroundColor = Theme.Bg;
            g.BorderStyle = BorderStyle.None;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersDefaultCellStyle.BackColor = Theme.Navy;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.Navy;
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 40;
            g.RowTemplate.Height = 36;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            g.DefaultCellStyle.ForeColor = Theme.Texte;
            g.DefaultCellStyle.BackColor = Color.White;
            g.DefaultCellStyle.Padding = new Padding(8, 0, 4, 0);
            g.DefaultCellStyle.SelectionBackColor = Theme.OrangeSoft;
            g.DefaultCellStyle.SelectionForeColor = Theme.Navy;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Theme.Bordure;
            g.AllowUserToResizeRows = false;
            g.Margin = new Padding(24);
            g.ShowCellToolTips = true;
            typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(g, true, null);
        }

        public static void StyleListe(Panel header, DataGridView grille, Panel barre, Panel pied)
        {
            Degrade(header);
            StyleGrille(grille);
            barre.BackColor = Color.White;
            pied.BackColor = Color.White;
            if (header.Parent != null)
            {
                header.Parent.BackColor = Theme.Bg;
                header.Parent.Font = new Font("Segoe UI", 9.5F);
            }
        }

        public static void StyleDetail(Form f, Panel header, Button enregistrer, Button annuler)
        {
            f.BackColor = Color.White;
            f.Font = new Font("Segoe UI", 9.75F);
            Degrade(header);
            StyleBouton(enregistrer, true);
            StyleBouton(annuler, false);
            annuler.BackColor = Color.FromArgb(107, 114, 128);
            annuler.MouseLeave += (s, e) => annuler.BackColor = Color.FromArgb(107, 114, 128);
        }
    }
}
