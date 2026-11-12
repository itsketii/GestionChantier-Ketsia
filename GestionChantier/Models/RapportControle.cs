using System;

namespace GestionChantier.Models
{
    public class RapportControle
    {
        public int RapportId { get; set; }
        public DateTime RapportDate { get; set; } = DateTime.Today;
        public string RapportRecommandation { get; set; } = string.Empty;
        public int ControleId { get; set; }
        public string SerTravNom { get; set; } = string.Empty;
        public DateTime ControleDate { get; set; }

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return "RC-" + RapportId.ToString("D4"); } }
    }
}
