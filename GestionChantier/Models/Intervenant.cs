using System;

namespace GestionChantier.Models
{
    public class Intervenant
    {
        public int IntervenantId { get; set; }
        public string IntervenantNom { get; set; } = string.Empty;
        public string IntervenantSpecialite { get; set; } = string.Empty;
        public decimal IntervenantTauxHoraire { get; set; }

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return IntervenantNom + " (" + IntervenantSpecialite + ")"; } }
    }
}
