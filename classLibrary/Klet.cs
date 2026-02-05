namespace classLibrary
{
    public class Klet : Prostor
    {
        public Klet() : base("Klet") { }

        // Polimorfizem (override): Klet ima svojo omejitev kapacitete.
        public override int MaxStvari => 10;

        // Polimorfizem (override): Klet razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (shranjevanje)";
    }
}
