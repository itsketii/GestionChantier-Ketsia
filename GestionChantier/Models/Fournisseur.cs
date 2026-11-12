using System;

namespace GestionChantier.Models
{
    public class Fournisseur
    {
        public int FournisseurId { get; set; }
        public string FournisseurNom { get; set; } = string.Empty;
        public string FournisseurAdresse { get; set; } = string.Empty;
        public string FournisseurTelephone { get; set; } = string.Empty;
        public string FournisseurMail { get; set; } = string.Empty;

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return FournisseurNom; } }
    }
}
