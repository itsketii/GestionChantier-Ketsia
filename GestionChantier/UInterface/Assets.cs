using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace GestionChantier.UInterface
{
    /// <summary>Chargement des images intégrées au projet (dossier Assets).</summary>
    public static class Assets
    {
        private static readonly Dictionary<string, Image> _cache = new Dictionary<string, Image>();

        public static Image Image(string nom)
        {
            Image img;
            if (_cache.TryGetValue(nom, out img)) return img;
            using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Assets." + nom))
            {
                img = s == null ? null : System.Drawing.Image.FromStream(s);
            }
            _cache[nom] = img;
            return img;
        }
    }
}
