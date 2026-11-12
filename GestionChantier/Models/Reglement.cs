using System;

namespace GestionChantier.Models
{
    public class Reglement
    {
        public int ReglementId { get; set; }
        public DateTime ReglementDate { get; set; } = DateTime.Today;
        public decimal ReglementMontant { get; set; }
        public int? AchatId { get; set; }
        public int? SerTravId { get; set; }
        public string AchatLibelle { get; set; } = string.Empty;
        public string SerTravNom { get; set; } = string.Empty;

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return "RG-" + ReglementId.ToString("D4"); } }
    }
}
