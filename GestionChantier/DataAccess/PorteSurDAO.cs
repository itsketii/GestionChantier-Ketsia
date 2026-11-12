using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class PorteSurDAO
    {
        private static PorteSur Map(MySqlDataReader r)
        {
            var x = new PorteSur();
            x.AchatId = DbHelper.Int(r, "achat_id");
            x.ArticleId = DbHelper.Int(r, "article_id");
            x.Quantite = DbHelper.Int(r, "quantite");
            x.PrixAchat = DbHelper.Dec(r, "prix_achat");
            x.AchatLibelle = DbHelper.Str(r, "achat_libelle");
            x.ArticleNom = DbHelper.Str(r, "article_nom");
            x.ArticleUnite = DbHelper.Str(r, "article_unite");
            x.SousTotal = DbHelper.Dec(r, "sous_total");
            return x;
        }

        public List<PorteSur> ReadAll()
        {
            var liste = new List<PorteSur>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_porte_sur_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public List<PorteSur> ReadByAchat(int achatId)
        {
            var liste = new List<PorteSur>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_porte_sur_list_by_achat"))
            {
                cmd.Parameters.AddWithValue("p_achat_id", achatId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public PorteSur ReadById(int achatId, int articleId)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_porte_sur_get"))
            {
                cmd.Parameters.AddWithValue("p_achat_id", achatId);
                cmd.Parameters.AddWithValue("p_article_id", articleId);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public void Create(PorteSur x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_porte_sur_create"))
            {
                cmd.Parameters.AddWithValue("p_achat_id", x.AchatId);
                cmd.Parameters.AddWithValue("p_article_id", x.ArticleId);
                cmd.Parameters.AddWithValue("p_quantite", x.Quantite);
                cmd.Parameters.AddWithValue("p_prix_achat", x.PrixAchat);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PorteSur x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_porte_sur_update"))
            {
                cmd.Parameters.AddWithValue("p_achat_id", x.AchatId);
                cmd.Parameters.AddWithValue("p_article_id", x.ArticleId);
                cmd.Parameters.AddWithValue("p_quantite", x.Quantite);
                cmd.Parameters.AddWithValue("p_prix_achat", x.PrixAchat);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int achatId, int articleId)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_porte_sur_delete"))
            {
                cmd.Parameters.AddWithValue("p_achat_id", achatId);
                cmd.Parameters.AddWithValue("p_article_id", articleId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
