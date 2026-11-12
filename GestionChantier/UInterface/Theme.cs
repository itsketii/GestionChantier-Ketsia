using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace GestionChantier.UInterface
{
    /// <summary>Charte graphique : bleu nuit + orange BTP.</summary>
    public static class Theme
    {
        public static readonly Color Navy = Color.FromArgb(11, 31, 58);
        public static readonly Color NavyLight = Color.FromArgb(24, 57, 102);
        public static readonly Color NavyHover = Color.FromArgb(31, 72, 124);
        public static readonly Color Orange = Color.FromArgb(242, 140, 27);
        public static readonly Color OrangeDark = Color.FromArgb(217, 119, 6);
        public static readonly Color OrangeSoft = Color.FromArgb(255, 237, 213);
        public static readonly Color Bg = Color.FromArgb(243, 245, 249);
        public static readonly Color Card = Color.White;
        public static readonly Color Texte = Color.FromArgb(31, 41, 55);
        public static readonly Color Muted = Color.FromArgb(107, 114, 128);
        public static readonly Color Bordure = Color.FromArgb(226, 230, 238);
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);
        public static readonly Color Succes = Color.FromArgb(22, 163, 74);
        public static readonly Color Bleu = Color.FromArgb(59, 130, 246);

        public static readonly Color[] Palette = { Navy, Orange, Bleu, Succes, Color.FromArgb(139, 92, 246), Color.FromArgb(148, 163, 184) };

        public static Font Police(float taille, FontStyle style = FontStyle.Regular)
        {
            return new Font("Segoe UI", taille, style);
        }

        public static Font PoliceGras(float taille)
        {
            return new Font("Segoe UI Semibold", taille, FontStyle.Bold);
        }

        public static string Fcfa(decimal v)
        {
            return v.ToString("N0", CultureInfo.CurrentCulture) + " FCFA";
        }

        /// <summary>Format compact : 185 M, 12,5 k...</summary>
        public static string Compact(decimal v)
        {
            decimal a = Math.Abs(v);
            if (a >= 1000000000m) return (v / 1000000000m).ToString("0.##", CultureInfo.CurrentCulture) + " Md";
            if (a >= 1000000m) return (v / 1000000m).ToString("0.#", CultureInfo.CurrentCulture) + " M";
            if (a >= 1000m) return (v / 1000m).ToString("0.#", CultureInfo.CurrentCulture) + " k";
            return v.ToString("0", CultureInfo.CurrentCulture);
        }

        public static GraphicsPath RectArrondi(RectangleF r, float rayon)
        {
            float d = rayon * 2f;
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
    }
}
