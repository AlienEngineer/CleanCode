using Liquid.IO;

namespace Liquid
{
    public interface IReport
    {
        void Export();
    }

    internal class InsuranceReportWithTotal : IReport
    {
        private readonly IInsuranceRecordWriter insuranceRecordWriter;
        private readonly IInsuranceRecordReader insuranceReader;

        public InsuranceReportWithTotal(IInsuranceRecordWriter insuranceRecordWriter, IInsuranceRecordReader insuranceReader)
        {
            this.insuranceRecordWriter = insuranceRecordWriter;
            this.insuranceReader = insuranceReader;
        }

        public void Export()
        {
            insuranceRecordWriter.StartExport();

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