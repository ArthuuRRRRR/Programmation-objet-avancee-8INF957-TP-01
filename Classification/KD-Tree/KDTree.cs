using ClassificationGrainsDeBle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassificationGrainsDeBle.Classification.Trie;

namespace ClassificationGrainsDeBle.Classification.KD_Tree
{
    internal class KDTree
    {
        private KDNode root;

        public KDTree(List<Ble> donnee)
        {
            // On convertit en tableau :
            Ble[] entite = donnee.ToArray();
            
        }
    }
}
