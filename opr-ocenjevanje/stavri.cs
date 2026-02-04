using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opr_ocenjevanje
{
    public class Stvar 
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
            }
        }

        public Stvar(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;

        public static bool operator ==(Stvar a, Stvar b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Name == b.Name;
        }

        public static bool operator !=(Stvar a, Stvar b) => !(a == b);

        public override bool Equals(object obj)
        {
            return obj is Stvar item && item.Name == Name;
        }

    }
}
