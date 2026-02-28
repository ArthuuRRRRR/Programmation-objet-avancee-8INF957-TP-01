using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationGrainsDeBle.Domain
{
    internal abstract class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public abstract double acheter();
        public abstract double produire();
        
    }
}
