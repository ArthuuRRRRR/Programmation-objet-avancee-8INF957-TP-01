using ClassificationGrainsDeBle.Domain;
using ClassificationGrainsDeBle.Resultats;
using System;
using System.Collections.Generic;

namespace ClassificationGrainsDeBle.Resultats
{
    public static class Evaluation
    {
        private static readonly string[] Classes = { "Kama", "Rosa", "Canadian" };

        public static EvaluationResult Evaluer(List<Ble> test, List<string> predictions)
        {
            if (test.Count != predictions.Count)
                throw new Exception("Erreur: test et predictions n'ont pas la même taille.");

            var res = new EvaluationResult();
            res.Total = test.Count;

            for (int i = 0; i < test.Count; i++)
            {
                string reel = Normaliser(test[i].Variety);
                string pred = Normaliser(predictions[i]);

                int r = IndexClasse(reel);
                int p = IndexClasse(pred);

                res.Confusion[r, p]++;

                if (r == p) res.Correct++;
            }

            res.Accuracy = (double)res.Correct / res.Total;
            return res;
        }

        public static void Afficher(EvaluationResult res)
        {
            Console.WriteLine("\n===== ÉVALUATION de Arthur et Kewan =====");
            Console.WriteLine($"Total     : {res.Total}");
            Console.WriteLine($"Correct   : {res.Correct}");
            Console.WriteLine($"Accuracy  : {res.Accuracy * 100:F2}%\n");

            Console.WriteLine("Matrice de confusion (réel = lignes, prédit = colonnes)");
            Console.WriteLine("             Kama    Rosa  Canadian");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{Classes[i],-12}");
                for (int j = 0; j < 3; j++)
                    Console.Write($"{res.Confusion[i, j],8}");
                Console.WriteLine();
            }
            Console.WriteLine("======================\n");
        }

        private static string Normaliser(string s)
            => s.Trim();

        private static int IndexClasse(string c)
        {
            for (int i = 0; i < Classes.Length; i++)
                if (c.Equals(Classes[i], StringComparison.OrdinalIgnoreCase))
                    return i;

            throw new Exception("Classe inconnue: " + c);
        }
    }
}