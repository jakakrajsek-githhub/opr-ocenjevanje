using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opr_ocenjevanje
{
    public class Klet : Prostor
    {
        public const int MaxStvari = 5;

        public Klet() : base("Kuhinja") { }

        public override void AddStvar(Stvar Stvar) //
        {
            if (Stvari.Count < MaxStvari)
                base.AddStvar(Stvar);
        }
    }
}
