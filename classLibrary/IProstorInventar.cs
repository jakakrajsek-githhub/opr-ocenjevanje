using System.Collections.Generic;

namespace classLibrary
{
    // Vmesnik: standardizira delo z inventarjem prostora (seznam + dostop po indeksu).
    public interface IProstorInventar
    {
        // Indekser v vmesniku: zahteva, da razred omogoča branje/pisanje elementa po indeksu.
        Stvar this[int index] { get; set; }
        IReadOnlyList<Stvar> VseStvari { get; }
    }
}
