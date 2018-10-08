using Liquid.IO;
using Liquid.Models;

namespace Liquid
{
    internal class Exporter
    {
        private readonly IInsuranceRecordWriter insuranceRecordWriter;
        private readonly IInsuranceRecordReader insuranceReader;

        public Exporter(IInsuranceRecordWriter insuranceRecordWriter, IInsuranceRecordReader insuranceReader)
        {
            this.insuranceRecordWriter = insuranceRecordWriter;
            this.insuranceReader = insuranceReader;
        }

        public void Export(TypeOfHousing typeOfHousing)
        {
            insuranceRecordWriter.StartExport(typeOfHousing);

            var total = 0.0;
            foreach (var record in insuranceReader.GetInsuranceRecords())
            {
                insuranceRecordWriter.StoreRecord(record);
                total += record.Value;
            }

            insuranceRecordWriter.StoreTotalValue(total);
        }
    }
}