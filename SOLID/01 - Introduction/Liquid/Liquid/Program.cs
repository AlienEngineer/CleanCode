using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

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

        private interface IInsuranceRecordWriter
        {
            void StartExport(int client);
            void StoreTotalValue(double total);
            void StoreRecord(InsuranceRecord record);
        }

        private class CsvFileWriter : IInsuranceRecordWriter
        {
            private static StreamWriter _output;

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
        }

        private interface IInsuranceRecordReader
        {
            IEnumerable<InsuranceRecord> GetInsuranceRecords();
        }

        private class CsvFileReader : IInsuranceRecordReader
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

        }

        private class TypeOfHouseFilteredRecordReader : IInsuranceRecordReader
        {
            private readonly IInsuranceRecordReader csvFile;
            private readonly string residential;

            public TypeOfHouseFilteredRecordReader(IInsuranceRecordReader csvFile, string residential)
            {
                this.csvFile = csvFile;
                this.residential = residential;
            }

            public IEnumerable<InsuranceRecord> GetInsuranceRecords()
            {
                return csvFile.GetInsuranceRecords()
                    .Where(e => e.TypeOfHouse == residential);
            }
        }

        public static void Main(string[] args)
        {
            var csvFileWriter = new CsvFileWriter();

            IInsuranceRecordReader csvFile = new CsvFileReader();
            int.TryParse(args[0], out var client);

            if (client == 1)
            {
                csvFile = new TypeOfHouseFilteredRecordReader(csvFile, "Residential");
            }
            else if (client == 2)
            {
                csvFile = new TypeOfHouseFilteredRecordReader(csvFile, "Commercial");
            }

            var total = 0.0;

            csvFileWriter.StartExport(client);

            foreach (var record in csvFile.GetInsuranceRecords())
            {
                csvFileWriter.StoreRecord(record);
                total += record.Value;
            }

            csvFileWriter.StoreTotalValue(total);
        }
    }

}
