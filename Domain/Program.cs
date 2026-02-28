using ClassificationGrainsDeBle.Domain;
using ClassificationGrainsDeBle.Loader;
using ClassificationGrainsDeBle.Classification;
using ClassificationGrainsDeBle.Classification.Interfaces;
using ClassificationGrainsDeBle.Classification.Distances;
using ClassificationGrainsDeBle.Resultats;
using Spectre.Console;
using System.Collections.Generic;
using System.IO;

namespace ClassificationGrainsDeBle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Write(new FigletText("KNN Ble").Centered().Color(Color.Green));

            // Choix de k voisins
            int k = AnsiConsole.Ask<int>("Entrez la valeur de [green]k :[/]");
            // Méthode de la distance à choisir             
            var choixDistance = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Choisissez la [green]distance[/]")
                .AddChoices(new[]
                {
                    "Euclidienne",
                    "Manhattan"
                }));

            // Implémentation du choix de la distance
            IDistance distance;

            if (choixDistance == "Euclidienne")
                distance = new DistanceEuclidienne();
                
            else
                distance = new DistanceManhattan();
            AnsiConsole.MarkupLine($"[green]Méthode de distance:[/] {choixDistance}");
            // Chargement des donnée

            List<Ble> trainData = CsvLoader.Load("C:\\Users\\kewan lensen\\Documents\\Trimestre2\\Programmation objet avancée\\TP1\\base_de_données\\seeds_dataset_training.csv", ';');
            List<Ble> testData = CsvLoader.Load("C:\\Users\\kewan lensen\\Documents\\Trimestre2\\Programmation objet avancée\\TP1\\base_de_données\\seeds_dataset_test.csv", ';');

            AnsiConsole.MarkupLine($"[green]Train:[/] {trainData.Count} échantillons");
            AnsiConsole.MarkupLine($"[green]Test:[/] {testData.Count} échantillons");

            // Construction du classifieur KNN
            KNN classifier = new KNN(trainData, k, distance);

            // Classification des données de test
            List<string> predictions = new List<string>();

            foreach (var ble in testData)
            {
                predictions.Add(classifier.Predict(ble));
            }

            // Evaluation des résultats
            var result = Evaluation.Evaluer(testData, predictions);

            // Affichage des réqultats
            AnsiConsole.MarkupLine($"\n[bold green]Accuracy : {result.Accuracy * 100:F2}%[/]\n");

            var table = new Table();
            table.Border(TableBorder.Rounded);
            table.AddColumn("Réel \\ Prédit");
            table.AddColumn("Kama");
            table.AddColumn("Rosa");
            table.AddColumn("Canadian");

            string[] classes = { "Kama", "Rosa", "Canadian" };

            // Matrice de confusion
            for (int i = 0; i < 3; i++)
            {
                table.AddRow(
                    classes[i],
                    result.Confusion[i, 0].ToString(),
                    result.Confusion[i, 1].ToString(),
                    result.Confusion[i, 2].ToString()
                );
            }

            AnsiConsole.Write(table);


            // Sauvegarde des résultats dans un fichier json
            JsonExport.Sauvegarder(result, k, choixDistance);
            AnsiConsole.MarkupLine("\n[green]Résultats sauvegardés dans 'evaluation_result.json'[/]");

            AnsiConsole.MarkupLine("\n[grey]Appuyez sur une touche pour quitter...[/]");
            Console.ReadKey();

        }
    }
}