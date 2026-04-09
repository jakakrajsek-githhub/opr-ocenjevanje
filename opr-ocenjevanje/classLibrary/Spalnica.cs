namespace classLibrary
{
    public class Spalnica : Prostor
    {
        public Spalnica() : base("Spalnica") { }

        //Spalnica ima svojo omejitev kapacitete.
        public override int MaxStvari => 12;

        //Spalnica razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (počitek)";
    }
}
