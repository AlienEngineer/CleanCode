using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Liquid
{
    internal class CsvFile
    {
        private static InsuranceRecord MapInsuranceRecord(int i, IReadOnlyList<string> fileLines)
        {
            string[] data = fileLines[i].Split(',');

            double.TryParse(data[8], NumberStyles.Any, CultureInfo.InvariantCulture, out double value);
            return new InsuranceRecord
            {
                Country = data[3],
                TypeOfHouse = data[15],
                Value = value
            };
        }

        public IEnumerable<InsuranceRecord> GetInsuranceRecords()
        {
            string[] fileLines = File.ReadAllLines(".\\FL_insurance_sample.csv");

            List<InsuranceRecord> insuranceRecords = new List<InsuranceRecord>();

            for (int i = 1; i < fileLines.Length; i++)
            {
                InsuranceRecord record = MapInsuranceRecord(i, fileLines);
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
}