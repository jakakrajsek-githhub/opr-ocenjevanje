using System;
using System.Collections.Generic;
using System.Linq;

namespace classLibrary
{
    // Delegate za dogodke
    public delegate void StvarDogodekHandler(Stvar stvar);

    // Abstraktni razred + implementacija vmesnikov
    public abstract class Prostor : IOpisljivo, IProstorInventar, IEquatable<Prostor>
    {
        private readonly List<Stvar> _stvari = new List<Stvar>();

        public static int SteviloProstorov { get; private set; }

        private string _imeProstora;

        public string ImeProstora  //Lastnost private in public.inhj9uioh98oh
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

        // Predlogi za combobox v UI (kaj običajno sodi v prostor).
        // Po domače: ko klikneš sobo, dobiš "smiselne stvari" za dodat.
        public virtual IReadOnlyList<string> PredlaganeStvari => ItemPravila.PredlaganeZaProstor(ImeProstora);

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

        // Objektni metodi za bolj berljivo preverjanje inventarja.
        public bool Vsebuje(Stvar stvar) => stvar != null && _stvari.Any(s => s == stvar);
        public bool VsebujeIme(string imeStvari) =>
            !string.IsNullOrWhiteSpace(imeStvari)
            && _stvari.Any(s => string.Equals(s.Ime, imeStvari.Trim(), StringComparison.OrdinalIgnoreCase));

        // Indeksator
        public Stvar this[int index]
        {
            get => _stvari[index];
            set => _stvari[index] = value;
        }

        // Omejitve po centralnih pravilih predmet -> dovoljeni prostori.
        // Če stvar ne paše v sobo, jo tukaj zavrnemo.
        public virtual bool LahkoVsebuje(Stvar stvar)
        {
            return stvar != null
                && !string.IsNullOrWhiteSpace(stvar.Ime)
                && ItemPravila.LahkoVProstoru(stvar.Ime, ImeProstora);
        }

        public virtual bool DodajStvar(Stvar stvar)
        {
            if (stvar == null || JePoln || !LahkoVsebuje(stvar))
                return false;

            // Da ne bo "dve isti stvari v isti sobi", to tukaj ustavimo.
            if (_stvari.Any(s => s.Equals(stvar)))
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

        // Objektne metode (value-like primerjava po imenu prostora + tipu).
        public bool Equals(Prostor drugi)
        {
            if (ReferenceEquals(null, drugi))
                return false;

            if (ReferenceEquals(this, drugi))
                return true;

            return GetType() == drugi.GetType()
                && string.Equals(ImeProstora, drugi.ImeProstora, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) => Equals(obj as Prostor);

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + GetType().GetHashCode();
                hash = (hash * 23) + (ImeProstora ?? string.Empty).ToUpperInvariant().GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Prostor levi, Prostor desni)
        {
            if (ReferenceEquals(levi, desni))
                return true;

            if (ReferenceEquals(levi, null) || ReferenceEquals(desni, null))
                return false;

            return levi.Equals(desni);
        }

        public static bool operator !=(Prostor levi, Prostor desni) => !(levi == desni);

        // Operaterja za delo z inventarjem.
        public static Prostor operator +(Prostor prostor, Stvar stvar)
        {
            if (prostor == null)
                throw new ArgumentNullException(nameof(prostor));

            prostor.DodajStvar(stvar);
            return prostor;
        }

        public static Prostor operator -(Prostor prostor, Stvar stvar)
        {
            if (prostor == null)
                throw new ArgumentNullException(nameof(prostor));

            prostor.OdstraniStvar(stvar);
            return prostor;
        }
    }
}
