namespace classLibrary
{
    public class Kopalnica : Prostor
    {
        public Kopalnica() : base("Kopalnica") { }

        //Kopalnica ima svojo omejitev kapacitete.
        public override int MaxStvari => 8;

        //Kopalnica razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (higiena)";
    }
}
