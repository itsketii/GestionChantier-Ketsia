using GestionChantier.Models;

namespace GestionChantier.UInterface
{
    /// <summary>Utilisateur actuellement connecté.</summary>
    public static class Session
    {
        public static Utilisateur Courant { get; set; }

        public static bool EstAdmin
        {
            get { return Courant != null && Courant.UtilisateurRole == "Admin"; }
        }

        public static bool PeutModifier
        {
            get { return Courant != null && Courant.UtilisateurRole != "Consultant"; }
        }
    }
}
