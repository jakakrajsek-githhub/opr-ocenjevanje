namespace classLibrary
{
    public class Garaza : Prostor
    {
        public Garaza() : base("Garaža") { }


        public override int MaxStvari => 8;

        // Garaža razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (orodje in prevoz)";
    }
}
