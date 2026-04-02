namespace classLibrary
{
    public class Klet : Prostor
    {
        public Klet() : base("Klet") { }

        // Klet ima svojo omejitev kapacitete.
        public override int MaxStvari => 16;

        //Klet razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (shranjevanje)";
    }
}
