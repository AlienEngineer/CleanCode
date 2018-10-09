using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Liquid.Models;

namespace Liquid.IO.CsvFiles
{
    internal class CsvFileReader : IInsuranceRecordReader
    {
        private static InsuranceRecord MapInsuranceRecord(int i, IReadOnlyList<string> fileLines)
        {
            var data = fileLines[i].Split(',');

            double.TryParse(data[8], NumberStyles.Any, CultureInfo.InvariantCulture, out var value);
            return new InsuranceRecord
            {
                Country = data[2],
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
}