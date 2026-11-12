using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class ReglementDAO
    {
        private static Reglement Map(MySqlDataReader r)
        {
            var x = new Reglement();
            x.ReglementId = DbHelper.Int(r, "reglement_id");
            x.ReglementDate = DbHelper.Date(r, "reglement_date");
            x.ReglementMontant = DbHelper.Dec(r, "reglement_montant");
            x.AchatId = DbHelper.IntN(r, "achat_id");
            x.SerTravId = DbHelper.IntN(r, "ser_trav_id");
            x.AchatLibelle = DbHelper.Str(r, "achat_libelle");
            x.SerTravNom = DbHelper.Str(r, "ser_trav_nom");
            return x;
        }

        public List<Reglement> ReadAll()
        {
            var liste = new List<Reglement>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_reglement_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public Reglement ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_reglement_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(Reglement x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_reglement_create"))
            {
                cmd.Parameters.AddWithValue("p_reglement_date", x.ReglementDate);
                cmd.Parameters.AddWithValue("p_reglement_montant", x.ReglementMontant);
                cmd.Parameters.AddWithValue("p_achat_id", DbHelper.Nz(x.AchatId));
                cmd.Parameters.AddWithValue("p_ser_trav_id", DbHelper.Nz(x.SerTravId));
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(Reglement x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_reglement_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.ReglementId);
                cmd.Parameters.AddWithValue("p_reglement_date", x.ReglementDate);
                cmd.Parameters.AddWithValue("p_reglement_montant", x.ReglementMontant);
                cmd.Parameters.AddWithValue("p_achat_id", DbHelper.Nz(x.AchatId));
                cmd.Parameters.AddWithValue("p_ser_trav_id", DbHelper.Nz(x.SerTravId));
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_reglement_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
