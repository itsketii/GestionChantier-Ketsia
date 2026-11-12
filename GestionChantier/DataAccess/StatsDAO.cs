using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace GestionChantier.DataAccess
{
    /// <summary>Requêtes de statistiques (tableau de bord) et de données pour les impressions.</summary>
    public class StatsDAO
    {
        // paramètres : nom1, valeur1, nom2, valeur2...
        public DataTable Requete(string sql, params object[] parametres)
        {
            using (var cn = Connexion.Ouvrir())
            using (var cmd = new MySqlCommand(sql, cn))
            {
                for (int i = 0; i + 1 < parametres.Length; i += 2)
                    cmd.Parameters.AddWithValue((string)parametres[i], parametres[i + 1]);
                var dt = new DataTable();
                new MySqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }

        public decimal Scalaire(string sql, params object[] parametres)
        {
            var dt = Requete(sql, parametres);
            if (dt.Rows.Count == 0 || dt.Rows[0][0] == DBNull.Value) return 0m;
            return Convert.ToDecimal(dt.Rows[0][0]);
        }

        public decimal NbChantiers() { return Scalaire("SELECT COUNT(*) FROM chantier"); }
        public decimal NbChantiersEnCours() { return Scalaire("SELECT COUNT(*) FROM chantier WHERE chantier_statut = 'En cours'"); }
        public decimal BudgetTotal() { return Scalaire("SELECT COALESCE(SUM(chantier_budget),0) FROM chantier"); }
        public decimal DepensesTtc() { return Scalaire("SELECT COALESCE(SUM(facture_total_ttc),0) FROM facture_achat"); }
        public decimal TotalReglements() { return Scalaire("SELECT COALESCE(SUM(reglement_montant),0) FROM reglement"); }
        public decimal NbIntervenants() { return Scalaire("SELECT COUNT(*) FROM intervenant"); }
        public decimal NbControles() { return Scalaire("SELECT COUNT(*) FROM controle_qualite"); }

        public List<KeyValuePair<string, decimal>> BudgetParChantier()
        {
            var l = new List<KeyValuePair<string, decimal>>();
            foreach (DataRow r in Requete("SELECT chantier_nom, chantier_budget FROM chantier ORDER BY chantier_budget DESC LIMIT 6").Rows)
                l.Add(new KeyValuePair<string, decimal>(Convert.ToString(r[0]), Convert.ToDecimal(r[1])));
            return l;
        }

        public List<KeyValuePair<string, decimal>> ChantiersParStatut()
        {
            var l = new List<KeyValuePair<string, decimal>>();
            foreach (DataRow r in Requete("SELECT chantier_statut, COUNT(*) FROM chantier GROUP BY chantier_statut ORDER BY COUNT(*) DESC").Rows)
                l.Add(new KeyValuePair<string, decimal>(Convert.ToString(r[0]), Convert.ToDecimal(r[1])));
            return l;
        }

        public List<KeyValuePair<string, decimal>> AchatsMensuels()
        {
            var l = new List<KeyValuePair<string, decimal>>();
            var dt = Requete("SELECT DATE_FORMAT(facture_date, '%Y-%m') AS mois, SUM(facture_total_ttc) AS total " +
                             "FROM facture_achat GROUP BY mois ORDER BY mois DESC LIMIT 8");
            var fr = new CultureInfo("fr-FR");
            foreach (DataRow r in dt.Rows)
            {
                DateTime d = DateTime.ParseExact(Convert.ToString(r[0]) + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                l.Insert(0, new KeyValuePair<string, decimal>(d.ToString("MMM yy", fr), Convert.ToDecimal(r[1])));
            }
            return l;
        }

        // ----- Données pour les impressions -----
        public DataTable InfoChantier(int id)
        {
            return Requete("SELECT c.*, cl.client_nom, cl.client_telephone, cl.client_email " +
                           "FROM chantier c INNER JOIN client cl ON cl.client_id = c.client_id WHERE c.chantier_id = @id", "@id", id);
        }

        public DataTable PhasesChantier(int id)
        {
            return Requete("SELECT phase_ordre, phase_libelle FROM phase WHERE chantier_id = @id ORDER BY phase_ordre", "@id", id);
        }

        public DataTable AchatsChantier(int id)
        {
            return Requete("SELECT a.achat_date, a.achat_description, " +
                           "COALESCE(SUM(ps.quantite * ps.prix_achat),0) AS total_ht " +
                           "FROM achat a LEFT JOIN porte_sur ps ON ps.achat_id = a.achat_id " +
                           "WHERE a.chantier_id = @id GROUP BY a.achat_id, a.achat_date, a.achat_description ORDER BY a.achat_date", "@id", id);
        }

        public decimal ReglementsChantier(int id)
        {
            return Scalaire("SELECT COALESCE(SUM(r.reglement_montant),0) FROM reglement r " +
                            "LEFT JOIN achat a ON a.achat_id = r.achat_id " +
                            "LEFT JOIN service_travail s ON s.ser_trav_id = r.ser_trav_id " +
                            "LEFT JOIN phase p ON p.phase_id = s.phase_id " +
                            "WHERE a.chantier_id = @id OR p.chantier_id = @id", "@id", id);
        }

        public DataTable InfoFacture(int id)
        {
            return Requete("SELECT f.*, fo.fournisseur_nom, fo.fournisseur_adresse, fo.fournisseur_telephone, fo.fournisseur_mail " +
                           "FROM facture_achat f INNER JOIN fournisseur fo ON fo.fournisseur_id = f.fournisseur_id WHERE f.facture_id = @id", "@id", id);
        }

        public DataTable LignesFacture(int id)
        {
            return Requete("SELECT a.achat_id, a.achat_description, ch.chantier_nom, ar.article_nom, ar.article_unite, ps.quantite, ps.prix_achat, " +
                           "ps.quantite * ps.prix_achat AS sous_total " +
                           "FROM achat a INNER JOIN chantier ch ON ch.chantier_id = a.chantier_id " +
                           "INNER JOIN porte_sur ps ON ps.achat_id = a.achat_id INNER JOIN article ar ON ar.article_id = ps.article_id " +
                           "WHERE a.facture_id = @id ORDER BY a.achat_id, ar.article_nom", "@id", id);
        }
    }
}
