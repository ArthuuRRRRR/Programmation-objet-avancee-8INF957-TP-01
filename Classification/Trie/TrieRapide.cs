using ClassificationGrainsDeBle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationGrainsDeBle.Classification.Trie
{
    public static class TrieRapide
    {
        public static void Trie_Rapide(Ble[] bles, int gauche, int droit, int index)
        {
            if (gauche < droit)
            {
                int pivot = Partition(bles, gauche, droit, index);
                Trie_Rapide(bles, gauche, pivot - 1, index);
                Trie_Rapide(bles, pivot + 1, droit, index);
            }
        }

        public static int Partition(Ble[] bles, int gauche, int droit, int index)
        {
            // On choisit le dernier élément comme pivot. 
            double pivot = bles[droit].VecteurCaracteristique()[index];
            int i = gauche - 1;

            for (int j = gauche; j < droit; j++)
            {
                if (bles[j].VecteurCaracteristique()[index] < pivot)
                {
                    i++;
                    // On switch les données
                    Ble v = bles[i];
                    bles[i] = bles[j];
                    bles[j] = v;
                }
            }
            Ble va = bles[i + 1];
            bles[i + 1] = bles[droit];
            bles[droit] = va;
            return i + 1;
        }
    }
}
