using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opr_ocenjevanje
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
             
        }
        public static List<Prostor> Prostors { get; } = new List<Prostor>()
        {
            new Kuhinja(),
            new Dnevna_soba(),
            new Spalnica(),
            new Kopalnica(),
            new Garaža(),
            new Klet(),
        };

        public static Prostor GetProstorByName(string name)//Poišče sobo po imenu
        {
            return Prostors.Find(r => r.ProstorName == name);
        }
    }
}
