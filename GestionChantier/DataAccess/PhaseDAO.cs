using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class PhaseDAO
    {
        private static Phase Map(MySqlDataReader r)
        {
            var x = new Phase();
            x.PhaseId = DbHelper.Int(r, "phase_id");
            x.PhaseLibelle = DbHelper.Str(r, "phase_libelle");
            x.PhaseOrdre = DbHelper.Int(r, "phase_ordre");
            x.ChantierId = DbHelper.Int(r, "chantier_id");
            x.ChantierNom = DbHelper.Str(r, "chantier_nom");
            return x;
        }

        public List<Phase> ReadAll()
        {
            var liste = new List<Phase>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_phase_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public Phase ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_phase_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(Phase x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_phase_create"))
            {
                cmd.Parameters.AddWithValue("p_phase_libelle", x.PhaseLibelle);
                cmd.Parameters.AddWithValue("p_phase_ordre", x.PhaseOrdre);
                cmd.Parameters.AddWithValue("p_chantier_id", x.ChantierId);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(Phase x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_phase_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.PhaseId);
                cmd.Parameters.AddWithValue("p_phase_libelle", x.PhaseLibelle);
                cmd.Parameters.AddWithValue("p_phase_ordre", x.PhaseOrdre);
                cmd.Parameters.AddWithValue("p_chantier_id", x.ChantierId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_phase_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
