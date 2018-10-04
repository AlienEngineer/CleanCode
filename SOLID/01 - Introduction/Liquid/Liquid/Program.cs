using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Liquid
{
    // Read from a csv file
    // Get the total value of insured houses
    // Store the Value by country
    // The last line must have the total and the current date
    // -----
    // Client 1: Ignore Residential type of housing.
    // Client 2: Ignore Commercial type of housing.

    // Violations:
    // SRP, OCP, DIP
    public class Program
    {
        private class InsuranceRecord
        {
            public double Value { get; set; }
            public string TypeOfHouse { get; set; }
            public string Country { get; set; }
        }

        class CsvFile
        {
            private static InsuranceRecord MapInsuranceRecord(int i, IReadOnlyList<string> fileLines)
            {
                var data = fileLines[i].Split(',');

                double.TryParse(data[8], NumberStyles.Any, CultureInfo.InvariantCulture, out var value);
                return new InsuranceRecord
                {
                    Country = data[3],
                    TypeOfHouse = data[15],
                    Value = value
                };
            }

            public IEnumerable<InsuranceRecord> GetInsuranceRecords()
            {
                var fileLines = File.ReadAllLines(".\\FL_insurance_sample.csv");

                var insuranceRecords = new List<InsuranceRecord>();

                for (var i = 1; i < fileLines.Length; i++)
                {
                    var record = MapInsuranceRecord(i, fileLines);
                    insuranceRecords.Add(record);
                }

                return insuranceRecords;
            }

            public void StartExport(int client)
            {
                _output = new StreamWriter(File.OpenWrite($".\\MyOutput{client}.csv"));
                _output.WriteLine($"Country,Value");
            }

            public void StoreTotalValue(double total)
            {
                _output.WriteLine("{0},{1}", total.ToString("F2", CultureInfo.InvariantCulture), DateTime.Now.ToString("d", CultureInfo.InvariantCulture));
                _output.Flush();
                _output.Close();
            }

            public void StoreRecord(InsuranceRecord record)
            {
                _output.WriteLine($"{record.Country},{record.Value.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            private static StreamWriter _output;
        }

        public static void Main(string[] args)
        {
            var csvFile = new CsvFile();

            int.TryParse(args[0], out var client);

            var total = 0.0;

            csvFile.StartExport(client);

            foreach (var record in csvFile.GetInsuranceRecords())
            {
                if (client == 1)
                {
                    if (record.TypeOfHouse == "Residential")
                    {
                        csvFile.StoreRecord(record);
                        total += record.Value;
                    }
                }
                if (client == 2)
                {
                    if (record.TypeOfHouse == "Commercial")
                    {
                        csvFile.StoreRecord(record);
                        total += record.Value;
                    }
                }
            }

            csvFile.StoreTotalValue(total);
        }
    }
}
