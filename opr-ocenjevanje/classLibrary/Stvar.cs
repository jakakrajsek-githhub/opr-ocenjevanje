namespace classLibrary
{
    public class Stvar : System.IEquatable<Stvar>
    {
        private string _ime;

        public string Ime
        {
            get => _ime;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _ime = value.Trim();
                }
            }
        }

        public Stvar(string ime)
        {
            Ime = ime;
        }

        // Objektna metoda: vrne novo instanco iste stvari.
        public Stvar Kloniraj()
        {
            return new Stvar(Ime);
        }

        public override string ToString() => Ime;

        public bool Equals(Stvar druga)
        {
            if (ReferenceEquals(null, druga))
                return false;

            if (ReferenceEquals(this, druga))
                return true;

            return string.Equals(druga.Ime, Ime, System.StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Stvar);
        }

        public override int GetHashCode()
        {
            return (Ime ?? string.Empty).ToUpperInvariant().GetHashCode();
        }

        // Preoblaganje operatorjev za enostavno primerjanje stvari.
        public static bool operator ==(Stvar leva, Stvar desna)
        {
            if (ReferenceEquals(leva, desna))
                return true;

            if (ReferenceEquals(leva, null) || ReferenceEquals(desna, null))
                return false;

            return leva.Equals(desna);
        }

        public static bool operator !=(Stvar leva, Stvar desna) => !(leva == desna);
    }
}
