using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationGrainsDeBle.Resultats
{
    public static class JsonExport
    {
        public static void Sauvegarder(EvaluationResult res, int k, string distance)
        {
            var objet = new
            {
                Date = System.DateTime.Now,
                Accuracy = res.Accuracy,
                Confusion = res.Confusion,
                Total = res.Total,
                Correct = res.Correct,
                K = k,
                Distance = distance
            };

            string json = JsonConvert.SerializeObject(objet, Formatting.Indented);
            File.WriteAllText("resultats.json", json);
        }
    }
}
