namespace classLibrary
{
    public class DnevnaSoba : Prostor
    {
        public DnevnaSoba() : base("Dnevna soba") { }

        public override int MaxStvari => 6;

        // Polimorfizem (override): Dnevna soba razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (udobje in druženje)";
    }
}
