using classLibrary;
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

        public static List<Prostor> Prostori { get; } = new List<Prostor>
        {
            new Kuhinja(),
            new DnevnaSoba(),
            new Spalnica(),
            new Kopalnica(),
            new Garaza(),
            new Klet(),
        };

        public static Prostor GetProstorByName(string ime)
        {
            return Prostori.Find(prostor => prostor.ImeProstora == ime);
        }
    }
}
