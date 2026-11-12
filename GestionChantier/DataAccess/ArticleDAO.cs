using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GestionChantier.Models;

namespace GestionChantier.DataAccess
{
    public class ArticleDAO
    {
        private static Article Map(MySqlDataReader r)
        {
            var x = new Article();
            x.ArticleId = DbHelper.Int(r, "article_id");
            x.ArticleNom = DbHelper.Str(r, "article_nom");
            x.ArticleUnite = DbHelper.Str(r, "article_unite");
            x.ArticlePrixUnitaire = DbHelper.Dec(r, "article_prix_unitaire");
            return x;
        }

        public List<Article> ReadAll()
        {
            var liste = new List<Article>();
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_article_list"))
            {
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) liste.Add(Map(r));
                }
            }
            return liste;
        }

        public Article ReadById(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_article_get"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? Map(r) : null;
                }
            }
        }

        public int Create(Article x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_article_create"))
            {
                cmd.Parameters.AddWithValue("p_article_nom", x.ArticleNom);
                cmd.Parameters.AddWithValue("p_article_unite", x.ArticleUnite);
                cmd.Parameters.AddWithValue("p_article_prix_unitaire", x.ArticlePrixUnitaire);
                var o = cmd.Parameters.Add("p_id", MySqlDbType.Int32);
                o.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(o.Value);
            }
        }

        public void Update(Article x)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_article_update"))
            {
                cmd.Parameters.AddWithValue("p_id", x.ArticleId);
                cmd.Parameters.AddWithValue("p_article_nom", x.ArticleNom);
                cmd.Parameters.AddWithValue("p_article_unite", x.ArticleUnite);
                cmd.Parameters.AddWithValue("p_article_prix_unitaire", x.ArticlePrixUnitaire);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = DbHelper.Proc(cn, "sp_article_delete"))
            {
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
