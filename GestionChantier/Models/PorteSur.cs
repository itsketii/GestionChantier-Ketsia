using System;

namespace GestionChantier.Models
{
    public class PorteSur
    {
        public int AchatId { get; set; }
        public int ArticleId { get; set; }
        public int Quantite { get; set; }
        public decimal PrixAchat { get; set; }
        public string AchatLibelle { get; set; } = string.Empty;
        public string ArticleNom { get; set; } = string.Empty;
        public string ArticleUnite { get; set; } = string.Empty;
        public decimal SousTotal { get; set; }

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return AchatId + "/" + ArticleId; } }
    }
}
