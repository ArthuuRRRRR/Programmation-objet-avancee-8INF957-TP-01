using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassificationGrainsDeBle.Classification.Interfaces;
using ClassificationGrainsDeBle.Classification.KD_Tree;
using ClassificationGrainsDeBle.Domain;

namespace ClassificationGrainsDeBle.Classification
{
    internal class KNN : IClassifier
    {
        private KD_Tree.KDTree kdTree;
        private int k;
        private IDistance distance;

        //Constructeur 
        public KNN(List<Ble> Listdonnees, int k, IDistance distance)
        {
            this.kdTree = new KD_Tree.KDTree(Listdonnees);
            this.k = k;
            this.distance = distance;
        }

        // Méthode de classification
        public string Predict(Ble grain)
        {
            // Récupère les k plus proche voisins
            List<Ble> voisins = kdTree.RechercheVoisins(grain, k, distance);
            // On compte les classes des voisins
            Dictionary<string, int> compteClasses = new Dictionary<string, int>();

            // On compte les votes 
            int nbKama = 0;
            int nbRosa = 0;
            int nbCanadian = 0;

            for (int i = 0; i < voisins.Count; i++)
            {
                if (voisins[i].Variety == "Kama")
                    nbKama++;
                else if (voisins[i].Variety == "Rosa")
                    nbRosa++;
                else if (voisins[i].Variety == "Canadian")
                    nbCanadian++;
            }

            // On retourne la classe majoritaire
            if (nbKama > nbRosa && nbKama > nbCanadian)
                return "Kama";
            else if (nbRosa > nbKama && nbRosa > nbCanadian)
                return "Rosa";
            else
                return "Canadian";




        }
    }
}

