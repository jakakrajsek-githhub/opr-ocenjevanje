using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opr_ocenjevanje
{
    public class Dnevna_soba : Prostor
    {
        public const int MaxStvari = 5;

        public Dnevna_soba() : base("Dnevna soba") { }

        public override void AddStvar(Stvar Stvar) // Pogleda da v listboxu ni več kot 5 besed (enako pri vseh sobah)
        {
            if (Stvari.Count < MaxStvari)
                base.AddStvar(Stvar);
        }
    }
}
