using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class ChantierDAO
    {
        private static Chantier Map(MySqlDataReader r)
        {
            var x = new Chantier();
            x.ChantierId = DbHelper.Int(r, "chantier_id");
            x.ChantierNom = DbHelper.Str(r, "chantier_nom");
            x.ChantierAdresse = DbHelper.Str(r, "chantier_adresse");
            x.ChantierStatut = DbHelper.Str(r, "chantier_statut");
            x.ChantierDateDebut = DbHelper.Date(r, "chantier_date_debut");
            x.ChantierDateFin = DbHelper.Date(r, "chantier_date_fin");
            x.ChantierBudget = DbHelper.Dec(r, "chantier_budget");
            x.ClientId = DbHelper.Int(r, "client_id");
            x.ClientNom = DbHelper.Str(r, "client_nom");
            x.DepenseHt = DbHelper.Dec(r, "depense_ht");
            return x;
        }

        public List<Chantier> ReadAll()
        {
            var liste = new List<Chantier>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_chantier_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public Chantier ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_chantier_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(Chantier x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_chantier_create"))
            {
                cmd.Parameters.AddWithValue("p_chantier_nom", x.ChantierNom);
                cmd.Parameters.AddWithValue("p_chantier_adresse", x.ChantierAdresse);
                cmd.Parameters.AddWithValue("p_chantier_statut", x.ChantierStatut);
                cmd.Parameters.AddWithValue("p_chantier_date_debut", x.ChantierDateDebut);
                cmd.Parameters.AddWithValue("p_chantier_date_fin", x.ChantierDateFin);
                cmd.Parameters.AddWithValue("p_chantier_budget", x.ChantierBudget);
                cmd.Parameters.AddWithValue("p_client_id", x.ClientId);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(Chantier x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_chantier_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.ChantierId);
                cmd.Parameters.AddWithValue("p_chantier_nom", x.ChantierNom);
                cmd.Parameters.AddWithValue("p_chantier_adresse", x.ChantierAdresse);
                cmd.Parameters.AddWithValue("p_chantier_statut", x.ChantierStatut);
                cmd.Parameters.AddWithValue("p_chantier_date_debut", x.ChantierDateDebut);
                cmd.Parameters.AddWithValue("p_chantier_date_fin", x.ChantierDateFin);
                cmd.Parameters.AddWithValue("p_chantier_budget", x.ChantierBudget);
                cmd.Parameters.AddWithValue("p_client_id", x.ClientId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_chantier_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
