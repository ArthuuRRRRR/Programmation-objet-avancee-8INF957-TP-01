using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationGrainsDeBle.Classification.Interfaces
{
    internal interface IDistance
    {
        double Compiler(double[] point1, double[] point2);
    }
}
