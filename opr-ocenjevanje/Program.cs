using classLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace opr_ocenjevanje
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        // Glavni seznam prostorov (uporablja ga UI).
        public static List<classLibrary.Prostor> Prostori { get; } = new List<classLibrary.Prostor>
        {
            new Kuhinja(),
            new DnevnaSoba(),
            new Spalnica(),
            new Kopalnica(),
            new Garaza(),
            new Klet(),
        };

        // Združljivost za stare reference (npr. Program.Prostors iz prve faze).
        public static List<classLibrary.Prostor> Prostors => Prostori;

        public static classLibrary.Prostor GetProstorByName(string ime)
        {
            return Prostori.Find(prostor => prostor.ImeProstora == ime);
        }
    }
}
