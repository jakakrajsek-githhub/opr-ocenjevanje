namespace classLibrary
{
    public class Spalnica : Prostor
    {
        public Spalnica() : base("Spalnica") { }

        // Polimorfizem (override): Spalnica ima svojo omejitev kapacitete.
        public override int MaxStvari => 7;

        // Polimorfizem (override): Spalnica razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (počitek)";
    }
}
