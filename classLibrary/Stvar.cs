namespace classLibrary
{
    public class Stvar
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

        public override string ToString() => Ime;

        public override bool Equals(object obj)
        {
            return obj is Stvar druga && druga.Ime == Ime;
        }

        public override int GetHashCode()
        {
            return Ime?.GetHashCode() ?? 0;
        }
    }
}
