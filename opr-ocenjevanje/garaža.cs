using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opr_ocenjevanje
{
    public class Garaža : Prostor
    {
        public const int MaxStvari = 5;

        public Garaža() : base("Garaža") { }

        public override void AddStvar(Stvar Stvar)
        {
            if (Stvari.Count < MaxStvari)
                base.AddStvar(Stvar);
        }
    }
}
