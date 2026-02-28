using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationGrainsDeBle.Resultats
{
    public class EvaluationResult
    {
        public double Accuracy { get; set; }
        public int[,] Confusion { get; set; } = new int[3, 3];
        public int Total { get; set; }
        public int Correct { get; set; }
    }
}