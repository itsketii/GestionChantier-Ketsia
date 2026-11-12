using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GestionChantier.UInterface
{
    /// <summary>Bouton du menu latéral (avec barre orange quand il est actif).</summary>
    public class NavButton : Button
    {
        private bool _actif;
        public bool Actif { get { return _actif; } set { _actif = value; BackColor = value ? Theme.NavyLight : Theme.Navy; Invalidate(); } }

        public NavButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Theme.NavyHover;
            FlatAppearance.MouseDownBackColor = Theme.NavyLight;
            BackColor = Theme.Navy;
            ForeColor = Color.FromArgb(220, 228, 240);
            Font = new Font("Segoe UI", 10F);
            TextAlign = ContentAlignment.MiddleLeft;
            Padding = new Padding(26, 0, 0, 0);
            Cursor = Cursors.Hand;
            Height = 32;
            TabStop = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_actif)
                using (var br = new SolidBrush(Theme.Orange)) e.Graphics.FillRectangle(br, 0, 4, 5, Height - 8);
        }
    }

    /// <summary>Carte d'indicateur (KPI) du tableau de bord.</summary>
    public class KpiCard : Control
    {
        public string Titre { get; set; }
        public string Valeur { get; set; }
        public string Detail { get; set; }
        public Color Accent { get; set; }

        public KpiCard()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Accent = Theme.Orange; Valeur = "-"; Titre = ""; Detail = "";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.Clear(Theme.Bg);
            var r = new RectangleF(0.5f, 0.5f, Width - 2, Height - 2);
            using (var path = Theme.RectArrondi(r, 10))
            {
                g.FillPath(Brushes.White, path);
                using (var p = new Pen(Theme.Bordure)) g.DrawPath(p, path);
                g.SetClip(path);
                using (var br = new SolidBrush(Accent)) g.FillRectangle(br, 0, 0, 6, Height);
                g.ResetClip();
            }
            using (var f = Theme.Police(9.5F)) g.DrawString(Titre, f, new SolidBrush(Theme.Muted), 20, 14);
            using (var f = Theme.PoliceGras(19F)) g.DrawString(Valeur, f, new SolidBrush(Theme.Navy), 18, 36);
            using (var f = Theme.Police(8.5F)) g.DrawString(Detail, f, new SolidBrush(Theme.Muted), 20, Height - 28);
        }
    }

    /// <summary>Histogramme simple dessiné en GDI+.</summary>
    public class BarChart : Control
    {
        public string Titre { get; set; }
        public List<KeyValuePair<string, decimal>> Donnees { get; set; }

        public BarChart()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Donnees = new List<KeyValuePair<string, decimal>>();
            Titre = "";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.Clear(Theme.Bg);
            var r = new RectangleF(0.5f, 0.5f, Width - 2, Height - 2);
            using (var path = Theme.RectArrondi(r, 10))
            {
                g.FillPath(Brushes.White, path);
                using (var p = new Pen(Theme.Bordure)) g.DrawPath(p, path);
            }
            using (var f = Theme.PoliceGras(11F)) g.DrawString(Titre, f, new SolidBrush(Theme.Navy), 18, 14);
            if (Donnees == null || Donnees.Count == 0)
            {
                using (var f = Theme.Police(10F)) g.DrawString("Aucune donnée", f, new SolidBrush(Theme.Muted), 18, 50);
                return;
            }
            decimal max = 0m;
            foreach (var d in Donnees) if (d.Value > max) max = d.Value;
            if (max <= 0) max = 1;
            float gauche = 20, droite = 20, haut = 56, bas = 40;
            float zoneW = Width - gauche - droite, zoneH = Height - haut - bas;
            float pas = zoneW / Donnees.Count;
            float bw = Math.Min(64f, pas * 0.56f);
            using (var pen = new Pen(Theme.Bordure))
                for (int i = 0; i <= 3; i++) { float yy = haut + zoneH - zoneH * i / 3f; g.DrawLine(pen, gauche, yy, Width - droite, yy); }
            for (int i = 0; i < Donnees.Count; i++)
            {
                float h = (float)(Donnees[i].Value / max) * (zoneH - 18);
                float x = gauche + pas * i + (pas - bw) / 2f;
                float y = haut + zoneH - h;
                var barre = new RectangleF(x, y, bw, Math.Max(2f, h));
                bool pic = Donnees[i].Value == max;
                using (var br = new LinearGradientBrush(new RectangleF(x, y - 1, bw, h + 2), pic ? Theme.Orange : Theme.NavyHover, pic ? Theme.OrangeDark : Theme.Navy, 90f))
                    g.FillRectangle(br, barre);
                var sfc = new StringFormat { Alignment = StringAlignment.Center };
                using (var f = Theme.PoliceGras(8.5F)) g.DrawString(Theme.Compact(Donnees[i].Value), f, new SolidBrush(Theme.Navy), new RectangleF(x - 20, y - 18, bw + 40, 16), sfc);
                var sfl = new StringFormat { Alignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap };
                using (var f = Theme.Police(8.5F)) g.DrawString(Donnees[i].Key, f, new SolidBrush(Theme.Muted), new RectangleF(gauche + pas * i + 2, haut + zoneH + 6, pas - 4, 30), sfl);
            }
        }
    }

    /// <summary>Graphique en anneau avec légende.</summary>
    public class DonutChart : Control
    {
        public string Titre { get; set; }
        public List<KeyValuePair<string, decimal>> Donnees { get; set; }

        public DonutChart()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Donnees = new List<KeyValuePair<string, decimal>>();
            Titre = "";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.Clear(Theme.Bg);
            var r = new RectangleF(0.5f, 0.5f, Width - 2, Height - 2);
            using (var path = Theme.RectArrondi(r, 10))
            {
                g.FillPath(Brushes.White, path);
                using (var p = new Pen(Theme.Bordure)) g.DrawPath(p, path);
            }
            using (var f = Theme.PoliceGras(11F)) g.DrawString(Titre, f, new SolidBrush(Theme.Navy), 18, 14);
            decimal total = 0m;
            foreach (var d in Donnees) total += d.Value;
            if (total <= 0) return;
            float taille = Math.Min(Height - 80, Width * 0.5f);
            var cercle = new RectangleF(24, 54 + (Height - 54 - taille) / 2f - 10, taille, taille);
            float angle = -90f;
            for (int i = 0; i < Donnees.Count; i++)
            {
                float balayage = (float)(Donnees[i].Value / total) * 360f;
                using (var br = new SolidBrush(Theme.Palette[i % Theme.Palette.Length]))
                    g.FillPie(br, cercle.X, cercle.Y, cercle.Width, cercle.Height, angle, balayage);
                angle += balayage;
            }
            float t = taille * 0.58f;
            g.FillEllipse(Brushes.White, cercle.X + (taille - t) / 2f, cercle.Y + (taille - t) / 2f, t, t);
            var sfc = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using (var f = Theme.PoliceGras(18F)) g.DrawString(total.ToString("0"), f, new SolidBrush(Theme.Navy), new RectangleF(cercle.X, cercle.Y - 8, taille, taille), sfc);
            using (var f = Theme.Police(8.5F)) g.DrawString("chantiers", f, new SolidBrush(Theme.Muted), new RectangleF(cercle.X, cercle.Y + 16, taille, taille), sfc);
            float lx = cercle.Right + 24, ly = cercle.Y + taille / 2f - Donnees.Count * 13f;
            for (int i = 0; i < Donnees.Count; i++)
            {
                using (var br = new SolidBrush(Theme.Palette[i % Theme.Palette.Length])) g.FillRectangle(br, lx, ly + i * 26 + 4, 12, 12);
                using (var f = Theme.Police(9.5F)) g.DrawString(Donnees[i].Key + "  (" + Donnees[i].Value.ToString("0") + ")", f, new SolidBrush(Theme.Texte), lx + 20, ly + i * 26);
            }
        }
    }
}
