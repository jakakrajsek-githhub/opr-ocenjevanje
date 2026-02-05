namespace classLibrary
{
    public class Klet : Prostor
    {
        public Klet() : base("Klet") { }

        public override int MaxStvari => 10;

        public override string Opis() => base.Opis() + " (shranjevanje)";
    }
}
