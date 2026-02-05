using System.Collections.Generic;

namespace classLibrary
{
    public interface IProstorInventar
    {
        Stvar this[int index] { get; set; }
        IReadOnlyList<Stvar> VseStvari { get; }
    }
}
