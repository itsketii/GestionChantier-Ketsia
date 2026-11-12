using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using GestionChantier.UInterface;

namespace GestionChantier
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Culture française avec espace simple comme séparateur de milliers
            var fr = (CultureInfo)new CultureInfo("fr-FR").Clone();
            fr.NumberFormat.NumberGroupSeparator = " ";
            fr.NumberFormat.CurrencyGroupSeparator = " ";
            CultureInfo.DefaultThreadCurrentCulture = fr;
            CultureInfo.DefaultThreadCurrentUICulture = fr;
            Thread.CurrentThread.CurrentCulture = fr;
            Thread.CurrentThread.CurrentUICulture = fr;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (var login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK) break;
                }
                using (var principal = new FrmPrincipal())
                {
                    Application.Run(principal);
                    if (!principal.Deconnecte) break;
                }
            }
        }
    }
}
