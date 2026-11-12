using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class IntervenantDAO
    {
        private static Intervenant Map(MySqlDataReader r)
        {
            var x = new Intervenant();
            x.IntervenantId = DbHelper.Int(r, "intervenant_id");
            x.IntervenantNom = DbHelper.Str(r, "intervenant_nom");
            x.IntervenantSpecialite = DbHelper.Str(r, "intervenant_specialite");
            x.IntervenantTauxHoraire = DbHelper.Dec(r, "intervenant_taux_horaire");
            return x;
        }

        public List<Intervenant> ReadAll()
        {
            var liste = new List<Intervenant>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_intervenant_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public Intervenant ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_intervenant_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(Intervenant x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_intervenant_create"))
            {
                cmd.Parameters.AddWithValue("p_intervenant_nom", x.IntervenantNom);
                cmd.Parameters.AddWithValue("p_intervenant_specialite", x.IntervenantSpecialite);
                cmd.Parameters.AddWithValue("p_intervenant_taux_horaire", x.IntervenantTauxHoraire);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(Intervenant x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_intervenant_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.IntervenantId);
                cmd.Parameters.AddWithValue("p_intervenant_nom", x.IntervenantNom);
                cmd.Parameters.AddWithValue("p_intervenant_specialite", x.IntervenantSpecialite);
                cmd.Parameters.AddWithValue("p_intervenant_taux_horaire", x.IntervenantTauxHoraire);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_intervenant_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
