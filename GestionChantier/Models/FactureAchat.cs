using System;

namespace GestionChantier.Models
{
    public class FactureAchat
    {
        public int FactureId { get; set; }
        public decimal FactureTotalTtc { get; set; }
        public DateTime FactureDate { get; set; } = DateTime.Today;
        public int FournisseurId { get; set; }
        public string FournisseurNom { get; set; } = string.Empty;
        public string Reference { get { return "FA-" + FactureId.ToString("D4"); } }

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return Reference + " – " + FournisseurNom; } }
    }
}
