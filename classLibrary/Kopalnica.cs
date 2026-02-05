namespace classLibrary
{
    public class Kopalnica : Prostor
    {
        public Kopalnica() : base("Kopalnica") { }

        // Polimorfizem (override): Kopalnica ima svojo omejitev kapacitete.
        public override int MaxStvari => 4;

        // Polimorfizem (override): Kopalnica razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (higiena)";
    }
}
