namespace classLibrary
{
    public class Spalnica : Prostor
    {
        public Spalnica() : base("Spalnica") { }

        public override int MaxStvari => 7;

        public override string Opis() => base.Opis() + " (počitek)";
    }
}
