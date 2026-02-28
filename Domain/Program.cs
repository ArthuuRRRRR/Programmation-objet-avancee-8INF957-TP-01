// See https://aka.ms/new-console-template for more information
using ClassificationGrainsDeBle.Domain;

Console.WriteLine("Hello, World!");

var train = CsvLoader.Load(@"C:\Users\delha\OneDrive\Desktop\Cours_UQAR\POO\seeds_dataset_test.csv", ';');
Console.WriteLine($"Train chargé: {train.Count}");

Console.WriteLine(train[0].Variety);
Console.WriteLine(string.Join(", ", train[0].VecteurCaracteristique()));