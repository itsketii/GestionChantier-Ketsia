using System;

namespace GestionChantier.Models
{
    public class Phase
    {
        public int PhaseId { get; set; }
        public string PhaseLibelle { get; set; } = string.Empty;
        public int PhaseOrdre { get; set; }
        public int ChantierId { get; set; }
        public string ChantierNom { get; set; } = string.Empty;

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return ChantierNom + " – " + PhaseLibelle; } }
    }
}
