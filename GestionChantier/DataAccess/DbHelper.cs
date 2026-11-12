using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace GestionChantier.DataAccess
{
    /// <summary>Petites méthodes utilitaires de lecture et d'appel de procédures stockées.</summary>
    public static class DbHelper
    {
        public static MySqlCommand Proc(MySqlConnection cn, string nom)
        {
            return new MySqlCommand(nom, cn) { CommandType = CommandType.StoredProcedure };
        }

        public static string Str(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? string.Empty : Convert.ToString(r.GetValue(i));
        }

        public static int Int(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0 : Convert.ToInt32(r.GetValue(i));
        }

        public static int? IntN(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            if (r.IsDBNull(i)) return null;
            return Convert.ToInt32(r.GetValue(i));
        }

        public static decimal Dec(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0m : Convert.ToDecimal(r.GetValue(i));
        }

        public static DateTime Date(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? DateTime.Today : Convert.ToDateTime(r.GetValue(i));
        }

        public static bool Bool(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return !r.IsDBNull(i) && Convert.ToInt32(r.GetValue(i)) != 0;
        }

        public static object Nz(int? v)
        {
            return v.HasValue ? (object)v.Value : DBNull.Value;
        }

        /// <summary>Transforme les erreurs MySQL courantes en messages clairs pour l'utilisateur.</summary>
        public static string Message(MySqlException ex)
        {
            switch (ex.Number)
            {
                case 1451:
                    return "Suppression impossible : cet enregistrement est utilisé par d'autres données (chantier, achat, règlement...).";
                case 1452:
                    return "Opération impossible : l'élément lié (client, chantier, facture...) n'existe pas.";
                case 1062:
                    return "Cet enregistrement existe déjà (identifiant ou couple déjà utilisé).";
                case 3819:
                case 4025:
                    return "Une règle de gestion n'est pas respectée (montant négatif, dates incohérentes, quantité nulle...).";
                case 1045:
                    return "Accès refusé à MySQL : vérifiez l'utilisateur et le mot de passe dans Connexion.cs.";
                case 1049:
                    return "La base de données est introuvable : exécutez d'abord le script GestionChantier_MySQL.sql.";
                case 0:
                    return "Impossible de joindre le serveur MySQL : vérifiez qu'il est démarré (XAMPP / WAMP).";
                default:
                    return "Erreur MySQL (" + ex.Number + ") : " + ex.Message;
            }
        }
    }
}
