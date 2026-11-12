using System;

namespace GestionChantier.Models
{
    public class ControleQualite
    {
        public int ControleId { get; set; }
        public DateTime ControleDate { get; set; } = DateTime.Today;
        public int SerTravId { get; set; }
        public string SerTravNom { get; set; } = string.Empty;

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return "CQ-" + ControleId.ToString("D4") + " – " + SerTravNom; } }
    }
}
