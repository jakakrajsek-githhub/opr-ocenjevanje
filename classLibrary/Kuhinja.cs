namespace classLibrary
{
    public class Kuhinja : Prostor
    {
        public Kuhinja() : base("Kuhinja") { }

        public override int MaxStvari => 5;

        public override string Opis() => base.Opis() + " (vmesniki in posoda)";
    }
}
