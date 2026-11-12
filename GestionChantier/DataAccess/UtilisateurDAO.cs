using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class UtilisateurDAO
    {
        private static Utilisateur Map(MySqlDataReader r)
        {
            var x = new Utilisateur();
            x.UtilisateurId = DbHelper.Int(r, "utilisateur_id");
            x.UtilisateurLogin = DbHelper.Str(r, "utilisateur_login");
            x.UtilisateurNomComplet = DbHelper.Str(r, "utilisateur_nom_complet");
            x.UtilisateurRole = DbHelper.Str(r, "utilisateur_role");
            x.UtilisateurActif = DbHelper.Bool(r, "utilisateur_actif");
            return x;
        }

        public List<Utilisateur> ReadAll()
        {
            var liste = new List<Utilisateur>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_utilisateur_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public Utilisateur ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_utilisateur_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(Utilisateur x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_utilisateur_create"))
            {
                cmd.Parameters.AddWithValue("p_utilisateur_login", x.UtilisateurLogin);
                cmd.Parameters.AddWithValue("p_utilisateur_nom_complet", x.UtilisateurNomComplet);
                cmd.Parameters.AddWithValue("p_mot_de_passe", x.MotDePasse);
                cmd.Parameters.AddWithValue("p_utilisateur_role", x.UtilisateurRole);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(Utilisateur x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_utilisateur_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.UtilisateurId);
                cmd.Parameters.AddWithValue("p_utilisateur_nom_complet", x.UtilisateurNomComplet);
                cmd.Parameters.AddWithValue("p_utilisateur_role", x.UtilisateurRole);
                cmd.Parameters.AddWithValue("p_utilisateur_actif", (x.UtilisateurActif ? 1 : 0));
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_utilisateur_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // Connexion : retourne l'utilisateur si identifiant + mot de passe sont corrects (compte actif), sinon null
        public Utilisateur Authentifier(string login, string motDePasse)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_utilisateur_authentifier"))
            {
                cmd.Parameters.AddWithValue("p_utilisateur_login", login);
                cmd.Parameters.AddWithValue("p_mot_de_passe", motDePasse);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        // Retourne true si l'ancien mot de passe était correct et que le changement a été effectué
        public bool ChangerMotDePasse(int id, string ancien, string nouveau)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_utilisateur_changer_mot_de_passe"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.Parameters.AddWithValue("p_ancien_mot_de_passe", ancien);
                cmd.Parameters.AddWithValue("p_nouveau_mot_de_passe", nouveau);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
