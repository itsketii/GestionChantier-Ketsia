using System;

namespace GestionChantier.Models
{
    public class Utilisateur
    {
        public int UtilisateurId { get; set; }
        public string UtilisateurLogin { get; set; } = string.Empty;
        public string UtilisateurNomComplet { get; set; } = string.Empty;
        public string MotDePasse { get; set; } = string.Empty;
        public string UtilisateurRole { get; set; } = string.Empty;
        public bool UtilisateurActif { get; set; }

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return UtilisateurNomComplet; } }
    }
}
