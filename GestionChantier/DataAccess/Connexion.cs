using System;
using MySql.Data.MySqlClient;

namespace GestionChantier.DataAccess
{
    /// <summary>
    /// Point unique de connexion à MySQL.
    /// Modifiez la chaîne ci-dessous selon votre serveur (XAMPP / WAMP / MySQL Server).
    /// </summary>
    public static class Connexion
    {
        public static string ChaineConnexion =
            "Server=localhost;Port=3306;Database=dbGestionChantierKetsia;Uid=root;Pwd=;" +
            "CharSet=utf8mb4;SslMode=None;AllowPublicKeyRetrieval=True;ConnectionTimeout=8;";

        public static string NomBase
        {
            get { return new MySqlConnectionStringBuilder(ChaineConnexion).Database; }
        }

        public static string NomServeur
        {
            get { return new MySqlConnectionStringBuilder(ChaineConnexion).Server; }
        }

        public static MySqlConnection Ouvrir()
        {
            var cn = new MySqlConnection(ChaineConnexion);
            cn.Open();
            return cn;
        }

        public static bool Tester(out string erreur)
        {
            try
            {
                using (var cn = Ouvrir()) { erreur = ""; return true; }
            }
            catch (Exception ex)
            {
                erreur = ex.Message;
                return false;
            }
        }
    }
}
