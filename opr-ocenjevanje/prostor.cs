using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opr_ocenjevanje
{
    public abstract class Prostor
    {
        public static int ProstorCount { get; private set; }
        public readonly string ProstorName;// Readonly polje – ime sobe se po konstruktorju ne more spremeniti

        protected List<Stvar> Stvari = new List<Stvar>();// Zaščitena lista stvari dostopna podrazredom

        protected Prostor(string name)
        {
            ProstorName = name;
            ProstorCount++;
        }

        ~Prostor() // Destruktor – kliče se ob uničenju objekta
        {
            ProstorCount--;
        }

        public virtual void AddStvar(Stvar Stvar) //virtualna metoda za dodajanje
        {
            Stvari.Add(Stvar);
        }

        public virtual void RemoveStvar(Stvar Stvar)
        {
            Stvari.Remove(Stvar);
        }

        public List<Stvar> GetStvari() //Vrne seznam stvari
        { 
            return Stvari; 
        }

        public override string ToString() //Uporablja se v ComboBoxu
        {
            return ProstorName;
        } 
    }
}
