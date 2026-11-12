using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GestionChantier.UInterface
{
    /// <summary>Export d'une grille au format CSV (s'ouvre directement dans Excel).</summary>
    public static class CsvExporter
    {
        public static void Exporter(DataGridView dgv, string nomFichier)
        {
            if (dgv.Rows.Count == 0) { UiHelper.Avertir("Il n'y a aucune donnée à exporter."); return; }
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Fichier CSV (*.csv)|*.csv";
                dlg.FileName = nomFichier + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";
                if (dlg.ShowDialog() != DialogResult.OK) return;
                try
                {
                    var sb = new StringBuilder();
                    var colonnes = new System.Collections.Generic.List<DataGridViewColumn>();
                    foreach (DataGridViewColumn c in dgv.Columns) if (c.Visible) colonnes.Add(c);
                    sb.AppendLine(string.Join(";", colonnes.ConvertAll(c => Echapper(c.HeaderText))));
                    foreach (DataGridViewRow r in dgv.Rows)
                    {
                        var vals = new System.Collections.Generic.List<string>();
                        foreach (var c in colonnes)
                        {
                            object v = r.Cells[c.Index].Value;
                            string t = v is bool ? ((bool)v ? "Oui" : "Non")
                                     : v is DateTime ? ((DateTime)v).ToString("dd/MM/yyyy")
                                     : Convert.ToString(v);
                            vals.Add(Echapper(t));
                        }
                        sb.AppendLine(string.Join(";", vals));
                    }
                    File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
                    UiHelper.Info("Export terminé :\n" + dlg.FileName);
                }
                catch (Exception ex) { UiHelper.Erreur(ex); }
            }
        }

        private static string Echapper(string s)
        {
            if (s == null) return "";
            s = s.Replace("\r", " ").Replace("\n", " ");
            return (s.Contains(";") || s.Contains("\"")) ? "\"" + s.Replace("\"", "\"\"") + "\"" : s;
        }
    }
}
