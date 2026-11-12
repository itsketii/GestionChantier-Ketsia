using System;

namespace GestionChantier.Models
{
    public class Achat
    {
        public int AchatId { get; set; }
        public DateTime AchatDate { get; set; } = DateTime.Today;
        public string AchatDescription { get; set; } = string.Empty;
        public int ChantierId { get; set; }
        public int FactureId { get; set; }
        public string ChantierNom { get; set; } = string.Empty;
        public string FactureRef { get; set; } = string.Empty;
        public decimal TotalHt { get; set; }

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return "ACH-" + AchatId.ToString("D4") + " – " + AchatDescription; } }
    }
}
