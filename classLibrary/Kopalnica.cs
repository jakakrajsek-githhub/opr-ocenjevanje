namespace classLibrary
{
    public class Kopalnica : Prostor
    {
        public Kopalnica() : base("Kopalnica") { }

        public override int MaxStvari => 4;

        public override string Opis() => base.Opis() + " (higiena)";
    }
}
