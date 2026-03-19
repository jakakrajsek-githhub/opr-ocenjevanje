using System;
using System.Collections.Generic;

namespace classLibrary
{
    // Delegate za dogodke
    public delegate void StvarDogodekHandler(Stvar stvar);

    // Abstraktni razred + implementacija vmesnikov
    public abstract class Prostor : IOpisljivo, IProstorInventar
    {
        private readonly List<Stvar> _stvari = new List<Stvar>();

        public static int SteviloProstorov { get; private set; }

        private string _imeProstora;

        public string ImeProstora  //Lastnost private in public.
        {
            get { return _imeProstora; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _imeProstora = value;
                }
            }
        }

        // Eventi
        public event StvarDogodekHandler StvarDodana;
        public event StvarDogodekHandler StvarOdstranjena;

        // Vsak podrazred določi max
        public abstract int MaxStvari { get; }

        protected Prostor(string imeProstora)
        {
            ImeProstora = imeProstora;
            SteviloProstorov++;
        }

        // Read-only seznam
        public IReadOnlyList<Stvar> VseStvari => _stvari.AsReadOnly();

        // Dodatne lastnosti
        public int SteviloStvari => _stvari.Count;
        public bool JePoln => _stvari.Count >= MaxStvari;

        // Indeksator
        public Stvar this[int index]
        {
            get => _stvari[index];
            set => _stvari[index] = value;
        }

        public virtual bool DodajStvar(Stvar stvar)
        {
            if (stvar == null || JePoln)
                return false;

            _stvari.Add(stvar);

            // sproži event
            StvarDodana?.Invoke(stvar);

            return true;
        }

        public virtual bool OdstraniStvar(Stvar stvar)
        {
            bool removed = _stvari.Remove(stvar);

            if (removed)
            {
                // sproži event
                StvarOdstranjena?.Invoke(stvar);
            }

            return removed;
        }

        public virtual string Opis()
        {
            return $"{ImeProstora}: {_stvari.Count}/{MaxStvari} stvari";
        }

        public override string ToString() => ImeProstora;
    }
}