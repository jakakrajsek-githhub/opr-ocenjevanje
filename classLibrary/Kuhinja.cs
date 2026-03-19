namespace classLibrary
{
    public class Kuhinja : Prostor
    {
        public Kuhinja() : base("Kuhinja") { }

        // Kuhinja ima svojo omejitev kapacitete.
        public override int MaxStvari => 5;

        // Kuhinja razširi osnovni opis prostora.
        public override string Opis() => base.Opis() + " (vmesniki in posoda)";
    }
}
