using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class ClientDAO
    {
        private static Client Map(MySqlDataReader r)
        {
            var x = new Client();
            x.ClientId = DbHelper.Int(r, "client_id");
            x.ClientNom = DbHelper.Str(r, "client_nom");
            x.ClientTelephone = DbHelper.Str(r, "client_telephone");
            x.ClientEmail = DbHelper.Str(r, "client_email");
            return x;
        }

        public List<Client> ReadAll()
        {
            var liste = new List<Client>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_client_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public Client ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_client_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(Client x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_client_create"))
            {
                cmd.Parameters.AddWithValue("p_client_nom", x.ClientNom);
                cmd.Parameters.AddWithValue("p_client_telephone", x.ClientTelephone);
                cmd.Parameters.AddWithValue("p_client_email", x.ClientEmail);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(Client x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_client_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.ClientId);
                cmd.Parameters.AddWithValue("p_client_nom", x.ClientNom);
                cmd.Parameters.AddWithValue("p_client_telephone", x.ClientTelephone);
                cmd.Parameters.AddWithValue("p_client_email", x.ClientEmail);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_client_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
