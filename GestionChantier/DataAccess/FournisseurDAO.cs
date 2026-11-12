using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class FournisseurDAO
    {
        private static Fournisseur Map(MySqlDataReader r)
        {
            var x = new Fournisseur();
            x.FournisseurId = DbHelper.Int(r, "fournisseur_id");
            x.FournisseurNom = DbHelper.Str(r, "fournisseur_nom");
            x.FournisseurAdresse = DbHelper.Str(r, "fournisseur_adresse");
            x.FournisseurTelephone = DbHelper.Str(r, "fournisseur_telephone");
            x.FournisseurMail = DbHelper.Str(r, "fournisseur_mail");
            return x;
        }

        public List<Fournisseur> ReadAll()
        {
            var liste = new List<Fournisseur>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_fournisseur_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public Fournisseur ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_fournisseur_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(Fournisseur x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_fournisseur_create"))
            {
                cmd.Parameters.AddWithValue("p_fournisseur_nom", x.FournisseurNom);
                cmd.Parameters.AddWithValue("p_fournisseur_adresse", x.FournisseurAdresse);
                cmd.Parameters.AddWithValue("p_fournisseur_telephone", x.FournisseurTelephone);
                cmd.Parameters.AddWithValue("p_fournisseur_mail", x.FournisseurMail);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(Fournisseur x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_fournisseur_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.FournisseurId);
                cmd.Parameters.AddWithValue("p_fournisseur_nom", x.FournisseurNom);
                cmd.Parameters.AddWithValue("p_fournisseur_adresse", x.FournisseurAdresse);
                cmd.Parameters.AddWithValue("p_fournisseur_telephone", x.FournisseurTelephone);
                cmd.Parameters.AddWithValue("p_fournisseur_mail", x.FournisseurMail);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_fournisseur_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
