using ClassificationGrainsDeBle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassificationGrainsDeBle.Classification.Trie;
using ClassificationGrainsDeBle.Classification.Interfaces;

namespace ClassificationGrainsDeBle.Classification.KD_Tree
{
    internal class KDNode // noeud de l'arbre
    {
        public Ble Data { get; set; } // grain de blé 
        public int Axe { get; set; }
        public KDNode Left { get; set; } // sous-arbre gauche
        public KDNode Right { get; set; } // sous-arbre droit
        public KDNode(Ble data, int axe)
        {
            this.Data = data;
            this.Axe = axe;
        }
    }




    internal class KDTree
    {
        private KDNode racine; // racine de l'arbre

        //Constructeur
        public KDTree(List<Ble> Listdonnees)
        {
            // On convertit en tableau :
            Ble[] tableauDeBles = Listdonnees.ToArray();
            racine = Construction(tableauDeBles, 0, tableauDeBles.Length - 1, 0);

        }

        // Méthode de construction de l'arbre
        private KDNode Construction(Ble[] bles, int debut, int fin, int profondeur)
        {
            // Si plus d'élements.
            if (debut > fin)
                return null;

            // 7 caractéristiques
            TrieRapide.Trie_Rapide(bles, debut, fin, profondeur % 7);

            int milieu = (debut + fin) / 2; // médiane 
            // Création du noeud avec la médiane 
            KDNode nouveauNoeud = new KDNode(bles[milieu], profondeur % 7);
            nouveauNoeud.Left = Construction(bles, debut, milieu - 1, profondeur + 1); // Sous-arbre gauche
            nouveauNoeud.Right = Construction(bles, milieu + 1, fin, profondeur + 1); // Sous-arbre droit
            return nouveauNoeud;

        }

        // Méthode de recherche du plus proche voisin
        public List<Ble> RechercheVoisins(Ble cible, int k, IDistance distance)
        {
            // Liste pour stocker les k plus proches voisins
            List<(Ble grain, double dist)> Listevoisins = new List<(Ble, double)>();
            Cherche(racine, cible, k, distance, Listevoisins);

            List<Ble> resultat = new List<Ble>();
            for (int i = 0; i < Listevoisins.Count; i++)
            {
                resultat.Add(Listevoisins[i].grain);

            }
            return resultat;
        }

        public void Cherche(KDNode noeud, Ble cible, int k, IDistance distance, List<(Ble grain, double dist)> Listevoisins)
        {
            if (noeud == null)
                return;

            double dist = distance.Compiler(noeud.Data.VecteurCaracteristique(), cible.VecteurCaracteristique());
            int i = 0;
            while (i < Listevoisins.Count && Listevoisins[i].dist < dist)
            {
                i++;
                

            }
            if (i < k)
            {
                Listevoisins.Insert(i, (noeud.Data, dist));
                if (Listevoisins.Count > k)
                {
                    Listevoisins.RemoveAt(k); // Supprimer le voisin le plus éloigné si la liste dépasse k
                }
            }
            int axe = noeud.Axe; // Axe de division
            double diff = cible.VecteurCaracteristique()[axe] - noeud.Data.VecteurCaracteristique()[axe];
            // On choisit le sous-arbre à explorer en fonction de la position de la cible par rapport au noeud actuel

            if (diff > 0)
            {
                Cherche(noeud.Right, cible, k, distance, Listevoisins); // Explorer le sous-arbre droit
                if (Listevoisins.Count < k || Math.Abs(diff) < Listevoisins[Listevoisins.Count - 1].dist)
                {
                    Cherche(noeud.Left, cible, k, distance, Listevoisins); // Explorer le sous-arbre gauche

                }

            }
            else
            {
                Cherche(noeud.Left, cible, k, distance, Listevoisins); // Explorer le sous-arbre gauche
                if (Listevoisins.Count < k || Math.Abs(diff) < Listevoisins.[Listevoisins.Count-1].dist)
                {
                    Cherche(noeud.Right, cible, k, distance, Listevoisins); // Explorer le sous-arbre droit
                }

            }
        }
    }
}
