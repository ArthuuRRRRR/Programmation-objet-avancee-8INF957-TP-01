using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationGrainsDeBle.Domain
{
    internal class Client : Personne
    {
        public string Email { get; set; }
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
