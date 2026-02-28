using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassificationGrainsDeBle.Classification.Interfaces;

namespace ClassificationGrainsDeBle.Classification.Distances
{
    internal class DistanceEuclidienne : IDistance
    {
        public double Compiler(double[] point1, double[] point2)
        {
            if (point1.Length != point2.Length)
                throw new ArgumentException("Les points doivent avoir la même dimension.");
            double sum = 0.0;
            for (int i = 0; i < point1.Length; i++)
            {
                sum += Math.Pow(point1[i] - point2[i], 2);
            }
            return Math.Sqrt(sum);
        }
    }
}
