using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class RapportControleDAO
    {
        private static RapportControle Map(MySqlDataReader r)
        {
            var x = new RapportControle();
            x.RapportId = DbHelper.Int(r, "rapport_id");
            x.RapportDate = DbHelper.Date(r, "rapport_date");
            x.RapportRecommandation = DbHelper.Str(r, "rapport_recommandation");
            x.ControleId = DbHelper.Int(r, "controle_id");
            x.SerTravNom = DbHelper.Str(r, "ser_trav_nom");
            x.ControleDate = DbHelper.Date(r, "controle_date");
            return x;
        }

        public List<RapportControle> ReadAll()
        {
            var liste = new List<RapportControle>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_rapport_controle_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public RapportControle ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_rapport_controle_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(RapportControle x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_rapport_controle_create"))
            {
                cmd.Parameters.AddWithValue("p_rapport_date", x.RapportDate);
                cmd.Parameters.AddWithValue("p_rapport_recommandation", x.RapportRecommandation);
                cmd.Parameters.AddWithValue("p_controle_id", x.ControleId);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(RapportControle x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_rapport_controle_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.RapportId);
                cmd.Parameters.AddWithValue("p_rapport_date", x.RapportDate);
                cmd.Parameters.AddWithValue("p_rapport_recommandation", x.RapportRecommandation);
                cmd.Parameters.AddWithValue("p_controle_id", x.ControleId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_rapport_controle_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
