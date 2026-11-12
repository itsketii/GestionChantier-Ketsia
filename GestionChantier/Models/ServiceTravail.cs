using System;

namespace GestionChantier.Models
{
    public class ServiceTravail
    {
        public int SerTravId { get; set; }
        public string SerTravNom { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int PhaseId { get; set; }
        public int IntervenantId { get; set; }
        public string ChantierNom { get; set; } = string.Empty;
        public string PhaseLibelle { get; set; } = string.Empty;
        public string IntervenantNom { get; set; } = string.Empty;

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return SerTravNom; } }
    }
}
