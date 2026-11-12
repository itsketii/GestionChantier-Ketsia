using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class ServiceTravailDAO
    {
        private static ServiceTravail Map(MySqlDataReader r)
        {
            var x = new ServiceTravail();
            x.SerTravId = DbHelper.Int(r, "ser_trav_id");
            x.SerTravNom = DbHelper.Str(r, "ser_trav_nom");
            x.Type = DbHelper.Str(r, "type");
            x.PhaseId = DbHelper.Int(r, "phase_id");
            x.IntervenantId = DbHelper.Int(r, "intervenant_id");
            x.ChantierNom = DbHelper.Str(r, "chantier_nom");
            x.PhaseLibelle = DbHelper.Str(r, "phase_libelle");
            x.IntervenantNom = DbHelper.Str(r, "intervenant_nom");
            return x;
        }

        public List<ServiceTravail> ReadAll()
        {
            var liste = new List<ServiceTravail>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_service_travail_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public ServiceTravail ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_service_travail_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(ServiceTravail x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_service_travail_create"))
            {
                cmd.Parameters.AddWithValue("p_ser_trav_nom", x.SerTravNom);
                cmd.Parameters.AddWithValue("p_type", x.Type);
                cmd.Parameters.AddWithValue("p_phase_id", x.PhaseId);
                cmd.Parameters.AddWithValue("p_intervenant_id", x.IntervenantId);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(ServiceTravail x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_service_travail_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.SerTravId);
                cmd.Parameters.AddWithValue("p_ser_trav_nom", x.SerTravNom);
                cmd.Parameters.AddWithValue("p_type", x.Type);
                cmd.Parameters.AddWithValue("p_phase_id", x.PhaseId);
                cmd.Parameters.AddWithValue("p_intervenant_id", x.IntervenantId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_service_travail_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
