using System;
using System.Globalization;
using System.IO;
using Liquid.Models;

namespace Liquid.IO.CsvFiles
{
    internal class CsvFileWriter : IInsuranceRecordWriter
    {
        private static StreamWriter _output;

        public void StartExport(TypeOfHousing client)
        {
            _output = new StreamWriter(File.OpenWrite($".\\MyOutput{(int)client}.csv"));
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
}