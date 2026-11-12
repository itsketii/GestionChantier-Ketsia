using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class AchatDAO
    {
        private static Achat Map(MySqlDataReader r)
        {
            var x = new Achat();
            x.AchatId = DbHelper.Int(r, "achat_id");
            x.AchatDate = DbHelper.Date(r, "achat_date");
            x.AchatDescription = DbHelper.Str(r, "achat_description");
            x.ChantierId = DbHelper.Int(r, "chantier_id");
            x.FactureId = DbHelper.Int(r, "facture_id");
            x.ChantierNom = DbHelper.Str(r, "chantier_nom");
            x.FactureRef = DbHelper.Str(r, "facture_ref");
            x.TotalHt = DbHelper.Dec(r, "total_ht");
            return x;
        }

        public List<Achat> ReadAll()
        {
            var liste = new List<Achat>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_achat_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public Achat ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_achat_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(Achat x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_achat_create"))
            {
                cmd.Parameters.AddWithValue("p_achat_date", x.AchatDate);
                cmd.Parameters.AddWithValue("p_achat_description", x.AchatDescription);
                cmd.Parameters.AddWithValue("p_chantier_id", x.ChantierId);
                cmd.Parameters.AddWithValue("p_facture_id", x.FactureId);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(Achat x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_achat_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.AchatId);
                cmd.Parameters.AddWithValue("p_achat_date", x.AchatDate);
                cmd.Parameters.AddWithValue("p_achat_description", x.AchatDescription);
                cmd.Parameters.AddWithValue("p_chantier_id", x.ChantierId);
                cmd.Parameters.AddWithValue("p_facture_id", x.FactureId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_achat_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
