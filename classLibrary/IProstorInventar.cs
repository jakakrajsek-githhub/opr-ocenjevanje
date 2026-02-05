using System.Collections.Generic;

namespace classLibrary
{
    // standardizira delo z inventarjem prostora (seznam + dostop po indeksu).
    public interface IProstorInventar
    {
        //zahteva da razred omogoča branje/pisanje elementa po indeksu.
        Stvar this[int index] { get; set; }
        IReadOnlyList<Stvar> VseStvari { get; }
    }
}
