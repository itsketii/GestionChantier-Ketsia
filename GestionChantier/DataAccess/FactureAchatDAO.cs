using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class FactureAchatDAO
    {
        private static FactureAchat Map(MySqlDataReader r)
        {
            var x = new FactureAchat();
            x.FactureId = DbHelper.Int(r, "facture_id");
            x.FactureTotalTtc = DbHelper.Dec(r, "facture_total_ttc");
            x.FactureDate = DbHelper.Date(r, "facture_date");
            x.FournisseurId = DbHelper.Int(r, "fournisseur_id");
            x.FournisseurNom = DbHelper.Str(r, "fournisseur_nom");
            return x;
        }

        public List<FactureAchat> ReadAll()
        {
            var liste = new List<FactureAchat>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_facture_achat_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public FactureAchat ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_facture_achat_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(FactureAchat x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_facture_achat_create"))
            {
                cmd.Parameters.AddWithValue("p_facture_total_ttc", x.FactureTotalTtc);
                cmd.Parameters.AddWithValue("p_facture_date", x.FactureDate);
                cmd.Parameters.AddWithValue("p_fournisseur_id", x.FournisseurId);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(FactureAchat x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_facture_achat_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.FactureId);
                cmd.Parameters.AddWithValue("p_facture_total_ttc", x.FactureTotalTtc);
                cmd.Parameters.AddWithValue("p_facture_date", x.FactureDate);
                cmd.Parameters.AddWithValue("p_fournisseur_id", x.FournisseurId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_facture_achat_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
