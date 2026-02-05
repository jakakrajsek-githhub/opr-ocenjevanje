using System.Collections.Generic;

namespace classLibrary
{
    // Abstraktni razred + implementacija vmesnikov (IOpisljivo, IProstorInventar).
    public abstract class Prostor : IOpisljivo, IProstorInventar
    {
        private readonly List<Stvar> _stvari = new List<Stvar>();

        public static int SteviloProstorov { get; private set; }
        public string ImeProstora { get; }

        // Polimorfizem: vsak podrazred sam določi maksimalno število stvari.
        public abstract int MaxStvari { get; }

        protected Prostor(string imeProstora)
        {
            ImeProstora = imeProstora;
            SteviloProstorov++;
        }

        public IReadOnlyList<Stvar> VseStvari => _stvari.AsReadOnly();

        // Indekser: dostop do posamezne stvari v prostoru po številki.
        public Stvar this[int index]
        {
            get => _stvari[index];
            set => _stvari[index] = value;
        }

        public virtual bool DodajStvar(Stvar stvar)
        {
            if (stvar == null || _stvari.Count >= MaxStvari)
            {
                return false;
            }

            _stvari.Add(stvar);
            return true;
        }

        public virtual bool OdstraniStvar(Stvar stvar)
        {
            return _stvari.Remove(stvar);
        }

        // Polimorfizem: podrazredi lahko prepišejo opis in dodajo svojo specializacijo.
        public virtual string Opis()
        {
            return $"{ImeProstora}: {_stvari.Count}/{MaxStvari} stvari";
        }

        public override string ToString() => ImeProstora;
    }
}
