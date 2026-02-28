using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationGrainsDeBle.Domain
{
    internal class Ferme
    {
        public string nom { get; set; }
        public string adresse { get; set; }

        public List<Fermier> Fermiers { get; set; }

        public void AjouterFermier(Fermier fermier)
        {
            if (Fermiers == null)
            {
                Fermiers = new List<Fermier>();
            }
            Fermiers.Add(fermier);
        }

        public Fermier getFermiers(int id)
        {
            if (Fermiers != null)
            {
                return Fermiers.FirstOrDefault(f => f.Id == id);
            }
            return null;
        }
    }
}
