using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ClassificationGrainsDeBle.Domain;

namespace ClassificationGrainsDeBle.Domain
{
    public static class CsvLoader
    {
        public static List<Ble> Load(string path, char separator = '\t')
        {
            var list = new List<Ble>();

            using (var reader = new StreamReader(path))
            {
                string? line;
                int lineNumber = 0;

                reader.ReadLine();
                lineNumber++;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(separator);


                    if (parts.Length != 8)
                    {
                        Console.WriteLine($"Ligne {lineNumber}: colonnes incorrectes ({parts.Length})");
                        continue;
                    }

                    try
                    {
                        var ble = new Ble();


                        ble.Variety = parts[0].Trim();


                        ble.Area = double.Parse(parts[1], CultureInfo.InvariantCulture);
                        ble.Perimeter = double.Parse(parts[2], CultureInfo.InvariantCulture);
                        ble.Compactnesses = double.Parse(parts[3], CultureInfo.InvariantCulture);
                        ble.Kernel_Length = double.Parse(parts[4], CultureInfo.InvariantCulture);
                        ble.Kernel_Width = double.Parse(parts[5], CultureInfo.InvariantCulture);
                        ble.Asymmetry_Coefficient = double.Parse(parts[6], CultureInfo.InvariantCulture);
                        ble.Groove_Length = double.Parse(parts[7], CultureInfo.InvariantCulture);

                        list.Add(ble);
                    }
                    catch
                    {
                        Console.WriteLine($"Ligne {lineNumber}: erreur de format");
                    }
                }
            }

            return list;
        }
    }
}