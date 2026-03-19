namespace classLibrary
{
    public class Garaza : Prostor
    {
        public Garaza() : base("Garaža") { }

        //Garaža ima svojo omejitev kapacitete.
        public override int MaxStvari => 8;

        //Garaža razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (orodje in prevoz)";
    }
}
