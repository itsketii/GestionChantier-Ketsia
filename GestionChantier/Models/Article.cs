using System;

namespace GestionChantier.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleNom { get; set; } = string.Empty;
        public string ArticleUnite { get; set; } = string.Empty;
        public decimal ArticlePrixUnitaire { get; set; }

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return ArticleNom + " (" + ArticleUnite + ")"; } }
    }
}
