using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class ControleQualiteDAO
    {
        private static ControleQualite Map(MySqlDataReader r)
        {
            var x = new ControleQualite();
            x.ControleId = DbHelper.Int(r, "controle_id");
            x.ControleDate = DbHelper.Date(r, "controle_date");
            x.SerTravId = DbHelper.Int(r, "ser_trav_id");
            x.SerTravNom = DbHelper.Str(r, "ser_trav_nom");
            return x;
        }

        public List<ControleQualite> ReadAll()
        {
            var liste = new List<ControleQualite>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_controle_qualite_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public ControleQualite ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_controle_qualite_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(ControleQualite x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_controle_qualite_create"))
            {
                cmd.Parameters.AddWithValue("p_controle_date", x.ControleDate);
                cmd.Parameters.AddWithValue("p_ser_trav_id", x.SerTravId);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(ControleQualite x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_controle_qualite_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.ControleId);
                cmd.Parameters.AddWithValue("p_controle_date", x.ControleDate);
                cmd.Parameters.AddWithValue("p_ser_trav_id", x.SerTravId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_controle_qualite_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
