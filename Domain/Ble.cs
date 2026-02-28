using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationGrainsDeBle.Domain
{
    internal class Ble
    {
        // On va suivre les attributs du fichier csv : 
        // l'attribut à déterminer : 
        public string Variety { get; set; }

        // Features : 
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public double Compactnesses { get; set; }
        public double Kernel_Length { get; set; }
        public double Kernel_Width { get; set; }
        public double Asymmetry_Coefficient { get; set; }
        public double Groove_Length { get; set; }

        // Méthode pour retourner le vecteur de caractéristiques 
        public double[] VecteurCaracteristique() { return new double[] {Area,  Perimeter, Compactnesses, Kernel_Length, Kernel_Width, Asymmetry_Coefficient, Groove_Length }; 
        }
    }
}
