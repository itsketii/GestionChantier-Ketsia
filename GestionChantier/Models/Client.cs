using System;

namespace GestionChantier.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientNom { get; set; } = string.Empty;
        public string ClientTelephone { get; set; } = string.Empty;
        public string ClientEmail { get; set; } = string.Empty;

        // Texte affiché dans les listes déroulantes
        public string Libelle { get { return ClientNom; } }
    }
}
