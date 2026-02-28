using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationGrainsDeBle.Domain
{
    internal class Fermier : Personne
    {
        public string NumeroEmploye { get; set; }

        public override double acheter()
        {
            throw new NotImplementedException();
        }
        public override double produire()
        {
            throw new NotImplementedException();
        }
    }
}
