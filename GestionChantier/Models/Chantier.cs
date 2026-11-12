using System;

namespace GestionChantier.Models
{
    public class Chantier
    {
        public int ChantierId { get; set; }
        public string ChantierNom { get; set; } = string.Empty;
        public string ChantierAdresse { get; set; } = string.Empty;
        public string ChantierStatut { get; set; } = string.Empty;
        public DateTime ChantierDateDebut { get; set; } = DateTime.Today;
        public DateTime ChantierDateFin { get; set; } = DateTime.Today;
        public decimal ChantierBudget { get; set; }
        public int ClientId { get; set; }
        public string ClientNom { get; set; } = string.Empty;
        public decimal DepenseHt { get; set; }

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return ChantierNom; } }
    }
}
