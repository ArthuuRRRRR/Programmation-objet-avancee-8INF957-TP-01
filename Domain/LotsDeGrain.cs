using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassificationGrainsDeBle.Domain.Interfaces;

namespace ClassificationGrainsDeBle.Domain
{
    internal class LotsDeGrain : ITransaction
    {

        public int Id { get; set; }
        public DateTime DateRecolte { get; set; }
        public double Poids { get; set; }
        public double PrixUnitaire { get; set; }
        public List<Ble> Bles { get; set; }
        //public List<Sesame> Sesames { get; set; }


        public double CalculerPrix()
        {
            return Poids * PrixUnitaire;
        }



    }
}
